using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ACL.Application.Domain.Notifications;
using ACL.Application.Domain.Notifications.Outgoings;

namespace ACL.Application.Infrastructure.Persistence.Configurations;

 public class EmailOutgoingConfiguration : IEntityTypeConfiguration<EmailOutgoing>
    {
        public void Configure(EntityTypeBuilder<EmailOutgoing> builder)
        {
            builder.ToTable("notification_email_outgoings");

            builder.HasKey(neo => neo.Id);

            builder.Property(neo => neo.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)");

            builder.Property(neo => neo.NotificationCredentialId)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName("notification_credential_id")
                .HasColumnType("int(11)");

            builder.Property(neo => neo.Subject)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValue("0")
                .HasColumnType("varchar(255)")
                .HasComment("Subject of the email");

            builder.Property(neo => neo.Content)
                .IsRequired()
                .HasColumnType("longtext")
                .HasComment("full email body content with html");

            builder.Property(neo => neo.To)
                .IsRequired()
                .HasColumnType("mediumtext")
                .HasComment("email must be separated by comma(,)");

            builder.Property(neo => neo.Cc)
                .HasColumnType("mediumtext")
                .HasComment("email must be separated by comma(,)");

            builder.Property(neo => neo.Bcc)
                .HasColumnType("mediumtext")
                .HasComment("email must be separated by comma(,)");

            builder.Property(neo => neo.IsAttachment)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnType("tinyint(1)")
                .HasColumnName("is_attachment")
                .HasComment("0=no attachment, 1=has attachment");

            builder.Property(neo => neo.AttachmentDetails)
                .HasColumnType("mediumtext")
                .HasColumnName("attachment_details")
                .HasComment("Attachment file path must be kept by comma(,) separator");

            builder.Property(neo => neo.Status)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("tinyint(4)")
                .HasComment("0=pending, 1= completed, 2= failed");

            builder.Property(neo => neo.Attempt)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int(11)");

            builder.Property(neo => neo.SentAt)
                .HasColumnName("sent_at")
                .HasColumnType("datetime");

            builder.Property(neo => neo.NotificationEventId)
                .IsRequired()
                .HasColumnName("notification_event_id")
                .HasColumnType("int(11)");

            builder.Property(neo => neo.NotificationEventName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("notification_event_name")
                .HasColumnType("varchar(50)");

            builder.Property(neo => neo.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(neo => neo.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(neo => neo.CompanyId)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName("company_id")
                .HasColumnType("int(11)");
        }
    }
