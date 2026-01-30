using ExpenseTracker.Domain.Common;
using ExpenseTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Entities
{
    public class ExpenseApproval : BaseEntity
    {
        public Guid ExpenseId { get; set; }
        public Expense Expense { get; set; } = null!;

        public Guid ApproverId { get; set; }
        public User Approver { get; set; } = null!;

        public ManagerApprovalStatus Decision { get; set; }
        public string? Comments { get; set; }

        public DateTime ActionDate { get; set; }
    }
}
