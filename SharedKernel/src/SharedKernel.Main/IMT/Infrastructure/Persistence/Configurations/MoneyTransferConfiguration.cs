using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Main.IMT.Domain.Entities;

namespace SharedKernel.Main.Infrastructure.Persistence.IMT.Configurations
{
    public class MoneyTransferConfiguration : IEntityTypeConfiguration<MoneyTransfer>
    {
        public void Configure(EntityTypeBuilder<MoneyTransfer> builder)
        {
            builder.ToTable("imt_money_transfers");

            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();  // For AUTO_INCREMENT

            builder.Property(e => e.QuotationId)
                .HasColumnName("quotation_id")
                .IsRequired();

            builder.Property(e => e.InstitutionId)
                .HasColumnName("institution_id");

            builder.Property(e => e.InvoiceId)
                .HasColumnName("invoice_id")
                .HasMaxLength(50);

            builder.Property(e => e.OrderId)
                .HasColumnName("order_id")
                .HasMaxLength(50);

            builder.Property(e => e.PaymentId)
                .HasColumnName("payment_id")
                .HasMaxLength(50)
                .IsUnicode(false); // UTF8 collation

            builder.Property(e => e.RemoteOrderId)
                .HasColumnName("remote_order_id")
                .HasMaxLength(50)
                .HasComment("Transaction id by providers");

            builder.Property(e => e.Mode)
                .HasColumnName("mode")
                .HasColumnType("tinyint");

            builder.Property(e => e.RequestAmount)
                .HasColumnName("request_amount")
                .HasColumnType("decimal(12,4)");

            builder.Property(e => e.CurrencyId)
                .HasColumnName("currency_id");

            builder.Property(e => e.MttId)
                .HasColumnName("mtt_id");

            builder.Property(e => e.ExchangeRate)
                .HasColumnName("exchange_rate")
                .HasColumnType("decimal(12,9)");

            builder.Property(e => e.Commission)
                .HasColumnName("commission")
                .HasColumnType("decimal(12,9)");

            builder.Property(e => e.Cot)
                .HasColumnName("cot")
                .HasColumnType("decimal(12,9)");

            builder.Property(e => e.Tax)
                .HasColumnName("tax")
                .HasColumnType("decimal(12,9)");

            builder.Property(e => e.MarkUp)
                .HasColumnName("mark_up")
                .HasColumnType("decimal(12,9)");

            builder.Property(e => e.MarkUpPercentage)
                .HasColumnName("mark_up_percentage")
                .HasColumnType("decimal(12,9)");

            builder.Property(e => e.MarkUpFixed)
                .HasColumnName("mark_up_fixed")
                .HasColumnType("decimal(12,9)");

            builder.Property(e => e.SendAmount)
                .HasColumnName("send_amount")
                .HasColumnType("decimal(12,9)");

            builder.Property(e => e.TransactionStateId)
                .HasColumnName("transaction_state_id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");
        }
    }
}
