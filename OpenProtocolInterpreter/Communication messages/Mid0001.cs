using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// MID 0001 Communication start
    /// </summary>
    public class Mid0001 : Mid
    {
        public override StringBuilder Pack()
        {
            StringBuilder sb = base.Pack();
            return AddLength(sb);
        }
    }
}
