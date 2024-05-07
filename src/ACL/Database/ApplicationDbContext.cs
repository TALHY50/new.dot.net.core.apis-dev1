using System;
using System.Collections.Generic;
using System.Reflection;
using ACL.Database.Models;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using SharedLibrary.Interfaces;

namespace ACL.Database;

public partial class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AclBranch> AclBranches { get; set; }

    public virtual DbSet<AclCompany> AclCompanies { get; set; }

    public virtual DbSet<AclCompanyModule> AclCompanyModules { get; set; }

    public virtual DbSet<AclCountry> AclCountries { get; set; }

    public virtual DbSet<AclModule> AclModules { get; set; }

    public virtual DbSet<AclPage> AclPages { get; set; }

    public virtual DbSet<AclPageRoute> AclPageRoutes { get; set; }

    public virtual DbSet<AclRole> AclRoles { get; set; }

    public virtual DbSet<AclRolePage> AclRolePages { get; set; }

    public virtual DbSet<AclState> AclStates { get; set; }

    public virtual DbSet<AclSubModule> AclSubModules { get; set; }

    public virtual DbSet<AclUser> AclUsers { get; set; }

    public virtual DbSet<AclUserUsergroup> AclUserUsergroups { get; set; }

    public virtual DbSet<AclUsergroup> AclUsergroups { get; set; }

    public virtual DbSet<AclUsergroupRole> AclUsergroupRoles { get; set; }

    public virtual DbSet<AclUsertypeSubmodule> AclUsertypeSubmodules { get; set; }

    //public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<FailedJob> FailedJobs { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<PersonalAccessToken> PersonalAccessTokens { get; set; }

    //static string server = Environment.GetEnvironmentVariable("DB_HOST") ?? throw new InvalidOperationException("DB_HOST environment variable not found.");
    //static string database = Environment.GetEnvironmentVariable("DB_DATABASE") ?? throw new InvalidOperationException("DB_DATABASE environment variable not found.");
    //static string userName = Environment.GetEnvironmentVariable("DB_USERNAME") ?? throw new InvalidOperationException("DB_USERNAME environment variable not found.");
    //static string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? null;

    //string connectionString = $"server={server};database={database};User ID={userName};Password={password};CharSet=utf8mb4;";

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    //    => optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
        //modelBuilder
        //    .UseCollation("utf8mb4_general_ci")
        //    .HasCharSet("utf8mb4");

        modelBuilder.Entity<AclBranch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_branches");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CompanyId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("company_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("created_by_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Sequence)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("sequence");
            entity.Property(e => e.Status)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<AclCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_companies");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)")
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
            entity.Property(e => e.CmmiLevel)
                .HasColumnType("tinyint(4)")
                .HasColumnName("cmmi_level");
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
            entity.Property(e => e.NoOfEmployees)
                .HasColumnType("int(11)")
                .HasColumnName("no_of_employees");
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
                .HasColumnType("tinyint(4)")
                .HasColumnName("status");
            entity.Property(e => e.TaxNo)
                .HasMaxLength(40)
                .HasColumnName("tax_no");
            entity.Property(e => e.TaxOffice)
                .HasMaxLength(191)
                .HasColumnName("tax_office");
            entity.Property(e => e.Timezone)
                .HasColumnType("int(11)")
                .HasColumnName("timezone");
            entity.Property(e => e.TimezoneValue)
                .HasMaxLength(20)
                .HasColumnName("timezone_value");
            entity.Property(e => e.UniqueColumnName)
                .HasDefaultValueSql("'1'")
                .HasComment("1=>email,2=>username")
                .HasColumnType("tinyint(4)")
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

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CompanyId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ModuleId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AclCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_countries");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("created_by_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Sequence)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("sequence");
            entity.Property(e => e.Status)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<AclModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_modules");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
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
            entity.Property(e => e.Sequence)
                .HasColumnType("int(11)")
                .HasColumnName("sequence");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AclPage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_pages");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AvailableToCompany)
                .HasColumnType("tinyint(4)")
                .HasColumnName("available_to_company");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MethodName)
                .HasMaxLength(255)
                .HasColumnName("method_name");
            entity.Property(e => e.MethodType)
                .HasComment("1=Post, 2=Get, 3=Put, 4=Delete")
                .HasColumnType("int(11)")
                .HasColumnName("method_type");
            entity.Property(e => e.ModuleId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.SubModuleId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("sub_module_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AclPageRoute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_page_routes");

            entity.HasIndex(e => e.PageId, "acl_page_routes_page_id_index");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PageId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("page_id");
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

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CompanyId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasComment("creator auth ID")
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("created_by_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById)
                .HasComment("approve auth ID")
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<AclRolePage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_role_pages");

            entity.HasIndex(e => new { e.RoleId, e.PageId }, "acl_role_pages_role_id_page_id_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PageId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("page_id");
            entity.Property(e => e.RoleId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("role_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AclState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_states");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CountryId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("created_by_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Sequence)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("sequence");
            entity.Property(e => e.Status)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<AclSubModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_sub_modules");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
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
            entity.Property(e => e.ModuleId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Sequence)
                .HasColumnType("int(11)")
                .HasColumnName("sequence");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        /*modelBuilder.Entity<AclUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_users");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
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
            entity.Property(e => e.CompanyId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("company_id");
            entity.Property(e => e.Country)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("created_by_id");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasComment("1=Male, 2=Female")
                .HasColumnType("tinyint(4)")
                .HasColumnName("gender");
            entity.Property(e => e.ImgPath)
                .HasColumnType("text")
                .HasColumnName("img_path");
            entity.Property(e => e.IsAdminVerified)
                .HasComment("0=Pending, 1=Approved, 2=Not Approved, 3=Lock User")
                .HasColumnType("tinyint(4)")
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
                .HasColumnType("tinyint(4)")
                .HasColumnName("otp_channel");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PermissionVersion)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("permission_version");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.RememberToken)
                .HasMaxLength(100)
                .HasColumnName("remember_token");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=>Inactive or disable; 1=>enable or active; 2=> disabled or suspected;3= awaiting disable or banned;4=awaiting GSM")
                .HasColumnType("tinyint(4)")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserType)
                .HasComment("USER_TYPE_SS_ADMIN = 0; USER_TYPE_S_ADMIN = 1; USER_TYPE_USER = 2")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_type");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
        });*/

        modelBuilder.Entity<AclUserUsergroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_user_usergroups");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CompanyId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("user_id");
            entity.Property(e => e.UsergroupId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("usergroup_id");
        });

        modelBuilder.Entity<AclUsergroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_usergroups");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Category)
                .HasComment("1 = Project manager, 2 = Developer, 3 = Reporter, 4 = Admin")
                .HasColumnType("tinyint(4)")
                .HasColumnName("category");
            entity.Property(e => e.CompanyId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("company_id");
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
                .HasColumnType("tinyint(4)")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AclUsergroupRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_usergroup_roles");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CompanyId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.RoleId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("role_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UsergroupId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("usergroup_id");
        });

        modelBuilder.Entity<AclUsertypeSubmodule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_usertype_submodules");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.SubModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sub_module_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserTypeId)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("user_type_id");
        });

        //modelBuilder.Entity<Efmigrationshistory>(entity =>
        //{
        //    entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

        //    entity.ToTable("_efmigrationshistory");

        //    entity.Property(e => e.MigrationId).HasMaxLength(150);
        //    entity.Property(e => e.ProductVersion).HasMaxLength(32);
        //});

        modelBuilder.Entity<FailedJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("failed_jobs");

            entity.HasIndex(e => e.Uuid, "failed_jobs_uuid_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Connection)
                .HasColumnType("text")
                .HasColumnName("connection");
            entity.Property(e => e.Exception).HasColumnName("exception");
            entity.Property(e => e.FailedAt)
                .HasDefaultValueSql("current_timestamp()")
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

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Batch)
                .HasColumnType("int(11)")
                .HasColumnName("batch");
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

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
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
            entity.Property(e => e.TokenableId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("tokenable_id");
            entity.Property(e => e.TokenableType).HasColumnName("tokenable_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AclBranch>().HasData(
          new AclBranch
          {
              Id = 1,
              CompanyId = 2,
              Name = "Test",
              Address = "Dhaka",
              Description = "Test",
              Status = 1,
              Sequence = 1,
              CreatedById = 1,
              UpdatedById = 1,
              CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
              UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
          }
       );

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
        modelBuilder.Entity<AclCompanyModule>().HasData(
         new AclCompanyModule
         {
             Id = 1,
             CompanyId = 1,
             ModuleId = 1001,
             CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
             UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
         }
      );
        modelBuilder.Entity<AclCountry>().HasData(
            new AclCountry[]{
                new AclCountry
                {
                    Id = 1,
                    Name = "Afghanistan",
                    Description = "This is beautiful country",
                    Code = "AF",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 2,
                    Name = "Albania",
                    Description = "This is beautiful country",
                    Code = "AL",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 3,
                    Name = "Algeria",
                    Description = "This is beautiful country",
                    Code = "DZ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 4,
                    Name = "American Samoa",
                    Description = "This is beautiful country",
                    Code = "AS",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 5,
                    Name = "Andorra",
                    Description = "This is beautiful country",
                    Code = "AD",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 6,
                    Name = "Angola",
                    Description = "This is beautiful country",
                    Code = "AO",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 7,
                    Name = "Anguilla",
                    Description = "This is beautiful country",
                    Code = "AI",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 8,
                    Name = "Antarctica",
                    Description = "This is beautiful country",
                    Code = "AQ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 9,
                    Name = "Antigua and Barbuda",
                    Description = "This is beautiful country",
                    Code = "AG",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 10,
                    Name = "Argentina",
                    Description = "This is beautiful country",
                    Code = "AR",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 11,
                    Name = "Armenia",
                    Description = "This is beautiful country",
                    Code = "AM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 12,
                    Name = "Aruba",
                    Description = "This is beautiful country",
                    Code = "AW",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 13,
                    Name = "Australia",
                    Description = "This is beautiful country",
                    Code = "AU",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 14,
                    Name = "Austria",
                    Description = "This is beautiful country",
                    Code = "AT",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 15,
                    Name = "Azerbaijan",
                    Description = "This is beautiful country",
                    Code = "AZ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 16,
                    Name = "Bahamas",
                    Description = "This is beautiful country",
                    Code = "BS",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 17,
                    Name = "Bahrain",
                    Description = "This is beautiful country",
                    Code = "BH",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 18,
                    Name = "Bangladesh",
                    Description = "This is beautiful country",
                    Code = "BD",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 19,
                    Name = "Barbados",
                    Description = "This is beautiful country",
                    Code = "BB",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 20,
                    Name = "Belarus",
                    Description = "This is beautiful country",
                    Code = "BY",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 21,
                    Name = "Belgium",
                    Description = "This is beautiful country",
                    Code = "BE",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 22,
                    Name = "Belize",
                    Description = "This is beautiful country",
                    Code = "BZ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 23,
                    Name = "Benin",
                    Description = "This is beautiful country",
                    Code = "BJ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 24,
                    Name = "Bermuda",
                    Description = "This is beautiful country",
                    Code = "BM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 25,
                    Name = "Bhutan",
                    Description = "This is beautiful country",
                    Code = "BT",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 26,
                    Name = "Bolivia, Plurinational State of",
                    Description = "This is beautiful country",
                    Code = "BO",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 27,
                    Name = "Bonaire, Sint Eustatius and Saba",
                    Description = "This is beautiful country",
                    Code = "BQ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 28,
                    Name = "Bosnia and Herzegovina",
                    Description = "This is beautiful country",
                    Code = "BA",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 29,
                    Name = "Botswana",
                    Description = "This is beautiful country",
                    Code = "BW",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 30,
                    Name = "Bouvet Island",
                    Description = "This is beautiful country",
                    Code = "BV",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 31,
                    Name = "Brazil",
                    Description = "This is beautiful country",
                    Code = "BR",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 32,
                    Name = "British Indian Ocean Territory",
                    Description = "This is beautiful country",
                    Code = "IO",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 33,
                    Name = "Brunei Darussalam",
                    Description = "This is beautiful country",
                    Code = "BN",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 34,
                    Name = "Bulgaria",
                    Description = "This is beautiful country",
                    Code = "BG",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 35,
                    Name = "Burkina Faso",
                    Description = "This is beautiful country",
                    Code = "BF",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 36,
                    Name = "Burundi",
                    Description = "This is beautiful country",
                    Code = "BI",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 37,
                    Name = "Cambodia",
                    Description = "This is beautiful country",
                    Code = "KH",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 38,
                    Name = "Cameroon",
                    Description = "This is beautiful country",
                    Code = "CM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 39,
                    Name = "Canada",
                    Description = "This is beautiful country",
                    Code = "CA",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 40,
                    Name = "Cape Verde",
                    Description = "This is beautiful country",
                    Code = "CV",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 41,
                    Name = "Cayman Islands",
                    Description = "This is beautiful country",
                    Code = "KY",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 42,
                    Name = "Central African Republic",
                    Description = "This is beautiful country",
                    Code = "CF",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 43,
                    Name = "Chad",
                    Description = "This is beautiful country",
                    Code = "TD",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 44,
                    Name = "Chile",
                    Description = "This is beautiful country",
                    Code = "CL",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 45,
                    Name = "China",
                    Description = "This is beautiful country",
                    Code = "CN",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 46,
                    Name = "Christmas Island",
                    Description = "This is beautiful country",
                    Code = "CX",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 47,
                    Name = "Cocos (Keeling) Islands",
                    Description = "This is beautiful country",
                    Code = "CC",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 48,
                    Name = "Colombia",
                    Description = "This is beautiful country",
                    Code = "CO",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 49,
                    Name = "Comoros",
                    Description = "This is beautiful country",
                    Code = "KM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 50,
                    Name = "Congo",
                    Description = "This is beautiful country",
                    Code = "CG",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 51,
                    Name = "Congo, the Democratic Republic of the",
                    Description = "This is beautiful country",
                    Code = "CD",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 52,
                    Name = "Cook Islands",
                    Description = "This is beautiful country",
                    Code = "CK",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 53,
                    Name = "Costa Rica",
                    Description = "This is beautiful country",
                    Code = "CR",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 54,
                    Name = "Croatia",
                    Description = "This is beautiful country",
                    Code = "HR",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 55,
                    Name = "Cuba",
                    Description = "This is beautiful country",
                    Code = "CU",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 56,
                    Name = "CuraÃ§ao",
                    Description = "This is beautiful country",
                    Code = "CW",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 57,
                    Name = "Cyprus",
                    Description = "This is beautiful country",
                    Code = "CY",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 58,
                    Name = "Czech Republic",
                    Description = "This is beautiful country",
                    Code = "CZ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 59,
                    Name = "CÃ´te d'Ivoire",
                    Description = "This is beautiful country",
                    Code = "CI",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 60,
                    Name = "Denmark",
                    Description = "This is beautiful country",
                    Code = "DK",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 61,
                    Name = "Djibouti",
                    Description = "This is beautiful country",
                    Code = "DJ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 62,
                    Name = "Dominica",
                    Description = "This is beautiful country",
                    Code = "DM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 63,
                    Name = "Dominican Republic",
                    Description = "This is beautiful country",
                    Code = "DO",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 64,
                    Name = "Ecuador",
                    Description = "This is beautiful country",
                    Code = "EC",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 65,
                    Name = "Egypt",
                    Description = "This is beautiful country",
                    Code = "EG",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 66,
                    Name = "El Salvador",
                    Description = "This is beautiful country",
                    Code = "SV",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 67,
                    Name = "Equatorial Guinea",
                    Description = "This is beautiful country",
                    Code = "GQ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 68,
                    Name = "Eritrea",
                    Description = "This is beautiful country",
                    Code = "ER",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 69,
                    Name = "Estonia",
                    Description = "This is beautiful country",
                    Code = "EE",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 70,
                    Name = "Ethiopia",
                    Description = "This is beautiful country",
                    Code = "ET",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 71,
                    Name = "Falkland Islands (Malvinas)",
                    Description = "This is beautiful country",
                    Code = "FK",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 72,
                    Name = "Faroe Islands",
                    Description = "This is beautiful country",
                    Code = "FO",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 73,
                    Name = "Fiji",
                    Description = "This is beautiful country",
                    Code = "FJ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 74,
                    Name = "Finland",
                    Description = "This is beautiful country",
                    Code = "FI",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 75,
                    Name = "France",
                    Description = "This is beautiful country",
                    Code = "FR",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 76,
                    Name = "French Guiana",
                    Description = "This is beautiful country",
                    Code = "GF",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 77,
                    Name = "French Polynesia",
                    Description = "This is beautiful country",
                    Code = "PF",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 78,
                    Name = "French Southern Territories",
                    Description = "This is beautiful country",
                    Code = "TF",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 79,
                    Name = "Gabon",
                    Description = "This is beautiful country",
                    Code = "GA",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 80,
                    Name = "Gambia",
                    Description = "This is beautiful country",
                    Code = "GM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 81,
                    Name = "Georgia",
                    Description = "This is beautiful country",
                    Code = "GE",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 82,
                    Name = "Germany",
                    Description = "This is beautiful country",
                    Code = "DE",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 83,
                    Name = "Ghana",
                    Description = "This is beautiful country",
                    Code = "GH",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 84,
                    Name = "Gibraltar",
                    Description = "This is beautiful country",
                    Code = "GI",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 85,
                    Name = "Greece",
                    Description = "This is beautiful country",
                    Code = "GR",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 86,
                    Name = "Greenland",
                    Description = "This is beautiful country",
                    Code = "GL",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 87,
                    Name = "Grenada",
                    Description = "This is beautiful country",
                    Code = "GD",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 88,
                    Name = "Guadeloupe",
                    Description = "This is beautiful country",
                    Code = "GP",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 89,
                    Name = "Guam",
                    Description = "This is beautiful country",
                    Code = "GU",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 90,
                    Name = "Guatemala",
                    Description = "This is beautiful country",
                    Code = "GT",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 91,
                    Name = "Guernsey",
                    Description = "This is beautiful country",
                    Code = "GG",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 92,
                    Name = "Guinea",
                    Description = "This is beautiful country",
                    Code = "GN",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 93,
                    Name = "Guinea-Bissau",
                    Description = "This is beautiful country",
                    Code = "GW",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 94,
                    Name = "Guyana",
                    Description = "This is beautiful country",
                    Code = "GY",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 95,
                    Name = "Haiti",
                    Description = "This is beautiful country",
                    Code = "HT",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 96,
                    Name = "Heard Island and McDonald Islands",
                    Description = "This is beautiful country",
                    Code = "HM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 97,
                    Name = "Holy See (Vatican City State)",
                    Description = "This is beautiful country",
                    Code = "VA",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 98,
                    Name = "Honduras",
                    Description = "This is beautiful country",
                    Code = "HN",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 99,
                    Name = "Hong Kong",
                    Description = "This is beautiful country",
                    Code = "HK",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 100,
                    Name = "Hungary",
                    Description = "This is beautiful country",
                    Code = "HU",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 101,
                    Name = "Iceland",
                    Description = "This is beautiful country",
                    Code = "IS",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 102,
                    Name = "India",
                    Description = "This is beautiful country",
                    Code = "IN",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 103,
                    Name = "Indonesia",
                    Description = "This is beautiful country",
                    Code = "ID",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 104,
                    Name = "Iran, Islamic Republic of",
                    Description = "This is beautiful country",
                    Code = "IR",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 105,
                    Name = "Iraq",
                    Description = "This is beautiful country",
                    Code = "IQ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 106,
                    Name = "Ireland",
                    Description = "This is beautiful country",
                    Code = "IE",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 107,
                    Name = "Isle of Man",
                    Description = "This is beautiful country",
                    Code = "IM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 108,
                    Name = "Israel",
                    Description = "This is beautiful country",
                    Code = "IL",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 109,
                    Name = "Italy",
                    Description = "This is beautiful country",
                    Code = "IT",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 110,
                    Name = "Jamaica",
                    Description = "This is beautiful country",
                    Code = "JM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 111,
                    Name = "Japan",
                    Description = "This is beautiful country",
                    Code = "JP",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 112,
                    Name = "Jersey",
                    Description = "This is beautiful country",
                    Code = "JE",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 113,
                    Name = "Jordan",
                    Description = "This is beautiful country",
                    Code = "JO",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 114,
                    Name = "Kazakhstan",
                    Description = "This is beautiful country",
                    Code = "KZ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 115,
                    Name = "Kenya",
                    Description = "This is beautiful country",
                    Code = "KE",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 116,
                    Name = "Kiribati",
                    Description = "This is beautiful country",
                    Code = "KI",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 117,
                    Name = "Korea, Democratic People's Republic of",
                    Description = "This is beautiful country",
                    Code = "KP",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 118,
                    Name = "Korea, Republic of",
                    Description = "This is beautiful country",
                    Code = "KR",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 119,
                    Name = "Kuwait",
                    Description = "This is beautiful country",
                    Code = "KW",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 120,
                    Name = "Kyrgyzstan",
                    Description = "This is beautiful country",
                    Code = "KG",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 121,
                    Name = "Lao People's Democratic Republic",
                    Description = "This is beautiful country",
                    Code = "LA",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 122,
                    Name = "Latvia",
                    Description = "This is beautiful country",
                    Code = "LV",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 123,
                    Name = "Lebanon",
                    Description = "This is beautiful country",
                    Code = "LB",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 124,
                    Name = "Lesotho",
                    Description = "This is beautiful country",
                    Code = "LS",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 125,
                    Name = "Liberia",
                    Description = "This is beautiful country",
                    Code = "LR",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 126,
                    Name = "Libya",
                    Description = "This is beautiful country",
                    Code = "LY",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 127,
                    Name = "Liechtenstein",
                    Description = "This is beautiful country",
                    Code = "LI",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 128,
                    Name = "Lithuania",
                    Description = "This is beautiful country",
                    Code = "LT",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 129,
                    Name = "Luxembourg",
                    Description = "This is beautiful country",
                    Code = "LU",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 130,
                    Name = "Macao",
                    Description = "This is beautiful country",
                    Code = "MO",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 131,
                    Name = "Macedonia, the Former Yugoslav Republic of",
                    Description = "This is beautiful country",
                    Code = "MK",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 132,
                    Name = "Madagascar",
                    Description = "This is beautiful country",
                    Code = "MG",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 133,
                    Name = "Malawi",
                    Description = "This is beautiful country",
                    Code = "MW",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 134,
                    Name = "Malaysia",
                    Description = "This is beautiful country",
                    Code = "MY",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 135,
                    Name = "Maldives",
                    Description = "This is beautiful country",
                    Code = "MV",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 136,
                    Name = "Mali",
                    Description = "This is beautiful country",
                    Code = "ML",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 137,
                    Name = "Malta",
                    Description = "This is beautiful country",
                    Code = "MT",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 138,
                    Name = "Marshall Islands",
                    Description = "This is beautiful country",
                    Code = "MH",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 139,
                    Name = "Martinique",
                    Description = "This is beautiful country",
                    Code = "MQ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 140,
                    Name = "Mauritania",
                    Description = "This is beautiful country",
                    Code = "MR",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 141,
                    Name = "Mauritius",
                    Description = "This is beautiful country",
                    Code = "MU",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 142,
                    Name = "Mayotte",
                    Description = "This is beautiful country",
                    Code = "YT",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 143,
                    Name = "Mexico",
                    Description = "This is beautiful country",
                    Code = "MX",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 144,
                    Name = "Micronesia, Federated States of",
                    Description = "This is beautiful country",
                    Code = "FM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 145,
                    Name = "Moldova, Republic of",
                    Description = "This is beautiful country",
                    Code = "MD",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 146,
                    Name = "Monaco",
                    Description = "This is beautiful country",
                    Code = "MC",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 147,
                    Name = "Mongolia",
                    Description = "This is beautiful country",
                    Code = "MN",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 148,
                    Name = "Montenegro",
                    Description = "This is beautiful country",
                    Code = "ME",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 149,
                    Name = "Montserrat",
                    Description = "This is beautiful country",
                    Code = "MS",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 150,
                    Name = "Morocco",
                    Description = "This is beautiful country",
                    Code = "MA",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 151,
                    Name = "Mozambique",
                    Description = "This is beautiful country",
                    Code = "MZ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 152,
                    Name = "Myanmar",
                    Description = "This is beautiful country",
                    Code = "MM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 153,
                    Name = "Namibia",
                    Description = "This is beautiful country",
                    Code = "NA",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 154,
                    Name = "Nauru",
                    Description = "This is beautiful country",
                    Code = "NR",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 155,
                    Name = "Nepal",
                    Description = "This is beautiful country",
                    Code = "NP",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 156,
                    Name = "Netherlands",
                    Description = "This is beautiful country",
                    Code = "NL",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 157,
                    Name = "New Caledonia",
                    Description = "This is beautiful country",
                    Code = "NC",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 158,
                    Name = "New Zealand",
                    Description = "This is beautiful country",
                    Code = "NZ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 159,
                    Name = "Nicaragua",
                    Description = "This is beautiful country",
                    Code = "NI",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 160,
                    Name = "Niger",
                    Description = "This is beautiful country",
                    Code = "NE",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 161,
                    Name = "Nigeria",
                    Description = "This is beautiful country",
                    Code = "NG",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 162,
                    Name = "Niue",
                    Description = "This is beautiful country",
                    Code = "NU",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 163,
                    Name = "Norfolk Island",
                    Description = "This is beautiful country",
                    Code = "NF",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 164,
                    Name = "Northern Mariana Islands",
                    Description = "This is beautiful country",
                    Code = "MP",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 165,
                    Name = "Norway",
                    Description = "This is beautiful country",
                    Code = "NO",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 166,
                    Name = "Oman",
                    Description = "This is beautiful country",
                    Code = "OM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 167,
                    Name = "Pakistan",
                    Description = "This is beautiful country",
                    Code = "PK",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 168,
                    Name = "Palau",
                    Description = "This is beautiful country",
                    Code = "PW",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 169,
                    Name = "Palestine, State of",
                    Description = "This is beautiful country",
                    Code = "PS",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 170,
                    Name = "Panama",
                    Description = "This is beautiful country",
                    Code = "PA",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 171,
                    Name = "Papua New Guinea",
                    Description = "This is beautiful country",
                    Code = "PG",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 172,
                    Name = "Paraguay",
                    Description = "This is beautiful country",
                    Code = "PY",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 173,
                    Name = "Peru",
                    Description = "This is beautiful country",
                    Code = "PE",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 174,
                    Name = "Philippines",
                    Description = "This is beautiful country",
                    Code = "PH",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 175,
                    Name = "Pitcairn",
                    Description = "This is beautiful country",
                    Code = "PN",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 176,
                    Name = "Poland",
                    Description = "This is beautiful country",
                    Code = "PL",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 177,
                    Name = "Portugal",
                    Description = "This is beautiful country",
                    Code = "PT",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 178,
                    Name = "Puerto Rico",
                    Description = "This is beautiful country",
                    Code = "PR",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 179,
                    Name = "Qatar",
                    Description = "This is beautiful country",
                    Code = "QA",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 180,
                    Name = "Romania",
                    Description = "This is beautiful country",
                    Code = "RO",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 181,
                    Name = "Russian Federation",
                    Description = "This is beautiful country",
                    Code = "RU",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 182,
                    Name = "Rwanda",
                    Description = "This is beautiful country",
                    Code = "RW",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 183,
                    Name = "RÃ©union",
                    Description = "This is beautiful country",
                    Code = "RE",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 184,
                    Name = "Saint BarthÃ©lemy",
                    Description = "This is beautiful country",
                    Code = "BL",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 185,
                    Name = "Saint Helena, Ascension and Tristan da Cunha",
                    Description = "This is beautiful country",
                    Code = "SH",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 186,
                    Name = "Saint Kitts and Nevis",
                    Description = "This is beautiful country",
                    Code = "KN",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 187,
                    Name = "Saint Lucia",
                    Description = "This is beautiful country",
                    Code = "LC",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 188,
                    Name = "Saint Martin (French part)",
                    Description = "This is beautiful country",
                    Code = "MF",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 189,
                    Name = "Saint Pierre and Miquelon",
                    Description = "This is beautiful country",
                    Code = "PM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 190,
                    Name = "Saint Vincent and the Grenadines",
                    Description = "This is beautiful country",
                    Code = "VC",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 191,
                    Name = "Samoa",
                    Description = "This is beautiful country",
                    Code = "WS",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 192,
                    Name = "San Marino",
                    Description = "This is beautiful country",
                    Code = "SM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 193,
                    Name = "Sao Tome and Principe",
                    Description = "This is beautiful country",
                    Code = "ST",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 194,
                    Name = "Saudi Arabia",
                    Description = "This is beautiful country",
                    Code = "SA",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 195,
                    Name = "Senegal",
                    Description = "This is beautiful country",
                    Code = "SN",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 196,
                    Name = "Serbia",
                    Description = "This is beautiful country",
                    Code = "RS",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 197,
                    Name = "Seychelles",
                    Description = "This is beautiful country",
                    Code = "SC",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 198,
                    Name = "Sierra Leone",
                    Description = "This is beautiful country",
                    Code = "SL",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 199,
                    Name = "Singapore",
                    Description = "This is beautiful country",
                    Code = "SG",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 200,
                    Name = "Sint Maarten (Dutch part)",
                    Description = "This is beautiful country",
                    Code = "SX",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 201,
                    Name = "Slovakia",
                    Description = "This is beautiful country",
                    Code = "SK",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 202,
                    Name = "Slovenia",
                    Description = "This is beautiful country",
                    Code = "SI",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 203,
                    Name = "Solomon Islands",
                    Description = "This is beautiful country",
                    Code = "SB",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 204,
                    Name = "Somalia",
                    Description = "This is beautiful country",
                    Code = "SO",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 205,
                    Name = "South Africa",
                    Description = "This is beautiful country",
                    Code = "ZA",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 206,
                    Name = "South Georgia and the South Sandwich Islands",
                    Description = "This is beautiful country",
                    Code = "GS",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 207,
                    Name = "South Sudan",
                    Description = "This is beautiful country",
                    Code = "SS",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 208,
                    Name = "Spain",
                    Description = "This is beautiful country",
                    Code = "ES",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 209,
                    Name = "Sri Lanka",
                    Description = "This is beautiful country",
                    Code = "LK",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 210,
                    Name = "Sudan",
                    Description = "This is beautiful country",
                    Code = "SD",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 211,
                    Name = "Suriname",
                    Description = "This is beautiful country",
                    Code = "SR",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 212,
                    Name = "Svalbard and Jan Mayen",
                    Description = "This is beautiful country",
                    Code = "SJ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 213,
                    Name = "Swaziland",
                    Description = "This is beautiful country",
                    Code = "SZ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 214,
                    Name = "Sweden",
                    Description = "This is beautiful country",
                    Code = "SE",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 215,
                    Name = "Switzerland",
                    Description = "This is beautiful country",
                    Code = "CH",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 216,
                    Name = "Syrian Arab Republic",
                    Description = "This is beautiful country",
                    Code = "SY",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 217,
                    Name = "Taiwan, Province of China",
                    Description = "This is beautiful country",
                    Code = "TW",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 218,
                    Name = "Tajikistan",
                    Description = "This is beautiful country",
                    Code = "TJ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 219,
                    Name = "Tanzania, United Republic of",
                    Description = "This is beautiful country",
                    Code = "TZ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 220,
                    Name = "Thailand",
                    Description = "This is beautiful country",
                    Code = "TH",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 221,
                    Name = "Timor-Leste",
                    Description = "This is beautiful country",
                    Code = "TL",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 222,
                    Name = "Togo",
                    Description = "This is beautiful country",
                    Code = "TG",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 223,
                    Name = "Tokelau",
                    Description = "This is beautiful country",
                    Code = "TK",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 224,
                    Name = "Tonga",
                    Description = "This is beautiful country",
                    Code = "TO",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 225,
                    Name = "Trinidad and Tobago",
                    Description = "This is beautiful country",
                    Code = "TT",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 226,
                    Name = "Tunisia",
                    Description = "This is beautiful country",
                    Code = "TN",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 227,
                    Name = "Turkey",
                    Description = "This is beautiful country",
                    Code = "TR",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 228,
                    Name = "Turkmenistan",
                    Description = "This is beautiful country",
                    Code = "TM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 229,
                    Name = "Turks and Caicos Islands",
                    Description = "This is beautiful country",
                    Code = "TC",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 230,
                    Name = "Tuvalu",
                    Description = "This is beautiful country",
                    Code = "TV",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 231,
                    Name = "Uganda",
                    Description = "This is beautiful country",
                    Code = "UG",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 232,
                    Name = "Ukraine",
                    Description = "This is beautiful country",
                    Code = "UA",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 233,
                    Name = "United Arab Emirates",
                    Description = "This is beautiful country",
                    Code = "AE",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 234,
                    Name = "United Kingdom",
                    Description = "This is beautiful country",
                    Code = "GB",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 235,
                    Name = "United States",
                    Description = "This is beautiful country",
                    Code = "US",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 236,
                    Name = "United States Minor Outlying Islands",
                    Description = "This is beautiful country",
                    Code = "UM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 237,
                    Name = "Uruguay",
                    Description = "This is beautiful country",
                    Code = "UY",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 238,
                    Name = "Uzbekistan",
                    Description = "This is beautiful country",
                    Code = "UZ",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 239,
                    Name = "Vanuatu",
                    Description = "This is beautiful country",
                    Code = "VU",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 240,
                    Name = "Venezuela, Bolivarian Republic of",
                    Description = "This is beautiful country",
                    Code = "VE",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 241,
                    Name = "Viet Nam",
                    Description = "This is beautiful country",
                    Code = "VN",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 242,
                    Name = "Virgin Islands, British",
                    Description = "This is beautiful country",
                    Code = "VG",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 243,
                    Name = "Virgin Islands, U.S.",
                    Description = "This is beautiful country",
                    Code = "VI",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 244,
                    Name = "Wallis and Futuna",
                    Description = "This is beautiful country",
                    Code = "WF",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 245,
                    Name = "Western Sahara",
                    Description = "This is beautiful country",
                    Code = "EH",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 246,
                    Name = "Yemen",
                    Description = "This is beautiful country",
                    Code = "YE",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 247,
                    Name = "Zambia",
                    Description = "This is beautiful country",
                    Code = "ZM",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 248,
                    Name = "Zimbabwe",
                    Description = "This is beautiful country",
                    Code = "ZW",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
                new AclCountry
                {
                    Id = 249,
                    Name = "Ã…land Islands",
                    Description = "This is beautiful country",
                    Code = "AX",
                    Status = 1,
                    Sequence = 0,
                    CreatedById = 2,
                    UpdatedById = 2,
                    CreatedAt = DateTime.Parse("2015-11-04 01:52:01"),
                    UpdatedAt = DateTime.Parse("2019-03-28 13:29:33")
                },
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
        modelBuilder.Entity<AclState>().HasData(
                new AclState[]
                {
                    new AclState
                    {
                        Id = 1,
                        Name ="Dhaka",
                        Description ="Dhaka city of BD",
                        CountryId = 1,
                        CreatedById = 1,
                        UpdatedById = 1,
                        Sequence = 100,
                        Status = 1,
                        CreatedAt = DateTime.Parse("2019-03-22 08:38:12"),
                        UpdatedAt = DateTime.Parse("2023-11-01 19:17:00")
                    }
                }
            );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
