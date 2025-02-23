using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf
{
    public interface IGenerateExpensesReportPdfUseCase
    {
        Task<byte[]> Execute(DateOnly month);
    }
}
