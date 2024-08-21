using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Main.Domain.IMT;

namespace SharedKernel.Main.Infrastructure.Persistence.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("imt_currencies");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)")
                .IsRequired();

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasColumnType("varchar(10)");

            builder.Property(e => e.IsoCode)
                .HasColumnName("iso_code")
                .HasColumnType("varchar(10)");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Symbol)
                .HasColumnName("symbol")
                .HasColumnType("varchar(50)");

            builder.Property(e => e.CreatedById)
                .HasColumnName("created_by_id")
                .HasColumnType("int(11)");

            builder.Property(e => e.UpdatedById)
                .HasColumnName("updated_by_id")
                .HasColumnType("int(11)");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");
        }
    }
}
