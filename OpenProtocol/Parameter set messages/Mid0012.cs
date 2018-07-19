using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocol
{
    public class Mid0012 : Mid
    {
        public string PsetID { get; set; }
        public override StringBuilder Pack()
        {
            sb = new StringBuilder();
            sb.Append(PsetID.PadLeft(3, '0'));
            return base.Pack();
        }
    }
}
