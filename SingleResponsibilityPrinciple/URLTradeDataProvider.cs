using System.Collections.Generic;
using System.IO;
using System.Net;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    class URLTradeDataProvider : ITradeDataProvider
    {
        public URLTradeDataProvider(Stream stream)
        {
            this.stream = stream;
        }

        public IEnumerable<string> GetTradeData()
        {
            
            var tradeData = new List<string>();
            // create a web client and use it to read the file stored at the given URL
            var client = new WebClient();
            using (var stream = client.OpenRead("http://faculty.css.edu/tgibbons/trades4.txt"))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;
        }
        private readonly Stream stream;
    }
}
