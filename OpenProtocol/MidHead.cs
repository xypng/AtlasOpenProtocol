using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocol
{
    public class MidHead
    {
        public int Length { get; set; }

        public string MID { get; set; }

        public string Revision { get; set; }

        public string NoAckflag { get; set; }

        public string StationID { get; set; }

        public string SpindleID { get; set; }

        public string Spare { get; set; }
    }
}
