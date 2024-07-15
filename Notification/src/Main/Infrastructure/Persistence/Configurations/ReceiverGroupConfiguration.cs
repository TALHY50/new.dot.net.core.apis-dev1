using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.Application.Domain.Setups;
using Notification.Application.Domain.ValueObjects;

namespace Notification.Application.Infrastructure.Persistence.Configurations
{
    public class ReceiverGroupConfiguration : IEntityTypeConfiguration<ReceiverGroup>
    {
        public void Configure(EntityTypeBuilder<ReceiverGroup> builder)
        {
            builder.ToTable("notification_receiver_groups");

            builder.HasKey(rg => rg.Id);

            builder.Property(rg => rg.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)");

            builder.Property(rg => rg.Type)
                .IsRequired()
                .HasColumnType("tinyint(4)")
                .HasConversion(
                    nt => nt.Type,
                    nt => NotificationType.From(nt))
                .HasComment("1=mail, 2= sms, 3 = web");

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
                .HasColumnName("cc_emails")
                .HasComment("must be separated by comma(,)");

            builder.Property(rg => rg.BccEmails)
                .HasColumnType("text")
                .HasColumnName("bcc_emails")
                .HasComment("must be separated by comma(,)");

            builder.Property(rg => rg.CreatedById)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName("created_by_id")
                .HasColumnType("int(11)");

            builder.Property(rg => rg.UpdatedById)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName("updated_by_id")
                .HasColumnType("int(11)");

            builder.Property(rg => rg.Status)
                .IsRequired()
                .HasDefaultValue(1)
                .HasColumnType("tinyint(4)")
                .HasComment("1= active, 0= inactive");

            builder.Property(rg => rg.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(rg => rg.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(rg => rg.CompanyId)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName("company_id")
                .HasColumnType("int(11)");
        }
    }
}
