using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Auth.Models
{
    public class LoginRequest
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
