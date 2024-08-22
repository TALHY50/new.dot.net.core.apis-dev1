using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Main.Domain.Notification.Notifications.Events;
using SharedKernel.Main.Domain.Notification.ValueObjects;

namespace SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations
{
    public class EventTemplateConfiguration : IEntityTypeConfiguration<EventTemplate>
    {
        public void Configure(EntityTypeBuilder<EventTemplate> builder)
        {
            builder.ToTable("notification_event_templates");

            builder.HasKey(e => e.Id);

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.Id), "id")
                .HasColumnType("int(11)")
                .IsRequired()
                .ValueGeneratedOnAdd();

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.NotificationEventId), "notification_event_id")
                .HasColumnType("int(11)")
                .IsRequired();

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(e => e.Subject), "subject")
                .HasColumnType("varchar(255)")
                .IsRequired()
                .HasDefaultValue(string.Empty)
                .HasComment("Email subject or Web Title");

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(e => e.Content), "content")
                .HasColumnType("text")
                .IsRequired();

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(e => e.Path), "path")
                .HasColumnType("varchar(255)");

            RelationalPropertyBuilderExtensions
                .HasColumnName<NotificationType>(builder.Property(e => e.Type), "type")
                .HasColumnType("tinyint(4)")
                .IsRequired()
                .HasConversion(
                    nt => nt.Type,
                    nt => NotificationType.From(nt))
                .HasComment("1=email, 2=sms, 3=web");

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(e => e.Variables), "variables")
                .HasColumnType("text")
                .HasComment("Must be set as comma(,) separator {{$var1}},{{$var2}}");

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.CreatedById), "created_by_id")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(1);

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.UpdatedById), "updated_by_id")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(1);

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.Status), "status")
                .HasColumnType("tinyint(4)")
                .IsRequired()
                .HasDefaultValue(0)
                .HasComment("1= active, 0=inactive");

            RelationalPropertyBuilderExtensions
                .HasColumnName<string>(builder.Property(e => e.Language), "language")
                .HasColumnType("varchar(3)")
                .IsRequired()
                .HasDefaultValue("eng")
                .HasComment("3 digit iso code");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(e => e.CreatedAt), "created_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(e => e.UpdatedAt), "updated_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(e => e.CompanyId), "company_id")
                .HasColumnType("int(11)")
                .IsRequired();
        }
    }
}
