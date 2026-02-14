using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Application.DTO;


[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService userService;

    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    [Authorize(Roles = "Administrator,Manager")]
    public async Task<ActionResult<PagedResult<UserDto>>> GetUsers(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var usersList = await userService.GetUsersAsync(page, pageSize);
        return Ok(usersList);
    }
}
