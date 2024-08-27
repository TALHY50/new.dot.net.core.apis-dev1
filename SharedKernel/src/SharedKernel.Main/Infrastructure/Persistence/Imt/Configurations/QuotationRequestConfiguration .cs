using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Domain.IMT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Main.Infrastructure.Persistence.IMT.Configurations
{
    public class ImtQuotationRequestConfiguration : IEntityTypeConfiguration<QuotationRequest>
    {
        public void Configure(EntityTypeBuilder<QuotationRequest> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("imt_quotation_requests", tb => tb.HasComment("Table for storing IMT quotation requests"));

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.Request)
                .HasColumnName("request")
                .HasColumnType("text")
                .IsUnicode(true);

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        }
    }
}
