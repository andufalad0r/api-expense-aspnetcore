using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_expense_aspnetcore.Models;

namespace api_expense_aspnetcore.Intrefaces
{
    public interface ITransactionRepo
    {
        Task<List<UserTransaction>> GetByBudgetIdAsync(int budgetId);
        Task<int> GetBudgetIdByUser(string userId);
        Task UpdateBudget(int budgetId, float amount);
        Task<UserTransaction> CreateAsync(UserTransaction transaction);
        Task<UserTransaction> DeleteAsync(int id);
    }
}