using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.Application.Domain.Notifications;

namespace Notification.Application.Infrastructure.Persistence.Configurations
{
    public class EventTemplateConfiguration : IEntityTypeConfiguration<EventTemplate>
    {
        public void Configure(EntityTypeBuilder<EventTemplate> builder)
        {
            builder.ToTable("event_templates");

            builder.HasKey(et => et.Id);

            builder.Property(et => et.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11) unsigned");

            builder.Property(et => et.NotificationEventId)
                .IsRequired()
                .HasColumnType("int(11)");

            builder.Property(et => et.Subject)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValue(string.Empty)
                .HasColumnType("varchar(255)")
                .HasComment("Email subject or Web Title");

            builder.Property(et => et.Content)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(et => et.Path)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(et => et.Type)
                .IsRequired()
                .HasDefaultValue(1)
                .HasColumnType("tinyint(4)")
                .HasComment("1=email, 2=sms, 3=web");

            builder.Property(et => et.Variables)
                .HasColumnType("text")
                .HasComment("Must be set as comma(,) separator {{$var1}},{{$var2}}");

            builder.Property(et => et.CreatedById)
                .IsRequired()
                .HasDefaultValue(1)
                .HasColumnType("int(11)");

            builder.Property(et => et.UpdatedById)
                .IsRequired()
                .HasDefaultValue(1)
                .HasColumnType("int(11)");

            builder.Property(et => et.Status)
                .IsRequired()
                .HasDefaultValue(1)
                .HasColumnType("tinyint(4)")
                .HasComment("1= active, 0=inactive");

            builder.Property(et => et.Language)
                .IsRequired()
                .HasMaxLength(3)
                .HasDefaultValue("eng")
                .HasColumnType("varchar(3)")
                .HasComment("3 digit iso code");

            builder.Property(et => et.CreatedAt)
                .HasColumnType("datetime");

            builder.Property(et => et.UpdatedAt)
                .HasColumnType("datetime");

            builder.Property(et => et.CompanyId)
                .IsRequired()
                .HasColumnType("int(11)");
        }
    }
}
