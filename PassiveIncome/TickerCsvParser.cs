using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PassiveIncome
{
    public class TickerCsvParser
    {
        //Date,Open,High,Low,Close,Volume,Adj Close
        //2016-01-15,173.529999,173.529999,173.529999,173.529999,000,173.529999

        private readonly string[] _content;
        public TickerCsvParser(string rawContent)
        {
            _content = rawContent.Split(new[] {Environment.NewLine, "\n", "\r"}, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
        }

        public IEnumerable<SymbolDatum> Parse() => _content.Select(ParseRow);

        internal static SymbolDatum ParseRow(string row)
        {
            var pieces = row.Split(',');
            var date = ParseDate(pieces[0]);
            var open = Convert.ToDecimal(pieces[1]);
            var high = Convert.ToDecimal(pieces[2]);
            var low = Convert.ToDecimal(pieces[3]);
            var close = Convert.ToDecimal(pieces[4]);
            var volume = Convert.ToInt64(pieces[5]);
            var adjustedClose = Convert.ToDecimal(pieces[6]);
            return new SymbolDatum(date, open, high, low, close, volume, adjustedClose);
        }

        internal static DateTime ParseDate(string date) => DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
    }
}