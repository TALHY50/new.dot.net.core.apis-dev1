using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SharedKernel.Main.Domain.Notification.Setups;

namespace Notification.App.Infrastructure.Persistence.Configurations
{
    public class LayoutConfiguration : IEntityTypeConfiguration<Layout>
    {
        public void Configure(EntityTypeBuilder<Layout> builder)
        {
            builder.ToTable("layouts");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("bigint(20) unsigned");

            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(l => l.Content)
                .IsRequired()
                .HasColumnType("text")
                .HasComment("content must contain a variable name {{$template}} . one and only once");

            builder.Property(l => l.FilePath)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValue(string.Empty)
                .HasColumnType("varchar(255)");

            builder.Property(l => l.IsDefault)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("tinyint(1)");

            builder.Property(l => l.CreatedById)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int(11)")
                .HasComment("The person who created the layout");

            builder.Property(l => l.UpdatedById)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int(11)")
                .HasComment("The person who updated the layout");

            builder.Property(l => l.CreatedAt)
                .HasColumnType("datetime");

            builder.Property(l => l.UpdatedAt)
                .HasColumnType("datetime");

            builder.Property(l => l.CompanyId)
                .IsRequired()
                .HasColumnType("bigint(20)");
        }
    }
}
