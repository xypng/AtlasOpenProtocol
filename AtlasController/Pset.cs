using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AtlasController
{
    [Serializable]
    public class Pset
    {
        /// <summary>
        /// PsetID
        /// </summary>
        public int PsetID { get; set; }

        /// <summary>
        /// PsetName
        /// </summary>
        public string PsetName { get; set; } = string.Empty;

        private string rotationDirection = "CW";
        /// <summary>
        /// Rotation Direction
        /// </summary>
        public string RotationDirection
        {
            get
            {
                return rotationDirection;
            }
            set
            {
                if (value=="CW"||value=="CCW")
                {
                    rotationDirection = value;
                }
            }
        }

        private int batchSize = 1;
        /// <summary>
        /// Batch Size
        /// </summary>
        public int BatchSize
        {
            get
            {
                return batchSize;
            }
            set
            {
                if (value>=0 && value<=99)
                {
                    batchSize = value;
                }
            }
        }

        private int torqueMin = 0;
        /// <summary>
        /// Rorque Min
        /// </summary>
        public int TorqueMin
        {
            get
            {
                return torqueMin;
            }
            set
            {
                if (value >= 0 && value <= 999999)
                {
                    torqueMin = value;
                }
            }
        }

        private int torqueMax = 999999;
        /// <summary>
        /// Torque Max
        /// </summary>
        public int TorqueMax
        {
            get
            {
                return torqueMax;
            }
            set
            {
                if (value >= 0 && value <= 999999)
                {
                    torqueMax = value;
                }
            }
        }

        private int torqueTarget = 500000;
        /// <summary>
        /// Torque Target
        /// </summary>
        public int TorqueTarget
        {
            get
            {
                return torqueTarget;
            }
            set
            {
                if (value >= 0 && value <= 999999)
                {
                    torqueTarget = value;
                }
            }
        }

        private int angleMin = 0;
        /// <summary>
        /// Angle Min
        /// </summary>
        public int AngleMin
        {
            get
            {
                return angleMin;
            }
            set
            {
                if (value >= 0 && value <= 99999)
                {
                    angleMin = value;
                }
            }
        }

        private int angleMax = 99999;
        /// <summary>
        /// Angle max
        /// </summary>
        public int AngleMax
        {
            get
            {
                return angleMax;
            }
            set
            {
                if (value >= 0 && value <= 99999)
                {
                    angleMax = value;
                }
            }
        }

        private int angleTarget = 50000;
        /// <summary>
        /// Angle Target
        /// </summary>
        public int AngleTarget
        {
            get
            {
                return angleTarget;
            }
            set
            {
                if (value >= 0 && value <= 99999)
                {
                    angleTarget = value;
                }
            }
        }
    }
}
