using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualCards.Application.Common.Model
{
    public class tblRequestandResponseLogs
    {
        public Guid Id { get; set; }
        public string RequestType { get; set; }
        public string RequestPayload { get; set; }
        public string Response { get; set; }
        public DateTime RequestTimestamp { get; set; }
        public DateTime ResponseTimestamp { get; set; }
        public string RequestUrl { get; set; }

    }
}
