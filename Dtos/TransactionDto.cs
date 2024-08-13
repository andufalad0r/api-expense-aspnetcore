using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_expense_aspnetcore.Dtos
{
    public class TransactionDto
    {
        public int Id { get; set; }
        [Required]
        public required int BudgetId { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        public string? Category { get; set; }
        [Required]
        [Range(.1, 1000000)]
        public float Amount { get; set; } 
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}