using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Application.DTO;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public async Task<ExpenseDTO> CreateAsync(Guid employeeId, CreateExpenseRequest request)
        {
            var expense = new Expense
            {
                EmployeeId = employeeId,
                CategoryId = request.CategoryId,
                Amount = request.Amount,
                ExpenseDate = request.ExpenseDate,
                Description = request.Description,
                Status = ExpenseStatus.Draft,
                CreatedAt = DateTime.UtcNow,
            };

            await _expenseRepository.AddAsync(expense);
            return MapToDto(expense);
        }

        private static ExpenseDTO MapToDto(Expense e)
        {
            return new ExpenseDTO
            {
                Id = e.Id,
                Amount = e.Amount,
                ExpenseDate = e.ExpenseDate,
                Status = e.Status.ToString(),
                CategoryName = e.Category?.Name ?? "",
                Approvals = e.Approvals
                .Select(a => new ApprovalHistoryDto
                {
                    ApproverId = a.ApproverId,
                    Decision = a.Decision.ToString(),
                    Comments = a.Comments,
                    ActionDate = a.ActionDate
                })
                .ToList()
            };
        }

        public async Task SubmitAsync(Guid employeeId, Guid expenseId)
        {
            var expense = await _expenseRepository.GetByIdAsync(expenseId);
            if (expense == null)
                throw new Exception("No Expense found");

            if (expense.EmployeeId != employeeId)
                throw new Exception("Not your expense");

            if (expense.Status != ExpenseStatus.Draft)
                throw new Exception("Only draft can be submitted");

            expense.Status = ExpenseStatus.Submitted;

            await _expenseRepository.UpdateAsync(expense);
        }

        public async Task ApproveAsync(Guid managerId, ApprovalDto request)
        {
            var expense = await _expenseRepository.GetByIdAsync(request.ExpenseId);
            if (expense == null)
                throw new Exception("Expense not found");

            if (expense.Status != ExpenseStatus.Submitted)
                throw new Exception("Only submitted expenses can be actioned");

            var approval = new ExpenseApproval
            {
                ExpenseId = expense.Id,
                ApproverId = managerId,
                Decision = request.Approve ? ManagerApprovalStatus.Approved : ManagerApprovalStatus.Rejected,
                Comments = request.Comments,
                ActionDate = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            };

            expense.Approvals.Add(approval);
            expense.Status = request.Approve ? ExpenseStatus.Approved : ExpenseStatus.Rejected;
            await _expenseRepository.UpdateAsync(expense);
        }

        public async Task<List<ExpenseDTO>> MyExpenses(Guid employeeId)
        {
            var expenses = await _expenseRepository.GetByEmployeeAsync(employeeId);
            return expenses.Select(MapToDto).ToList();
        }

        public async Task<List<ExpenseDTO>> PendingForManager()
        {
            var expenses = await _expenseRepository.GetByStatusAsync(ExpenseStatus.Submitted);

            return expenses.Select(MapToDto).ToList();
        }
    }
}
