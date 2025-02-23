using CashFlow.Communication.Reponses;

namespace CashFlow.Application.UseCases.Expenses.CashFlow.GetAll;
public interface IGetAllExpenseUseCase
{
    Task<RequestExpensesJson> Execute();
}
