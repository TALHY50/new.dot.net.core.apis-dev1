using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedBusiness.Main.IMT.Domain.Entities;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Configurations
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
