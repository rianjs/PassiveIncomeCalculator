using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using PassiveIncome;

namespace PassiveIncomeUnitTests
{
    [TestFixture]
    internal class TickerCsvParserUnitTests
    {
        [Test, TestCaseSource(nameof(ParseDate_TestCases))]
        public DateTime ParseDate_Tests(string date)
        {
            var dt = TickerCsvParser.ParseDate(date);
            return dt;
        }

        public static IEnumerable<ITestCaseData>ParseDate_TestCases()
        {
            yield return new TestCaseData("2015-01-01")
                .Returns(new DateTime(2015,01,01))
                .SetName("2015-01-01 returns 01/01/2015 DateTime object");

            yield return new TestCaseData("2015-12-25")
                .Returns(new DateTime(2015, 12, 25))
                .SetName("2015-01-01 returns 12/25/2015 DateTime object");
        }

        [Test, TestCaseSource(nameof(ParseRow_TestCases))]
        public void SymbolData_Tests(string rawActual, SymbolDatum expected)
        {
            var actual = TickerCsvParser.ParseRow(rawActual);
            Assert.AreEqual(expected.AdjustedClose, actual.AdjustedClose);
            Assert.AreEqual(expected.Close, actual.Close);
            Assert.AreEqual(expected.DailyHigh, actual.DailyHigh);
            Assert.AreEqual(expected.DailyLow, actual.DailyLow);
            Assert.AreEqual(expected.Date, actual.Date);
            Assert.AreEqual(expected.OpeningPrice, actual.OpeningPrice);
            Assert.AreEqual(expected.TradeVolume, actual.TradeVolume);
        }

        public static IEnumerable<ITestCaseData> ParseRow_TestCases()
        {
            var expected = new SymbolDatum(new DateTime(2016, 01, 15), 173.529999m, 173.529999m, 173.529999m, 173.529999m, 0L, 173.529999m);
            yield return new TestCaseData("2016-01-15,173.529999,173.529999,173.529999,173.529999,000,173.529999", expected)
                .SetName("Fractional decimals behaves OK");
        } 
    }
}
