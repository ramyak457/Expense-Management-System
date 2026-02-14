using ExpenseTracker.Application.DTO;
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
        Task<(List<UserDto> Users, int TotalCount)> GetUsersAsync(int page, int pageSize);
    }
}
