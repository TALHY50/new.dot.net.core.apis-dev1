using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.Application.Domain.Notifications;

namespace Notification.Application.Infrastructure.Persistence.Configurations
{
    public class SmsEventConfiguration : IEntityTypeConfiguration<SmsEvent>
    {
        public void Configure(EntityTypeBuilder<SmsEvent> builder)
        {
            builder.ToTable("sms_events");

            builder.HasKey(se => se.Id);

            builder.Property(se => se.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("bigint(20) unsigned");

            builder.Property(se => se.NotificationEventId)
                .IsRequired()
                .HasColumnType("int(11)");

            builder.Property(se => se.NotificationCredentialId)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int(11)");

            builder.Property(se => se.NotificationReceiverGroupId)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int(11)");

            builder.Property(se => se.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .HasComment("Deposit Approve, Deposit Reject etc");

            builder.Property(se => se.IsAllowFromApp)
                .IsRequired()
                .HasDefaultValue(1)
                .HasColumnType("tinyint(1)")
                .HasComment("1= allows manual receivers, 0= does not allow manual receivers");

            builder.Property(se => se.CreatedAt)
                .HasColumnType("datetime");

            builder.Property(se => se.UpdatedAt)
                .HasColumnType("datetime");
        }
    }
}