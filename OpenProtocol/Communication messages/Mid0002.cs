using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocol
{
    /// <summary>
    /// MID 0002 Communication start acknowledge
    /// </summary>
    public class Mid0002 : Mid
    {
        public string CellID { get; set; }

        public string ChannelID { get; set; }

        public string ControllerName { get; set; }
         
        public Mid0002(string message) : base(message)
        {
            try
            {
                this.CellID = message.Substring(22, 4);
                this.ChannelID = message.Substring(28, 2);
                this.ControllerName = message.Substring(32, 25);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
