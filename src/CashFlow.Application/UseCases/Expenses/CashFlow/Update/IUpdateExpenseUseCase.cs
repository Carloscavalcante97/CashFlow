using CashFlow.Communication.Request;

namespace CashFlow.Application.UseCases.Expenses.CashFlow.Update
{
    public interface IUpdateExpenseUseCase
    {
        Task Execute(long id, RequestExpenseJson request);
    }
}
