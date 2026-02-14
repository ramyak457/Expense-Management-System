using ExpenseTracker.Application.DTO;
using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Common.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllAsync();
        Task<ExpenseCategory> CreateAsync(CreateCategoryDto dto);
    }
}
