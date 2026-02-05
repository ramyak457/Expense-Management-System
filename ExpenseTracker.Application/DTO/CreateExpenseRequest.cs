using System;

namespace ExpenseTracker.Application.DTO
{
    public class CreateExpenseRequest
    {
        public Guid CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string? Description { get; set; }
    }
}
