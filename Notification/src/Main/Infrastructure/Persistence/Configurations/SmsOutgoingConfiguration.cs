using ACL.Application.Domain.Notifications;
using ACL.Application.Domain.Notifications.Outgoings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ACL.Application.Infrastructure.Persistence.Configurations
{
    public class SmsOutgoingConfiguration : IEntityTypeConfiguration<SmsOutgoing>
    {
        public void Configure(EntityTypeBuilder<SmsOutgoing> builder)
        {
            builder.ToTable("sms_outgoings");

            builder.HasKey(so => so.Id);

            builder.Property(so => so.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)");

            builder.Property(so => so.NotificationCredentialId)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int(11)");

            builder.Property(so => so.Content)
                .IsRequired()
                .HasColumnType("longtext")
                .HasComment("full sms content");

            builder.Property(so => so.To)
                .IsRequired()
                .HasColumnType("mediumtext")
                .HasComment("phone number must be set as comma(,) separator");

            builder.Property(so => so.Status)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("tinyint(4)")
                .HasComment("0=pending, 1= completed, 2= failed");

            builder.Property(so => so.Attempt)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int(11)");

            builder.Property(so => so.SentAt)
                .HasColumnType("datetime")
                .HasComment("The moment when sms sent successfully");

            builder.Property(so => so.NotificationEventId)
                .IsRequired()
                .HasColumnType("int(11)");

            builder.Property(so => so.NotificationEventName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(so => so.CreatedAt)
                .HasColumnType("datetime");

            builder.Property(so => so.UpdatedAt)
                .HasColumnType("datetime");

            builder.Property(so => so.CompanyId)
                .IsRequired()
                .HasColumnType("int(11)")
                .HasDefaultValue(0);
        }
    }
}
