using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Application.DTO;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CategoryDTO>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();

            return list.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                CreatedAt = c.CreatedAt,
                LastUpdatedAt = c.UpdatedAt
            }).ToList();
        }

        public async Task CreateAsync(CreateCategoryDto dto)
        {
            var category = new ExpenseCategory
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.AddAsync(category);
        }
    }
}
