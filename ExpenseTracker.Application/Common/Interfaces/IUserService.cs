using ExpenseTracker.Application.DTO;

namespace ExpenseTracker.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<PagedResult<UserDto>> GetUsersAsync(int page, int pageSize);
    }
}
