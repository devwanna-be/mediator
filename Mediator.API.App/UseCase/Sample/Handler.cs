using Mediator.API.App.Enum;
using Mediator.API.App.Model;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator.API.App.UseCase.Sample
{
    public class SampleHandler : IRequestHandler<SampleRequest, ResponseOne<SampleResponse>>
    {
        public async Task<ResponseOne<SampleResponse>> Handle(SampleRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1);

            SampleResponse data = new SampleResponse()
            {
                FullName = "Donald J. Trump",
                BirthCity = "New York",
                Birthday = new DateTime(1946, 06, 14),
                Height = 170,
                Weight = 100
            };

            ResponseOne<SampleResponse> response =
                new ResponseOne<SampleResponse>();
            response.Status = (int)ResponseStatus.SUCCESS;
            response.Message = "Data berhasil ditemukan.";
            response.Data = data;

            return response;
        }
    }
}