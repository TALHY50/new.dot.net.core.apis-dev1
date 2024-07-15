using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ACL.Application.Domain.Notifications;
using ACL.Application.Domain.Notifications.Events;

namespace ACL.Application.Infrastructure.Persistence.Configurations
{
    public class SmsEventConfiguration : IEntityTypeConfiguration<SmsEvent>
    {
        public void Configure(EntityTypeBuilder<SmsEvent> builder)
        {
            builder.ToTable("notification_sms_events");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.NotificationEventId)
                .HasColumnName("notification_event_id")
                .HasColumnType("int(11)")
                .IsRequired();

            builder.Property(e => e.NotificationCredentialId)
                .HasColumnName("notification_credential_id")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.NotificationReceiverGroupId)
                .HasColumnName("notification_receiver_group_id")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .IsRequired()
                .HasComment("Deposit Approve, Deposit Reject etc");

            builder.Property(e => e.IsAllowFromApp)
                .HasColumnName("is_allow_from_app")
                .HasColumnType("tinyint(1)")
                .IsRequired()
                .HasDefaultValue(true)
                .HasComment("1= allows manual receivers, 0= does not allow manual receivers");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");
        }
    }
}