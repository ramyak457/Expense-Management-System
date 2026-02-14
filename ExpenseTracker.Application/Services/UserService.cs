using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Application.DTO;
public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<UserDto>> GetUsersAsync(int page, int pageSize)
    {
         var (users, totalCount) = await _repository.GetUsersAsync(page, pageSize);

        return new PagedResult<UserDto>
        {
            Items = users,
            Page = page,
            TotalCount = totalCount,
            TotalPages = 
                (int)Math.Ceiling(totalCount / (double)pageSize)
        };
    }
}
