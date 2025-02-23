namespace CashFlow.Application.UseCases.Expenses.CashFlow.Delete
{
   public interface IDeleteExpenseUseCase
    {
        Task Execute(long id);
    }
}

