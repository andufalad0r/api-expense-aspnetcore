using api_expense_aspnetcore.Models;

namespace api_expense_aspnetcore.Interfaces
{
    public interface IAuthService
    {
        Task<(int, string)> Registration(RegistrationModel model, string role);
        Task<(int, string)> Login(LoginModel model);
    }
}