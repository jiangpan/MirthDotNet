using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("com.mirth.connect.model.LoginStatus")]
    public class LoginStatus
    {
        public enum StatusEnum
        {
            SUCCESS, SUCCESS_GRACE_PERIOD, FAIL, FAIL_EXPIRED, FAIL_LOCKED_OUT, FAIL_VERSION_MISMATCH
        }

        [XmlElement("status")]
        public StatusEnum Status { get; set; }
        [XmlElement("message")]
        public string Message { get; set; }

        public LoginStatus() { }

        public LoginStatus(StatusEnum status, String message)
        {
            this.Status = status;
            this.Message = message;
        }
    }
}
