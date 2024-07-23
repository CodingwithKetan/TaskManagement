using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class RepositoryContext : IdentityDbContext<Employee>
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public DbSet<UserTask> Tasks { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            // Additional configuration for other Identity entities
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<UserTask>()
               .HasOne(ut => ut.AssignedEmployee)
               .WithMany(e => e.Tasks)
               .HasForeignKey(ut => ut.AssignedTo)
               .OnDelete(DeleteBehavior.Cascade); // Cascade delete for AssignedEmployee

            modelBuilder.Entity<UserTask>()
                .HasOne(ut => ut.Creator)
                .WithMany() // No navigation property in Employee for Creator
                .HasForeignKey(ut => ut.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
