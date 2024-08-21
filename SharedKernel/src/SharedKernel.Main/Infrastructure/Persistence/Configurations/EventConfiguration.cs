using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Main.Domain.Notification.Notifications.Events;

namespace SharedKernel.Main.Infrastructure.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("notification_events");

            builder.HasKey(e => e.Id);

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.Id), "id")
                .HasColumnType("int(11)")
                .IsRequired()
                .ValueGeneratedOnAdd();

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(e => e.Category), "category")
                .HasColumnType("varchar(50)")
                .IsRequired()
                .HasDefaultValue("0");

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(e => e.Name), "name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            RelationalPropertyBuilderExtensions
                .HasColumnName<bool>(builder.Property(e => e.IsEmail), "is_email")
                .HasColumnType("tinyint(1)")
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("true=notification is enabled for email");

            RelationalPropertyBuilderExtensions
                .HasColumnName<bool>(builder.Property(e => e.IsSms), "is_sms")
                .HasColumnType("tinyint(1)")
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("true=notification is enabled for sms");

            RelationalPropertyBuilderExtensions
                .HasColumnName<bool>(builder.Property(e => e.IsWeb), "is_web")
                .HasColumnType("tinyint(1)")
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("true=notification is enabled for webhook");

            RelationalPropertyBuilderExtensions
                .HasColumnName<bool>(builder.Property(e => e.IsAllowFromApp), "is_allow_from_app")
                .HasColumnType("tinyint(1)")
                .IsRequired()
                .HasDefaultValue(true)
                .HasComment("1= allows manual receivers, 0= does not allow manual receivers");

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.CreatedById), "created_by_id")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(0)
                .HasComment("The person who created the event");

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.UpdatedById), "updated_by_id")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(0)
                .HasComment("The person who updated the event last time");

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.Status), "status")
                .HasColumnType("tinyint(4)")
                .IsRequired()
                .HasComment("1=active, 0=inactive");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(e => e.CreatedAt), "created_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(e => e.UpdatedAt), "updated_at")
                .HasColumnType("datetime");
        }
    }
}
