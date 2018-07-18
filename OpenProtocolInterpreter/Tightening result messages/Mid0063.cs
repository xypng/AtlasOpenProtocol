using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// MID 0063 Last tightening result data unsubscribe
    /// </summary>
    public class Mid0063 : Mid
    {
        public override StringBuilder Pack()
        {
            StringBuilder sb = base.Pack();
            return AddLength(sb);
        }
    }
}
