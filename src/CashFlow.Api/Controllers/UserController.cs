using CashFlow.Application.UseCases.User.Register;
using CashFlow.Communication.Reponses;
using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterUserUseCase useCase,
            [FromBody] RequestRegisterUserJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }    
}
