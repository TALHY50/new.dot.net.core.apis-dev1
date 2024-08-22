using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Main.Domain.Notification.Notifications.Events;

namespace SharedKernel.Main.Infrastructure.Persistence.Configurations
{
    public class SmsEventConfiguration : IEntityTypeConfiguration<SmsEvent>
    {
        public void Configure(EntityTypeBuilder<SmsEvent> builder)
        {
            builder.ToTable("notification_sms_events");

            builder.HasKey(e => e.Id);

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.Id), "id")
                .HasColumnType("int(11)")
                .IsRequired()
                .ValueGeneratedOnAdd();

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.NotificationEventId), "notification_event_id")
                .HasColumnType("int(11)")
                .IsRequired();

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.NotificationCredentialId), "notification_credential_id")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(0);

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.NotificationReceiverGroupId), "notification_receiver_group_id")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(0);

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(e => e.Name), "name")
                .HasColumnType("varchar(100)")
                .IsRequired()
                .HasComment("Deposit Approve, Deposit Reject etc");

            RelationalPropertyBuilderExtensions
                .HasColumnName<bool>(builder.Property(e => e.IsAllowFromApp), "is_allow_from_app")
                .HasColumnType("tinyint(1)")
                .IsRequired()
                .HasDefaultValue(true)
                .HasComment("1= allows manual receivers, 0= does not allow manual receivers");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(e => e.CreatedAt), "created_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(e => e.UpdatedAt), "updated_at")
                .HasColumnType("datetime");
        }
    }
}