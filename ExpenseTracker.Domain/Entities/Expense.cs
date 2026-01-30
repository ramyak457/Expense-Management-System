using ExpenseTracker.Domain.Common;
using ExpenseTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Entities
{
    public class Expense : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public User Employee { get; set; } = null!;

        public Guid CategoryId { get; set; }
        public ExpenseCategory Category { get; set; } = null!;

        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string? Description { get; set; }

        public ExpenseStatus Status { get; set; } = ExpenseStatus.Draft;
        public ICollection<ExpenseApproval> Approvals { get; set; } = new List<ExpenseApproval>();
        public ICollection<ExpenseReceipt> Receipts { get; set; } = new List<ExpenseReceipt>();
    }
}
