using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// MID 0005 Command accepted 
    /// </summary>
    public class Mid0005 : Mid
    {
        public string Mid { get; set; }
        public Mid0005(string message) : base(message)
        {
            try
            {
                Mid = message.Substring(20, 4);
            }
            catch
            {

            }
        }
    }
}
