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
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {
        try
        {
            var useCase = new RegisterExpenseUseCase();
            var response = useCase.Execute(request);
            return Created(string.Empty, response);
        }
        catch (ArgumentException ex)
        {
            var errorResponse = new ResponseErrorJson
            {
                ErrorMessage = new List<string> { ex.Message }
            };
            return BadRequest(errorResponse);
        }
        catch
        {
            var errorResponse = new ResponseErrorJson
            {
                ErrorMessage = new List<string> { "unknown Error" }
            };
            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }
}
