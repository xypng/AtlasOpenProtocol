using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// MID 0011 Parameter set ID upload reply
    /// </summary>
    public class Mid0011 : Mid
    {
        public string[] Psets;
        public Mid0011(string message) : base(message)
        {
            try
            {
                int psetCount = Convert.ToInt32(message.Substring(20, 3));
                Psets = new string[psetCount];
                for (int i = 0; i < psetCount; i++)
                {
                    Psets[i] = message.Substring(23 + i*3, 3);
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
