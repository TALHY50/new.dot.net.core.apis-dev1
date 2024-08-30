using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Configurations
{
    public class InstitutionAppSettingConfiguration : IEntityTypeConfiguration<InstitutionAppSetting>
    {
        public void Configure(EntityTypeBuilder<InstitutionAppSetting> builder)
        {
            builder.ToTable("imt_institution_app_settings");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.InstitutionId)
                .HasColumnName("institution_id")
                .IsRequired();

            builder.Property(e => e.AppName)
                .HasColumnName("app_name")
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.AppId)
                .HasColumnName("app_id")
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.AppSecret)
                .HasColumnName("app_secret")
                .HasMaxLength(100)
                .IsUnicode(true)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Token)
                .HasColumnName("token")
                .HasMaxLength(100)
                .IsUnicode(true)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at");

            builder.Property(e => e.ExpiredAt)
                .HasColumnName("expired_at");

            builder.Property(e => e.CreatedById)
                .HasColumnName("created_by_id");

            builder.Property(e => e.UpdatedById)
                .HasColumnName("updated_by_id");
        }
    }
}
