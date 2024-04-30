using System;
using System.Collections.Generic;
using ACL.Database.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ACL.Database;

public partial class ApplicationDbContext : DbContext
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

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<FailedJob> FailedJobs { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<PersonalAccessToken> PersonalAccessTokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=acl;user id=root;charset=utf8mb4", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.22-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AclBranch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acl_branches");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CompanyId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("company_id");
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
            entity.Property(e => e.CompanyId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("company_id");
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
            entity.Property(e => e.CompanyId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("company_id");
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

        modelBuilder.Entity<AclUser>(entity =>
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
        });

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

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
