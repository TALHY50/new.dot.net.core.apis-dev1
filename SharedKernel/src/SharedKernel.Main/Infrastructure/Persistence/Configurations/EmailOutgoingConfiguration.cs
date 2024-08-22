using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Main.Domain.Notification.Notifications.Outgoings;

namespace SharedKernel.Main.Infrastructure.Persistence.Configurations;

 public class EmailOutgoingConfiguration : IEntityTypeConfiguration<EmailOutgoing>
    {
        public void Configure(EntityTypeBuilder<EmailOutgoing> builder)
        {
            builder.ToTable("notification_email_outgoings");

            builder.HasKey(neo => neo.Id);

            RelationalPropertyBuilderExtensions
                .HasColumnType<int>(builder.Property(neo => neo.Id)
                    .ValueGeneratedOnAdd(), "int(11)");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<int>(builder.Property(neo => neo.NotificationCredentialId)
                    .IsRequired(), 0)
                .HasColumnName("notification_credential_id")
                .HasColumnType("int(11)");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<string>(builder.Property(neo => neo.Subject)
                    .IsRequired()
                    .HasMaxLength(255), "0")
                .HasColumnType("varchar(255)")
                .HasComment("Subject of the email");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(neo => neo.Content)
                    .IsRequired(), "longtext")
                .HasComment("full email body content with html");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(neo => neo.To)
                    .IsRequired(), "mediumtext")
                .HasComment("email must be separated by comma(,)");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(neo => neo.Cc), "mediumtext")
                .HasComment("email must be separated by comma(,)");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(neo => neo.Bcc), "mediumtext")
                .HasComment("email must be separated by comma(,)");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<bool>(builder.Property(neo => neo.IsAttachment)
                    .IsRequired(), false)
                .HasColumnType("tinyint(1)")
                .HasColumnName("is_attachment")
                .HasComment("0=no attachment, 1=has attachment");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(neo => neo.AttachmentDetails), "mediumtext")
                .HasColumnName("attachment_details")
                .HasComment("Attachment file path must be kept by comma(,) separator");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<int>(builder.Property(neo => neo.Status)
                    .IsRequired(), 0)
                .HasColumnType("tinyint(4)")
                .HasComment("0=pending, 1= completed, 2= failed");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<int>(builder.Property(neo => neo.Attempt)
                    .IsRequired(), 0)
                .HasColumnType("int(11)");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(neo => neo.SentAt), "sent_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(neo => neo.NotificationEventId)
                    .IsRequired(), "notification_event_id")
                .HasColumnType("int(11)");

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(neo => neo.NotificationEventName)
                    .IsRequired()
                    .HasMaxLength(50), "notification_event_name")
                .HasColumnType("varchar(50)");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(neo => neo.CreatedAt), "created_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(neo => neo.UpdatedAt), "updated_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<int>(builder.Property(neo => neo.CompanyId)
                    .IsRequired(), 0)
                .HasColumnName("company_id")
                .HasColumnType("int(11)");
        }
    }
