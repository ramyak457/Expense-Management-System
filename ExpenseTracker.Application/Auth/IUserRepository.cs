using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Auth
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
