using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.DTO
{
    public class ApprovalHistoryDto
    {
        public Guid ApproverId { get; set; }
        public string Decision { get; set; } = null!;
        public string? Comments { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
