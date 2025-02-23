using CashFlow.Communication.Reponse;
using CashFlow.Communication.Request;

namespace CashFlow.Application.UseCases.Expenses.CashFlow.Register
{
    public interface IRegisterExpenseUseCase
    {
        Task<ResponseExpenseJson> Execute(RequestExpenseJson request);
    }
}
