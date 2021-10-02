using Entities.DbModels.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.DataAccess.Specifics.DBs.EF.ModelsConfig
{
    public class ExpenseConfig : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(w=> w.IdExpense);
            builder.Property(w => w.IdExpense).ValueGeneratedNever();
            builder.Property(s => s.Quantity).IsRequired().HasDefaultValue(0);
            builder.Property(s => s.Tittle).IsRequired().HasMaxLength(55);
            builder.Property(s => s.ExpenseDate).IsRequired();
            builder.Property(w => w.CreateDate).HasDefaultValueSql("getdate()");
            builder.Property(w => w.LastUpdateDate).HasDefaultValueSql("getdate()");

            builder.HasOne(w => w.ExpenseType).WithMany(w => w.Expense).HasForeignKey(w => w.IdType).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
