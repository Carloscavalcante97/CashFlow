using CashFlow.Communication.Reponse;

namespace CashFlow.Application.UseCases.Expenses.GetExpenseById;
public interface IGetExpenseByIdUseCase
{
    public Task<ResponseExpenseJson> Execute(long id);
}
