using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassiveIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BridgeToAsync().Wait();
            Console.ReadLine();
        }

        private static async Task BridgeToAsync()
        {
            var downloader = new HistoricalDataDownloader("VFIAX", new DateTime(2007, 01, 01));
            var rawContent = await downloader.DownloadHistoricalDataAsync();
            var vfiaxHist = new TickerCsvParser(rawContent).Parse();
            var queryableHistory = TickerHistory(vfiaxHist);
            var startDate = DateTime.UtcNow.AddYears(-1);
            var priceOnOrAfterStartDate = queryableHistory.First(pair => pair.Key >= startDate);
            Console.WriteLine(priceOnOrAfterStartDate.Key + Environment.NewLine + priceOnOrAfterStartDate.Value.AdjustedClose);
        }

        internal static Dictionary<DateTime, SymbolDatum> TickerHistory(IEnumerable<SymbolDatum> dataDump)
        {
            return dataDump.ToDictionary(d => d.Date, d => d);
        }

        internal static double ComputeNumberOfShares(decimal sharePrice, decimal principal)
            => Math.Round(Convert.ToDouble(principal / sharePrice), 4);
    }
}
