using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Models
{
    public class AuthResponse
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = default!;
        public string Token { get; set; } = default!;
        public List<string> Roles { get; set; } = new();
    }
}
