using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocol
{
    /// <summary>
    /// MID 0018 Select Parameter set
    /// </summary>
    public class Mid0018 : Mid
    {
        public string PsetID { get; set; }

        public override string Pack()
        {
            sb = new StringBuilder();
            sb.Append(PsetID.PadLeft(3, '0'));
            return base.Pack();
        }
    }
}
