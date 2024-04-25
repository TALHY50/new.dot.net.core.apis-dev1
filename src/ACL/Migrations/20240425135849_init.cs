using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ACL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_branches",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    company_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    sequence = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    created_by_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    updated_by_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acl_branches", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_companies",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cemail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    postcode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fax = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    state = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    country = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    logo = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    registration_no = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    timezone = table.Column<int>(type: "int", nullable: false),
                    unique_column_name = table.Column<sbyte>(type: "tinyint", nullable: false, defaultValueSql: "'1'", comment: "1=>email,2=>username"),
                    timezone_value = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tax_no = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tax_office = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sector = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    average_turnover = table.Column<double>(type: "double(12,4)", nullable: false),
                    no_of_employees = table.Column<int>(type: "int", nullable: false),
                    cmmi_level = table.Column<sbyte>(type: "tinyint", nullable: false),
                    yearly_revenue = table.Column<double>(type: "double(12,4)", nullable: false),
                    hourly_rate = table.Column<double>(type: "double(12,4)", nullable: false),
                    daily_rate = table.Column<double>(type: "double(12,4)", nullable: false),
                    status = table.Column<sbyte>(type: "tinyint", nullable: false, defaultValueSql: "'1'", comment: "1=active,0=inactive"),
                    added_by = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_company_modules",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    company_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    module_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_countries",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    company_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    sequence = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    created_by_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    updated_by_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acl_countries", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_modules",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    icon = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sequence = table.Column<int>(type: "int", nullable: false),
                    display_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_page_routes",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    page_id = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    route_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    route_url = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_pages",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    module_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    sub_module_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    method_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    method_type = table.Column<int>(type: "int", nullable: false, comment: "1=Post, 2=Get, 3=Put, 4=Delete"),
                    available_to_company = table.Column<sbyte>(type: "tinyint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_role_pages",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    role_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    page_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_roles",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<sbyte>(type: "tinyint", nullable: false, defaultValueSql: "'1'"),
                    company_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    created_by_id = table.Column<ulong>(type: "bigint unsigned", nullable: true, comment: "creator auth ID"),
                    updated_by_id = table.Column<ulong>(type: "bigint unsigned", nullable: true, comment: "approve auth ID"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_states",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    company_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    country_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    sequence = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    created_by_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    updated_by_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acl_states", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_sub_modules",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    module_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    controller_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    icon = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sequence = table.Column<int>(type: "int", nullable: false),
                    default_method = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    display_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_user_usergroups",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usergroup_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    user_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    company_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_usergroup_roles",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usergroup_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    role_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    company_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_usergroups",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    group_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    category = table.Column<sbyte>(type: "tinyint", nullable: false, comment: "1 = Project manager, 2 = Developer, 3 = Reporter, 4 = Admin"),
                    dashboard_url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<sbyte>(type: "tinyint", nullable: false, defaultValueSql: "'1'"),
                    company_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_users",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    avatar = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dob = table.Column<DateTime>(type: "date", nullable: true),
                    gender = table.Column<sbyte>(type: "tinyint", nullable: true, comment: "1=Male, 2=Female"),
                    address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    country = table.Column<uint>(type: "int unsigned", nullable: false),
                    phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_admin_verified = table.Column<sbyte>(type: "tinyint", nullable: false, comment: "0=Pending, 1=Approved, 2=Not Approved, 3=Lock User"),
                    user_type = table.Column<uint>(type: "int unsigned", nullable: false, comment: "USER_TYPE_SS_ADMIN = 0; USER_TYPE_S_ADMIN = 1; USER_TYPE_USER = 2"),
                    remember_token = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    activated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    language = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false, defaultValueSql: "'en'")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    img_path = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<sbyte>(type: "tinyint", nullable: false, defaultValueSql: "'1'", comment: "0=>Inactive or disable; 1=>enable or active; 2=> disabled or suspected;3= awaiting disable or banned;4=awaiting GSM"),
                    company_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    permission_version = table.Column<uint>(type: "int unsigned", nullable: false),
                    otp_channel = table.Column<sbyte>(type: "tinyint", nullable: false, comment: "0 => all channel like sms, email, 1 => only sms, 2=> only email"),
                    login_at = table.Column<DateTime>(type: "datetime", nullable: true, comment: "user logged in time"),
                    created_by_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    auth_identifier = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acl_usertype_submodules",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_type_id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    sub_module_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "failed_jobs",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uuid = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    connection = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    queue = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    payload = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    exception = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    failed_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "migrations",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    migration = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    batch = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personal_access_tokens",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tokenable_type = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tokenable_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    token = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    abilities = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_used_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    expires_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "acl_companies",
                columns: new[] { "id", "added_by", "address1", "address2", "average_turnover", "cemail", "city", "cmmi_level", "cname", "country", "created_at", "daily_rate", "email", "fax", "hourly_rate", "logo", "name", "no_of_employees", "phone", "postcode", "registration_no", "sector", "state", "status", "tax_no", "tax_office", "timezone", "timezone_value", "unique_column_name", "updated_at", "yearly_revenue" },
                values: new object[] { 1ul, 1, "A", "A2", 0.0, "ssadmin@softrobotics.com", "C", (sbyte)0, "Admin", "BD", new DateTime(2015, 11, 4, 1, 52, 1, 0, DateTimeKind.Unspecified), 0.0, "ssadmin@softrobotics.com", "Fax", 0.0, "logo", "Default", 6, "031", "4100", "420", null, "s", (sbyte)1, "tax", null, 254, "TimeZone", (sbyte)1, new DateTime(2019, 3, 28, 13, 29, 33, 0, DateTimeKind.Unspecified), 0.0 });

            migrationBuilder.InsertData(
                table: "acl_modules",
                columns: new[] { "id", "created_at", "display_name", "icon", "name", "sequence", "updated_at" },
                values: new object[,]
                {
                    { 1001ul, new DateTime(2015, 12, 9, 12, 10, 46, 0, DateTimeKind.Unspecified), "Company", "<i class=\"fa fa-list-ul\"></i>", "Company", 6, new DateTime(2019, 3, 20, 21, 52, 50, 0, DateTimeKind.Unspecified) },
                    { 1002ul, new DateTime(2015, 12, 9, 12, 10, 46, 0, DateTimeKind.Unspecified), "Master Data", "<i class=\"fa fa-list-ul\"></i>", "Master Data", 2, new DateTime(2019, 3, 26, 22, 38, 37, 0, DateTimeKind.Unspecified) },
                    { 1003ul, new DateTime(2015, 12, 9, 12, 10, 47, 0, DateTimeKind.Unspecified), "Access Control", "<img src=\"adminca/assets/img/icons/access-control.svg\" />", "Access Control", 1099, new DateTime(2016, 8, 6, 16, 24, 34, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "acl_page_routes",
                columns: new[] { "id", "created_at", "page_id", "route_name", "route_url", "updated_at" },
                values: new object[,]
                {
                    { 1ul, null, 3001ul, "acl.company.list", "companies", null },
                    { 2ul, null, 3002ul, "acl.company.add", "companies/add", null },
                    { 3ul, null, 3003ul, "acl.company.edit", "companies/edit/{id}", null },
                    { 4ul, null, 3004ul, "acl.company.destroy", "companies/delete/{id}", null },
                    { 5ul, null, 3005ul, "acl.company.show", "companies/view/{id}", null },
                    { 6ul, null, 3015ul, "acl.module.list", "modules", null },
                    { 7ul, null, 3016ul, "acl.module.add", "modules/add", null },
                    { 8ul, null, 3017ul, "acl.module.edit", "modules/edit/{id}", null },
                    { 9ul, null, 3018ul, "acl.module.destroy", "modules/delete/{id}", null },
                    { 10ul, null, 3019ul, "acl.module.view", "modules/view/{id}", null },
                    { 11ul, null, 3080ul, "acl.company_module.list", "company/modules", null },
                    { 12ul, null, 3081ul, "acl.company_module.add", "company/modules/add", null },
                    { 13ul, null, 3082ul, "acl.company_module.edit", "company/modules/edit/{id}", null },
                    { 14ul, null, 3083ul, "acl.company_module.destroy", "company/modules/delete/{id}", null },
                    { 15ul, null, 3084ul, "acl.company_module.view", "company/modules/view/{id}", null },
                    { 16ul, null, 3025ul, "acl.submodule.list", "submodules", null },
                    { 17ul, null, 3026ul, "acl.submodule.add", "submodules/add", null },
                    { 18ul, null, 3027ul, "acl.submodule.edit", "submodules/edit/{id}", null },
                    { 19ul, null, 3028ul, "acl.submodule.destroy", "submodules/delete/{id}", null },
                    { 20ul, null, 3029ul, "acl.submodule.view", "submodules/view/{id}", null },
                    { 21ul, null, 3035ul, "acl.page.list", "pages", null },
                    { 22ul, null, 3036ul, "acl.page.add", "pages/add", null },
                    { 23ul, null, 3037ul, "acl.page.edit", "pages/edit/{id}", null },
                    { 24ul, null, 3038ul, "acl.page.destroy", "pages/delete/{id}", null },
                    { 25ul, null, 3039ul, "acl.page.view", "pages/view/{id}", null },
                    { 26ul, null, 3045ul, "acl.user.list", "users", null },
                    { 27ul, null, 3046ul, "acl.user.add", "users/add", null },
                    { 28ul, null, 3047ul, "acl.user.edit", "users/edit/{id}", null },
                    { 29ul, null, 3048ul, "acl.user.destroy", "users/delete/{id}", null },
                    { 30ul, null, 3049ul, "acl.user.view", "users/view/{id}", null },
                    { 31ul, null, 3055ul, "acl.role.list", "roles", null },
                    { 32ul, null, 3056ul, "acl.role.add", "roles/add", null },
                    { 33ul, null, 3057ul, "acl.role.edit", "roles/edit/{id}", null },
                    { 34ul, null, 3058ul, "acl.role.destroy", "roles/delete/{id}", null },
                    { 35ul, null, 3059ul, "acl.role.view", "roles/view/{id}", null },
                    { 36ul, null, 3065ul, "acl.usergroups.list", "usergroups", null },
                    { 37ul, null, 3066ul, "acl.usergroups.add", "usergroups/add", null },
                    { 38ul, null, 3067ul, "acl.usergroups.edit", "usergroups/edit/{id}", null },
                    { 39ul, null, 3068ul, "acl.usergroups.destroy", "usergroups/delete/{id}", null },
                    { 40ul, null, 3069ul, "acl.usergroups.view", "usergroups/view/{id}", null },
                    { 41ul, null, 3075ul, "acl.usergroups.role.association", "usergroups/roles/{user_group_id}", null },
                    { 42ul, null, 3076ul, "acl.usergroups.role.association.update", "usergroups/roles/update", null },
                    { 43ul, null, 3078ul, "acl.role&page.association", "permissions/associations/{role_id}", null },
                    { 44ul, null, 3079ul, "acl.role&page.association.update", "permissions/associations/update", null },
                    { 45ul, null, 3036ul, "acl.page.route.add", "pages/routes/add", null },
                    { 46ul, null, 3037ul, "acl.page.route.edit", "pages/routes/edit/{id}", null },
                    { 47ul, null, 3038ul, "acl.page.route.destroy", "pages/routes/delete/{id}", null }
                });

            migrationBuilder.InsertData(
                table: "acl_pages",
                columns: new[] { "id", "available_to_company", "created_at", "method_name", "method_type", "module_id", "name", "sub_module_id", "updated_at" },
                values: new object[,]
                {
                    { 3001ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 51, 0, DateTimeKind.Unspecified), "index", 0, 1001ul, "Company List", 2001ul, new DateTime(2015, 12, 9, 12, 10, 51, 0, DateTimeKind.Unspecified) },
                    { 3002ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "create", 0, 1001ul, "Add New Company", 2001ul, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified) },
                    { 3003ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "edit", 2, 1001ul, "Modify Company", 2001ul, new DateTime(2019, 3, 27, 15, 3, 28, 0, DateTimeKind.Unspecified) },
                    { 3004ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "destroy", 2, 1001ul, "Delete Company", 2001ul, new DateTime(2019, 3, 26, 22, 42, 31, 0, DateTimeKind.Unspecified) },
                    { 3005ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "show", 0, 1001ul, "View Company", 2001ul, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified) },
                    { 3015ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 53, 0, DateTimeKind.Unspecified), "index", 0, 1002ul, "Module List", 2020ul, new DateTime(2015, 12, 9, 12, 10, 53, 0, DateTimeKind.Unspecified) },
                    { 3016ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 53, 0, DateTimeKind.Unspecified), "create", 0, 1002ul, "Add New Module", 2020ul, new DateTime(2015, 12, 9, 12, 10, 53, 0, DateTimeKind.Unspecified) },
                    { 3017ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 53, 0, DateTimeKind.Unspecified), "edit", 0, 1002ul, "Modify Module", 2020ul, new DateTime(2015, 12, 9, 12, 10, 53, 0, DateTimeKind.Unspecified) },
                    { 3018ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified), "destroy", 0, 1002ul, "Delete Module", 2020ul, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified) },
                    { 3019ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified), "view", 0, 1002ul, "View Module", 2020ul, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified) },
                    { 3025ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified), "index", 0, 1002ul, "Submodule List", 2021ul, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified) },
                    { 3026ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified), "create", 0, 1002ul, "Add New Submodule", 2021ul, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified) },
                    { 3027ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified), "edit", 0, 1002ul, "Modify Submodule", 2021ul, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified) },
                    { 3028ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 55, 0, DateTimeKind.Unspecified), "destroy", 0, 1002ul, "Delete Submodule", 2021ul, new DateTime(2015, 12, 9, 12, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 3029ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 55, 0, DateTimeKind.Unspecified), "view", 0, 1002ul, "View Submodule", 2021ul, new DateTime(2015, 12, 9, 12, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 3035ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 55, 0, DateTimeKind.Unspecified), "index", 0, 1002ul, "Page List", 2022ul, new DateTime(2015, 12, 9, 12, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 3036ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 55, 0, DateTimeKind.Unspecified), "create", 0, 1002ul, "Add New Page", 2022ul, new DateTime(2016, 1, 21, 10, 44, 25, 0, DateTimeKind.Unspecified) },
                    { 3037ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified), "edit", 0, 1002ul, "Modify Page", 2022ul, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified) },
                    { 3038ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified), "destroy", 0, 1002ul, "Delete Page", 2022ul, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified) },
                    { 3039ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified), "view", 0, 1002ul, "View Page", 2022ul, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified) },
                    { 3045ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified), "index", 0, 1003ul, "User List", 2050ul, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified) },
                    { 3046ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 10, 57, 0, DateTimeKind.Unspecified), "create", 0, 1003ul, "User Add", 2050ul, new DateTime(2015, 12, 9, 12, 10, 57, 0, DateTimeKind.Unspecified) },
                    { 3047ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 10, 57, 0, DateTimeKind.Unspecified), "edit", 0, 1003ul, "User Edit", 2050ul, new DateTime(2015, 12, 9, 12, 10, 57, 0, DateTimeKind.Unspecified) },
                    { 3048ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 10, 57, 0, DateTimeKind.Unspecified), "destroy", 0, 1003ul, "User Delete", 2050ul, new DateTime(2015, 12, 9, 12, 10, 57, 0, DateTimeKind.Unspecified) },
                    { 3049ul, (sbyte)0, new DateTime(2015, 11, 22, 23, 13, 47, 0, DateTimeKind.Unspecified), "view", 0, 1003ul, "User View", 2050ul, new DateTime(2015, 11, 22, 23, 13, 47, 0, DateTimeKind.Unspecified) },
                    { 3055ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 2, 0, DateTimeKind.Unspecified), "index", 0, 1003ul, "Role List", 2051ul, new DateTime(2015, 12, 9, 12, 12, 2, 0, DateTimeKind.Unspecified) },
                    { 3056ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 2, 0, DateTimeKind.Unspecified), "create", 0, 1003ul, "Role Add", 2051ul, new DateTime(2015, 12, 9, 12, 12, 2, 0, DateTimeKind.Unspecified) },
                    { 3057ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified), "edit", 0, 1003ul, "Role Edit", 2051ul, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified) },
                    { 3058ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified), "destroy", 0, 1003ul, "Role Delete", 2051ul, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified) },
                    { 3059ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified), "view", 0, 1003ul, "Role View", 2051ul, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified) },
                    { 3065ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified), "index", 0, 1003ul, "UserGroup List", 2052ul, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified) },
                    { 3066ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified), "create", 0, 1003ul, "UserGroup Add", 2052ul, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified) },
                    { 3067ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified), "edit", 0, 1003ul, "UserGroup Edit", 2052ul, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified) },
                    { 3068ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified), "destroy", 0, 1003ul, "UserGroup Delete", 2052ul, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified) },
                    { 3069ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified), "view", 0, 1003ul, "UserGroup View", 2052ul, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified) },
                    { 3075ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 5, 0, DateTimeKind.Unspecified), "index", 0, 1003ul, "Usergroup Role Association", 2053ul, new DateTime(2015, 12, 9, 12, 12, 5, 0, DateTimeKind.Unspecified) },
                    { 3076ul, (sbyte)1, new DateTime(2021, 12, 9, 15, 10, 51, 0, DateTimeKind.Unspecified), "edit", 0, 1003ul, "Usergroup & Role Association Update", 2053ul, new DateTime(2021, 12, 9, 15, 10, 51, 0, DateTimeKind.Unspecified) },
                    { 3078ul, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 5, 0, DateTimeKind.Unspecified), "index", 0, 1003ul, "Role & Page Association", 2054ul, new DateTime(2015, 12, 9, 12, 12, 5, 0, DateTimeKind.Unspecified) },
                    { 3079ul, (sbyte)1, new DateTime(2021, 12, 9, 15, 10, 51, 0, DateTimeKind.Unspecified), "edit", 0, 1003ul, "Role & Page Association Update", 2054ul, new DateTime(2021, 12, 9, 15, 10, 51, 0, DateTimeKind.Unspecified) },
                    { 3080ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 51, 0, DateTimeKind.Unspecified), "index", 0, 1003ul, "Company Module List", 2055ul, new DateTime(2015, 12, 9, 12, 10, 51, 0, DateTimeKind.Unspecified) },
                    { 3081ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "create", 0, 1003ul, "Add New Company Module", 2055ul, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified) },
                    { 3082ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "edit", 2, 1003ul, "Modify Company Module", 2055ul, new DateTime(2019, 3, 27, 15, 3, 28, 0, DateTimeKind.Unspecified) },
                    { 3083ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "destroy", 2, 1003ul, "Delete Company Module", 2055ul, new DateTime(2019, 3, 26, 22, 42, 31, 0, DateTimeKind.Unspecified) },
                    { 3084ul, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "show", 0, 1003ul, "View Company Module", 2055ul, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "acl_role_pages",
                columns: new[] { "id", "created_at", "page_id", "role_id", "updated_at" },
                values: new object[,]
                {
                    { 1ul, null, 3001ul, 1ul, null },
                    { 2ul, null, 3002ul, 1ul, null },
                    { 3ul, null, 3003ul, 1ul, null },
                    { 4ul, null, 3004ul, 1ul, null },
                    { 5ul, null, 3005ul, 1ul, null },
                    { 6ul, null, 3015ul, 1ul, null },
                    { 7ul, null, 3016ul, 1ul, null },
                    { 8ul, null, 3017ul, 1ul, null },
                    { 9ul, null, 3018ul, 1ul, null },
                    { 10ul, null, 3019ul, 1ul, null },
                    { 11ul, null, 3025ul, 1ul, null },
                    { 12ul, null, 3026ul, 1ul, null },
                    { 13ul, null, 3027ul, 1ul, null },
                    { 14ul, null, 3028ul, 1ul, null },
                    { 15ul, null, 3029ul, 1ul, null },
                    { 16ul, null, 3035ul, 1ul, null },
                    { 17ul, null, 3036ul, 1ul, null },
                    { 18ul, null, 3037ul, 1ul, null },
                    { 19ul, null, 3038ul, 1ul, null },
                    { 20ul, null, 3039ul, 1ul, null },
                    { 21ul, null, 3080ul, 1ul, null },
                    { 22ul, null, 3081ul, 1ul, null },
                    { 23ul, null, 3082ul, 1ul, null },
                    { 24ul, null, 3083ul, 1ul, null },
                    { 25ul, null, 3084ul, 1ul, null }
                });

            migrationBuilder.InsertData(
                table: "acl_roles",
                columns: new[] { "id", "company_id", "created_at", "created_by_id", "name", "status", "title", "updated_at", "updated_by_id" },
                values: new object[] { 1ul, 1ul, new DateTime(2019, 3, 21, 20, 38, 30, 0, DateTimeKind.Unspecified), null, "", (sbyte)1, "super-super-admin", new DateTime(2015, 11, 9, 7, 17, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "acl_sub_modules",
                columns: new[] { "id", "controller_name", "created_at", "default_method", "display_name", "icon", "module_id", "name", "sequence", "updated_at" },
                values: new object[,]
                {
                    { 2001ul, "CompanyController", new DateTime(2015, 12, 9, 12, 10, 47, 0, DateTimeKind.Unspecified), "index", "Company Management", "<i class=\"fa fa-angle-double-right\"></i>", 1001ul, "Company Management", 100, new DateTime(2015, 12, 9, 12, 10, 47, 0, DateTimeKind.Unspecified) },
                    { 2020ul, "ModuleController", new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified), "index", "Module Management", "<i class=\"fa fa-angle-double-right\"></i>", 1002ul, "Module Management", 100, new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified) },
                    { 2021ul, "SubModuleController", new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified), "index", "Sub Module Management", "<i class=\"fa fa-angle-double-right\"></i>", 1002ul, "Sub Module Management", 101, new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified) },
                    { 2022ul, "PageController", new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified), "index", "Page Management", "<i class=\"fa fa-angle-double-right\"></i>", 1002ul, "Page Management", 102, new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified) },
                    { 2050ul, "UserController", new DateTime(2015, 12, 9, 12, 10, 49, 0, DateTimeKind.Unspecified), "index", "User Management", "<i class=\"fa fa-angle-double-right\"></i>", 1003ul, "User Management", 18, new DateTime(2015, 12, 9, 12, 10, 49, 0, DateTimeKind.Unspecified) },
                    { 2051ul, "RoleController", new DateTime(2015, 12, 9, 12, 10, 49, 0, DateTimeKind.Unspecified), "index", "Role Management", "<i class=\"fa fa-angle-double-right\"></i>", 1003ul, "Role Management", 101, new DateTime(2015, 12, 23, 14, 35, 45, 0, DateTimeKind.Unspecified) },
                    { 2052ul, "UsergroupController", new DateTime(2015, 12, 9, 12, 10, 49, 0, DateTimeKind.Unspecified), "index", "User Group Management", "<i class=\"fa fa-angle-double-right\"></i>", 1003ul, "User Group Management", 102, new DateTime(2015, 12, 9, 12, 10, 49, 0, DateTimeKind.Unspecified) },
                    { 2053ul, "UsergroupRoleController", new DateTime(2015, 12, 9, 12, 10, 49, 0, DateTimeKind.Unspecified), "index", "Usergroup & Role Association", "<i class=\"fa fa-angle-double-right\"></i>", 1003ul, "Usergroup & Role Association", 103, new DateTime(2015, 12, 9, 12, 10, 49, 0, DateTimeKind.Unspecified) },
                    { 2054ul, "RolePageController", new DateTime(2015, 12, 9, 12, 10, 50, 0, DateTimeKind.Unspecified), "index", "Role & Page Association", "<i class=\"fa fa-angle-double-right\"></i>", 1003ul, "Role & Page Association", 104, new DateTime(2015, 12, 9, 12, 10, 50, 0, DateTimeKind.Unspecified) },
                    { 2055ul, "CompanyModuleController", new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified), "index", "Company Module Management", "<i class=\"fa fa-angle-double-right\"></i>", 1003ul, "Company Module Management", 105, new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "acl_user_usergroups",
                columns: new[] { "id", "company_id", "created_at", "updated_at", "user_id", "usergroup_id" },
                values: new object[] { 1ul, 1ul, new DateTime(2024, 1, 24, 7, 23, 21, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 24, 7, 23, 23, 0, DateTimeKind.Unspecified), 1ul, 1ul });

            migrationBuilder.InsertData(
                table: "acl_usergroup_roles",
                columns: new[] { "id", "company_id", "created_at", "role_id", "updated_at", "usergroup_id" },
                values: new object[] { 1ul, 1ul, null, 1ul, null, 1ul });

            migrationBuilder.InsertData(
                table: "acl_usergroups",
                columns: new[] { "id", "category", "company_id", "created_at", "dashboard_url", "group_name", "status", "updated_at" },
                values: new object[] { 1ul, (sbyte)0, 1ul, new DateTime(2019, 3, 22, 8, 38, 12, 0, DateTimeKind.Unspecified), null, "super-super-admin-group", (sbyte)1, new DateTime(2023, 11, 1, 19, 17, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "acl_users",
                columns: new[] { "id", "activated_at", "address", "auth_identifier", "avatar", "city", "company_id", "country", "created_at", "created_by_id", "dob", "email", "first_name", "gender", "img_path", "is_admin_verified", "language", "last_name", "login_at", "otp_channel", "password", "permission_version", "phone", "remember_token", "status", "updated_at", "user_type", "username" },
                values: new object[] { 1ul, null, "Dhaka", null, "users/admin/c41353d1c1fcbdbd39f96ea46a3f769136952e79.png", "19", 1u, 0u, new DateTime(2018, 7, 10, 16, 21, 24, 0, DateTimeKind.Unspecified), 1u, new DateTime(1994, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ssadmin@sipay.com.tr", "admin1", (sbyte)1, "storage/users/1/2019-04-18-07-49-28-ba4fe9be59df7b82f8243d2126070d76f5305b3e.png", (sbyte)1, "en", "admin1", null, (sbyte)0, "Nop@ss1234", 1u, "+8801788343704", "", (sbyte)1, new DateTime(2021, 8, 25, 5, 46, 27, 0, DateTimeKind.Unspecified), 0u, "rajibecbb" });

            migrationBuilder.InsertData(
                table: "acl_usertype_submodules",
                columns: new[] { "id", "created_at", "sub_module_id", "updated_at", "user_type_id" },
                values: new object[,]
                {
                    { 1ul, null, 2001u, null, (byte)0 },
                    { 2ul, null, 2020u, null, (byte)0 },
                    { 3ul, null, 2021u, null, (byte)0 },
                    { 4ul, null, 2022u, null, (byte)0 },
                    { 5ul, null, 2050u, null, (byte)1 },
                    { 6ul, null, 2051u, null, (byte)1 },
                    { 7ul, null, 2052u, null, (byte)1 },
                    { 8ul, null, 2053u, null, (byte)1 },
                    { 9ul, null, 2054u, null, (byte)1 }
                });

            migrationBuilder.CreateIndex(
                name: "acl_page_routes_page_id_index",
                table: "acl_page_routes",
                column: "page_id");

            migrationBuilder.CreateIndex(
                name: "acl_role_pages_role_id_page_id_unique",
                table: "acl_role_pages",
                columns: new[] { "role_id", "page_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "failed_jobs_uuid_unique",
                table: "failed_jobs",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "personal_access_tokens_token_unique",
                table: "personal_access_tokens",
                column: "token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "personal_access_tokens_tokenable_type_tokenable_id_index",
                table: "personal_access_tokens",
                columns: new[] { "tokenable_type", "tokenable_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acl_branches");

            migrationBuilder.DropTable(
                name: "acl_companies");

            migrationBuilder.DropTable(
                name: "acl_company_modules");

            migrationBuilder.DropTable(
                name: "acl_countries");

            migrationBuilder.DropTable(
                name: "acl_modules");

            migrationBuilder.DropTable(
                name: "acl_page_routes");

            migrationBuilder.DropTable(
                name: "acl_pages");

            migrationBuilder.DropTable(
                name: "acl_role_pages");

            migrationBuilder.DropTable(
                name: "acl_roles");

            migrationBuilder.DropTable(
                name: "acl_states");

            migrationBuilder.DropTable(
                name: "acl_sub_modules");

            migrationBuilder.DropTable(
                name: "acl_user_usergroups");

            migrationBuilder.DropTable(
                name: "acl_usergroup_roles");

            migrationBuilder.DropTable(
                name: "acl_usergroups");

            migrationBuilder.DropTable(
                name: "acl_users");

            migrationBuilder.DropTable(
                name: "acl_usertype_submodules");

            migrationBuilder.DropTable(
                name: "failed_jobs");

            migrationBuilder.DropTable(
                name: "migrations");

            migrationBuilder.DropTable(
                name: "personal_access_tokens");
        }
    }
}
