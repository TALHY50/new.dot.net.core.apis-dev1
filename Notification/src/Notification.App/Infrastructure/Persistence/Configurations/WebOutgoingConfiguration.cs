using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SharedKernel.Main.Domain.Notification.Notifications.Outgoings;

namespace Notification.App.Infrastructure.Persistence.Configurations
{
    public class WebOutgoingConfiguration : IEntityTypeConfiguration<WebOutgoing>
    {
        public void Configure(EntityTypeBuilder<WebOutgoing> builder)
        {
            builder.ToTable("notification_web_outgoings");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)")
                .IsRequired();

            builder.Property(e => e.NotificationCredentialId)
                .HasColumnName("notification_credential_id")
                .HasColumnType("int(11)")
                .IsRequired();

            builder.Property(e => e.Subject)
                .HasColumnName("subject")
                .HasColumnType("varchar(255)")
                .HasDefaultValue(string.Empty)
                .HasComment("Title of the web notification");

            builder.Property(e => e.Content)
                .HasColumnName("content")
                .HasColumnType("longtext")
                .HasComment("payload of web notification");

            builder.Property(e => e.Host)
                .HasColumnName("host")
                .HasColumnType("varchar(255)")
                .IsRequired()
                .HasComment("url of the web notification host");

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("tinyint(4)")
                .IsRequired()
                .HasDefaultValue(0)
                .HasComment("0=pending, 1= completed, 2= failed ");

            builder.Property(e => e.Attempt)
                .HasColumnName("attempt")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.SentAt)
                .HasColumnName("sent_at")
                .HasColumnType("datetime");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.CompanyId)
                .HasColumnName("company_id")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.NotificationEventId)
                .HasColumnName("notification_event_id")
                .HasColumnType("int(11)")
                .IsRequired();

            builder.Property(e => e.NotificationEventName)
                .HasColumnName("notification_event_name")
                .HasColumnType("varchar(50)")
                .IsRequired();
        }
    }
}
