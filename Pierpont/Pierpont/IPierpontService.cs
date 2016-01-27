using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace Pierpont
{
    public interface IPierpontService
    {
        Dictionary<DateTime, decimal> ComputeDividends(DateTime startDate, decimal principal);
        Dictionary<DateTime, decimal> ComputeDividendsForPastYear();
        Dictionary<DateTime, decimal> ComputeDividendsForInterestingTimePeriods();
        bool Ping();
    }

    public interface IPierpontController
    {
        HttpResponseMessage ComputeDividends([FromBody] DividendRequest dividendRequest);
        HttpResponseMessage ComputeDividendsForPastYear();
        HttpResponseMessage ComputeDividendsForInterestingTimePeriods();
        HttpResponseMessage Ping();
    }
}
