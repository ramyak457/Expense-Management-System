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
                .Include(e => e.Receipts)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Expense>> GetByEmployeeAsync(Guid employeeId)
        {
            return await _context.Expenses
                .Include(e => e.Category)
                .Include(e => e.Approvals)
                .Where(e => e.EmployeeId == employeeId)
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Expense>> GetByStatusAsync(ExpenseStatus expenseStatus)
        {
            return await _context.Expenses
                .Include(e => e.Category)
                .Include(e => e.Approvals)
                .Include(e => e.Employee)
                .Where (e=> e.Status == expenseStatus)
                .OrderBy(e => e.CreatedAt)
                .ToListAsync();
        }

        public async Task UpdateAsync(Expense expense)
        {
            _context.Expenses.Update(expense);

            await _context.SaveChangesAsync();
        }
    }
}
