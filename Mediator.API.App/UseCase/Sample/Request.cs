using Mediator.API.App.Model;
using MediatR;

namespace Mediator.API.App.UseCase.Sample
{
    public class SampleRequest : IRequest<ResponseOne<SampleResponse>>
    {
        public string NRP { get; set; }
    }
}
