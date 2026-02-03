using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.DTO
{
    public class ExpenseDTO
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Status { get; set; } = null!;
        public string CategoryName { get; set; } = null!;

        public List<ApprovalHistoryDto> Approvals { get; set; } = null!;
        public CreateExpenseRequest ExpenseDetails { get; set; } = null!;

    }
}
