using ExpenseTracker.Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Validation
{
    public class ApprovalValidator: AbstractValidator<ApprovalDto>
    {
        public ApprovalValidator()
        {
            RuleFor(x => x.ExpenseId).NotEmpty();

            RuleFor(x => x.Comments).MaximumLength(300);
        }
    }
}
