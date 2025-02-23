using CashFlow.Application.UseCases.Expenses.Reports.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CashFlow.Api.Controllers;
[Route("api/[controller]")]
[ApiController]

public class ReportController : Controller
    {
    [HttpGet("excel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetExcel(
        [FromServices] IGenerateExpensesReportExcelUseCase useCase,
        [FromHeader]DateOnly month)
        {
         string data = $"{month.Year}/{month.Month}";
            byte[] file = await useCase.Execute(month);

        if(file.Length > 0) { 
        
        
            return File(file, MediaTypeNames.Application.Octet, $"report-{data}.xlsx");
        }
        return NoContent();
    } 
    }

