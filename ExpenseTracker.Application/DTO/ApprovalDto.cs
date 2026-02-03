using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.DTO
{
    public class ApprovalDto
    {
        public Guid ExpenseId { get; set; }
        public bool Approve { get; set; }
        public string? Comments { get; set; }
    }
}
