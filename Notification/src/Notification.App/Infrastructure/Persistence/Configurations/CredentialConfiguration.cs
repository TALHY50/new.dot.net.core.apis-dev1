using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Notification.App.Domain.Entities.Setups;
using Notification.App.Domain.Entities.ValueObjects;

namespace Notification.App.Infrastructure.Persistence.Configurations
{
    public class CredentialConfiguration : IEntityTypeConfiguration<Credential>
    {
        public void Configure(EntityTypeBuilder<Credential> builder)
        {
            builder.ToTable("notification_credentials");

            builder.HasKey(nc => nc.Id);

            RelationalPropertyBuilderExtensions
                .HasColumnType<int>(builder.Property(nc => nc.Id).ValueGeneratedOnAdd(), "int(11)");

            RelationalPropertyBuilderExtensions
                .HasColumnType<NotificationType>(builder.Property(nc => nc.Type).IsRequired(), "tinyint(4)")
                .HasConversion(
                    nt => nt.Type,
                    nt => NotificationType.From(nt))

                .HasComment("1=mail, 2= sms, 3 = web");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(nc => nc.Title).IsRequired().HasMaxLength(50), "varchar(50)")
                .HasComment("Name of the credentials. e.g: Codex, Verimo etc.");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(nc => nc.Host).IsRequired().HasMaxLength(255), "varchar(255)")
                .HasComment("host ip or url should be set here");

            RelationalPropertyBuilderExtensions
                .HasColumnType<int>(builder.Property(nc => nc.Port), "int(11)")
                .HasComment("port of the host or url");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<string>(builder.Property(nc => nc.Username).IsRequired().HasMaxLength(255), "0")
                .HasColumnType("varchar(255)")
                .HasComment("username/api_key/app_key may be set here");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<string>(builder.Property(nc => nc.Password).IsRequired().HasMaxLength(255), "0")
                .HasColumnType("varchar(255)")
                .HasComment("password/secret_key may be placed here");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<string>(builder.Property(nc => nc.ApiKey).IsRequired().HasMaxLength(255), "0")
                .HasColumnName("api_key")
                .HasColumnType("varchar(255)");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(nc => nc.EncryptionType).HasMaxLength(255), "varchar(255)")
                .HasColumnName("encryption_type")
                .HasComment("email encryption type e.g tls, ssl, starttls etc");

            RelationalPropertyBuilderExtensions
                .HasColumnType<TransportDriverType>(builder.Property(nc => nc.TransportDriver).HasMaxLength(255), "varchar(255)")
                .HasColumnName("transport_driver")
                .HasConversion(
                    td => td.Driver,
                    td => TransportDriverType.From(td))
                .HasComment("SMTP, Mailgun, etc.");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(nc => nc.FromAddress).HasMaxLength(255), "varchar(255)")
                .HasColumnName("from_address")
                .HasComment("email/phone/url may be placed here");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(nc => nc.FromName).HasMaxLength(50), "varchar(50)")
                .HasColumnName("from_name")
                .HasComment("Title of from address.");

            RelationalPropertyBuilderExtensions
                .HasColumnType<int>(builder.Property(nc => nc.CreatedById).IsRequired(), "int(11)")
                .HasColumnName("created_by_id")
                .HasDefaultValue(0);

            RelationalPropertyBuilderExtensions
                .HasColumnType<int>(builder.Property(nc => nc.UpdatedById).IsRequired(), "int(11)")
                .HasColumnName("updated_by_id")
                .HasDefaultValue(0);

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(nc => nc.CreatedAt), "created_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(nc => nc.UpdatedAt), "updated_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnName<int>(builder.Property(nc => nc.CompanyId).IsRequired(), "company_id")
                .HasColumnType("int(11)")
                .HasDefaultValue(0);
        }
    }
}
