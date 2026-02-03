using ExpenseTracker.Application.DTO;
using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Common.Interfaces
{
    public interface IExpenseService
    {
        Task<ExpenseDTO> CreateAsync(Guid employeeId, CreateExpenseRequest request);
        Task SubmitAsync(Guid userId, Guid expenseId);

        Task ApproveAsync(Guid managerId, ApprovalDto request);

        Task<List<ExpenseDTO>> MyExpenses(Guid userId);

        Task<List<ExpenseDTO>> PendingForManager();
    }
}
