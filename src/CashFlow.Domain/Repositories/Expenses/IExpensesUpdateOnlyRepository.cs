using CashFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpensesUpdateOnlyRepository
    {
        Task<Expense?> GetById(long id);
        /// <summary>
        /// This method update an expense
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        void Update(Expense expense);
    }
}
