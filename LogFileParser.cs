namespace LogParser
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class LogFileParser
    {
        private List<LogEntry> _logEntries = new List<LogEntry>();

        public void ParseLogFile(string filePath)
        {
            // Regex pattern generator is used to generate the pattern as per the sample document provided//
            string logPattern = @"(?<ip>\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}) - - \[.*\] ""GET (?<url>\S+)";
            Regex logRegex = new Regex(logPattern);


            foreach (string line in File.ReadAllLines(filePath))
            {
                Match match = logRegex.Match(line);
                if (match.Success)
                {
                    _logEntries.Add(new LogEntry(match.Groups["ip"].Value, match.Groups["url"].Value));
                }
            }
        }

        public int GetUniqueIPAddressCount()
        {
            return _logEntries.Select(entry => entry.IPAddress).Distinct().Count();
        }

        public IEnumerable<string> GetTop3MostVisitedURLs()
        {
            return _logEntries.GroupBy(entry => entry.RequestedURL)
                              .OrderByDescending(group => group.Count())
                              .Take(3)
                              .Select(group => $"{group.Key} (Visits: {group.Count()})");
        }

        public IEnumerable<string> GetTop3MostActiveIPAddresses()
        {
            return _logEntries.GroupBy(entry => entry.IPAddress)
                              .OrderByDescending(group => group.Count())
                              .Take(3)
                              .Select(group => $"{group.Key} (Requests: {group.Count()})");
        }
    }

}
