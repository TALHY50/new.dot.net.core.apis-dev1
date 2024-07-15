using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ACL.Application.Domain.Notifications;
using ACL.Application.Domain.Notifications.Events;
using ACL.Application.Domain.ValueObjects;

namespace ACL.Application.Infrastructure.Persistence.Configurations
{
    public class EventTemplateConfiguration : IEntityTypeConfiguration<EventTemplate>
    {
        public void Configure(EntityTypeBuilder<EventTemplate> builder)
        {
            builder.ToTable("notification_event_templates");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.NotificationEventId)
                .HasColumnName("notification_event_id")
                .HasColumnType("int(11)")
                .IsRequired();

            builder.Property(e => e.Subject)
                .HasColumnName("subject")
                .HasColumnType("varchar(255)")
                .IsRequired()
                .HasDefaultValue(string.Empty)
                .HasComment("Email subject or Web Title");

            builder.Property(e => e.Content)
                .HasColumnName("content")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(e => e.Path)
                .HasColumnName("path")
                .HasColumnType("varchar(255)");

            builder.Property(e => e.Type)
                .HasColumnName("type")
                .HasColumnType("tinyint(4)")
                .IsRequired()
                .HasConversion(
                    nt => nt.Type,
                    nt => NotificationType.From(nt))
                .HasComment("1=email, 2=sms, 3=web");

            builder.Property(e => e.Variables)
                .HasColumnName("variables")
                .HasColumnType("text")
                .HasComment("Must be set as comma(,) separator {{$var1}},{{$var2}}");

            builder.Property(e => e.CreatedById)
                .HasColumnName("created_by_id")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(e => e.UpdatedById)
                .HasColumnName("updated_by_id")
                .HasColumnType("int(11)")
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("tinyint(4)")
                .IsRequired()
                .HasDefaultValue(1)
                .HasComment("1= active, 0=inactive");

            builder.Property(e => e.Language)
                .HasColumnName("language")
                .HasColumnType("varchar(3)")
                .IsRequired()
                .HasDefaultValue("eng")
                .HasComment("3 digit iso code");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.CompanyId)
                .HasColumnName("company_id")
                .HasColumnType("int(11)")
                .IsRequired();
        }
    }
}
