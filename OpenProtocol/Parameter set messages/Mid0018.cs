﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocol
{
    /// <summary>
    /// MID 0018 Select Parameter set
    /// </summary>
    public class Mid0018 : Mid
    {
        public string PsetID { get; set; }

        public override StringBuilder Pack()
        {
            StringBuilder sb = base.Pack();
            sb.Append(PsetID.PadLeft(3, '0'));
            return AddLength(sb);
        }
    }
}