using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ACL.Application.Domain.Setups;
using ACL.Application.Domain.ValueObjects;
using Notification.Main.Domain.ValueObjects;

namespace ACL.Application.Infrastructure.Persistence.Configurations
{
    public class CredentialConfiguration : IEntityTypeConfiguration<Credential>
    {
        public void Configure(EntityTypeBuilder<Credential> builder)
        {
            builder.ToTable("notification_credentials");

            builder.HasKey(nc => nc.Id);

            builder.Property(nc => nc.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)");

            builder.Property(nc => nc.Type)
                .IsRequired()
                .HasColumnType("tinyint(4)")
                .HasConversion(
                    nt => nt.Type,
                    nt => NotificationType.From(nt))

                .HasComment("1=mail, 2= sms, 3 = web");

            builder.Property(nc => nc.Title)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)")
                .HasComment("Name of the credentials. e.g: Codex, Verimo etc.");

            builder.Property(nc => nc.Host)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)")
                .HasComment("host ip or url should be set here");

            builder.Property(nc => nc.Port)
                .HasColumnType("int(11)")
                .HasComment("port of the host or url");

            builder.Property(nc => nc.Username)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValue("0")
                .HasColumnType("varchar(255)")
                .HasComment("username/api_key/app_key may be set here");

            builder.Property(nc => nc.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValue("0")
                .HasColumnType("varchar(255)")
                .HasComment("password/secret_key may be placed here");

            builder.Property(nc => nc.ApiKey)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValue("0")
                .HasColumnName("api_key")
                .HasColumnType("varchar(255)");

            builder.Property(nc => nc.EncryptionType)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)")
                .HasColumnName("encryption_type")
                .HasComment("email encryption type e.g tls, ssl, starttls etc");

            builder.Property(nc => nc.TransportDriver)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)")
                .HasColumnName("transport_driver")
                .HasConversion(
                    td => td.Driver,
                    td => TransportDriverType.From(td))
                .HasComment("SMTP, Mailgun, etc.");

            builder.Property(nc => nc.FromAddress)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)")
                .HasColumnName("from_address")
                .HasComment("email/phone/url may be placed here");

            builder.Property(nc => nc.FromName)
                .HasMaxLength(50)
                .HasColumnType("varchar(50)")
                .HasColumnName("from_name")
                .HasComment("Title of from address.");

            builder.Property(nc => nc.CreatedById)
                .IsRequired()
                .HasColumnType("int(11)")
                .HasColumnName("created_by_id")
                .HasDefaultValue(0);

            builder.Property(nc => nc.UpdatedById)
                .IsRequired()
                .HasColumnType("int(11)")
                .HasColumnName("updated_by_id")
                .HasDefaultValue(0);

            builder.Property(nc => nc.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(nc => nc.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(nc => nc.CompanyId)
                .IsRequired()
                .HasColumnName("company_id")
                .HasColumnType("int(11)")
                .HasDefaultValue(0);
        }
    }
}
