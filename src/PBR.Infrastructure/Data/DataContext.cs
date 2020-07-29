using PBR.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Microsoft.Data.SqlClient;
using PBR.Core.Entities.Base;

namespace PBR.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ApplicationAccount> applicationAccounts { get;set; }
        public DbSet<ApplicationDepartment> applicationDepartments { get; set; }
        public DbSet<APPlication> application { get; set; }
        public DbSet<Department>  departments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(ConfigureProduct);
            builder.Entity<Category>(ConfigureCategory);
            builder.Entity<Account>(ConfigureAccount);
            builder.Entity<ApplicationAccount>(ConfigureApplicationAccount);
            builder.Entity<ApplicationDepartment>(ConfigureApplicationDepartment);
            builder.Entity<APPlication>(ConfigureApplication);
            builder.Entity<Department>(ConfigureDepartment);

        }

        private void ConfigureDepartment(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");

            builder.HasKey(ci => ci.DepartmentId);

            builder.Property(cb => cb.DepartmentId)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureApplication(EntityTypeBuilder<APPlication> builder)
        {
            builder.ToTable("Application");

            builder.HasKey(ci => ci.ApplicationId);

            builder.Property(cb => cb.ApplicationId)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureApplicationDepartment(EntityTypeBuilder<ApplicationDepartment> builder)
        {
            builder.ToTable("ApplicationDepartment");

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.ApplicationAccountId)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureApplicationAccount(EntityTypeBuilder<ApplicationAccount> builder)
        {
            builder.ToTable("ApplicationAccount");

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.GroupId)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureAccount(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.AccountName)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.ProductName)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureCategory(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.CategoryName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
