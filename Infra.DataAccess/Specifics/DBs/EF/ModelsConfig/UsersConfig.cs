using Entities.DbModels.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.DataAccess.Specifics.DBs.EF.ModelsConfig
{
    public class UsersConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(s => s.IdUser);
            
            builder.Property(w => w.IdUser).ValueGeneratedNever();
            builder.Property(s => s.Email).IsRequired();
            builder.Property(s => s.Username).IsRequired();
            builder.Property(s => s.Password).IsRequired();
            builder.Property(s => s.BirthDate).IsRequired();
            builder.Property(w => w.CreateDate).HasDefaultValueSql("getdate()");
            builder.Property(w => w.LastUpdateDate).HasDefaultValueSql("getdate()");

            builder.HasAlternateKey(w =>  w.Email );
            builder.HasAlternateKey(w => w.Username);

            builder.HasMany(w => w.Ingress).WithOne(w => w.User).HasForeignKey(w => w.IdUser).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasMany(w => w.Expense).WithOne(w => w.User).HasForeignKey(w => w.IdUser).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasMany(w => w.IngressType).WithOne(w => w.User).HasForeignKey(w => w.IdUser).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasMany(w => w.ExpenseType).WithOne(w => w.User).HasForeignKey(w => w.IdUser).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
