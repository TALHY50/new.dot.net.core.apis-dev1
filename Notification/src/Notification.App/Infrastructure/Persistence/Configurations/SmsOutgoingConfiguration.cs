using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Notification.App.Domain.Entities.Outgoings;

namespace Notification.App.Infrastructure.Persistence.Configurations
{
    public class SmsOutgoingConfiguration : IEntityTypeConfiguration<SmsOutgoing>
    {
        public void Configure(EntityTypeBuilder<SmsOutgoing> builder)
        {
            builder.ToTable("notification_sms_outgoings");

            builder.HasKey(so => so.Id);

            RelationalPropertyBuilderExtensions
                .HasColumnType<int>(builder.Property(so => so.Id).ValueGeneratedOnAdd(), "int(11)");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<int>(builder.Property(so => so.NotificationCredentialId).IsRequired(), 0)
                .HasColumnName("notification_credential_id")
                .HasColumnType("int(11)");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(so => so.Content).IsRequired(), "longtext")
                .HasComment("full sms content");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(so => so.To).IsRequired(), "mediumtext")
                .HasComment("phone number must be set as comma(,) separator");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<int>(builder.Property(so => so.Status).IsRequired(), 0)
                .HasColumnType("tinyint(4)")
                .HasComment("0=pending, 1= completed, 2= failed");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<int>(builder.Property(so => so.Attempt).IsRequired(), 0)
                .HasColumnType("int(11)");

            RelationalPropertyBuilderExtensions
                .HasColumnType<DateTime?>(builder.Property(so => so.SentAt), "datetime")
                .HasColumnName("sent_at")
                .HasComment("The moment when sms sent successfully");

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(so => so.NotificationEventId).IsRequired(), "notification_event_id")
                .HasColumnType("int(11)");

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(so => so.NotificationEventName).IsRequired().HasMaxLength(50), "notification_event_name")
                .HasColumnType("varchar(50)");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(so => so.CreatedAt), "created_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(so => so.UpdatedAt), "updated_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnType<int>(builder.Property(so => so.CompanyId).IsRequired(), "int(11)")
                .HasColumnName("company_id")
                .HasDefaultValue(0);
        }
    }
}
