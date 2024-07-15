using ACL.Application.Domain.Notifications;
using ACL.Application.Domain.Notifications.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ACL.Application.Infrastructure.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("notification_events");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Category)
                .HasColumnName("category")
                .HasColumnType("varchar(50)")
                .IsRequired()
                .HasDefaultValue("0");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.IsEmail)
                .HasColumnName("is_email")
                .HasColumnType("tinyint(1)")
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("true=notification is enabled for email");

            builder.Property(e => e.IsSms)
                .HasColumnName("is_sms")
                .HasColumnType("tinyint(1)")
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("true=notification is enabled for sms");

            builder.Property(e => e.IsWeb)
                .HasColumnName("is_web")
                .HasColumnType("tinyint(1)")
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("true=notification is enabled for webhook");

            builder.Property(e => e.IsAllowFromApp)
                .HasColumnName("is_allow_from_app")
                .HasColumnType("tinyint(1)")
                .IsRequired()
                .HasDefaultValue(true)
                .HasComment("1= allows manual receivers, 0= does not allow manual receivers");

            builder.Property(e => e.CreatedById)
                .HasColumnName("created_by_id")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(0)
                .HasComment("The person who created the event");

            builder.Property(e => e.UpdatedById)
                .HasColumnName("updated_by_id")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(0)
                .HasComment("The person who updated the event last time");

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("tinyint(4)")
                .IsRequired()
                .HasComment("1=active, 0=inactive");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");
        }
    }
}
