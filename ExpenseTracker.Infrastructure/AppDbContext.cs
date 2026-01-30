using ExpenseTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();

        public DbSet<Expense> Expenses => Set<Expense>();
        public DbSet<ExpenseCategory> ExpenseCategories => Set<ExpenseCategory>();
        public DbSet<ExpenseApproval> ExpenseApprovals => Set<ExpenseApproval>();
        public DbSet<ExpenseReceipt> ExpenseReceipts => Set<ExpenseReceipt>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.Email).IsRequired();
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.Property(u => u.FirstName).IsRequired();
                entity.Property(u => u.LastName).IsRequired();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Name).IsRequired();
            });

            //UserRole many-to-many relationship configuration
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });

                entity.HasOne(ur => ur.User)
                      .WithMany(u => u.UserRoles)
                      .HasForeignKey(ur => ur.UserId);

                entity.HasOne(ur => ur.Role)
                      .WithMany(r => r.UserRoles)
                      .HasForeignKey(ur => ur.RoleId);
            });

            modelBuilder.Entity<ExpenseCategory>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name).IsRequired();
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Amount)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                entity.Property(e => e.Status)
                      .IsRequired();

                entity.HasOne(e => e.Employee)
                      .WithMany(u => u.Expenses)
                      .HasForeignKey(e => e.EmployeeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Category)
                      .WithMany(c => c.Expenses)
                      .HasForeignKey(e => e.CategoryId);
            });

            modelBuilder.Entity<ExpenseApproval>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Decision).IsRequired();

                entity.HasOne(a => a.Expense)
                      .WithMany(e => e.Approvals)
                      .HasForeignKey(a => a.ExpenseId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.Approver)
                      .WithMany()
                      .HasForeignKey(a => a.ApproverId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ExpenseReceipt>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.FileName).IsRequired();
                entity.Property(r => r.FileUrl).IsRequired();

                entity.HasOne(r => r.Expense)
                      .WithMany(e => e.Receipts)
                      .HasForeignKey(r => r.ExpenseId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
