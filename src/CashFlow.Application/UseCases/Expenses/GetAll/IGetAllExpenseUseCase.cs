using CashFlow.Communication.Reponses;

namespace CashFlow.Application.UseCases.Expenses.GetAll;
public interface IGetAllExpenseUseCase
{
    Task<RequestExpensesJson> Execute();
}
