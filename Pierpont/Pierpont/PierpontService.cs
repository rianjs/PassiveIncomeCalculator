using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace Pierpont
{
    internal class PierpontService : IPierpontService
    {
        private readonly CancellationTokenSource _cancellationToken;
        private static readonly ILog _logger = LogManager.GetLogger("PierpontService");

        public PierpontService(CancellationTokenSource cancellationToken)
        {
            _cancellationToken = cancellationToken;
            Start();
        }

        public void Start()
        {
            _logger.Info(new {Message = "Pierpont Service has started"});
            //Warm up the cache?
        }

        public async Task Stop()
        {
            _cancellationToken.Cancel();
            _logger.Info(new {Message = "Pierpont Service is stopping"});
            //Cleanup operations
        }

        public Dictionary<DateTime, decimal> ComputeDividends(DateTime startDate, decimal principal)
        {
            return new Dictionary<DateTime, decimal> { { DateTime.UtcNow.Date, 0m} };
        }

        public Dictionary<DateTime, decimal> ComputeDividendsForPastYear()
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTime, decimal> ComputeDividendsForInterestingTimePeriods()
        {
            throw new NotImplementedException();
        }

        public bool Ping() => true;
    }
}
