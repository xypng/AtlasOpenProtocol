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
                return null;
            }
            else
            {
                int length;
                if(!int.TryParse(message.Substring(0, 4), out length))
                {
                    leftMessage = message;
                    return null;
                }
                if (length>message.Length)
                {
                    leftMessage = message;
                    return null;
                }
                leftMessage = message.Substring(length);
                string mid = message.Substring(4, 4);
                Type type = Type.GetType("OpenProtocol.Mid" + mid);
                return Activator.CreateInstance(type, message) as Mid;
            }
        }
    }
}
