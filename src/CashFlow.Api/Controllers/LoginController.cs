using CashFlow.Application.UseCases.Login;
using CashFlow.Communication.Reponses;
using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(
            [FromServices] IDoLoginUseCase useCase,
            [FromBody] RequestLoginJson request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
