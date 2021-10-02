using Entities.DbModels.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.DataAccess.Specifics.DBs.EF.ModelsConfig
{
    public class IngressTypeConfig : IEntityTypeConfiguration<IngressType>
    {
        public void Configure(EntityTypeBuilder<IngressType> builder)
        {
            builder.HasKey(w => w.IdType);
            builder.Property(w => w.IdType).ValueGeneratedNever();
            builder.Property(s => s.TypeName).IsRequired().HasMaxLength(55);
            builder.Property(w => w.CreateDate).HasDefaultValueSql("getdate()");
            builder.Property(w => w.LastUpdateDate).HasDefaultValueSql("getdate()");
        }

    
    }
}