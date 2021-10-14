using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Mediator.API.Core.Helper
{
    public class HangfireFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            //Can use this for NetCore
            //return context.GetHttpContext().User.Identity.IsAuthenticated;
            return true;
        }
    }
}
