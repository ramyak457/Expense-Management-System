using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _context;
        public ExpenseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<Expense?> GetByIdAsync(Guid id)
        {
            return await _context.Expenses
                .Include(e => e.Category)
                .Include(e => e.Approvals)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<Expense>> GetByEmployeeAsync(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Expense>> GetByStatusAsync(ExpenseStatus expenseStatus)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Expense expense)
        {
            throw new NotImplementedException();
        }
    }
}
