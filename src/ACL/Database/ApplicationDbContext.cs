using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using ACL.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ACL.Database;

public partial class ApplicationDbContext : DbContext
{
    private readonly ILoggerFactory _loggerFactory;

    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggerFactory loggerFactory)
        : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    public virtual DbSet<AclCompany> AclCompanies { get; set; }

    public virtual DbSet<AclCompanyModule> AclCompanyModules { get; set; }

    public virtual DbSet<AclModule> AclModules { get; set; }

    public virtual DbSet<AclPage> AclPages { get; set; }

    public virtual DbSet<AclPageRoute> AclPageRoutes { get; set; }

    public virtual DbSet<AclRole> AclRoles { get; set; }

    public virtual DbSet<AclRolePage> AclRolePages { get; set; }

    public virtual DbSet<AclSubModule> AclSubModules { get; set; }

    public virtual DbSet<AclUser> AclUsers { get; set; }

    public virtual DbSet<AclUserUsergroup> AclUserUsergroups { get; set; }

    public virtual DbSet<AclUsergroup> AclUsergroups { get; set; }

    public virtual DbSet<AclUsergroupRole> AclUsergroupRoles { get; set; }

    public virtual DbSet<AclUsertypeSubmodule> AclUsertypeSubmodules { get; set; }

    public virtual DbSet<FailedJob> FailedJobs { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<PersonalAccessToken> PersonalAccessTokens { get; set; }
    public virtual DbSet<AclCountry> AclCountries { get; set; }
    public virtual DbSet<AclState> AclStates { get; set; }
    public virtual DbSet<AclBranch> AclBranches { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AclCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_companies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasDefaultValueSql("'1'")
                .HasColumnName("added_by");
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .HasColumnName("address2");
            entity.Property(e => e.AverageTurnover)
                .HasColumnType("double(12,4)")
                .HasColumnName("average_turnover");
            entity.Property(e => e.Cemail)
                .HasMaxLength(100)
                .HasColumnName("cemail");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.CmmiLevel).HasColumnName("cmmi_level");
            entity.Property(e => e.Cname)
                .HasMaxLength(100)
                .HasColumnName("cname");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DailyRate)
                .HasColumnType("double(12,4)")
                .HasColumnName("daily_rate");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .HasColumnName("fax");
            entity.Property(e => e.HourlyRate)
                .HasColumnType("double(12,4)")
                .HasColumnName("hourly_rate");
            entity.Property(e => e.Logo)
                .HasMaxLength(191)
                .HasColumnName("logo");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.NoOfEmployees).HasColumnName("no_of_employees");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Postcode)
                .HasMaxLength(10)
                .HasColumnName("postcode");
            entity.Property(e => e.RegistrationNo)
                .HasMaxLength(40)
                .HasColumnName("registration_no");
            entity.Property(e => e.Sector)
                .HasMaxLength(191)
                .HasColumnName("sector");
            entity.Property(e => e.State)
                .HasMaxLength(15)
                .HasColumnName("state");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active,0=inactive")
                .HasColumnName("status");
            entity.Property(e => e.TaxNo)
                .HasMaxLength(40)
                .HasColumnName("tax_no");
            entity.Property(e => e.TaxOffice)
                .HasMaxLength(191)
                .HasColumnName("tax_office");
            entity.Property(e => e.Timezone).HasColumnName("timezone");
            entity.Property(e => e.TimezoneValue)
                .HasMaxLength(20)
                .HasColumnName("timezone_value");
            entity.Property(e => e.UniqueColumnName)
                .HasDefaultValueSql("'1'")
                .HasComment("1=>email,2=>username")
                .HasColumnName("unique_column_name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.YearlyRevenue)
                .HasColumnType("double(12,4)")
                .HasColumnName("yearly_revenue");
        });

        modelBuilder.Entity<AclCompanyModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_company_modules");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AclModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_modules");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(100)
                .HasColumnName("display_name");
            entity.Property(e => e.Icon)
                .HasMaxLength(255)
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AclPage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_pages");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailableToCompany).HasColumnName("available_to_company");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MethodName)
                .HasMaxLength(255)
                .HasColumnName("method_name");
            entity.Property(e => e.MethodType)
                .HasComment("1=Post, 2=Get, 3=Put, 4=Delete")
                .HasColumnName("method_type");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.SubModuleId).HasColumnName("sub_module_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AclPageRoute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_page_routes");

            entity.HasIndex(e => e.PageId, "acl_page_routes_page_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PageId).HasColumnName("page_id");
            entity.Property(e => e.RouteName)
                .HasMaxLength(100)
                .HasColumnName("route_name");
            entity.Property(e => e.RouteUrl)
                .HasMaxLength(100)
                .HasColumnName("route_url");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AclRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasComment("creator auth ID")
                .HasColumnName("created_by_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById)
                .HasComment("approve auth ID")
                .HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<AclRolePage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_role_pages");

            entity.HasIndex(e => new { e.RoleId, e.PageId }, "acl_role_pages_role_id_page_id_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PageId).HasColumnName("page_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AclSubModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_sub_modules");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ControllerName)
                .HasMaxLength(255)
                .HasColumnName("controller_name");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DefaultMethod)
                .HasMaxLength(50)
                .HasColumnName("default_method");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(100)
                .HasColumnName("display_name");
            entity.Property(e => e.Icon)
                .HasMaxLength(255)
                .HasColumnName("icon");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AclUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivatedAt)
                .HasColumnType("datetime")
                .HasColumnName("activated_at");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.AuthIdentifier)
                .HasMaxLength(150)
                .HasColumnName("auth_identifier");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasColumnName("avatar");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasComment("1=Male, 2=Female")
                .HasColumnName("gender");
            entity.Property(e => e.ImgPath)
                .HasColumnType("text")
                .HasColumnName("img_path");
            entity.Property(e => e.IsAdminVerified)
                .HasComment("0=Pending, 1=Approved, 2=Not Approved, 3=Lock User")
                .HasColumnName("is_admin_verified");
            entity.Property(e => e.Language)
                .HasMaxLength(2)
                .HasDefaultValueSql("'en'")
                .HasColumnName("language");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.LoginAt)
                .HasComment("user logged in time")
                .HasColumnType("datetime")
                .HasColumnName("login_at");
            entity.Property(e => e.OtpChannel)
                .HasComment("0 => all channel like sms, email, 1 => only sms, 2=> only email")
                .HasColumnName("otp_channel");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PermissionVersion).HasColumnName("permission_version");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.RememberToken)
                .HasMaxLength(100)
                .HasColumnName("remember_token");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=>Inactive or disable; 1=>enable or active; 2=> disabled or suspected;3= awaiting disable or banned;4=awaiting GSM")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserType)
                .HasComment("USER_TYPE_SS_ADMIN = 0; USER_TYPE_S_ADMIN = 1; USER_TYPE_USER = 2")
                .HasColumnName("user_type");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
        });

        modelBuilder.Entity<AclUserUsergroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_user_usergroups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UsergroupId).HasColumnName("usergroup_id");
        });

        modelBuilder.Entity<AclUsergroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_usergroups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category)
                .HasComment("1 = Project manager, 2 = Developer, 3 = Reporter, 4 = Admin")
                .HasColumnName("category");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DashboardUrl)
                .HasMaxLength(255)
                .HasColumnName("dashboard_url");
            entity.Property(e => e.GroupName)
                .HasMaxLength(100)
                .HasColumnName("group_name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AclUsergroupRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_usergroup_roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UsergroupId).HasColumnName("usergroup_id");
        });

        modelBuilder.Entity<AclUsertypeSubmodule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_usertype_submodules");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.SubModuleId).HasColumnName("sub_module_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");
        });

        modelBuilder.Entity<FailedJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("failed_jobs");

            entity.HasIndex(e => e.Uuid, "failed_jobs_uuid_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Connection)
                .HasColumnType("text")
                .HasColumnName("connection");
            entity.Property(e => e.Exception).HasColumnName("exception");
            entity.Property(e => e.FailedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("failed_at");
            entity.Property(e => e.Payload).HasColumnName("payload");
            entity.Property(e => e.Queue)
                .HasColumnType("text")
                .HasColumnName("queue");
            entity.Property(e => e.Uuid).HasColumnName("uuid");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("migrations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Batch).HasColumnName("batch");
            entity.Property(e => e.Migration1)
                .HasMaxLength(255)
                .HasColumnName("migration");
        });

        modelBuilder.Entity<PersonalAccessToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("personal_access_tokens");

            entity.HasIndex(e => e.Token, "personal_access_tokens_token_unique").IsUnique();

            entity.HasIndex(e => new { e.TokenableType, e.TokenableId }, "personal_access_tokens_tokenable_type_tokenable_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abilities)
                .HasColumnType("text")
                .HasColumnName("abilities");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("timestamp")
                .HasColumnName("expires_at");
            entity.Property(e => e.LastUsedAt)
                .HasColumnType("timestamp")
                .HasColumnName("last_used_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Token)
                .HasMaxLength(64)
                .HasColumnName("token");
            entity.Property(e => e.TokenableId).HasColumnName("tokenable_id");
            entity.Property(e => e.TokenableType).HasColumnName("tokenable_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });


        modelBuilder.Entity<AclCompany>().HasData(
            new AclCompany
            {
                Id = 1,
                Name = "Default",
                Cname = "Admin",
                Cemail = "ssadmin@softrobotics.com",
                Address1 = "A",
                Address2 = "A2",
                Postcode = "4100",
                Phone = "031",
                Fax = "Fax",
                TimezoneValue = "TimeZone",
                Logo = "logo",
                TaxNo = "tax",
                Email = "ssadmin@softrobotics.com",
                City = "C",
                State = "s",
                Country = "BD",
                RegistrationNo = "420",
                Timezone = 254,
                UniqueColumnName = 1,
                NoOfEmployees = 6,
                Status = 1,
                AddedBy = 1,
                CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
            }
         );

        modelBuilder.Entity<AclUser>().HasData(
             new AclUser
             {
                 Id = 1,
                 FirstName = "admin1",
                 LastName = "admin1",
                 Email = "ssadmin@sipay.com.tr",
                 Avatar = "users/admin/c41353d1c1fcbdbd39f96ea46a3f769136952e79.png",
                 Password = "Nop@ss1234", // Hashing should be done before storing in actual code
                 Dob = DateTime.Parse("1994-02-22"),
                 Gender = 1,
                 Address = "Dhaka",
                 City = "19",
                 Phone = "+8801788343704",
                 IsAdminVerified = 1,
                 UserType = 0,
                 RememberToken = "",
                 CreatedAt = DateTime.Parse("2018-07-10 16:21:24"),
                 UpdatedAt = DateTime.Parse("2021-08-25 05:46:27"),
                 Language = "en",
                 Username = "rajibecbb",
                 ImgPath = "storage/users/1/2019-04-18-07-49-28-ba4fe9be59df7b82f8243d2126070d76f5305b3e.png",
                 Status = 1,
                 CompanyId = 1,
                 PermissionVersion = 1,
                 OtpChannel = 0,
                 CreatedById = 1
             }
        );

        modelBuilder.Entity<AclModule>().HasData(
            new AclModule[]
            {
                new AclModule
                {
                    Id = 1001,
                    Name = "Company",
                    Icon = "<i class=\"fa fa-list-ul\"></i>",
                    Sequence = 6,
                    CreatedAt = DateTime.Parse("2015-12-09 12:10:46"),
                    UpdatedAt = DateTime.Parse("2019-03-20 21:52:50"),
                    DisplayName = "Company"
                },
                new AclModule
                {
                    Id = 1002,
                    Name = "Master Data",
                    Icon = "<i class=\"fa fa-list-ul\"></i>",
                    Sequence = 2,
                    CreatedAt = DateTime.Parse("2015-12-09 12:10:46"),
                    UpdatedAt = DateTime.Parse("2019-03-26 22:38:37"),
                    DisplayName = "Master Data"
                },
                new AclModule
                {
                    Id = 1003,
                    Name = "Access Control",
                    Icon = "<img src=\"adminca/assets/img/icons/access-control.svg\" />",
                    Sequence = 1099,
                    CreatedAt = DateTime.Parse("2015-12-09 12:10:47"),
                    UpdatedAt = DateTime.Parse("2016-08-06 16:24:34"),
                    DisplayName = "Access Control"
                }
            }
        );

        modelBuilder.Entity<AclSubModule>().HasData(
            new AclSubModule[]
            {
                new AclSubModule
                {
                    Id = 2001,
                    ModuleId = 1001,
                    Name = "Company Management",
                    ControllerName = "CompanyController",
                    Icon = "<i class=\"fa fa-angle-double-right\"></i>",
                    Sequence = 100,
                    CreatedAt = DateTime.Parse("2015-12-09 12:10:47"),
                    UpdatedAt = DateTime.Parse("2015-12-09 12:10:47"),
                    DefaultMethod = "index",
                    DisplayName = "Company Management"
                },
                new AclSubModule
                {
                    Id = 2020,
                    ModuleId = 1002,
                    Name = "Module Management",
                    ControllerName = "ModuleController",
                    Icon = "<i class=\"fa fa-angle-double-right\"></i>",
                    Sequence = 100,
                    CreatedAt = DateTime.Parse("2015-12-09 12:10:48"),
                    UpdatedAt = DateTime.Parse("2015-12-09 12:10:48"),
                    DefaultMethod = "index",
                    DisplayName = "Module Management"
                },
                new AclSubModule
                {
                    Id = 2021,
                    ModuleId = 1002,
                    Name = "Sub Module Management",
                    ControllerName = "SubModuleController",
                    Icon = "<i class=\"fa fa-angle-double-right\"></i>",
                    Sequence = 101,
                    CreatedAt = DateTime.Parse("2015-12-09 12:10:48"),
                    UpdatedAt = DateTime.Parse("2015-12-09 12:10:48"),
                    DefaultMethod = "index",
                    DisplayName = "Sub Module Management"
                },
                new AclSubModule
                {
                    Id = 2022,
                    ModuleId = 1002,
                    Name = "Page Management",
                    ControllerName = "PageController",
                    Icon = "<i class=\"fa fa-angle-double-right\"></i>",
                    Sequence = 102,
                    CreatedAt = DateTime.Parse("2015-12-09 12:10:48"),
                    UpdatedAt = DateTime.Parse("2015-12-09 12:10:48"),
                    DefaultMethod = "index",
                    DisplayName = "Page Management"
                },
                new AclSubModule
                {
                    Id = 2050,
                    ModuleId = 1003,
                    Name = "User Management",
                    ControllerName = "UserController",
                    Icon = "<i class=\"fa fa-angle-double-right\"></i>",
                    Sequence = 18,
                    CreatedAt = DateTime.Parse("2015-12-09 12:10:49"),
                    UpdatedAt = DateTime.Parse("2015-12-09 12:10:49"),
                    DefaultMethod = "index",
                    DisplayName = "User Management"
                },
                new AclSubModule
                {
                    Id = 2051,
                    ModuleId = 1003,
                    Name = "Role Management",
                    ControllerName = "RoleController",
                    Icon = "<i class=\"fa fa-angle-double-right\"></i>",
                    Sequence = 101,
                    CreatedAt = DateTime.Parse("2015-12-09 12:10:49"),
                    UpdatedAt = DateTime.Parse("2015-12-23 14:35:45"),
                    DefaultMethod = "index",
                    DisplayName = "Role Management"
                },
                new AclSubModule
                {
                    Id = 2052,
                    ModuleId = 1003,
                    Name = "User Group Management",
                    ControllerName = "UsergroupController",
                    Icon = "<i class=\"fa fa-angle-double-right\"></i>",
                    Sequence = 102,
                    CreatedAt = DateTime.Parse("2015-12-09 12:10:49"),
                    UpdatedAt = DateTime.Parse("2015-12-09 12:10:49"),
                    DefaultMethod = "index",
                    DisplayName = "User Group Management"
                },
                new AclSubModule
                {
                    Id = 2053,
                    ModuleId = 1003,
                    Name = "Usergroup & Role Association",
                    ControllerName = "UsergroupRoleController",
                    Icon = "<i class=\"fa fa-angle-double-right\"></i>",
                    Sequence = 103,
                    CreatedAt = DateTime.Parse("2015-12-09 12:10:49"),
                    UpdatedAt = DateTime.Parse("2015-12-09 12:10:49"),
                    DefaultMethod = "index",
                    DisplayName = "Usergroup & Role Association"
                },
                new AclSubModule
                {
                    Id = 2054,
                    ModuleId = 1003,
                    Name = "Role & Page Association",
                    ControllerName = "RolePageController",
                    Icon = "<i class=\"fa fa-angle-double-right\"></i>",
                    Sequence = 104,
                    CreatedAt = DateTime.Parse("2015-12-09 12:10:50"),
                    UpdatedAt = DateTime.Parse("2015-12-09 12:10:50"),
                    DefaultMethod = "index",
                    DisplayName = "Role & Page Association"
                },
                new AclSubModule
                {
                    Id = 2055,
                    ModuleId = 1003,
                    Name = "Company Module Management",
                    ControllerName = "CompanyModuleController",
                    Icon = "<i class=\"fa fa-angle-double-right\"></i>",
                    Sequence = 105,
                    CreatedAt = DateTime.Parse("2015-12-09 12:10:48"),
                    UpdatedAt = DateTime.Parse("2015-12-09 12:10:48"),
                    DefaultMethod = "index",
                    DisplayName = "Company Module Management"
                }
            }
        );

        modelBuilder.Entity<AclPage>().HasData(
                new AclPage[]
                {
                    new AclPage
                    {
                        Id = 3001,
                        ModuleId = 1001,
                        SubModuleId = 2001,
                        Name = "Company List",
                        MethodName = "index",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:51"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:51")
                    },
                    new AclPage
                    {
                        Id = 3002,
                        ModuleId = 1001,
                        SubModuleId = 2001,
                        Name = "Add New Company",
                        MethodName = "create",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:52"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:52")
                    },
                    new AclPage
                    {
                        Id = 3003,
                        ModuleId = 1001,
                        SubModuleId = 2001,
                        Name = "Modify Company",
                        MethodName = "edit",
                        MethodType = 2,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:52"),
                        UpdatedAt = DateTime.Parse("2019-03-27 15:03:28")
                    },
                    new AclPage
                    {
                        Id = 3004,
                        ModuleId = 1001,
                        SubModuleId = 2001,
                        Name = "Delete Company",
                        MethodName = "destroy",
                        MethodType = 2,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:52"),
                        UpdatedAt = DateTime.Parse("2019-03-26 22:42:31")
                    },
                    new AclPage
                    {
                        Id = 3005,
                        ModuleId = 1001,
                        SubModuleId = 2001,
                        Name = "View Company",
                        MethodName = "show",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:52"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:52")
                    },
                    new AclPage
                    {
                        Id = 3015,
                        ModuleId = 1002,
                        SubModuleId = 2020,
                        Name = "Module List",
                        MethodName = "index",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:53"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:53")
                    },
                    new AclPage
                    {
                        Id = 3016,
                        ModuleId = 1002,
                        SubModuleId = 2020,
                        Name = "Add New Module",
                        MethodName = "create",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:53"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:53")
                    },
                    new AclPage
                    {
                        Id = 3017,
                        ModuleId = 1002,
                        SubModuleId = 2020,
                        Name = "Modify Module",
                        MethodName = "edit",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:53"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:53")
                    },
                    new AclPage
                    {
                        Id = 3018,
                        ModuleId = 1002,
                        SubModuleId = 2020,
                        Name = "Delete Module",
                        MethodName = "destroy",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:54"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:54")
                    },
                    new AclPage
                    {
                        Id = 3019,
                        ModuleId = 1002,
                        SubModuleId = 2020,
                        Name = "View Module",
                        MethodName = "view",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:54"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:54")
                    },
                    new AclPage
                    {
                        Id = 3025,
                        ModuleId = 1002,
                        SubModuleId = 2021,
                        Name = "Submodule List",
                        MethodName = "index",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:54"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:54")
                    },
                    new AclPage
                    {
                        Id = 3026,
                        ModuleId = 1002,
                        SubModuleId = 2021,
                        Name = "Add New Submodule",
                        MethodName = "create",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:54"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:54")
                    },
                    new AclPage
                    {
                        Id = 3027,
                        ModuleId = 1002,
                        SubModuleId = 2021,
                        Name = "Modify Submodule",
                        MethodName = "edit",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:54"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:54")
                    },
                    new AclPage
                    {
                        Id = 3028,
                        ModuleId = 1002,
                        SubModuleId = 2021,
                        Name = "Delete Submodule",
                        MethodName = "destroy",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:55"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:55")
                    },
                    new AclPage
                    {
                        Id = 3029,
                        ModuleId = 1002,
                        SubModuleId = 2021,
                        Name = "View Submodule",
                        MethodName = "view",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:55"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:55")
                    },
                    new AclPage
                    {
                        Id = 3035,
                        ModuleId = 1002,
                        SubModuleId = 2022,
                        Name = "Page List",
                        MethodName = "index",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:55"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:55")
                    },
                    new AclPage
                    {
                        Id = 3036,
                        ModuleId = 1002,
                        SubModuleId = 2022,
                        Name = "Add New Page",
                        MethodName = "create",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:55"),
                        UpdatedAt = DateTime.Parse("2016-01-21 10:44:25")
                    },
                    new AclPage
                    {
                        Id = 3037,
                        ModuleId = 1002,
                        SubModuleId = 2022,
                        Name = "Modify Page",
                        MethodName = "edit",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:56"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:56")
                    },
                    new AclPage
                    {
                        Id = 3038,
                        ModuleId = 1002,
                        SubModuleId = 2022,
                        Name = "Delete Page",
                        MethodName = "destroy",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:56"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:56")
                    },
                    new AclPage
                    {
                        Id = 3039,
                        ModuleId = 1002,
                        SubModuleId = 2022,
                        Name = "View Page",
                        MethodName = "view",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:56"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:56")
                    },
                    new AclPage
                    {
                        Id = 3045,
                        ModuleId = 1003,
                        SubModuleId = 2050,
                        Name = "User List",
                        MethodName = "index",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:56"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:56")
                    },
                    new AclPage
                    {
                        Id = 3046,
                        ModuleId = 1003,
                        SubModuleId = 2050,
                        Name = "User Add",
                        MethodName = "create",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:57"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:57")
                    },
                    new AclPage
                    {
                        Id = 3047,
                        ModuleId = 1003,
                        SubModuleId = 2050,
                        Name = "User Edit",
                        MethodName = "edit",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:57"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:57")
                    },
                    new AclPage
                    {
                        Id = 3048,
                        ModuleId = 1003,
                        SubModuleId = 2050,
                        Name = "User Delete",
                        MethodName = "destroy",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:57"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:57")
                    },
                    new AclPage
                    {
                        Id = 3049,
                        ModuleId = 1003,
                        SubModuleId = 2050,
                        Name = "User View",
                        MethodName = "view",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-11-22 23:13:47"),
                        UpdatedAt = DateTime.Parse("2015-11-22 23:13:47")
                    },
                    new AclPage
                    {
                        Id = 3055,
                        ModuleId = 1003,
                        SubModuleId = 2051,
                        Name = "Role List",
                        MethodName = "index",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:12:02"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:12:02")
                    },
                    new AclPage
                    {
                        Id = 3056,
                        ModuleId = 1003,
                        SubModuleId = 2051,
                        Name = "Role Add",
                        MethodName = "create",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:12:02"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:12:02")
                    },
                    new AclPage
                    {
                        Id = 3057,
                        ModuleId = 1003,
                        SubModuleId = 2051,
                        Name = "Role Edit",
                        MethodName = "edit",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:12:03"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:12:03")
                    },
                    new AclPage
                    {
                        Id = 3058,
                        ModuleId = 1003,
                        SubModuleId = 2051,
                        Name = "Role Delete",
                        MethodName = "destroy",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:12:03"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:12:03")
                    },
                    new AclPage
                    {
                        Id = 3059,
                        ModuleId = 1003,
                        SubModuleId = 2051,
                        Name = "Role View",
                        MethodName = "view",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:12:03"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:12:03")
                    },
                    new AclPage
                    {
                        Id = 3065,
                        ModuleId = 1003,
                        SubModuleId = 2052,
                        Name = "UserGroup List",
                        MethodName = "index",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:12:03"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:12:03")
                    },
                    new AclPage
                    {
                        Id = 3066,
                        ModuleId = 1003,
                        SubModuleId = 2052,
                        Name = "UserGroup Add",
                        MethodName = "create",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:12:04"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:12:04")
                    },
                    new AclPage
                    {
                        Id = 3067,
                        ModuleId = 1003,
                        SubModuleId = 2052,
                        Name = "UserGroup Edit",
                        MethodName = "edit",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:12:04"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:12:04")
                    },
                    new AclPage
                    {
                        Id = 3068,
                        ModuleId = 1003,
                        SubModuleId = 2052,
                        Name = "UserGroup Delete",
                        MethodName = "destroy",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:12:04"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:12:04")
                    },
                    new AclPage
                    {
                        Id = 3069,
                        ModuleId = 1003,
                        SubModuleId = 2052,
                        Name = "UserGroup View",
                        MethodName = "view",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:12:04"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:12:04")
                    },
                    new AclPage
                    {
                        Id = 3075,
                        ModuleId = 1003,
                        SubModuleId = 2053,
                        Name = "Usergroup Role Association",
                        MethodName = "index",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:12:05"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:12:05")
                    },
                    new AclPage
                    {
                        Id = 3076,
                        ModuleId = 1003,
                        SubModuleId = 2053,
                        Name = "Usergroup & Role Association Update",
                        MethodName = "edit",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2021-12-09 15:10:51"),
                        UpdatedAt = DateTime.Parse("2021-12-09 15:10:51")
                    },
                    new AclPage
                    {
                        Id = 3078,
                        ModuleId = 1003,
                        SubModuleId = 2054,
                        Name = "Role & Page Association",
                        MethodName = "index",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2015-12-09 12:12:05"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:12:05")
                    },
                    new AclPage
                    {
                        Id = 3079,
                        ModuleId = 1003,
                        SubModuleId = 2054,
                        Name = "Role & Page Association Update",
                        MethodName = "edit",
                        MethodType = 0,
                        AvailableToCompany = 1,
                        CreatedAt = DateTime.Parse("2021-12-09 15:10:51"),
                        UpdatedAt = DateTime.Parse("2021-12-09 15:10:51")
                    },
                    new AclPage
                    {
                        Id = 3080,
                        ModuleId = 1003,
                        SubModuleId = 2055,
                        Name = "Company Module List",
                        MethodName = "index",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:51"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:51")
                    },
                    new AclPage
                    {
                        Id = 3081,
                        ModuleId = 1003,
                        SubModuleId = 2055,
                        Name = "Add New Company Module",
                        MethodName = "create",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:52"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:52")
                    },
                    new AclPage
                    {
                        Id = 3082,
                        ModuleId = 1003,
                        SubModuleId = 2055,
                        Name = "Modify Company Module",
                        MethodName = "edit",
                        MethodType = 2,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:52"),
                        UpdatedAt = DateTime.Parse("2019-03-27 15:03:28")
                    },
                    new AclPage
                    {
                        Id = 3083,
                        ModuleId = 1003,
                        SubModuleId = 2055,
                        Name = "Delete Company Module",
                        MethodName = "destroy",
                        MethodType = 2,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:52"),
                        UpdatedAt = DateTime.Parse("2019-03-26 22:42:31")
                    },
                    new AclPage
                    {
                        Id = 3084,
                        ModuleId = 1003,
                        SubModuleId = 2055,
                        Name = "View Company Module",
                        MethodName = "show",
                        MethodType = 0,
                        AvailableToCompany = 0,
                        CreatedAt = DateTime.Parse("2015-12-09 12:10:52"),
                        UpdatedAt = DateTime.Parse("2015-12-09 12:10:52")
                    }
                }
            );

        modelBuilder.Entity<AclPageRoute>().HasData(
                new AclPageRoute[]
                {
                    new AclPageRoute { Id=1, PageId = 3001, RouteName = "acl.company.list", RouteUrl = "companies" },
                    new AclPageRoute { Id=2, PageId = 3002, RouteName = "acl.company.add", RouteUrl = "companies/add" },
                    new AclPageRoute { Id=3, PageId = 3003, RouteName = "acl.company.edit", RouteUrl = "companies/edit/{id}" },
                    new AclPageRoute { Id=4, PageId = 3004, RouteName = "acl.company.destroy", RouteUrl = "companies/delete/{id}" },
                    new AclPageRoute { Id=5, PageId = 3005, RouteName = "acl.company.show", RouteUrl = "companies/view/{id}" },
                    new AclPageRoute { Id=6, PageId = 3015, RouteName = "acl.module.list", RouteUrl = "modules" },
                    new AclPageRoute { Id=7, PageId = 3016, RouteName = "acl.module.add", RouteUrl = "modules/add" },
                    new AclPageRoute { Id=8, PageId = 3017, RouteName = "acl.module.edit", RouteUrl = "modules/edit/{id}" },
                    new AclPageRoute { Id=9, PageId = 3018, RouteName = "acl.module.destroy", RouteUrl = "modules/delete/{id}" },
                    new AclPageRoute { Id=10, PageId = 3019, RouteName = "acl.module.view", RouteUrl = "modules/view/{id}" },
                    new AclPageRoute { Id=11, PageId = 3080, RouteName = "acl.company_module.list", RouteUrl = "company/modules" },
                    new AclPageRoute { Id=12, PageId = 3081, RouteName = "acl.company_module.add", RouteUrl = "company/modules/add" },
                    new AclPageRoute { Id=13, PageId = 3082, RouteName = "acl.company_module.edit", RouteUrl = "company/modules/edit/{id}" },
                    new AclPageRoute { Id=14, PageId = 3083, RouteName = "acl.company_module.destroy", RouteUrl = "company/modules/delete/{id}" },
                    new AclPageRoute { Id=15, PageId = 3084, RouteName = "acl.company_module.view", RouteUrl = "company/modules/view/{id}" },
                    new AclPageRoute { Id=16, PageId = 3025, RouteName = "acl.submodule.list", RouteUrl = "submodules" },
                    new AclPageRoute { Id=17, PageId = 3026, RouteName = "acl.submodule.add", RouteUrl = "submodules/add" },
                    new AclPageRoute { Id=18, PageId = 3027, RouteName = "acl.submodule.edit", RouteUrl = "submodules/edit/{id}" },
                    new AclPageRoute { Id=19, PageId = 3028, RouteName = "acl.submodule.destroy", RouteUrl = "submodules/delete/{id}" },
                    new AclPageRoute { Id=20, PageId = 3029, RouteName = "acl.submodule.view", RouteUrl = "submodules/view/{id}" },
                    new AclPageRoute { Id=21, PageId = 3035, RouteName = "acl.page.list", RouteUrl = "pages" },
                    new AclPageRoute { Id=22, PageId = 3036, RouteName = "acl.page.add", RouteUrl = "pages/add" },
                    new AclPageRoute { Id=23, PageId = 3037, RouteName = "acl.page.edit", RouteUrl = "pages/edit/{id}" },
                    new AclPageRoute { Id=24, PageId = 3038, RouteName = "acl.page.destroy", RouteUrl = "pages/delete/{id}" },
                    new AclPageRoute { Id=25, PageId = 3039, RouteName = "acl.page.view", RouteUrl = "pages/view/{id}" },
                    new AclPageRoute { Id=26, PageId = 3045, RouteName = "acl.user.list", RouteUrl = "users" },
                    new AclPageRoute { Id=27, PageId = 3046, RouteName = "acl.user.add", RouteUrl = "users/add" },
                    new AclPageRoute { Id=28, PageId = 3047, RouteName = "acl.user.edit", RouteUrl = "users/edit/{id}" },
                    new AclPageRoute { Id=29, PageId = 3048, RouteName = "acl.user.destroy", RouteUrl = "users/delete/{id}" },
                    new AclPageRoute { Id=30, PageId = 3049, RouteName = "acl.user.view", RouteUrl = "users/view/{id}" },
                    new AclPageRoute { Id=31, PageId = 3055, RouteName = "acl.role.list", RouteUrl = "roles" },
                    new AclPageRoute { Id=32, PageId = 3056, RouteName = "acl.role.add", RouteUrl = "roles/add" },
                    new AclPageRoute { Id=33, PageId = 3057, RouteName = "acl.role.edit", RouteUrl = "roles/edit/{id}" },
                    new AclPageRoute { Id=34, PageId = 3058, RouteName = "acl.role.destroy", RouteUrl = "roles/delete/{id}" },
                    new AclPageRoute { Id=35, PageId = 3059, RouteName = "acl.role.view", RouteUrl = "roles/view/{id}" },
                    new AclPageRoute { Id=36, PageId = 3065, RouteName = "acl.usergroups.list", RouteUrl = "usergroups" },
                    new AclPageRoute { Id=37, PageId = 3066, RouteName = "acl.usergroups.add", RouteUrl = "usergroups/add" },
                    new AclPageRoute { Id=38, PageId = 3067, RouteName = "acl.usergroups.edit", RouteUrl = "usergroups/edit/{id}" },
                    new AclPageRoute { Id=39, PageId = 3068, RouteName = "acl.usergroups.destroy", RouteUrl = "usergroups/delete/{id}" },
                    new AclPageRoute { Id=40, PageId = 3069, RouteName = "acl.usergroups.view", RouteUrl = "usergroups/view/{id}" },
                    new AclPageRoute { Id=41, PageId = 3075, RouteName = "acl.usergroups.role.association", RouteUrl = "usergroups/roles/{user_group_id}" },
                    new AclPageRoute { Id=42, PageId = 3076, RouteName = "acl.usergroups.role.association.update", RouteUrl = "usergroups/roles/update" },
                    new AclPageRoute { Id=43, PageId = 3078, RouteName = "acl.role&page.association", RouteUrl = "permissions/associations/{role_id}" },
                    new AclPageRoute { Id=44, PageId = 3079, RouteName = "acl.role&page.association.update", RouteUrl = "permissions/associations/update" },
                    new AclPageRoute { Id=45, PageId = 3036, RouteName = "acl.page.route.add", RouteUrl = "pages/routes/add" },
                    new AclPageRoute { Id=46, PageId = 3037, RouteName = "acl.page.route.edit", RouteUrl = "pages/routes/edit/{id}" },
                    new AclPageRoute { Id=47, PageId = 3038, RouteName = "acl.page.route.destroy", RouteUrl = "pages/routes/delete/{id}" }

                }
            );


        modelBuilder.Entity<AclRole>().HasData(
                new AclRole[]
                {
                    new AclRole
                    {
                        Id = 1,
                        CreatedById = null,
                        UpdatedById = null,
                        Title = "super-super-admin",
                        Name = "",
                        Status = 1,
                        CompanyId = 1,
                        CreatedAt = DateTime.Parse("2019-03-21 20:38:30"),
                        UpdatedAt = DateTime.Parse("2015-11-09 07:17:00")
                    }
                }
            );
        modelBuilder.Entity<AclRolePage>().HasData(
                new AclRolePage[]
                {
                    new AclRolePage { Id=1,  RoleId = 1, PageId = 3001 },
                    new AclRolePage { Id=2,  RoleId = 1, PageId = 3002 },
                    new AclRolePage { Id=3,  RoleId = 1, PageId = 3003 },
                    new AclRolePage { Id=4,  RoleId = 1, PageId = 3004 },
                    new AclRolePage { Id=5,  RoleId = 1, PageId = 3005 },
                    new AclRolePage { Id=6,  RoleId = 1, PageId = 3015 },
                    new AclRolePage { Id=7,  RoleId = 1, PageId = 3016 },
                    new AclRolePage { Id=8,  RoleId = 1, PageId = 3017 },
                    new AclRolePage { Id=9,  RoleId = 1, PageId = 3018 },
                    new AclRolePage { Id=10,  RoleId = 1, PageId = 3019 },
                    new AclRolePage { Id=11,  RoleId = 1, PageId = 3025 },
                    new AclRolePage { Id=12,  RoleId = 1, PageId = 3026 },
                    new AclRolePage { Id=13,  RoleId = 1, PageId = 3027 },
                    new AclRolePage { Id=14,  RoleId = 1, PageId = 3028 },
                    new AclRolePage { Id=15,  RoleId = 1, PageId = 3029 },
                    new AclRolePage { Id=16,  RoleId = 1, PageId = 3035 },
                    new AclRolePage { Id=17,  RoleId = 1, PageId = 3036 },
                    new AclRolePage { Id=18,  RoleId = 1, PageId = 3037 },
                    new AclRolePage { Id=19,  RoleId = 1, PageId = 3038 },
                    new AclRolePage { Id=20,  RoleId = 1, PageId = 3039 },
                    new AclRolePage { Id=21,  RoleId = 1, PageId = 3080 },
                    new AclRolePage { Id=22,  RoleId = 1, PageId = 3081 },
                    new AclRolePage { Id=23,  RoleId = 1, PageId = 3082 },
                    new AclRolePage { Id=24,  RoleId = 1, PageId = 3083 },
                    new AclRolePage { Id=25,  RoleId = 1, PageId = 3084 }
                }
            );

        modelBuilder.Entity<AclUsergroup>().HasData(
                new AclUsergroup[]
                {
                    new AclUsergroup
                    {
                        Id = 1,
                        GroupName = "super-super-admin-group",
                        Category = 0,
                        DashboardUrl = null,
                        Status = 1,
                        CompanyId = 1,
                        CreatedAt = DateTime.Parse("2019-03-22 08:38:12"),
                        UpdatedAt = DateTime.Parse("2023-11-01 19:17:00")
                    }
                }
            );

        modelBuilder.Entity<AclUsergroupRole>().HasData(
                new AclUsergroupRole[]
                {
                    new AclUsergroupRole
                    {
                        Id = 1,
                        UsergroupId = 1,
                        RoleId = 1,
                        CompanyId = 1
                    }
                }
            );

        modelBuilder.Entity<AclUserUsergroup>().HasData(
                new AclUserUsergroup[]
                {
                    new AclUserUsergroup
                    {
                        Id = 1,
                        UsergroupId = 1,
                        UserId = 1,
                        CompanyId = 1,
                        CreatedAt = DateTime.Parse("2024-01-24 07:23:21"),
                        UpdatedAt = DateTime.Parse("2024-01-24 07:23:23")
                    }
                }
            );

        modelBuilder.Entity<AclUsertypeSubmodule>().HasData(
                new AclUsertypeSubmodule[]
                {
                    new AclUsertypeSubmodule { Id=1, UserTypeId = 0, SubModuleId = 2001 },
                    new AclUsertypeSubmodule { Id=2, UserTypeId = 0, SubModuleId = 2020 },
                    new AclUsertypeSubmodule { Id=3, UserTypeId = 0, SubModuleId = 2021 },
                    new AclUsertypeSubmodule { Id=4, UserTypeId = 0, SubModuleId = 2022 },
                    new AclUsertypeSubmodule { Id=5, UserTypeId = 1, SubModuleId = 2050 },
                    new AclUsertypeSubmodule { Id=6, UserTypeId = 1, SubModuleId = 2051 },
                    new AclUsertypeSubmodule { Id=7, UserTypeId = 1, SubModuleId = 2052 },
                    new AclUsertypeSubmodule { Id=8, UserTypeId = 1, SubModuleId = 2053 },
                    new AclUsertypeSubmodule { Id=9, UserTypeId = 1, SubModuleId = 2054 }
                }
            );

        OnModelCreatingPartial(modelBuilder);

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory); // Enable EF Core logging
        base.OnConfiguring(optionsBuilder);
             optionsBuilder.ConfigureWarnings(warnings =>
             {
                 warnings.Ignore(InMemoryEventId.TransactionIgnoredWarning);
             });
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
