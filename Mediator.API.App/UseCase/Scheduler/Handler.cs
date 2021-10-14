using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator.API.App.UseCase.Scheduler
{
    public class SchedulerHandler : IRequestHandler<SchedulerRequest, string>
    {
        public async Task<string> Handle(SchedulerRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1);

            //INSERT YOUR LOGIC HERE
            //FOR THE SAKE OF EXAMPLE, I AM GOING TO RETURN STRING MESSAGE

            return "Successfully executed";
        }
    }
}