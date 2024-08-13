using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api_expense_aspnetcore.Dtos;
using api_expense_aspnetcore.Intrefaces;
using api_expense_aspnetcore.Mappers;
using api_expense_aspnetcore.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace api_expense_aspnetcore.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepo transactionRepo;
        public TransactionService(ITransactionRepo transactionRepo)
        {
            this.transactionRepo = transactionRepo;
        }
        public async Task<List<UserTransaction>> GetTransactionsForTheLastMonth(string userId)
        {
            int budgetId = await transactionRepo.GetBudgetIdByUser(userId);
            if(budgetId == 0)
            {
                return null;
            }
            var transactions = await transactionRepo.GetByBudgetIdAsync(budgetId);
            DateTime last30Days = DateTime.Today.AddDays(-30);
            var resultedTransactions = transactions.Where(x => x.CreatedAt >= last30Days);
            return resultedTransactions.ToList();
        }
        public async Task<List<UserTransaction>> GetTransactionsForTheLastWeek(string userId)
        {
            int budgetId = await transactionRepo.GetBudgetIdByUser(userId);
            if(budgetId == 0)
            {
                return null;
            }
            var transactions = await transactionRepo.GetByBudgetIdAsync(budgetId);
            DateTime last7Days = DateTime.Today.AddDays(-7);
            var resultedTransactions = transactions.Where(x => x.CreatedAt >= last7Days);
            return resultedTransactions.ToList();
        }
        public async Task<List<UserTransaction>> GetTransactionsForToday(string userId)
        {
            int budgetId = await transactionRepo.GetBudgetIdByUser(userId);
            if(budgetId == 0)
            {
                return null;
            }
            var transactions = await transactionRepo.GetByBudgetIdAsync(budgetId);
            var resultedTransactions = transactions.Where(x => x.CreatedAt.Day == DateTime.Today.Day);
            return resultedTransactions.ToList();
        }
        public async Task<UserTransaction> CreateTransaction(CreateTransactionDto createDto, string userId)
        {
            int budgetId = await transactionRepo.GetBudgetIdByUser(userId);
            if(budgetId == 0)
            {
                return null;
            }
            var transactionModel = createDto.FromCreateDtoToModel(budgetId);
            await transactionRepo.CreateAsync(transactionModel);
            await transactionRepo.UpdateBudget(budgetId, transactionModel.Amount);
            return transactionModel;
        }
        // hole
        public async Task<UserTransaction> DeleteTransaction(int id)
        {
            var transaction = await transactionRepo.DeleteAsync(id);
            if(transaction == null)
            {
                return null;
            }
            return transaction;
        }
    }
}