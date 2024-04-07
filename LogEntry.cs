using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser
{
    public class LogEntry
    {
        public string IPAddress { get; set; }
        public string RequestedURL { get; set; }

        // method named LogEntry for initializing the variables
        public LogEntry(string ipAddress, string requestedURL)
        {
            IPAddress = ipAddress;
            RequestedURL = requestedURL;
        }
    }

}
