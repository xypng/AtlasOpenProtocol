using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EPClient
{
    /// <summary>
    /// 工序
    /// </summary>
    [Serializable]
    public class Action
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 拧紧枪ID
        /// </summary>
        public string GunID { get; set; }

        /// <summary>
        /// Pset
        /// </summary>
        public int Pset { get; set; }

        /// <summary>
        /// OK个数
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public int OkCount { get; set; }

        /// <summary>
        /// Nok个数
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public int NokCount { get; set; }

    }
}
