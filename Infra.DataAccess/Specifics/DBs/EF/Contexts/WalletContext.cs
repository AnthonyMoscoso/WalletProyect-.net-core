using Entities.DbModels.EF;
using Infra.DataAccess.Specifics.DBs.EF.ModelsConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infra.DataAccess.Specifics.DBs.EF.Contexts
{
    public class WalletContext : DbContext
    {
        public WalletContext(DbContextOptions<WalletContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Ingress>(w => w.HasCheckConstraint("CK_Ingress_Quantity", "Quantity>=0"));
            modelBuilder.Entity<Expense>(w => w.HasCheckConstraint("CK_Expense_Quantity", "Quantity>=0"));
 

        }

        public DbSet<Expense> Expense { get; set; }
        public DbSet<ExpenseType> ExpenseType { get; set; }
        public DbSet<Ingress> Ingress { get; set; }
        public DbSet<IngressType> IngressType { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
