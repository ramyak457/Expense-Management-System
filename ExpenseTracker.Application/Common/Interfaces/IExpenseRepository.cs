using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Common.Interfaces
{
    public interface IExpenseRepository
    {
        Task AddAsync(Expense expense);
        Task<Expense?> GetByIdAsync(Guid id);
        Task<List<Expense>> GetByEmployeeAsync(Guid employeeId);
        Task<List<Expense>> GetByStatusAsync(ExpenseStatus expenseStatus);
        Task UpdateAsync(Expense expense);
    }
}
