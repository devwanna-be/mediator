using Hangfire;
using MediatR;

namespace Mediator.API.Core.Helper
{
    public static class MediatorExtension
    {
        /// <summary>
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="jobName"></param>
        /// <param name="request"></param>
        /// <param name="cron"></param>
        public static void Recurring(this IMediator mediator, string jobName, IRequest<string> request, string cron)
        {
            RecurringJob.AddOrUpdate<HangfireBridge>(jobName, x => x.Send(request), cron);
        }
    }
}
