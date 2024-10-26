using CashFlow.Communication.Reponse;
using CashFlow.Communication.Request;

namespace CashFlow.Application.UseCases.CashFlow.Register
{
    public interface IRegisterExpenseUseCase
    {
        Task<ResponseRegisteredExpenseJson> Execute(RequestRegisterExpenseJson request);
    }
}
