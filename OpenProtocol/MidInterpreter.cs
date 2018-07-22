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

        public static Mid Parse(string message)
        {
            string mid = message.Substring(4, 4);
            Type type = Type.GetType("OpenProtocol.Mid" + mid);
            if (type==null)
            {
                logger.Error(message + Environment.NewLine + "没有定义这种类型的消息");
                return null;
            }
            try
            {
                var result = Activator.CreateInstance(type, message) as Mid;
                return result;
            }
            catch(Exception ex)
            {
                logger.Error(message + Environment.NewLine + ex);
                return null;
            }
        }
    }
}
