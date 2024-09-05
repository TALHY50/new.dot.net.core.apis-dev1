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
        // Map to 'acl_users' table
        builder.ToTable("acl_users");

        // Primary Key
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("id").IsRequired();

        // Column mappings
        builder.Property(u => u.FirstName).HasColumnName("first_name").HasMaxLength(100);
        builder.Property(u => u.LastName).HasColumnName("last_name").HasMaxLength(100);
        builder.Property(u => u.Email).HasColumnName("email").HasMaxLength(50).IsRequired();
        builder.Property(u => u.Avatar).HasColumnName("avatar").HasMaxLength(255);
        builder.Property(u => u.Password).HasColumnName("password").HasMaxLength(255);
        builder.Property(u => u.Salt).HasColumnName("salt").HasMaxLength(100);
        builder.Property(u => u.Dob).HasColumnName("dob");
        builder.Property(u => u.Gender).HasColumnName("gender");
        builder.Property(u => u.Address).HasColumnName("address").HasMaxLength(255);
        builder.Property(u => u.City).HasColumnName("city").HasMaxLength(100);
        builder.Property(u => u.Country).HasColumnName("country").IsRequired();
        builder.Property(u => u.Phone).HasColumnName("phone").HasMaxLength(20);
        builder.Property(u => u.IsAdminVerified).HasColumnName("is_admin_verified").HasDefaultValue(0);
        builder.Property(u => u.UserType).HasColumnName("user_type").HasDefaultValue(0);
        builder.Property(u => u.RememberToken).HasColumnName("remember_token").HasMaxLength(100);
       // builder.Property(u => u.RefreshToken.Token).HasColumnName("refresh_token").HasMaxLength(300);
        builder.Property(u => u.CreatedAt).HasColumnName("created_at");
        builder.Property(u => u.UpdatedAt).HasColumnName("updated_at");
        builder.Property(u => u.ActivatedAt).HasColumnName("activated_at");
        builder.Property(u => u.Language).HasColumnName("language").HasMaxLength(2).HasDefaultValue("en");
        builder.Property(u => u.ImgPath).HasColumnName("img_path");
        builder.Property(u => u.Status).HasColumnName("status").HasDefaultValue(1);
        builder.Property(u => u.CompanyId).HasColumnName("company_id").IsRequired();
        builder.Property(u => u.PermissionVersion).HasColumnName("permission_version").IsRequired();
        builder.Property(u => u.OtpChannel).HasColumnName("otp_channel").HasDefaultValue(0);
        builder.Property(u => u.LoginAt).HasColumnName("login_at");
        builder.Property(u => u.CreatedById).HasColumnName("created_by_id").IsRequired();
        builder.Property(u => u.AuthIdentifier).HasColumnName("auth_identifier").HasMaxLength(150);

        // Identity-related fields (from ASP.NET Identity)
        builder.Property(u => u.NormalizedUserName).HasColumnName("normalized_user_name").HasMaxLength(256);
        builder.Property(u => u.NormalizedEmail).HasColumnName("normalized_email").HasMaxLength(256);
        builder.Property(u => u.EmailConfirmed).HasColumnName("email_confirmed").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("password_hash");
        builder.Property(u => u.SecurityStamp).HasColumnName("security_stamp");
        builder.Property(u => u.ConcurrencyStamp).HasColumnName("concurrency_stamp");
        builder.Property(u => u.PhoneNumber).HasColumnName("phone_number");
        builder.Property(u => u.PhoneNumberConfirmed).HasColumnName("phone_number_confirmed").HasDefaultValue(false);
        builder.Property(u => u.TwoFactorEnabled).HasColumnName("two_factor_enabled").IsRequired();
        builder.Property(u => u.LockoutEnd).HasColumnName("lockout_end");
        builder.Property(u => u.LockoutEnabled).HasColumnName("lockout_enabled").HasDefaultValue(false);
        builder.Property(u => u.AccessFailedCount).HasColumnName("access_failed_count").IsRequired();

        // Ignore fields marked with [NotMapped] in the entity class
        builder.Ignore(u => u.UserName);
       // builder.Ignore(u => u.Claims); // If the Claims are not stored in the table
       // builder.Ignore(u => u._permission); // Assuming it's not stored in DB
    }
}

//public class UserConfiguration : IEntityTypeConfiguration<User>
//{
//    public void Configure(EntityTypeBuilder<User> builder)
//    {

//            builder.HasKey(e => e.Id).HasName("PRIMARY");

//            builder.ToTable(name:"acl_users");

//            builder.Property(e => e.Id)
//                .HasColumnType("bigint(20) unsigned")
//                .HasColumnName("id");
//            builder.Property(e => e.ActivatedAt)
//                .HasColumnType("datetime")
//                .HasColumnName("activated_at");
//            builder.Property(e => e.Address)
//                .HasMaxLength(255)
//                .HasColumnName("address");
//            builder.Property(e => e.AuthIdentifier)
//                .HasMaxLength(150)
//                .HasColumnName("auth_identifier");
//            builder.Property(e => e.Avatar)
//                .HasMaxLength(255)
//                .HasColumnName("avatar");
//            builder.Property(e => e.City)
//                .HasMaxLength(100)
//                .HasColumnName("city");
//            builder.Property(e => e.CompanyId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("company_id");
//            builder.Property(e => e.Country)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("country");
//            builder.Property(e => e.CreatedAt)
//                .HasColumnType("datetime")
//                .HasColumnName("created_at");
//            builder.Property(e => e.CreatedById)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("created_by_id");
//            builder.Property(e => e.Dob).HasColumnName("dob");
//            /*builder.Property(e => e.Email)
//                .HasMaxLength(50)
//                .HasColumnName("email");*/
//            builder.Property(e => e.FirstName)
//                .HasMaxLength(100)
//                .HasColumnName("first_name");
//            builder.Property(e => e.Gender)
//                .HasComment("1=Male, 2=Female")
//                .HasColumnType("tinyint(4)")
//                .HasColumnName("gender");
//            builder.Property(e => e.ImgPath)
//                .HasColumnType("text")
//                .HasColumnName("img_path");
//            builder.Property(e => e.IsAdminVerified)
//                .HasComment("0=Pending, 1=Approved, 2=Not Approved, 3=Lock User")
//                .HasColumnType("tinyint(4)")
//                .HasColumnName("is_admin_verified");
//            builder.Property(e => e.Language)
//                .HasMaxLength(10)
//                .HasDefaultValueSql("'en-US'")
//                .HasColumnName("language");
//            builder.Property(e => e.LastName)
//                .HasMaxLength(100)
//                .HasColumnName("last_name");
//            builder.Property(e => e.Salt)
//                .HasColumnType("text")
//                .HasColumnName("salt");
//            builder.Property(e => e.LoginAt)
//                .HasComment("user logged in time")
//                .HasColumnType("datetime")
//                .HasColumnName("login_at");
//            builder.Property(e => e.OtpChannel)
//                .HasComment("0 => all channel like sms, email, 1 => only sms, 2=> only email")
//                .HasColumnType("tinyint(4)")
//                .HasColumnName("otp_channel");
//            builder.Property(e => e.Password)
//                .HasMaxLength(255)
//                .HasColumnName("password");
//            builder.Property(e => e.PermissionVersion)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("permission_version");
//            builder.Property(e => e.Phone)
//                .HasMaxLength(20)
//                .HasColumnName("phone");
//            builder.Property(e => e.RememberToken)
//                .HasMaxLength(100)
//                .HasColumnName("remember_token");
//            builder.Property(e => e.RefreshToken)
//                .HasColumnType("text")
//                .HasColumnName("refresh_token").HasValueJsonConverter();
//            builder.Property<IList<Claim>>("Claims")
//                .HasColumnType("text")
//                .HasColumnName("claims").HasValueJsonConverter();
//            builder.Property(e => e.Status)
//                .HasDefaultValueSql("'1'")
//                .HasComment("0=>Inactive or disable; 1=>enable or active; 2=> disabled or suspected;3= awaiting disable or banned;4=awaiting GSM")
//                .HasColumnType("tinyint(4)")
//                .HasColumnName("status");
//            builder.Property(e => e.UpdatedAt)
//                .HasColumnType("datetime")
//                .HasColumnName("updated_at");
//            builder.Property(e => e.UserType)
//                .HasComment("USER_TYPE_SS_ADMIN = 0; USER_TYPE_S_ADMIN = 1; USER_TYPE_USER = 2")
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("user_type");
//            builder.Property(e => e.UserName)
//                .HasMaxLength(20)
//                .HasColumnName("username");

//            builder.Property(e => e.NormalizedUserName)
//                .HasMaxLength(256)
//                .HasColumnName("normalized_user_name");

//            builder.Property(e => e.NormalizedEmail)
//                .HasMaxLength(256)
//                .HasColumnName("normalized_email");

//            builder.Property(e => e.EmailConfirmed)
//                .HasColumnType("tinyint(1)")
//                .HasColumnName("email_confirmed");

//            builder.Property(e => e.PasswordHash)
//                .HasColumnType("longtext")
//                .HasColumnName("password_hash");

//            builder.Property(e => e.SecurityStamp)
//                .HasColumnType("longtext")
//                .HasColumnName("security_stamp");

//            builder.Property(e => e.ConcurrencyStamp)
//                .HasColumnType("longtext")
//                .HasColumnName("concurrency_stamp");

//            builder.Property(e => e.PhoneNumber)
//                .HasColumnType("longtext")
//                .HasColumnName("phone_number");

//            builder.Property(e => e.PhoneNumberConfirmed)
//                .HasColumnType("tinyint(1)")
//                .HasColumnName("phone_number_confirmed");

//            builder.Property(e => e.TwoFactorEnabled)
//                .HasColumnType("tinyint(1)")
//                .HasColumnName("two_factor_enabled");

//            builder.Property(e => e.LockoutEnd)
//                .HasColumnType("datetime")
//                .HasColumnName("lockout_end");

//            builder.Property(e => e.LockoutEnabled)
//                .HasColumnType("tinyint(1)")
//                .HasColumnName("lockout_enabled");

//            builder.Property(e => e.AccessFailedCount)
//                .HasColumnType("int")
//                .HasColumnName("access_failed_count");

//    }


//}