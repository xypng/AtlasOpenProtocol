using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// MID 0010 Parameter set ID upload request 
    /// </summary>
    public class Mid0010 : Mid
    {
        public override StringBuilder Pack()
        {
            StringBuilder sb = base.Pack();
            return AddLength(sb);
        }
    }
}
