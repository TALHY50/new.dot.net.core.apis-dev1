using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ACL.Business.Domain.Entities; // Assuming UserSettings entity is in this namespace

namespace ACL.Business.Infrastructure.Persistence.Configurations
{
    public class UserSettingsConfiguration : IEntityTypeConfiguration<UserSetting>
    {
        public void Configure(EntityTypeBuilder<UserSetting> builder)
        {
            // Table Name
            builder.ToTable("acl_user_settings");

            // Primary Key
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            // Columns
            builder.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id")
                .HasComment("id of users table");

            builder.Property(e => e.AppId)
                .HasMaxLength(50)
                .HasColumnName("app_id");

            builder.Property(e => e.AppSecret)
                .HasMaxLength(50)
                .HasColumnName("app_secret");
        }
    }
}