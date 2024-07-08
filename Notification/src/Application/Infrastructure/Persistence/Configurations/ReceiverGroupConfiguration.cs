using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.Application.Domain.Setups;

namespace Notification.Application.Infrastructure.Persistence.Configurations
{
    public class ReceiverGroupConfiguration : IEntityTypeConfiguration<ReceiverGroup>
    {
        public void Configure(EntityTypeBuilder<ReceiverGroup> builder)
        {
            builder.ToTable("receiver_groups");

            builder.HasKey(rg => rg.Id);

            builder.Property(rg => rg.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)");

            builder.Property(rg => rg.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("0")
                .HasColumnType("varchar(50)");

            builder.Property(rg => rg.To)
                .HasColumnType("mediumtext")
                .HasComment("must be separated by comma(,)");

            builder.Property(rg => rg.CcEmails)
                .HasColumnType("text")
                .HasComment("must be separated by comma(,)");

            builder.Property(rg => rg.BccEmails)
                .HasColumnType("text")
                .HasComment("must be separated by comma(,)");

            builder.Property(rg => rg.CreatedById)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int(11)");

            builder.Property(rg => rg.UpdatedById)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int(11)");

            builder.Property(rg => rg.Status)
                .IsRequired()
                .HasDefaultValue(1)
                .HasColumnType("tinyint(4)")
                .HasComment("1= active, 0= inactive");

            builder.Property(rg => rg.CreatedAt)
                .HasColumnType("datetime");

            builder.Property(rg => rg.UpdatedAt)
                .HasColumnType("datetime");

            builder.Property(rg => rg.CompanyId)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int(11)");
        }
    }
}
