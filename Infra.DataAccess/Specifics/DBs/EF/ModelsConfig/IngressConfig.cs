using Entities.DbModels.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.DataAccess.Specifics.DBs.EF.ModelsConfig
{
    public class IngressConfig : IEntityTypeConfiguration<Ingress>
    {
        public void Configure(EntityTypeBuilder<Ingress> builder)
        {
            builder.HasKey(w => w.IdIngress);
            builder.Property(w => w.IdIngress).ValueGeneratedNever();
            builder.Property(s => s.Quantity).IsRequired().HasDefaultValue(0);
            builder.Property(s => s.Tittle).IsRequired().HasMaxLength(55);
            builder.Property(s => s.IngressDate).IsRequired();
            builder.Property(w => w.CreateDate).HasDefaultValueSql("getdate()");
            builder.Property(w => w.LastUpdateDate).HasDefaultValueSql("getdate()");

            builder.HasOne(w => w.IngressType).WithMany(w => w.Ingress).HasForeignKey(w => w.IdType).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
