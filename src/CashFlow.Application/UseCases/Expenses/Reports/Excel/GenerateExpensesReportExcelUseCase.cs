using CashFlow.Domain.Enum;
using CashFlow.Domain.Enums.Extensions;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expenses.Reports.Excel
{
    public class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase
    {
        private const string CURRENCY_SYMBOL = "$";
        private readonly IExpensesReadOnlyRepository _repository;
        public GenerateExpensesReportExcelUseCase(IExpensesReadOnlyRepository repository)
        {
            _repository = repository;
        }
        public async Task<byte[]> Execute(DateOnly month)
        {
            var expenses = await _repository.FilterByMonth(month);
            if (expenses.Count == 0)
            {
                return [];
            }

            using var workBook = new XLWorkbook();

            workBook.Author = "Antônio Cavalcante";

            workBook.Style.Font.FontSize = 12;

            workBook.Style.Font.FontName = "Times New Roman";

            var worksheet = workBook.Worksheets.Add(month.ToString("Y"));

            InsertHeader(worksheet);
            decimal expensesSum = 0;
            var raw = 2;
            foreach (var expense in expenses)
            {
                worksheet.Cell($"A{raw}").Value = expense.Title;
                worksheet.Cell($"B{raw}").Value = expense.Date;
                worksheet.Cell($"C{raw}").Value = expense.PaymentType.PaymentTypeToString();
                worksheet.Cell($"D{raw}").Value = expense.Amount;
                worksheet.Cell($"D{raw}").Style.NumberFormat.Format = $"-{CURRENCY_SYMBOL} #,##0.00";
                worksheet.Cell($"E{raw}").Value = expense.Description;
                expensesSum += expense.Amount;               
                raw++;
            }
            worksheet.Cell("F2").Value = expensesSum;
            worksheet.Cell("F2").Style.NumberFormat.Format = $"-{CURRENCY_SYMBOL} #,##0.00";

            worksheet.Columns().AdjustToContents();

            var file = new MemoryStream();

            workBook.SaveAs(file);

            return file.ToArray();

        }
       
        private void InsertHeader(IXLWorksheet worksheet)
        {
            worksheet.Cell("A1").Value = ResourceReportGenerationMessage.TITLE;
            worksheet.Cell("B1").Value = ResourceReportGenerationMessage.DATE;
            worksheet.Cell("C1").Value = ResourceReportGenerationMessage.PAYMENT_TYPE;
            worksheet.Cell("D1").Value = ResourceReportGenerationMessage.AMOUNT;
            worksheet.Cell("E1").Value = ResourceReportGenerationMessage.DESCRIPTION;
            worksheet.Cell("F1").Value = ResourceReportGenerationMessage.TOTAL;
            worksheet.Cells("A1:F1").Style.Font.Bold = true;
            worksheet.Cells("A1:F1").Style.Fill.BackgroundColor = XLColor.Green;
            worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            worksheet.Cell("F1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        }

    }
}
