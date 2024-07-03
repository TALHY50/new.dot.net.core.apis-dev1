using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.Application.Domain.Events;

namespace Notification.Application.Infrastructure.Persistence.Configurations
{
    public class NotificationEmailEventConfiguration : IEntityTypeConfiguration<EmailEvent>
    {
        public void Configure(EntityTypeBuilder<EmailEvent> builder)
        {
            builder.ToTable("notification_email_events");

            builder.HasKey(nee => nee.Id);

            builder.Property(nee => nee.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11) unsigned");

            builder.Property(nee => nee.NotificationEventId)
                .IsRequired()
                .HasColumnType("int(11)");

            builder.Property(nee => nee.NotificationCredentialId)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int(11)");

            builder.Property(nee => nee.NotificationReceiverGroupId)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int(11)");

            builder.Property(nee => nee.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .HasComment("Deposit Approve, Deposit Reject etc");

            builder.Property(nee => nee.IsAllowFromApp)
                .IsRequired()
                .HasDefaultValue(true)
                .HasColumnType("tinyint(1)")
                .HasComment("1= allows manual receivers, 0= does not allow manual receivers");

            builder.Property(nee => nee.IsAllowCc)
                .IsRequired()
                .HasDefaultValue(true)
                .HasColumnType("tinyint(1)")
                .HasComment("notification_receivers_groups cc can be on/off from here");

            builder.Property(nee => nee.IsAllowBcc)
                .IsRequired()
                .HasDefaultValue(true)
                .HasColumnType("tinyint(1)")
                .HasComment("notification_receivers_groups bcc can be on/off from here");

            builder.Property(nee => nee.CreatedAt)
                .HasColumnType("datetime");

            builder.Property(nee => nee.UpdatedAt)
                .HasColumnType("datetime");
        }
    }
}
