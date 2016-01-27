using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using log4net;

namespace Pierpont
{
    [RoutePrefix("pierpont")]
    internal class PierpontController : ApiController, IPierpontController
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(PierpontController));

        private readonly CancellationTokenSource _cts;
        private readonly IPierpontService _pierpont;
        public PierpontController(IPierpontService pierpontInstance, CancellationTokenSource cancellationTokenSource)
        {
            _cts = cancellationTokenSource;
            _pierpont = pierpontInstance;
        }

        private static HttpResponseMessage Unavailable => new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
        private static HttpResponseMessage NotImplemented => new HttpResponseMessage(HttpStatusCode.NotImplemented) { ReasonPhrase = "Method not yet implemented." };

        [HttpPost]
        [Route("ComputeDividends")]
        public HttpResponseMessage ComputeDividends(DividendRequest dividendRequest)
        {
            if (_cts.IsCancellationRequested)
            {
                return Unavailable;
            }

            var timer = Stopwatch.StartNew();
            try
            {
                var answer = _pierpont.ComputeDividends(dividendRequest.StartDate, dividendRequest.Principal);
                return Unavailable;
            }
            finally
            {
                timer.Stop();
                if (timer.ElapsedMilliseconds >= 1)
                {
                    _logger.Warn(new {Message = "Slow query in ComputeDividends", ElapsedTime = timer.ElapsedTicks, Request = dividendRequest});
                }
            }
        }

        public HttpResponseMessage ComputeDividendsForPastYear()
        {
            return Unavailable;
        }

        public HttpResponseMessage ComputeDividendsForInterestingTimePeriods()
        {
            return Unavailable;
        }

        [HttpGet]
        [Route("ping")]
        public HttpResponseMessage Ping()
        {
            if (_cts.IsCancellationRequested)
            {
                return Unavailable;
            }

            var isUp = _pierpont.Ping();
            var good = Request.CreateResponse(HttpStatusCode.OK, new { Message = "PING!" });
            return isUp ? good : new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
        }
    }
}
