using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.DTO
{
    public class ApprovalDto
    {
        public Guid ExpenseId { get; set; }
        public bool IsApproved { get; set; }
        public string? Comments { get; set; }
    }
}
