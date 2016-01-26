using System;
using System.Net;
using System.Threading.Tasks;

namespace PassiveIncome
{
    public class HistoricalDataDownloader
    {
        private readonly string _tickerSymbol;
        private readonly DateTime _startDate;
        public HistoricalDataDownloader(string tickerSymbol, DateTime startDate)
        {
            _startDate = startDate;
            _tickerSymbol = tickerSymbol;
        }

        private const string _yahoo = "http://ichart.finance.yahoo.com/table.csv?s=";
        public string DataUrl => _yahoo + _tickerSymbol + "&c=" + _startDate.Year;
        public async Task<string> DownloadHistoricalDataAsync()
        {
            using (var client = new WebClient())
            {
                var content = await client.DownloadStringTaskAsync(DataUrl);
                return content;
            }
        }
    }
}