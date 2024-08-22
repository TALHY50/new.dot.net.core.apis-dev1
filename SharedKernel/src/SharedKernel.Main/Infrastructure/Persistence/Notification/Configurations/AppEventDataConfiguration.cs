using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Main.Domain.Notification.Notifications.Events;

namespace SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations
{
    public class AppEventDataConfiguration : IEntityTypeConfiguration<AppEventData>
    {
        public void Configure(EntityTypeBuilder<AppEventData> builder)
        {
            builder.ToTable("notification_app_event_data");

            builder.HasKey(an => an.Id);

            RelationalPropertyBuilderExtensions
                .HasColumnType<int>(builder.Property(an => an.Id)
                    .ValueGeneratedOnAdd(), "int(11)");

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(an => an.NotificationEventId)
                    .IsRequired(), "notification_event_id")
                .HasColumnType("int(11)")
                .HasDefaultValue(0);

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(an => an.ReferenceUniqueId)
                    .HasMaxLength(100), "reference_unique_id")
                .HasColumnType("varchar(100)");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(an => an.Data), "text")
                .HasColumnName("data")
                .HasDefaultValue(null);

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(an => an.AttachmentInfo)
                    .HasMaxLength(100), "attachment_info")
                .HasColumnType("varchar(100)")
                .HasComment("Attachment info for template");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(an => an.Receivers), "text")
                .HasColumnName("receivers")
                .HasDefaultValue(null);

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(an => an.Url)
                    .HasMaxLength(255), "url")
                .HasColumnType("varchar(255)")
                .HasDefaultValue(null);

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(an => an.Path)
                    .HasMaxLength(255), "path")
                .HasColumnType("varchar(255)")
                .HasDefaultValue(null);

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(an => an.CreatedAt), "created_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(an => an.UpdatedAt), "updated_at")
                .HasColumnType("datetime");
        }
    }
}
