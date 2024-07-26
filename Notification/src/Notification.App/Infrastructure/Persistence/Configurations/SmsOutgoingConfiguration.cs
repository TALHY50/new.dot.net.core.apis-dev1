using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Notification.App.Domain.Notifications.Outgoings;

namespace Notification.App.Infrastructure.Persistence.Configurations
{
    public class SmsOutgoingConfiguration : IEntityTypeConfiguration<SmsOutgoing>
    {
        public void Configure(EntityTypeBuilder<SmsOutgoing> builder)
        {
            builder.ToTable("notification_sms_outgoings");

            builder.HasKey(so => so.Id);

            builder.Property(so => so.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)");

            builder.Property(so => so.NotificationCredentialId)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName("notification_credential_id")
                .HasColumnType("int(11)");

            builder.Property(so => so.Content)
                .IsRequired()
                .HasColumnType("longtext")
                .HasComment("full sms content");

            builder.Property(so => so.To)
                .IsRequired()
                .HasColumnType("mediumtext")
                .HasComment("phone number must be set as comma(,) separator");

            builder.Property(so => so.Status)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("tinyint(4)")
                .HasComment("0=pending, 1= completed, 2= failed");

            builder.Property(so => so.Attempt)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int(11)");

            builder.Property(so => so.SentAt)
                .HasColumnType("datetime")
                .HasColumnName("sent_at")
                .HasComment("The moment when sms sent successfully");

            builder.Property(so => so.NotificationEventId)
                .IsRequired()
                .HasColumnName("notification_event_id")
                .HasColumnType("int(11)");

            builder.Property(so => so.NotificationEventName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("notification_event_name")
                .HasColumnType("varchar(50)");

            builder.Property(so => so.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(so => so.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(so => so.CompanyId)
                .IsRequired()
                .HasColumnType("int(11)")
                .HasColumnName("company_id")
                .HasDefaultValue(0);
        }
    }
}
