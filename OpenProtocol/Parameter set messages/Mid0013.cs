using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocol
{
    /// <summary>
    /// MID 0013 Parameter set data upload reply
    /// </summary>
    public class Mid0013 : Mid
    {
        public string ParameterSetID { get; set; }
        public string ParameterSetName { get; set; }
        public RotationDirection RotationDirection { get; set; }
        public string BatchSize { get; set; }
        public double TorqueMin { get; set; }
        public double TorqueMax { get; set; }
        public double TorqueFinalTarget { get; set; }
        public int AngleMin { get; set; }
        public int AngleMax { get; set; }
        public int AngleFinalTarget { get; set; }

        public Mid0013(string message) : base(message)
        {
            try
            {
                ParameterSetID = message.Substring(22, 3);
                ParameterSetName = message.Substring(27, 25);
                RotationDirection = (RotationDirection)Convert.ToInt32(message.Substring(54, 1));
                BatchSize = message.Substring(57, 2);
                TorqueMin = Convert.ToInt32(message.Substring(61, 6)) / 100.0;
                TorqueMax = Convert.ToInt32(message.Substring(69, 6)) / 100.0;
                TorqueFinalTarget = Convert.ToInt32(message.Substring(77, 6)) / 100.0;
                AngleMin = Convert.ToInt32(message.Substring(85, 5));
                AngleMax = Convert.ToInt32(message.Substring(92, 5));
                AngleFinalTarget = Convert.ToInt32(message.Substring(99, 5));
            }
            catch (Exception ex)
            {
                logger.Error(message + Environment.NewLine + ex);
            }
        }
    }

    public enum RotationDirection
    {
        CW = 1,
        CCW = 2,
    }
}
