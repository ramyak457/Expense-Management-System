using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.DTO
{
    public class RegisterRequest
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Role { get; set; } = "Employee"; // Default role is Employee
    }
}
