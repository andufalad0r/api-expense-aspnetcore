namespace api_expense_aspnetcore.Models
{
    public class UserTransaction
    {
        public int Id { get; set; }
        public required int BudgetId { get; set; }
        public string? Category { get; set; }
        public float Amount { get; set; } 
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Budget Budget { get; set; } = null!;
    }
}