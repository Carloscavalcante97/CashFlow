using CashFlow.Communication.Reponses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.CashFlow.GetAll;
public interface IGetAllExpenseUseCase
{
    Task<RequestExpensesJson> Execute();
}
