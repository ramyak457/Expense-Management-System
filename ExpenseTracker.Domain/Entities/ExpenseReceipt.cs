using ExpenseTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Entities
{
    public class ExpenseReceipt : BaseEntity
    {
        public Guid ExpenseId { get; set; }
        public Expense Expense { get; set; } = null!;

        public string FileName { get; set; } = null!;
        public string FileUrl { get; set; } = null!;

        public DateTime UploadedAt { get; set; }
    }
}
