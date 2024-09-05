using ACL.Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Main.Infrastructure.Extensions;


//using Claim = ACL.Database.Models.Claim;

namespace ACL.Business.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable(name:"acl_users");

            builder.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            builder.Property(e => e.ActivatedAt)
                .HasColumnType("datetime")
                .HasColumnName("activated_at");
            builder.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            builder.Property(e => e.AuthIdentifier)
                .HasMaxLength(150)
                .HasColumnName("auth_identifier");
            builder.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasColumnName("avatar");
            builder.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            builder.Property(e => e.CompanyId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("company_id");
            builder.Property(e => e.Country)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("country");
            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            builder.Property(e => e.CreatedById)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("created_by_id");
            builder.Property(e => e.Dob).HasColumnName("dob");
            /*builder.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");*/
            builder.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            builder.Property(e => e.Gender)
                .HasComment("1=Male, 2=Female")
                .HasColumnType("tinyint(4)")
                .HasColumnName("gender");
            builder.Property(e => e.ImgPath)
                .HasColumnType("text")
                .HasColumnName("img_path");
            builder.Property(e => e.IsAdminVerified)
                .HasComment("0=Pending, 1=Approved, 2=Not Approved, 3=Lock User")
                .HasColumnType("tinyint(4)")
                .HasColumnName("is_admin_verified");
            builder.Property(e => e.Language)
                .HasMaxLength(10)
                .HasDefaultValueSql("'en-US'")
                .HasColumnName("language");
            builder.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            builder.Property(e => e.Salt)
                .HasColumnType("text")
                .HasColumnName("salt");
            builder.Property(e => e.LoginAt)
                .HasComment("user logged in time")
                .HasColumnType("datetime")
                .HasColumnName("login_at");
            builder.Property(e => e.OtpChannel)
                .HasComment("0 => all channel like sms, email, 1 => only sms, 2=> only email")
                .HasColumnType("tinyint(4)")
                .HasColumnName("otp_channel");
            builder.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            builder.Property(e => e.PermissionVersion)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("permission_version");
            builder.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            builder.Property(e => e.RememberToken)
                .HasMaxLength(100)
                .HasColumnName("remember_token");
            builder.Property(e => e.RefreshToken)
                .HasColumnType("text")
                .HasColumnName("refresh_token").HasValueJsonConverter();
            builder.Property<IList<Claim>>("Claims")
                .HasColumnType("text")
                .HasColumnName("claims").HasValueJsonConverter();
            builder.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=>Inactive or disable; 1=>enable or active; 2=> disabled or suspected;3= awaiting disable or banned;4=awaiting GSM")
                .HasColumnType("tinyint(4)")
                .HasColumnName("status");
            builder.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            builder.Property(e => e.UserType)
                .HasComment("USER_TYPE_SS_ADMIN = 0; USER_TYPE_S_ADMIN = 1; USER_TYPE_USER = 2")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_type");
            builder.Property(e => e.UserName)
                .HasMaxLength(20)
                .HasColumnName("username");
            
            builder.Property(e => e.NormalizedUserName)
                .HasMaxLength(256)
                .HasColumnName("normalized_user_name");

            builder.Property(e => e.NormalizedEmail)
                .HasMaxLength(256)
                .HasColumnName("normalized_email");

            builder.Property(e => e.EmailConfirmed)
                .HasColumnType("tinyint(1)")
                .HasColumnName("email_confirmed");

            builder.Property(e => e.PasswordHash)
                .HasColumnType("longtext")
                .HasColumnName("password_hash");

            builder.Property(e => e.SecurityStamp)
                .HasColumnType("longtext")
                .HasColumnName("security_stamp");

            builder.Property(e => e.ConcurrencyStamp)
                .HasColumnType("longtext")
                .HasColumnName("concurrency_stamp");

            builder.Property(e => e.PhoneNumber)
                .HasColumnType("longtext")
                .HasColumnName("phone_number");

            builder.Property(e => e.PhoneNumberConfirmed)
                .HasColumnType("tinyint(1)")
                .HasColumnName("phone_number_confirmed");

            builder.Property(e => e.TwoFactorEnabled)
                .HasColumnType("tinyint(1)")
                .HasColumnName("two_factor_enabled");

            builder.Property(e => e.LockoutEnd)
                .HasColumnType("datetime")
                .HasColumnName("lockout_end");

            builder.Property(e => e.LockoutEnabled)
                .HasColumnType("tinyint(1)")
                .HasColumnName("lockout_enabled");

            builder.Property(e => e.AccessFailedCount)
                .HasColumnType("int")
                .HasColumnName("access_failed_count");

    }


}