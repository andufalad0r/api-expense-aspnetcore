using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_expense_aspnetcore.Data;
using api_expense_aspnetcore.Dtos;
using api_expense_aspnetcore.Intrefaces;
using api_expense_aspnetcore.Models;
using Microsoft.EntityFrameworkCore;

namespace api_expense_aspnetcore.Repos
{
    public class BudgetRepo : IBudgetRepo
    {
        private readonly ApplicationDbContext dbContext;
        public BudgetRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Budget?> GetByUserId(string userId)
        {
            return await dbContext.Budgets.FirstOrDefaultAsync(b => b.UserId == userId);
        }
        public async Task<Budget> CreateAsync(Budget budget)
        {
            await dbContext.AddAsync(budget);
            await dbContext.SaveChangesAsync();
            return budget;
        }
        public async Task UpdateAsync(Budget budget)
        {
            dbContext.Budgets.Update(budget);
            await dbContext.SaveChangesAsync();
        }
    }
}