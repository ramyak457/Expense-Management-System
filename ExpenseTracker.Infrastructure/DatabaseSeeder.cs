using ExpenseTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Infrastructure
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(
        AppDbContext context,
        CancellationToken cancellationToken = default)
        {
            await SeedRolesAsync(context, cancellationToken);
            await SeedExpenseCategoriesAsync(context, cancellationToken);
            await SeedAdminUserAsync(context, cancellationToken);
        }

        private static async Task SeedRolesAsync(
            AppDbContext context,
            CancellationToken cancellationToken)
        {
            if (await context.Roles.AnyAsync(cancellationToken))
                return;

            var roles = new[]
            {
                new Role { Name = "Employee", CreatedAt = DateTime.Now },
                new Role { Name = "Manager", CreatedAt = DateTime.Now },
                new Role { Name = "Administrator", CreatedAt = DateTime.Now }
            };

            context.Roles.AddRange(roles);
            await context.SaveChangesAsync(cancellationToken);

        }

        private static async Task SeedExpenseCategoriesAsync(
            AppDbContext context,
            CancellationToken cancellationToken)
        {
            if (await context.ExpenseCategories.AnyAsync(cancellationToken))
                return;

            var categories = new[]
            {
                new ExpenseCategory { Name = "Travel", CreatedAt = DateTime.UtcNow },
                new ExpenseCategory { Name = "Food", CreatedAt = DateTime.UtcNow },
                new ExpenseCategory { Name = "Accomodation", CreatedAt = DateTime.UtcNow },
                new ExpenseCategory { Name = "Activities", CreatedAt = DateTime.UtcNow }
            };

            context.ExpenseCategories.AddRange(categories);
            await context.SaveChangesAsync(cancellationToken);

        }

        private static async Task SeedAdminUserAsync(
           AppDbContext context,
           CancellationToken cancellationToken)
        {
            if (await context.Users.AnyAsync(cancellationToken))
                return;
            var adminUser = new User
            {
                Email = "admin@expense.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                FirstName = "System",
                LastName = "Administrator",
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            context.Users.Add(adminUser);
            await context.SaveChangesAsync(cancellationToken);

            var adminRole = await context.Roles
                .FirstOrDefaultAsync(r => r.Name == "Administrator", cancellationToken);

            context.UserRoles.Add(new UserRole
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id
            });

            await context.SaveChangesAsync(cancellationToken);

        }
    }
}
