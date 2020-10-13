using Mediator.API.App.Model;
using Mediator.API.App.UseCase.Sample;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Mediator.API.Core.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SampleController : BaseController
    {
        /// <summary>
        /// Retrieve sample data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("sample/{nrp}")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseOne<SampleResponse>))]
        public async Task<ActionResult<ResponseOne<SampleResponse>>> GetSample([FromRoute] SampleRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
