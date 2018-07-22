using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocol
{
    /// <summary>
    /// MID 0061 Last tightening result data 
    /// </summary>
    public class Mid0061 : Mid
    {
        /// <summary>
        /// cellid
        /// </summary>
        public string CellID { get; set; }
        public string ChannelID { get; set; }
        public string TorqueControllerName { get; set; }
        public string VINNumber { get; set; }
        public string JobID { get; set; }
        public int ParameterSetID { get; set; }
        public string BatchSize { get; set; }
        public string BatchCounter { get; set; }
        public TighteningStatus TighteningStatus { get; set; }
        public TorqueStatus TorqueStatus { get; set; }
        public AngleStatus AngleStatus { get; set; }
        public double TorqueMinLimit { get; set; }
        public double TorqueMaxLimit { get; set; }
        public double TorqueFinalTarget { get; set; }
        public double Torque { get; set; }
        public int AngleMin { get; set; }
        public int AngleMax { get; set; }
        public int AngleFinalTarget { get; set; }
        public int Angle { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime DateTimeLastChange { get; set; }
        public BatchStatus BatchStatus { get; set; }
        public string TighteningID { get; set; }

        public Mid0061(string message) : base(message)
        {
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.FullDateTimePattern = "yyyy-MM-dd:HH:mm:ss";
            try
            {
                CellID = message.Substring(22, 4);
                ChannelID = message.Substring(28, 2);
                TorqueControllerName = message.Substring(32, 25);
                VINNumber = message.Substring(59, 25);
                JobID = message.Substring(86, 2);
                ParameterSetID = Convert.ToInt32(message.Substring(90, 3));
                BatchSize = message.Substring(95, 4);
                BatchCounter = message.Substring(101, 4);
                TighteningStatus = (TighteningStatus)Convert.ToInt32(message.Substring(107, 1));
                TorqueStatus = (TorqueStatus)Convert.ToInt32(message.Substring(110, 1));
                AngleStatus = (AngleStatus)Convert.ToInt32(message.Substring(113, 1));
                TorqueMinLimit = Convert.ToInt32(message.Substring(116, 6)) / 100.0;
                TorqueMaxLimit = Convert.ToInt32(message.Substring(124, 6)) / 100.0;
                TorqueFinalTarget = Convert.ToInt32(message.Substring(132, 6)) / 100.0;
                Torque = Convert.ToInt32(message.Substring(140, 6)) / 100.0;
                AngleMin = Convert.ToInt32(message.Substring(148, 5));
                AngleMax = Convert.ToInt32(message.Substring(155, 5));
                AngleFinalTarget = Convert.ToInt32(message.Substring(162, 5));
                Angle = Convert.ToInt32(message.Substring(169, 5));
                TimeStamp = DateTime.ParseExact(message.Substring(176, 19),
                    "yyyy-MM-dd:HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture);
                DateTimeLastChange = DateTime.ParseExact(message.Substring(197, 19), 
                    "yyyy-MM-dd:HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture);
                BatchStatus = (BatchStatus)Convert.ToInt32(message.Substring(218, 1));
                TighteningID = message.Substring(221, 10);
            }
            catch (Exception ex)
            {
                logger.Error(message + Environment.NewLine + ex);
            }
        }
    }

    public enum TighteningStatus
    {
        NOK,
        OK,
    }

    public enum TorqueStatus
    {
        Low,
        OK,
        High,
    }

    public enum AngleStatus
    {
        Low,
        OK,
        High,
    }

    public enum BatchStatus
    {
        NOK,
        OK,
        NotUsed,
    }
}
