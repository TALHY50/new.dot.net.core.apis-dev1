using IMT.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMT.App.Infrastructure.Persistence.Configurations
{
  public class ImtQuotationInfoConfiguration : IEntityTypeConfiguration<QuotationInfo>
{
    public void Configure(EntityTypeBuilder<QuotationInfo> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("imt_quotation_info", tb => tb.HasComment("Table for storing IMT quotation information"));

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .IsRequired();

        //builder.Property(e => e.Amount)
        //    .HasColumnType("decimal(16,4)")
        //    .HasColumnName("amount");

        builder.Property(e => e.CurrencyId)
            .HasColumnName("currency_id")
            .HasDefaultValueSql("'0'");

        builder.Property(e => e.Commission)
            .HasColumnType("decimal(16,4)")
            .HasColumnName("commission");

        //builder.Property(e => e.CommissionFixed)
        //    .HasColumnType("decimal(16,4)")
        //    .HasColumnName("commision_fixed");

        builder.Property(e => e.CommissionPercentage)
            .HasColumnType("decimal(16,4)")
            .HasColumnName("commission_percentage");

        builder.Property(e => e.Cot)
            .HasColumnType("decimal(16,4)")
            .HasColumnName("cot");

        builder.Property(e => e.CotPercentage)
            .HasColumnType("decimal(16,4)")
            .HasColumnName("cot_percentage");

        builder.Property(e => e.CotFixed)
            .HasColumnType("decimal(16,4)")
            .HasColumnName("cot_fixed");

        builder.Property(e => e.MarkUp)
            .HasColumnType("decimal(16,4)")
            .HasColumnName("mark_up");

        builder.Property(e => e.MarkUpPercentage)
            .HasColumnType("decimal(16,4)")
            .HasColumnName("mark_up_percentage");

        builder.Property(e => e.MarkUpFixed)
            .HasColumnType("decimal(16,4)")
            .HasColumnName("mark_up_fixed");

        builder.Property(e => e.Tax)
            .HasColumnType("decimal(16,4)")
            .HasColumnName("tax");

        builder.Property(e => e.TaxPercentage)
            .HasColumnType("decimal(16,4)")
            .HasColumnName("tax_percentage");

        builder.Property(e => e.TaxFixed)
            .HasColumnType("decimal(16,4)")
            .HasColumnName("tax_fixed");

        builder.Property(e => e.SentAmount)
            .HasColumnType("decimal(16,4)")
            .HasColumnName("sent_amount");

        builder.Property(e => e.CreatedAt)
            .HasColumnType("datetime")
            .HasColumnName("created_at");

        builder.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("updated_at");
    }
}
}
