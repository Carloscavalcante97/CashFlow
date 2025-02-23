using CashFlow.Communication.Reponse;

namespace CashFlow.Application.UseCases.Expenses.CashFlow.GetExpenseById;
public interface IGetExpenseByIdUseCase
{
    public Task<ResponseExpenseJson> Execute(long id);
}
