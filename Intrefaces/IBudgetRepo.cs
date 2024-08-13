using api_expense_aspnetcore.Dtos;
using api_expense_aspnetcore.Models;

namespace api_expense_aspnetcore.Intrefaces
{
    public interface IBudgetRepo
    {
        Task<Budget?> GetByUserId(string userId);
        Task<Budget> CreateAsync(Budget budget);
        Task UpdateAsync(Budget budget);
    }
}