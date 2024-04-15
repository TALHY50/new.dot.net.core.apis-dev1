﻿using System;
using System.Collections.Generic;
using ACL.Database.Models;
using Microsoft.EntityFrameworkCore;

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
                Email = "ssadmin@softrobotics.com",
                City = "C",
                State = "s",
                Country = "BD",
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
                        
                    }
                }

            );






        OnModelCreatingPartial(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
