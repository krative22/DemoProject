namespace LogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            // Specify the path to your log file here//
            string logFilePath = @"programming-task-example-data.log";
            LogFileParser parser = new();
            parser.ParseLogFile(logFilePath);

            // Provides the Ip for Uniques Ip addresses//
            Console.WriteLine($"Unique IP Addresses: {parser.GetUniqueIPAddressCount()}");
            Console.WriteLine("Top 3 Most Visited URLs:");
            foreach (string url in parser.GetTop3MostVisitedURLs())
            {
                Console.WriteLine($"- {url}");
            }
            // Provides the output doe three active ip addresses
            Console.WriteLine("Top 3 Most Active IP Addresses:");
            foreach (string ip in parser.GetTop3MostActiveIPAddresses())
            {
                Console.WriteLine($"- {ip}");
            }
        }
    }

}
