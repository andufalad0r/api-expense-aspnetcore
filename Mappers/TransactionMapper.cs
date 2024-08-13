using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_expense_aspnetcore.Dtos;
using api_expense_aspnetcore.Models;
using Npgsql.Replication;

namespace api_expense_aspnetcore.Mappers
{
    public static class TransactionMapper
    {
        public static UserTransaction FromCreateDtoToModel(this CreateTransactionDto createDto, int budgetId)
        {
            return new UserTransaction{
                Category = createDto.Category,
                Amount = createDto.Amount,
                Description = createDto.Description,
                BudgetId = budgetId,
                CreatedAt = DateTime.Today
            };
        }
        public static TransactionDto ToTransactionDto(this UserTransaction transaction)
        {
            return new TransactionDto{
                Id = transaction.Id,
                BudgetId = transaction.BudgetId,
                Category = transaction.Category,
                Description = transaction.Description,
                Amount = transaction.Amount
            };
        }
    }
}