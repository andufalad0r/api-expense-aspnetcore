using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api_expense_aspnetcore.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(30)] 
        public string? Name { get; set; }
    }
}