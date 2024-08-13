
using api_expense_aspnetcore.Data;
using api_expense_aspnetcore.Intrefaces;
using api_expense_aspnetcore.Models;
using Microsoft.EntityFrameworkCore;

namespace api_expense_aspnetcore.Repos
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly ApplicationDbContext dbContext;
        public TransactionRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<int> GetBudgetIdByUser(string userId)
        {
            var budget = await dbContext.Budgets.FirstOrDefaultAsync(c => c.UserId == userId);
            if(budget == null)
            {
                return 0;
            }
            return budget.Id;
        }
        public async Task UpdateBudget(int budgetId, float amount)
        {
            var budget = await dbContext.Budgets.FirstOrDefaultAsync(c => c.Id == budgetId);
            budget.TotalAmount += amount;
            await dbContext.SaveChangesAsync();
        }
        public async Task<List<UserTransaction>> GetByBudgetIdAsync(int budgetId)
        {
            return await dbContext.Transactions.Where(b => b.BudgetId == budgetId).ToListAsync();
        }
        public async Task<UserTransaction> CreateAsync(UserTransaction transaction)
        {
            await dbContext.Transactions.AddAsync(transaction);
            await dbContext.SaveChangesAsync();
            return transaction;
        }
        public async Task<UserTransaction> DeleteAsync(int id)
        {
            var transactionModel = await dbContext.Transactions.FirstOrDefaultAsync(x => x.Id == id);
            if(transactionModel == null)
            {
                return null;
            }
            dbContext.Transactions.Remove(transactionModel);
            await UpdateBudget(transactionModel.BudgetId, -transactionModel.Amount);
            await dbContext.SaveChangesAsync();
            return transactionModel;
        }
    }
}