using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_expense_aspnetcore.Dtos;
using api_expense_aspnetcore.Models;

namespace api_expense_aspnetcore.Intrefaces
{
    public interface ITransactionService
    {
        Task<List<UserTransaction>> GetTransactionsForTheLastMonth(string userId);
        Task<List<UserTransaction>> GetTransactionsForTheLastWeek(string userId);
        Task<List<UserTransaction>> GetTransactionsForToday(string userId);
        Task<UserTransaction> CreateTransaction(CreateTransactionDto createDto, string userId);
        Task<UserTransaction> DeleteTransaction(int id);

    }
}