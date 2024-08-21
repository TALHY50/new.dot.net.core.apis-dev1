using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Main.Domain.Notification.Setups;

namespace SharedKernel.Main.Infrastructure.Persistence.Configurations
{
    public class VariableConfiguration : IEntityTypeConfiguration<Variable>
    {
        public void Configure(EntityTypeBuilder<Variable> builder)
        {
            builder.ToTable("variables");

            builder.HasKey(v => v.Id);

            RelationalPropertyBuilderExtensions
                .HasColumnType<int>(builder.Property(v => v.Id)
                    .ValueGeneratedOnAdd(), "bigint(20) unsigned");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<string>(builder.Property(v => v.VariableName)
                    .IsRequired()
                    .HasMaxLength(50), string.Empty)
                .HasColumnType("varchar(50)")
                .HasComment("variable must be placed with comma separator");

            RelationalPropertyBuilderExtensions
                .HasColumnType<int>(builder.Property(v => v.CreatedById)
                    .IsRequired(), "int(11)")
                .HasDefaultValue(0)
                .HasComment("User Id of the person who created the event");

            RelationalPropertyBuilderExtensions
                .HasColumnType<int>(builder.Property(v => v.UpdatedById)
                    .IsRequired(), "int(11)")
                .HasDefaultValue(0)
                .HasComment("User Id of the person who updated the event for the last time");

            RelationalPropertyBuilderExtensions
                .HasColumnType<int>(builder.Property(v => v.Status)
                    .IsRequired(), "tinyint(4)")
                .HasDefaultValue(1)
                .HasComment("1=active, 0=inactive");

            RelationalPropertyBuilderExtensions
                .HasColumnType<DateTime?>(builder.Property(v => v.CreatedAt), "datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnType<DateTime?>(builder.Property(v => v.UpdatedAt), "datetime");

            builder.HasIndex(v => v.VariableName)
                .IsUnique();
        }
    }
}