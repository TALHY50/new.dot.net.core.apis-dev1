using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SharedKernel.Main.Domain.Setups;

namespace SharedKernel.Main.Infrastructure.Persistence.Configurations
{
    public class VariableConfiguration : IEntityTypeConfiguration<Variable>
    {
        public void Configure(EntityTypeBuilder<Variable> builder)
        {
            builder.ToTable("variables");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("bigint(20) unsigned");

            builder.Property(v => v.VariableName)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue(string.Empty)
                .HasColumnType("varchar(50)")
                .HasComment("variable must be placed with comma separator");

            builder.Property(v => v.CreatedById)
                .IsRequired()
                .HasColumnType("int(11)")
                .HasDefaultValue(0)
                .HasComment("User Id of the person who created the event");

            builder.Property(v => v.UpdatedById)
                .IsRequired()
                .HasColumnType("int(11)")
                .HasDefaultValue(0)
                .HasComment("User Id of the person who updated the event for the last time");

            builder.Property(v => v.Status)
                .IsRequired()
                .HasColumnType("tinyint(4)")
                .HasDefaultValue(1)
                .HasComment("1=active, 0=inactive");

            builder.Property(v => v.CreatedAt)
                .HasColumnType("datetime");

            builder.Property(v => v.UpdatedAt)
                .HasColumnType("datetime");

            builder.HasIndex(v => v.VariableName)
                .IsUnique();
        }
    }
}