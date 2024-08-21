using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Main.Domain.IMT;

namespace SharedKernel.Main.Infrastructure.Persistence.Configurations
{
    public class RegionsConfiguration : IEntityTypeConfiguration<Regions>
    {
        public void Configure(EntityTypeBuilder<Regions> builder)
        {
            builder.ToTable("imt_regions");

            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(10)")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)")
                .HasComment("Example : EuroZone, Asia Pacific");

            builder.Property(e => e.CompanyId)
                .HasColumnName("company_id")
                .HasDefaultValue(0)
                .HasColumnType("int(10)");

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("tinyint(3)")
                .HasDefaultValue(1)
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected")
                .IsRequired();

            builder.Property(e => e.CreatedById)
                .HasColumnName("created_by_id")
                .HasColumnType("int(10)");

            builder.Property(e => e.UpdatedById)
                .HasColumnName("updated_by_id")
                .HasColumnType("int(10)");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");


        }
    }
}
