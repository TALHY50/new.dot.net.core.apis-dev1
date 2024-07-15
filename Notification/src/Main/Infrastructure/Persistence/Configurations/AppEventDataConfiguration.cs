using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Notification.Application.Domain.Notifications;
using Notification.Application.Domain.Notifications.Events;

namespace Notification.Application.Infrastructure.Persistence.Configurations
{
    public class AppEventDataConfiguration : IEntityTypeConfiguration<AppEventData>
    {
        public void Configure(EntityTypeBuilder<AppEventData> builder)
        {
            builder.ToTable("notification_app_event_data");

            builder.HasKey(an => an.Id);

            builder.Property(an => an.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)");

            builder.Property(an => an.NotificationEventId)
                .IsRequired()
                .HasColumnName("notification_event_id")
                .HasColumnType("int(11)")
                .HasDefaultValue(0);

            builder.Property(an => an.ReferenceUniqueId)
                .HasMaxLength(100)
                .HasColumnName("reference_unique_id")
                .HasColumnType("varchar(100)");

            builder.Property(an => an.Data)
                .HasColumnType("text")
                .HasColumnName("data")
                .HasDefaultValue(null);

            builder.Property(an => an.AttachmentInfo)
                .HasMaxLength(100)
                .HasColumnName("attachment_info")
                .HasColumnType("varchar(100)")
                .HasComment("Attachment info for template");

            builder.Property(an => an.Receivers)
                .HasColumnType("text")
                .HasColumnName("receivers")
                .HasDefaultValue(null);

            builder.Property(an => an.Url)
                .HasMaxLength(255)
                .HasColumnName("url")
                .HasColumnType("varchar(255)")
                .HasDefaultValue(null);

            builder.Property(an => an.Path)
                .HasMaxLength(255)
                .HasColumnName("path")
                .HasColumnType("varchar(255)")
                .HasDefaultValue(null);

            builder.Property(an => an.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(an => an.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");
        }
    }
}
