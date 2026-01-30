using ExpenseTracker.Application.Auth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Auth
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
    }
}
