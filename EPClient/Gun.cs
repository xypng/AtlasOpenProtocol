using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPClient
{
    /// <summary>
    /// 拧紧枪
    /// </summary>
    [Serializable]
    public class Gun
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public bool Status { get; set; } = false;
    }
}
