using CashFlow.Communication.Reponses;
using CashFlow.Communication.Requests;

namespace CashFlow.Application.UseCases.Login
{
    public interface IDoLoginUseCase
    {
        Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
    }
}
