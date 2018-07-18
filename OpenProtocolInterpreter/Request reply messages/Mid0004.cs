using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// MID 0004 Command error 
    /// </summary>
    public class Mid0004 : Mid
    {
        public string Mid { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public Mid0004(string message) : base(message)
        {
            try
            {
                Mid = message.Substring(20, 4);
                ErrorCode = message.Substring(24, 2);
                ErrorDescription = ErrorDescriptionDic[ErrorCode];
            }
            catch
            {

            }
        }

        public Dictionary<string, string> ErrorDescriptionDic = new Dictionary<string, string>()
        {
            { "00", "No Error" },
            { "01", "Invalid data" },
            { "02", "Parameter set ID not present" },
            { "03", "Parameter set can not be set." },
            { "04", "Parameter set not running" },
            { "06", "VIN upload subscription already exists" },
            { "07", "VIN upload subscription does not exists" },
            { "08", "VIN input source not granted" },
            { "09", "Last tightening result subscription already exists" },
            { "10", "Last tightening result subscription does not exist" },
            { "11", "Alarm subscription already exists" },
            { "12", "Alarm subscription does not exist" },
            { "13", "Parameter set selection subscription already exists" },
            { "14", "Parameter set selection subscription does not exist" },
            { "15", "Tightening ID requested not found" },
            { "16", "Connection rejected protocol busy" },
            { "17", "Job ID not present" },
            { "18", "Job info subscription already exists" },
            { "19", "Job info subscription does not exist" },
            { "20", "Job can not be set" },
            { "21", "Job not running" },
            { "22", "Not possible to execute dynamic Job request" },
            { "23", "Job batch decrement failed" },
            { "24", "Not possible to create Pset" },
            { "25", "Programming control not granted" },
            { "30", "Controller is not a sync Master/station controller" },
            { "31", "Multi-spindle status subscription already exists" },
            { "32", "Multi-spindle status subscription does not exist" },
            { "33", "Multi-spindle result subscription already exists" },
            { "34", "Multi-spindle result subscription does not exist" },
            { "40", "Job line control info subscription already exists" },
            { "41", "Job line control info subscription does not exist" },
            { "42", "Identifier input source not granted" },
            { "43", "Multiple identifiers work order subscription already exists" },
            { "44", "Multiple identifiers work order subscription does not exist" },
            { "50", "Status external monitored inputs subscription already exists" },
            { "51", "Status external monitored inputs subscription does not exist" },
            { "52", "IO device not connected" },
            { "53", "Faulty IO device ID" },
            { "54", "Tool Tag ID unknown" },
            { "55", "Tool Tag ID subscription already exists" },
            { "56", "Tool Tag ID subscription does not exist" },
            { "57", "Tool Motor tuning failed" },
            { "58", "No alarm present" },
            { "59", "Tool currently in use" },
            { "60", "No histogram available" },
            { "61", "Pairing failed" },
            { "62", "Pairing denied" },
            { "63", "Pairing or Pairing abortion attempt on wrong tooltype" },
            { "64", "Pairing abortion denied" },
            { "65", "Pairing abortion failed" },
            { "66", "Pairing disconnection failed" },
            { "67", "Pairing in progress or already done" },
            { "68", "Pairing denied. No Program Control" },
            { "70", "Calibration failed" },
            { "71", "Subscription already exists" },
            { "72", "Subscription does not exists" },
            { "79", "Command failed" },
            { "80", "Audi emergency status subscription exists" },
            { "81", "Audi emergency status subscription does not exist" },
            { "82", "Automatic/Manual mode subscribe already exist" },
            { "83", "Automatic/Manual mode subscribe does not exist" },
            { "84", "The relay function subscription already exists" },
            { "85", "The relay function subscription does not exist" },
            { "86", "The selector socket info subscription already exist" },
            { "87", "The selector socket info subscription does not exist" },
            { "88", "The digin info subscription already exist" },
            { "89", "The digin info subscription does not exist" },
            { "90", "Lock at batch done subscription already exist" },
            { "91", "Lock at batch done subscription does not exist" },
            { "92", "Open protocol commands disabled" },
            { "93", "Open protocol commands disabled subscription already exists" },
            { "94", "Open protocol commands disabled subscription does not exist" },
            { "95", "Reject request, PowerMACS is in manual mode" },
            { "96", "Client already connected" },
            { "97", "MID revision unsupported" },
            { "98", "Controller internal request timeout" },
            { "99", "Unknown MID" },
        };
    }
}
