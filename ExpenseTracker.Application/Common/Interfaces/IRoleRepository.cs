using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Common.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role?> GetByNameAsync(string roleName);
    }
}
