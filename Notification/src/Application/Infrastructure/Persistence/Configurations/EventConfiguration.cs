using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.Application.Domain.Notifications;

namespace Notification.Application.Infrastructure.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("events");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)");

            builder.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("0")
                .HasColumnType("varchar(50)");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.IsEmail)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnType("tinyint(1)")
                .HasComment("true=notification is enabled for email");

            builder.Property(e => e.IsSms)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnType("tinyint(1)")
                .HasComment("true=notification is enabled for sms");

            builder.Property(e => e.IsWeb)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnType("tinyint(1)")
                .HasComment("true=notification is enabled for webhook");

            builder.Property(e => e.IsAllowFromApp)
                .IsRequired()
                .HasDefaultValue(true)
                .HasColumnType("tinyint(1)")
                .HasComment("1= allows manual receivers, 0= does not allow manual receivers");

            builder.Property(e => e.CreatedById)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int(11)")
                .HasComment("The person who created the event");

            builder.Property(e => e.UpdatedById)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int(11)")
                .HasComment("The person who updated the event last time");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValue(1)
                .HasColumnType("tinyint(4)")
                .HasComment("1=active, 0=inactive");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("datetime");
        }
    }
}
