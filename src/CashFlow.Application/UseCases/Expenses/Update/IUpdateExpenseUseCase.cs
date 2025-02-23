using CashFlow.Communication.Request;

namespace CashFlow.Application.UseCases.Expenses.Update
{
    public interface IUpdateExpenseUseCase
    {
        Task Execute(long id, RequestExpenseJson request);
    }
}
