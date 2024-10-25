using CashFlow.Communication.Reponse;
using CashFlow.Communication.Request;

namespace CashFlow.Application.UseCases.CashFlow.Register
{
    public interface IRegisterExpenseUseCase
    {
        public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request);
    }
}
