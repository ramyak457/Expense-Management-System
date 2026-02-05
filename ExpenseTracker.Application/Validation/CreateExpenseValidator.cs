using ExpenseTracker.Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Validation
{
    public class CreateExpenseValidator : AbstractValidator<CreateExpenseRequest>
    {
        public CreateExpenseValidator() 
        {
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero");

            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category is required");

            RuleFor(x => x.ExpenseDate).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Expense date cannot be in future");

            RuleFor(x => x.Description).MaximumLength(500);
        }       
    }
}
