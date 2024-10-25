using CashFlow.Application.UseCases.CashFlow.Register;
using CashFlow.Communication.Reponses;
using CashFlow.Communication.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RegisterController : ControllerBase
{
    [HttpPost]
    
    public IActionResult Register(
        [FromServices] IRegisterExpenseUseCase useCase, 
        [FromBody] RequestRegisterExpenseJson request)
    {
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        
        }
}
