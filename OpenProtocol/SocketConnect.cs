using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenProtocol
{
    public class SocketConnect
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public delegate void EventMessageHandler(object sender, Mid mid);

        #region 事件
        /// <summary>
        /// 连接成功
        /// </summary>
        public event EventHandler EventConnected;
        /// <summary>
        /// 建立通信成功
        /// </summary>
        public event EventHandler EventCommunicationed;
        /// <summary>
        /// 订阅拧紧结果成功
        /// </summary>
        public event EventHandler EventTighteningResultSubscribe;
        /// <summary>
        /// 连接断开
        /// </summary>
        public event EventHandler EventDisConnected;
        /// <summary>
        /// 收到拧紧结果
        /// </summary>
        public event EventMessageHandler EventTighteningResultRecived;
        /// <summary>
        /// 订阅拧紧结果失败
        /// </summary>
        public event EventMessageHandler EventTighteningResultNoSubscribe;
        #endregion

        #region 回调
        /// <summary>
        /// 收到档位个数的信息
        /// </summary>
        private Action<Mid> PsetIdsRecived;
        /// <summary>
        /// 收到档位的数据
        /// </summary>
        public Action<Mid> PsetDataRecived;
        /// <summary>
        /// 请求档位的数据失败
        /// </summary>
        public Action<Mid> PsetDataFail;
        /// <summary>
        /// 更改档位成功
        /// </summary>
        public Action PsetChanged;
        /// <summary>
        /// 更改档位失败
        /// </summary>
        public Action<Mid> PsetNoChange;
        #endregion

        private Timer heartBeatTimer;

        StringBuilder leaveSB = new StringBuilder();

        public Socket m_socket;
        IPEndPoint m_endPoint;
        private SocketAsyncEventArgs m_connectSAEA;
        private SocketAsyncEventArgs m_sendSAEA;

        public SocketConnect(string ip, int port=4545)
        {
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse(ip);
            m_endPoint = new IPEndPoint(iPAddress, port);
            m_connectSAEA = new SocketAsyncEventArgs { RemoteEndPoint = m_endPoint };
        }

        public void Start()
        {
            m_connectSAEA.Completed += OnConnectedCompleted;
            m_socket.ConnectAsync(m_connectSAEA);
        }

        public void OnConnectedCompleted(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success)
            {
                logger.Error(e.RemoteEndPoint.ToString() + " | socket连接失败：" + e.SocketError);
                EventDisConnected?.Invoke(this, e);
                m_socket.ConnectAsync(m_connectSAEA);
                return;
            }
            logger.Info(e.RemoteEndPoint.ToString() + " | socket连接成功");
            EventConnected?.Invoke(this, e);
            Socket socket = sender as Socket;
            string iPRemote = socket.RemoteEndPoint.ToString();
            SocketAsyncEventArgs receiveSAEA = new SocketAsyncEventArgs();
            byte[] receiveBuffer = new byte[1024 * 4];
            receiveSAEA.SetBuffer(receiveBuffer, 0, receiveBuffer.Length);
            receiveSAEA.Completed += OnReceiveCompleted;
            receiveSAEA.RemoteEndPoint = m_endPoint;
            socket.ReceiveAsync(receiveSAEA);
            Send(new Mid0001());
        }

        private void OnReceiveCompleted(object sender, SocketAsyncEventArgs e)
        {
            Socket socket = sender as Socket;
            if (e.SocketError == SocketError.Success && e.BytesTransferred > 0)
            {
                string ipAdress = socket.RemoteEndPoint.ToString();
                int lengthBuffer = e.BytesTransferred;
                byte[] receiveBuffer = e.Buffer;
                byte[] buffer = new byte[lengthBuffer];
                Buffer.BlockCopy(receiveBuffer, 0, buffer, 0, lengthBuffer);
                string msg = Encoding.ASCII.GetString(buffer);
                logger.Info(e.RemoteEndPoint.ToString() + " | 收到消息：" + msg);
                leaveSB.Append(msg);
                while(true)
                {
                    if (leaveSB.Length==0)
                    {
                        break;
                    }
                    logger.Info(e.RemoteEndPoint.ToString() + " | 处理消息：" + leaveSB);
                    if (leaveSB.Length<20)
                    {
                        logger.Info(e.RemoteEndPoint.ToString() + " | 长度不够：" + leaveSB.ToString());
                        break;
                    }
                    int len;
                    if (!int.TryParse(leaveSB.ToString().Substring(0, 4), out len) || len<=0)
                    {
                        logger.Error(e.RemoteEndPoint.ToString() + " | 长度不是正整数：" + leaveSB.ToString());
                        leaveSB.Clear();
                        break;
                    }
                    if (len>leaveSB.Length)
                    {
                        logger.Info(e.RemoteEndPoint.ToString() + " | 长度不够：" + leaveSB.ToString());
                        break;
                    }
                    string tmp = leaveSB.ToString().Substring(0, len);
                    leaveSB.Remove(0, len);
                    var mid = MidInterpreter.Parse(tmp);
                    if (mid is Mid0002)
                    {
                        if (heartBeatTimer == null)
                        {
                            heartBeatTimer = new Timer(HeartBeat, null, 10000, 10000);
                        }
                        logger.Info(e.RemoteEndPoint.ToString() + " | 建立通信成功");
                        Send(new Mid0060());
                        EventCommunicationed?.Invoke(this, e);
                    }
                    else if (mid is Mid0005)
                    {
                        if ((mid as Mid0005).Mid == "0060")
                        {
                            logger.Info(e.RemoteEndPoint.ToString() + " | 订阅拧紧结果成功");
                            EventTighteningResultSubscribe?.Invoke(this, e);
                        }
                        else if ((mid as Mid0005).Mid == "0018")
                        {
                            logger.Info(e.RemoteEndPoint.ToString() + " | 更改档位成功");
                            PsetChanged?.Invoke();
                            PsetChanged = null;
                        }
                    }
                    else if (mid is Mid0061)
                    {
                        logger.Info(e.RemoteEndPoint.ToString() + " | 收到拧紧结果：" + mid);
                        Send(new Mid0062());
                        EventTighteningResultRecived?.Invoke(this, mid);
                    }
                    else if (mid is Mid0011)
                    {
                        logger.Info(e.RemoteEndPoint.ToString() + " | 收到档位个数的信息：" + mid);
                        PsetIdsRecived?.Invoke(mid);
                        PsetIdsRecived = null;
                    }
                    else if (mid is Mid0013)
                    {
                        logger.Info(e.RemoteEndPoint.ToString() + " | 收到档位的数据：" + mid);
                        PsetDataRecived?.Invoke(mid);
                        PsetDataRecived = null;
                    }
                    else if (mid is Mid0004)
                    {
                        if ((mid as Mid0004).Mid == "0060")
                        {
                            logger.Error(e.RemoteEndPoint.ToString() + " | 订阅拧紧结果失败：" + mid);
                            EventTighteningResultNoSubscribe?.Invoke(this, mid);
                        }
                        else if ((mid as Mid0004).Mid == "0018")
                        {
                            logger.Error(e.RemoteEndPoint.ToString() + " | 更改档位失败：" + mid);
                            PsetNoChange?.Invoke(mid);
                        }
                        else if ((mid as Mid0004).Mid == "0012")
                        {
                            logger.Error(e.RemoteEndPoint.ToString() + " | 请求档位个数的信息失败：" + mid);
                            PsetDataFail?.Invoke(mid);
                            PsetDataFail = null;
                        }
                    }
                    else if (mid is Mid9999)
                    {

                    }
                }
                socket.ReceiveAsync(e);
            }
            else
            {
                socket.Disconnect(true);
                m_socket.ConnectAsync(m_connectSAEA);
                return;
            }
        }
        
        public bool Send(Mid mid)
        {
            if (m_connectSAEA.SocketError == SocketError.Success && m_socket != null)
            {
                Send(mid.Pack());
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 请求档位个数的信息 Mid0010
        /// </summary>
        /// <param name="success">成功的回调</param>
        public void RequestPsetIds(Action<Mid> success)
        {
            if (Send(new Mid0010()))
            {
                PsetIdsRecived = success;
            }
        }

        /// <summary>
        /// 请求档位数据 Mid0012
        /// </summary>
        /// <param name="psetID">档位ID</param>
        /// <param name="success">成功的回调</param>
        /// <param name="fail">失败的回调</param>
        public void RequestPsetData(string psetID, Action<Mid> success, Action<Mid> fail)
        {
            if (Send(new Mid0012() { PsetID = psetID }))
            {
                PsetDataRecived = success;
                PsetDataFail = fail;
            }
        }

        /// <summary>
        /// 选择档位
        /// </summary>
        /// <param name="psetID">档位</param>
        /// <param name="success">成功的回调</param>
        /// <param name="fail">失败的回调</param>
        public void SelectPset(string psetID, Action success, Action<Mid> fail)
        {
            if (Send(new Mid0018() { PsetID = psetID }))
            {
                PsetChanged = success;
                PsetNoChange = fail;
            }
        }
        
        private static readonly object lockObj = new object();

        public void Send(string msg)
        {
            lock(lockObj)
            {
                logger.Info(m_socket.RemoteEndPoint.ToString() + " | 发送消息：[" + msg + "]");
                byte[] sendBuffer = Encoding.ASCII.GetBytes(msg);
                if (m_sendSAEA == null)
                {
                    m_sendSAEA = new SocketAsyncEventArgs();
                    m_sendSAEA.Completed += OnSendCompleted;
                }
                m_sendSAEA.SetBuffer(sendBuffer, 0, sendBuffer.Length);
                if (m_connectSAEA.SocketError == SocketError.Success && m_socket != null)
                {
                    m_socket.SendAsync(m_sendSAEA);
                }
            }
        }

        private void OnSendCompleted(object sender, SocketAsyncEventArgs e)
        {
            Socket socket = sender as Socket;
            byte[] sendBuffer = e.Buffer;
            string sendMsg = Encoding.ASCII.GetString(sendBuffer);
            if (e.SocketError != SocketError.Success)
            {
                logger.Error(socket.RemoteEndPoint.ToString() + " | 发送消息[{0}]失败！", sendMsg);
                m_socket.Disconnect(true);
                m_socket.ConnectAsync(m_connectSAEA);
                return;
            }
            logger.Info(socket.RemoteEndPoint.ToString() + " | 发送消息[{0}]成功！", sendMsg);
        }

        public void DisConnect()
        {
            if (m_socket != null)
            {
                try
                {
                    m_socket.Shutdown(SocketShutdown.Both);
                }
                catch (SocketException se)
                {
                }
                finally
                {
                    m_socket.Close();
                }
            }
        }

        /// <summary>
        /// 心跳
        /// </summary>
        /// <param name="state"></param>
        private void HeartBeat(object state)
        {
            Send(new Mid9999());
        }
    }
}
