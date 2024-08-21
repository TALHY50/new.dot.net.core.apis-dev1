using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Main.Domain.IMT;

namespace SharedKernel.Main.Infrastructure.Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("country");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)")
                .IsRequired();

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasColumnType("varchar(100)")
                .HasDefaultValue(string.Empty)
                .HasComment("Country Code");

            builder.Property(e => e.IsoCode)
                .HasColumnName("iso_code")
                .HasColumnType("varchar(100)")
                .HasDefaultValue(string.Empty)
                .HasComment("Country ISO Code");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100")
                .HasDefaultValue(string.Empty)
                .HasComment("name of the country");

            builder.Property(e => e.CreatedById)
                .HasColumnName("created_by_id")
                .HasColumnType("int(11)")
                .HasDefaultValue(null)
                .HasComment("Created By Id");
            
            builder.Property(e => e.UpdatedById)
                .HasColumnName("updated_by_id")
                .HasColumnType("int(11)")
                .HasDefaultValue(null)
                .HasComment("Updated By Id");

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("tinyint(4)")
                .HasDefaultValue(1)
                .HasComment("0=inactive, 1= active, 2= soft-deleted "); //1=active, 0=inactive, 2=soft-deleted

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");
        }
    }
}
