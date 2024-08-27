using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Main.Notification.Domain.Entities.Setups;

namespace SharedKernel.Main.Notification.Infrastructure.Persistence.Configurations
{
    public class LayoutConfiguration : IEntityTypeConfiguration<Layout>
    {
        public void Configure(EntityTypeBuilder<Layout> builder)
        {
            builder.ToTable("layouts");

            builder.HasKey(l => l.Id);

            RelationalPropertyBuilderExtensions
                .HasColumnType<long>(builder.Property(l => l.Id)
                    .ValueGeneratedOnAdd(), "bigint(20) unsigned");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(l => l.Name)
                    .IsRequired()
                    .HasMaxLength(50), "varchar(50)");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(l => l.Content)
                    .IsRequired(), "text")
                .HasComment("content must contain a variable name {{$template}} . one and only once");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<string>(builder.Property(l => l.FilePath)
                    .IsRequired()
                    .HasMaxLength(255), string.Empty)
                .HasColumnType("varchar(255)");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<bool>(builder.Property(l => l.IsDefault)
                    .IsRequired(), 0)
                .HasColumnType("tinyint(1)");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<int>(builder.Property(l => l.CreatedById)
                    .IsRequired(), 0)
                .HasColumnType("int(11)")
                .HasComment("The person who created the layout");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<int>(builder.Property(l => l.UpdatedById)
                    .IsRequired(), 0)
                .HasColumnType("int(11)")
                .HasComment("The person who updated the layout");

            RelationalPropertyBuilderExtensions
                .HasColumnType<DateTime?>(builder.Property(l => l.CreatedAt), "datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnType<DateTime?>(builder.Property(l => l.UpdatedAt), "datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnType<long>(builder.Property(l => l.CompanyId)
                    .IsRequired(), "bigint(20)");
        }
    }
}
