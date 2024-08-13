namespace api_expense_aspnetcore.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public float TotalAmount { get; set; }
        public ICollection<UserTransaction> UserTransactions { get; set; } = new List<UserTransaction>();
    }
}