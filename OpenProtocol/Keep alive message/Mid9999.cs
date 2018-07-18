using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocol
{
    /// <summary>
    /// MID 9999 Keep alive message
    /// </summary>
    public class Mid9999 : Mid
    {
        public Mid9999():base()
        {

        }

        public Mid9999(string message) : base(message)
        {

        }

        public override StringBuilder Pack()
        {
            StringBuilder sb = base.Pack();
            return AddLength(sb);
        }
    }
}
