using OpenProtocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPClient
{
    /// <summary>
    /// 拧紧枪
    /// </summary>
    [Serializable]
    public class Gun
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public bool Status { get; set; } = false;

        /// <summary>
        /// 与控制器的连接
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public SocketConnect connect { get; set; }
    }
}
