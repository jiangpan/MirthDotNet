using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MirthDotNet.Model
{
    [Serializable]
    public class MirthDateTime
    {
        public static readonly DateTime UnixEpoch = new DateTime(1970,1,1,0,0,0,0);

        public long time { get; set; }
        public string timezone { get; set; }

        public DateTime DateTime
        {
            get
            {
                return UnixEpoch.AddMilliseconds(time).ToLocalTime();
            }
            set
            {
                time =
                    (long)
                    (DateTime.SpecifyKind(value, DateTimeKind.Unspecified) -
                     DateTime.SpecifyKind(UnixEpoch, DateTimeKind.Unspecified))
                    .TotalMilliseconds;
                timezone = "America/New_York"; // hard coded :(
            }
        }
    }
}
