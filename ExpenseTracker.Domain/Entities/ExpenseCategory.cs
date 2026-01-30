using ExpenseTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Entities
{
    public class ExpenseCategory : BaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
