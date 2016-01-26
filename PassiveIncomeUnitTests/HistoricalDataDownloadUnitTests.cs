using System;
using NUnit.Framework;
using PassiveIncome;

namespace PassiveIncomeUnitTests
{
    [TestFixture]
    public class HistoricalDataDownloadUnitTests
    {
        [Test]
        public void DataUrlTests()
        {
            const string expectedUrl = "http://ichart.finance.yahoo.com/table.csv?s=VFIAX&c=2007";

            var downloader = new HistoricalDataDownloader("VFIAX", new DateTime(2007, 01, 01));
            Assert.AreEqual(expectedUrl, downloader.DataUrl);
        }
    }
}
