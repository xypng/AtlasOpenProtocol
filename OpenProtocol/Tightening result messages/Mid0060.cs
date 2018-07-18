using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocol
{
    /// <summary>
    /// MID 0060 Last tightening result data subscribe
    /// </summary>
    public class Mid0060 : Mid
    {
        public override StringBuilder Pack()
        {
            StringBuilder sb = base.Pack();
            return AddLength(sb);
        }
    }
}
