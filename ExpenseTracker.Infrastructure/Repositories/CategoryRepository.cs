using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExpenseCategory>> GetAllAsync()
            => await _context.ExpenseCategories.ToListAsync();

        public async Task<ExpenseCategory?> GetByIdAsync(Guid id)
            => await _context.ExpenseCategories.FindAsync(id);

        public async Task AddAsync(ExpenseCategory category)
        {
            _context.ExpenseCategories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ExpenseCategory category)
        {
            _context.ExpenseCategories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
