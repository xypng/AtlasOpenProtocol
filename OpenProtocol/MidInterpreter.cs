using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocol
{
    public class MidInterpreter
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static Mid Parse(string message, out string leftMessage)
        {
            logger.Info(message);
            if (message.Length<20)
            {
                leftMessage = message;
                logger.Info("长度还不够");
                return null;
            }
            int length;
            if(!int.TryParse(message.Substring(0, 4), out length))
            {
                leftMessage = message;
                logger.Error("长度应该是数字");
                return null;
            }
            if (length>message.Length)
            {
                leftMessage = message;
                logger.Info("长度不够");
                return null;
            }
            leftMessage = message.Substring(length);
            string mid = message.Substring(4, 4);
            Type type = Type.GetType("OpenProtocol.Mid" + mid);
            if (type==null)
            {
                logger.Error("没有这种类型的消息");
                return null;
            }
            try
            {
                var result = Activator.CreateInstance(type, message) as Mid;
                logger.Info(result);
                return result;
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
    }
}
