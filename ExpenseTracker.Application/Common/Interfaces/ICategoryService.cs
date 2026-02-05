using ExpenseTracker.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Common.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllAsync();
        Task CreateAsync(CreateCategoryDto dto);
    }
}
