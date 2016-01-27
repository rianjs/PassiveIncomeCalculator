using System;

namespace Pierpont
{
    public class DividendRequest
    {
        public DateTime StartDate { get; private set; }
        public decimal Principal { get; private set; }

        public DividendRequest(DateTime startDate, decimal principal)
        {
            StartDate = startDate;
            Principal = principal;
        }
    }
}
