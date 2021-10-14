using MediatR;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Mediator.API.Core.Helper
{
    public class HangfireBridge
    {
        private readonly IMediator _mediator;

        public HangfireBridge(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Send(IRequest<string> request)
        {
            await _mediator.Send(request);
        }

        [DisplayName("{0}")]
        public async Task Send(string jobName, IRequest command) => await _mediator.Send(command);
    }
}
