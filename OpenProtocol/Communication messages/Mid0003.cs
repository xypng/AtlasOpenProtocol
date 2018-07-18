using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocol
{
    /// <summary>
    /// MID 0003 Communication stop
    /// </summary>
    public class Mid0003 : Mid
    {
        public override StringBuilder Pack()
        {
            StringBuilder sb = base.Pack();
            return AddLength(sb);
        }
    }
}
