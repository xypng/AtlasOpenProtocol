using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OpenProtocol
{
    public abstract class Mid
    {
        public MidHead MidHead { get; set; }

        public Mid()
        {
            this.MidHead = new MidHead() { MID = "", Revision="", NoAckflag="", StationID="", SpindleID="", Spare=""};
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
            catch
            {

            }
        }

        public virtual StringBuilder Pack()
        {
            StringBuilder sb = new StringBuilder(this.GetType().Name.Substring(3, 4));
            sb.Append(MidHead.Revision.PadLeft(3, '0'));
            sb.Append(MidHead.NoAckflag.PadLeft(1));
            sb.Append(MidHead.StationID.PadLeft(2));
            sb.Append(MidHead.SpindleID.PadLeft(2));
            sb.Append(MidHead.Spare.PadLeft(4));
            return sb;
        }

        public StringBuilder AddLength(StringBuilder sb)
        {
            return sb.Insert(0, (sb.Length + 4).ToString().PadLeft(4, '0'), 1).Append("\0");
        }

        public override string ToString()
        {
            var json = new JavaScriptSerializer().Serialize(this);
            return json;
        }
    }
}
