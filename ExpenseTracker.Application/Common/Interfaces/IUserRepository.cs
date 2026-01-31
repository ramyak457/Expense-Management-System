using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<bool> ExistsAsync(string email);
        Task AddUserAsync(User user);
    }
}
