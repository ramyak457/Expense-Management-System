using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Common.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<ExpenseCategory>> GetAllAsync();
        Task<ExpenseCategory?> GetByIdAsync(Guid id);
        Task AddAsync(ExpenseCategory category);
        Task UpdateAsync(ExpenseCategory category);
    }
}
