using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Main.Domain.Notification.Notifications.Outgoings;

namespace SharedKernel.Main.Infrastructure.Persistence.Configurations
{
    public class WebOutgoingConfiguration : IEntityTypeConfiguration<WebOutgoing>
    {
        public void Configure(EntityTypeBuilder<WebOutgoing> builder)
        {
            builder.ToTable("notification_web_outgoings");

            builder.HasKey(e => e.Id);

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.Id), "id")
                .HasColumnType("int(11)")
                .IsRequired();

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.NotificationCredentialId), "notification_credential_id")
                .HasColumnType("int(11)")
                .IsRequired();

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(e => e.Subject), "subject")
                .HasColumnType("varchar(255)")
                .HasDefaultValue(string.Empty)
                .HasComment("Title of the web notification");

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(e => e.Content), "content")
                .HasColumnType("longtext")
                .HasComment("payload of web notification");

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(e => e.Host), "host")
                .HasColumnType("varchar(255)")
                .IsRequired()
                .HasComment("url of the web notification host");

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.Status), "status")
                .HasColumnType("tinyint(4)")
                .IsRequired()
                .HasDefaultValue(0)
                .HasComment("0=pending, 1= completed, 2= failed ");

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.Attempt), "attempt")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(0);

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(e => e.SentAt), "sent_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(e => e.CreatedAt), "created_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(e => e.UpdatedAt), "updated_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.CompanyId), "company_id")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(0);

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.NotificationEventId), "notification_event_id")
                .HasColumnType("int(11)")
                .IsRequired();

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(e => e.NotificationEventName), "notification_event_name")
                .HasColumnType("varchar(50)")
                .IsRequired();
        }
    }
}
