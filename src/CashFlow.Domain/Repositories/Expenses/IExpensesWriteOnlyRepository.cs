using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpensesWriteOnlyRepository
    {
        /// <summary>
        /// This method add a new expense
        /// </summary>
        ///  <param name="expense"></param>
        ///  <returns></returns>
        Task Add(Expense expense);
        /// <summary>
        /// This method return true if the expense was deleted, otherwise return false
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(long id);

    }
}
