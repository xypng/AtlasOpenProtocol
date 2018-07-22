using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocol
{
    public abstract class Mid
    {
        protected static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        protected StringBuilder sb;

        public MidHead MidHead { get; set; }

        public Mid()
        {
            this.MidHead = new MidHead() { MID = "", Revision= "001", NoAckflag="", StationID="", SpindleID="", Spare=""};
        }

        public Mid(string message):this()
        {
            int len;
            int.TryParse(message.Substring(0, 4), out len);
            this.MidHead.Length = len;
            try
            {
                this.MidHead.MID = message.Substring(4, 4);
                this.MidHead.Revision = message.Substring(8, 3).Trim();
                this.MidHead.NoAckflag = message.Substring(11, 1).Trim();
                this.MidHead.StationID = message.Substring(12, 2).Trim();
                this.MidHead.SpindleID = message.Substring(14, 2).Trim();
                this.MidHead.Spare = message.Substring(16, 4).Trim();
            }
            catch(Exception ex)
            {
                logger.Error(message + Environment.NewLine + ex);
            }
        }

        public virtual string Pack()
        {
            if (sb==null)
            {
                sb = new StringBuilder();
            }
            sb.Insert(0, MidHead.Spare.PadLeft(4));
            sb.Insert(0, MidHead.SpindleID.PadLeft(2));
            sb.Insert(0, MidHead.StationID.PadLeft(2));
            sb.Insert(0, MidHead.NoAckflag.PadLeft(1));
            sb.Insert(0, MidHead.Revision.PadLeft(3, ' '));
            sb.Insert(0, this.GetType().Name.Substring(3, 4));
            sb.Insert(0, (sb.Length + 4).ToString().PadLeft(4, '0'), 1);
            string str = sb.ToString();
            return str;
        }

        public override string ToString()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            return json;
        }
    }
}
