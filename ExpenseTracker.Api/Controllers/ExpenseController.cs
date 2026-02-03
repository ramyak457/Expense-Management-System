using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Application.DTO;
using ExpenseTracker.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseTracker.Api.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    [Authorize]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExpenseRequest request)
        {
            var employeeId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _expenseService.CreateAsync(employeeId, request);

            return Ok(result);
        }
        [HttpPost("{expenseId}/submit")]
        public async Task<IActionResult> Submit(Guid expenseId)
        {
            var employeeId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            await _expenseService.SubmitAsync(employeeId, expenseId);

            return Ok(new { message = "Expense submitted successfully" });
        }

        [HttpGet("MyList")]
        public async Task<IActionResult> MyExpenses()
        {
            var employeeId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var expenses = await _expenseService.MyExpenses(employeeId);

            return Ok(expenses);
        }

        [HttpGet("pending")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Pending()
        {
            var expenses = await _expenseService.PendingForManager();

            return Ok(expenses);
        }

        [HttpPost("approve")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Approve([FromBody] ApprovalDto request)
        {
            var managerId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            await _expenseService.ApproveAsync(managerId, request);

            return Ok(new { message = "Decision updated" });
        }

    }
}
