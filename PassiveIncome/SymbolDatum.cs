using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassiveIncome
{
    public class SymbolDatum
    {
        public DateTime Date { get; private set; }
        public decimal OpeningPrice { get; private set; }
        public decimal DailyHigh { get; private set; }
        public decimal DailyLow { get; private set; }
        public decimal Close { get; private set; }
        public long TradeVolume { get; private set; }
        public decimal AdjustedClose { get; private set; }
        public SymbolDatum(DateTime date, decimal openingPrice, decimal dailyHigh, decimal dailyLow, decimal close,
            long tradeVolume, decimal adjustedClose)
        {
            Date = date;
            OpeningPrice = openingPrice;
            DailyHigh = dailyHigh;
            DailyLow = dailyLow;
            Close = close;
            TradeVolume = tradeVolume;
            AdjustedClose = adjustedClose;
        }
    }
}
