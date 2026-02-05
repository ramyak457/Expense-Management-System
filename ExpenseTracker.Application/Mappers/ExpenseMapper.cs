using ExpenseTracker.Application.DTO;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Mappers
{
    public static class ExpenseMapper
    {
        public static ExpenseDTO ToDto(Expense e)
        {
            return new ExpenseDTO
            {
                Id = e.Id,

                Amount = e.Amount,

                ExpenseDate = e.ExpenseDate,

                Status = e.Status.ToString(),

                CategoryName = e.Category?.Name ?? "Uncategorized",

                Approvals = e.Approvals?
                    .Select(a => new ApprovalHistoryDto
                    {
                        ApproverId = a.ApproverId,
                        Decision = a.Decision.ToString(),
                        Comments = a.Comments,
                        ActionDate = a.ActionDate
                    })
                    .ToList()
                    ?? new List<ApprovalHistoryDto>()
            };
        }
    }
}
