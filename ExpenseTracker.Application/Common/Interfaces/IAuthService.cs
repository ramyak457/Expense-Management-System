using ExpenseTracker.Application.Auth.DTO;
using ExpenseTracker.Application.Auth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
    }
}
