using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ACL.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "acl_branches",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    status = table.Column<sbyte>(type: "tinyint(3) unsigned", nullable: false),
                    sequence = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    created_by_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "acl_companies",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    cname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    cemail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    address1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    address2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    postcode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    phone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    fax = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    city = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    state = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    country = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    logo = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    registration_no = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    timezone = table.Column<int>(type: "int(11)", nullable: false),
                    unique_column_name = table.Column<sbyte>(type: "tinyint(4)", nullable: false, defaultValueSql: "'1'", comment: "1=>email,2=>username"),
                    timezone_value = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    tax_no = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    tax_office = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: true),
                    sector = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: true),
                    average_turnover = table.Column<double>(type: "double(12,4)", nullable: false),
                    no_of_employees = table.Column<int>(type: "int(11)", nullable: false),
                    cmmi_level = table.Column<sbyte>(type: "tinyint(4)", nullable: false),
                    yearly_revenue = table.Column<double>(type: "double(12,4)", nullable: false),
                    hourly_rate = table.Column<double>(type: "double(12,4)", nullable: false),
                    daily_rate = table.Column<double>(type: "double(12,4)", nullable: false),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: false, defaultValueSql: "'1'", comment: "1=active,0=inactive"),
                    added_by = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'1'"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "acl_company_modules",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    company_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    module_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "acl_countries",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    status = table.Column<sbyte>(type: "tinyint(3) unsigned", nullable: false),
                    sequence = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    created_by_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "acl_modules",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    icon = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    sequence = table.Column<int>(type: "int(11)", nullable: false),
                    display_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "acl_page_routes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    page_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    route_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    route_url = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "acl_pages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    module_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    sub_module_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    method_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    method_type = table.Column<int>(type: "int(11)", nullable: false, comment: "1=Post, 2=Get, 3=Put, 4=Delete"),
                    available_to_company = table.Column<sbyte>(type: "tinyint(4)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "acl_role_pages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    role_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    page_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "acl_roles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: false, defaultValueSql: "'1'"),
                    company_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    created_by_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, comment: "creator auth ID"),
                    updated_by_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, comment: "approve auth ID"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "acl_states",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    status = table.Column<sbyte>(type: "tinyint(3) unsigned", nullable: false),
                    sequence = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    created_by_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "acl_sub_modules",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    module_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    controller_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    icon = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    sequence = table.Column<int>(type: "int(11)", nullable: false),
                    default_method = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    display_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "acl_user_usergroups",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    usergroup_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    user_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    company_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "acl_usergroup_roles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    usergroup_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    role_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    company_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "acl_usergroups",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    group_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    category = table.Column<sbyte>(type: "tinyint(4)", nullable: false, comment: "1 = Project manager, 2 = Developer, 3 = Reporter, 4 = Admin"),
                    dashboard_url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: false, defaultValueSql: "'1'"),
                    company_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "acl_users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    last_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    avatar = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    dob = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    gender = table.Column<sbyte>(type: "tinyint(4)", nullable: true, comment: "1=Male, 2=Female"),
                    address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    country = table.Column<int>(type: "int(10) unsigned", nullable: false),
                    phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    is_admin_verified = table.Column<sbyte>(type: "tinyint(4)", nullable: false, comment: "0=Pending, 1=Approved, 2=Not Approved, 3=Lock User"),
                    user_type = table.Column<int>(type: "int(10) unsigned", nullable: false, comment: "USER_TYPE_SS_ADMIN = 0; USER_TYPE_S_ADMIN = 1; USER_TYPE_USER = 2"),
                    remember_token = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    activated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    language = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false, defaultValueSql: "'en'"),
                    username = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    img_path = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: false, defaultValueSql: "'1'", comment: "0=>Inactive or disable; 1=>enable or active; 2=> disabled or suspected;3= awaiting disable or banned;4=awaiting GSM"),
                    company_id = table.Column<int>(type: "int(10) unsigned", nullable: false),
                    permission_version = table.Column<int>(type: "int(10) unsigned", nullable: false),
                    otp_channel = table.Column<sbyte>(type: "tinyint(4)", nullable: false, comment: "0 => all channel like sms, email, 1 => only sms, 2=> only email"),
                    login_at = table.Column<DateTime>(type: "datetime", nullable: true, comment: "user logged in time"),
                    created_by_id = table.Column<int>(type: "int(10) unsigned", nullable: false),
                    auth_identifier = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "acl_usertype_submodules",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_type_id = table.Column<sbyte>(type: "tinyint(3) unsigned", nullable: false),
                    sub_module_id = table.Column<int>(type: "int(10) unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "failed_jobs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    uuid = table.Column<string>(type: "varchar(255)", nullable: false),
                    connection = table.Column<string>(type: "text", nullable: false),
                    queue = table.Column<string>(type: "text", nullable: false),
                    payload = table.Column<string>(type: "longtext", nullable: false),
                    exception = table.Column<string>(type: "longtext", nullable: false),
                    failed_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "current_timestamp()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "migrations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    migration = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    batch = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "personal_access_tokens",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tokenable_type = table.Column<string>(type: "varchar(255)", nullable: false),
                    tokenable_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    token = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    abilities = table.Column<string>(type: "text", nullable: true),
                    last_used_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    expires_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.InsertData(
                table: "acl_branches",
                columns: new[] { "id", "address", "created_at", "created_by_id", "description", "name", "sequence", "status", "updated_at", "updated_by_id" },
                values: new object[] { 1L, "Dhaka", new DateTime(2015, 11, 4, 1, 52, 1, 0, DateTimeKind.Unspecified), 1L, "Test", "Test", 1L, (sbyte)1, new DateTime(2019, 3, 28, 13, 29, 33, 0, DateTimeKind.Unspecified), 1L });

            migrationBuilder.InsertData(
                table: "acl_companies",
                columns: new[] { "id", "added_by", "address1", "address2", "average_turnover", "cemail", "city", "cmmi_level", "cname", "country", "created_at", "daily_rate", "email", "fax", "hourly_rate", "logo", "name", "no_of_employees", "phone", "postcode", "registration_no", "sector", "state", "status", "tax_no", "tax_office", "timezone", "timezone_value", "unique_column_name", "updated_at", "yearly_revenue" },
                values: new object[] { 1L, 1, "A", "A2", 0.0, "ssadmin@softrobotics.com", "C", (sbyte)0, "Admin", "BD", new DateTime(2015, 11, 4, 1, 52, 1, 0, DateTimeKind.Unspecified), 0.0, "ssadmin@softrobotics.com", "Fax", 0.0, "logo", "Default", 6, "031", "4100", "420", null, "s", (sbyte)1, "tax", null, 254, "TimeZone", (sbyte)1, new DateTime(2019, 3, 28, 13, 29, 33, 0, DateTimeKind.Unspecified), 0.0 });

            migrationBuilder.InsertData(
                table: "acl_company_modules",
                columns: new[] { "id", "company_id", "created_at", "module_id", "updated_at" },
                values: new object[] { 1L, 1L, new DateTime(2015, 11, 4, 1, 52, 1, 0, DateTimeKind.Unspecified), 1001L, new DateTime(2019, 3, 28, 13, 29, 33, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "acl_countries",
                columns: new[] { "id", "code", "created_at", "created_by_id", "description", "name", "sequence", "status", "updated_at", "updated_by_id" },
                values: new object[] { 1L, "BD", new DateTime(2015, 11, 4, 1, 52, 1, 0, DateTimeKind.Unspecified), 2L, "This is beautiful country", "Bangladesh", 0L, (sbyte)1, new DateTime(2019, 3, 28, 13, 29, 33, 0, DateTimeKind.Unspecified), 2L });

            migrationBuilder.InsertData(
                table: "acl_modules",
                columns: new[] { "id", "created_at", "display_name", "icon", "name", "sequence", "updated_at" },
                values: new object[,]
                {
                    { 1001L, new DateTime(2015, 12, 9, 12, 10, 46, 0, DateTimeKind.Unspecified), "Company", "<i class=\"fa fa-list-ul\"></i>", "Company", 6, new DateTime(2019, 3, 20, 21, 52, 50, 0, DateTimeKind.Unspecified) },
                    { 1002L, new DateTime(2015, 12, 9, 12, 10, 46, 0, DateTimeKind.Unspecified), "Master Data", "<i class=\"fa fa-list-ul\"></i>", "Master Data", 2, new DateTime(2019, 3, 26, 22, 38, 37, 0, DateTimeKind.Unspecified) },
                    { 1003L, new DateTime(2015, 12, 9, 12, 10, 47, 0, DateTimeKind.Unspecified), "Access Control", "<img src=\"adminca/assets/img/icons/access-control.svg\" />", "Access Control", 1099, new DateTime(2016, 8, 6, 16, 24, 34, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "acl_page_routes",
                columns: new[] { "id", "created_at", "page_id", "route_name", "route_url", "updated_at" },
                values: new object[,]
                {
                    { 1L, null, 3001L, "acl.company.list", "companies", null },
                    { 2L, null, 3002L, "acl.company.add", "companies/add", null },
                    { 3L, null, 3003L, "acl.company.edit", "companies/edit/{id}", null },
                    { 4L, null, 3004L, "acl.company.destroy", "companies/delete/{id}", null },
                    { 5L, null, 3005L, "acl.company.show", "companies/view/{id}", null },
                    { 6L, null, 3015L, "acl.module.list", "modules", null },
                    { 7L, null, 3016L, "acl.module.add", "modules/add", null },
                    { 8L, null, 3017L, "acl.module.edit", "modules/edit/{id}", null },
                    { 9L, null, 3018L, "acl.module.destroy", "modules/delete/{id}", null },
                    { 10L, null, 3019L, "acl.module.view", "modules/view/{id}", null },
                    { 11L, null, 3080L, "acl.company_module.list", "company/modules", null },
                    { 12L, null, 3081L, "acl.company_module.add", "company/modules/add", null },
                    { 13L, null, 3082L, "acl.company_module.edit", "company/modules/edit/{id}", null },
                    { 14L, null, 3083L, "acl.company_module.destroy", "company/modules/delete/{id}", null },
                    { 15L, null, 3084L, "acl.company_module.view", "company/modules/view/{id}", null },
                    { 16L, null, 3025L, "acl.submodule.list", "submodules", null },
                    { 17L, null, 3026L, "acl.submodule.add", "submodules/add", null },
                    { 18L, null, 3027L, "acl.submodule.edit", "submodules/edit/{id}", null },
                    { 19L, null, 3028L, "acl.submodule.destroy", "submodules/delete/{id}", null },
                    { 20L, null, 3029L, "acl.submodule.view", "submodules/view/{id}", null },
                    { 21L, null, 3035L, "acl.page.list", "pages", null },
                    { 22L, null, 3036L, "acl.page.add", "pages/add", null },
                    { 23L, null, 3037L, "acl.page.edit", "pages/edit/{id}", null },
                    { 24L, null, 3038L, "acl.page.destroy", "pages/delete/{id}", null },
                    { 25L, null, 3039L, "acl.page.view", "pages/view/{id}", null },
                    { 26L, null, 3045L, "acl.user.list", "users", null },
                    { 27L, null, 3046L, "acl.user.add", "users/add", null },
                    { 28L, null, 3047L, "acl.user.edit", "users/edit/{id}", null },
                    { 29L, null, 3048L, "acl.user.destroy", "users/delete/{id}", null },
                    { 30L, null, 3049L, "acl.user.view", "users/view/{id}", null },
                    { 31L, null, 3055L, "acl.role.list", "roles", null },
                    { 32L, null, 3056L, "acl.role.add", "roles/add", null },
                    { 33L, null, 3057L, "acl.role.edit", "roles/edit/{id}", null },
                    { 34L, null, 3058L, "acl.role.destroy", "roles/delete/{id}", null },
                    { 35L, null, 3059L, "acl.role.view", "roles/view/{id}", null },
                    { 36L, null, 3065L, "acl.usergroups.list", "usergroups", null },
                    { 37L, null, 3066L, "acl.usergroups.add", "usergroups/add", null },
                    { 38L, null, 3067L, "acl.usergroups.edit", "usergroups/edit/{id}", null },
                    { 39L, null, 3068L, "acl.usergroups.destroy", "usergroups/delete/{id}", null },
                    { 40L, null, 3069L, "acl.usergroups.view", "usergroups/view/{id}", null },
                    { 41L, null, 3075L, "acl.usergroups.role.association", "usergroups/roles/{user_group_id}", null },
                    { 42L, null, 3076L, "acl.usergroups.role.association.update", "usergroups/roles/update", null },
                    { 43L, null, 3078L, "acl.role&page.association", "permissions/associations/{role_id}", null },
                    { 44L, null, 3079L, "acl.role&page.association.update", "permissions/associations/update", null },
                    { 45L, null, 3036L, "acl.page.route.add", "pages/routes/add", null },
                    { 46L, null, 3037L, "acl.page.route.edit", "pages/routes/edit/{id}", null },
                    { 47L, null, 3038L, "acl.page.route.destroy", "pages/routes/delete/{id}", null }
                });

            migrationBuilder.InsertData(
                table: "acl_pages",
                columns: new[] { "id", "available_to_company", "created_at", "method_name", "method_type", "module_id", "name", "sub_module_id", "updated_at" },
                values: new object[,]
                {
                    { 3001L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 51, 0, DateTimeKind.Unspecified), "index", 0, 1001L, "Company List", 2001L, new DateTime(2015, 12, 9, 12, 10, 51, 0, DateTimeKind.Unspecified) },
                    { 3002L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "create", 0, 1001L, "Add New Company", 2001L, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified) },
                    { 3003L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "edit", 2, 1001L, "Modify Company", 2001L, new DateTime(2019, 3, 27, 15, 3, 28, 0, DateTimeKind.Unspecified) },
                    { 3004L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "destroy", 2, 1001L, "Delete Company", 2001L, new DateTime(2019, 3, 26, 22, 42, 31, 0, DateTimeKind.Unspecified) },
                    { 3005L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "show", 0, 1001L, "View Company", 2001L, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified) },
                    { 3015L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 53, 0, DateTimeKind.Unspecified), "index", 0, 1002L, "Module List", 2020L, new DateTime(2015, 12, 9, 12, 10, 53, 0, DateTimeKind.Unspecified) },
                    { 3016L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 53, 0, DateTimeKind.Unspecified), "create", 0, 1002L, "Add New Module", 2020L, new DateTime(2015, 12, 9, 12, 10, 53, 0, DateTimeKind.Unspecified) },
                    { 3017L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 53, 0, DateTimeKind.Unspecified), "edit", 0, 1002L, "Modify Module", 2020L, new DateTime(2015, 12, 9, 12, 10, 53, 0, DateTimeKind.Unspecified) },
                    { 3018L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified), "destroy", 0, 1002L, "Delete Module", 2020L, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified) },
                    { 3019L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified), "view", 0, 1002L, "View Module", 2020L, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified) },
                    { 3025L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified), "index", 0, 1002L, "Submodule List", 2021L, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified) },
                    { 3026L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified), "create", 0, 1002L, "Add New Submodule", 2021L, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified) },
                    { 3027L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified), "edit", 0, 1002L, "Modify Submodule", 2021L, new DateTime(2015, 12, 9, 12, 10, 54, 0, DateTimeKind.Unspecified) },
                    { 3028L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 55, 0, DateTimeKind.Unspecified), "destroy", 0, 1002L, "Delete Submodule", 2021L, new DateTime(2015, 12, 9, 12, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 3029L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 55, 0, DateTimeKind.Unspecified), "view", 0, 1002L, "View Submodule", 2021L, new DateTime(2015, 12, 9, 12, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 3035L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 55, 0, DateTimeKind.Unspecified), "index", 0, 1002L, "Page List", 2022L, new DateTime(2015, 12, 9, 12, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 3036L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 55, 0, DateTimeKind.Unspecified), "create", 0, 1002L, "Add New Page", 2022L, new DateTime(2016, 1, 21, 10, 44, 25, 0, DateTimeKind.Unspecified) },
                    { 3037L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified), "edit", 0, 1002L, "Modify Page", 2022L, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified) },
                    { 3038L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified), "destroy", 0, 1002L, "Delete Page", 2022L, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified) },
                    { 3039L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified), "view", 0, 1002L, "View Page", 2022L, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified) },
                    { 3045L, (sbyte)1, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified), "index", 0, 1003L, "User List", 2050L, new DateTime(2015, 12, 9, 12, 10, 56, 0, DateTimeKind.Unspecified) },
                    { 3046L, (sbyte)1, new DateTime(2015, 12, 9, 12, 10, 57, 0, DateTimeKind.Unspecified), "create", 0, 1003L, "User Add", 2050L, new DateTime(2015, 12, 9, 12, 10, 57, 0, DateTimeKind.Unspecified) },
                    { 3047L, (sbyte)1, new DateTime(2015, 12, 9, 12, 10, 57, 0, DateTimeKind.Unspecified), "edit", 0, 1003L, "User Edit", 2050L, new DateTime(2015, 12, 9, 12, 10, 57, 0, DateTimeKind.Unspecified) },
                    { 3048L, (sbyte)1, new DateTime(2015, 12, 9, 12, 10, 57, 0, DateTimeKind.Unspecified), "destroy", 0, 1003L, "User Delete", 2050L, new DateTime(2015, 12, 9, 12, 10, 57, 0, DateTimeKind.Unspecified) },
                    { 3049L, (sbyte)0, new DateTime(2015, 11, 22, 23, 13, 47, 0, DateTimeKind.Unspecified), "view", 0, 1003L, "User View", 2050L, new DateTime(2015, 11, 22, 23, 13, 47, 0, DateTimeKind.Unspecified) },
                    { 3055L, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 2, 0, DateTimeKind.Unspecified), "index", 0, 1003L, "Role List", 2051L, new DateTime(2015, 12, 9, 12, 12, 2, 0, DateTimeKind.Unspecified) },
                    { 3056L, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 2, 0, DateTimeKind.Unspecified), "create", 0, 1003L, "Role Add", 2051L, new DateTime(2015, 12, 9, 12, 12, 2, 0, DateTimeKind.Unspecified) },
                    { 3057L, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified), "edit", 0, 1003L, "Role Edit", 2051L, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified) },
                    { 3058L, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified), "destroy", 0, 1003L, "Role Delete", 2051L, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified) },
                    { 3059L, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified), "view", 0, 1003L, "Role View", 2051L, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified) },
                    { 3065L, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified), "index", 0, 1003L, "UserGroup List", 2052L, new DateTime(2015, 12, 9, 12, 12, 3, 0, DateTimeKind.Unspecified) },
                    { 3066L, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified), "create", 0, 1003L, "UserGroup Add", 2052L, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified) },
                    { 3067L, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified), "edit", 0, 1003L, "UserGroup Edit", 2052L, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified) },
                    { 3068L, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified), "destroy", 0, 1003L, "UserGroup Delete", 2052L, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified) },
                    { 3069L, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified), "view", 0, 1003L, "UserGroup View", 2052L, new DateTime(2015, 12, 9, 12, 12, 4, 0, DateTimeKind.Unspecified) },
                    { 3075L, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 5, 0, DateTimeKind.Unspecified), "index", 0, 1003L, "Usergroup Role Association", 2053L, new DateTime(2015, 12, 9, 12, 12, 5, 0, DateTimeKind.Unspecified) },
                    { 3076L, (sbyte)1, new DateTime(2021, 12, 9, 15, 10, 51, 0, DateTimeKind.Unspecified), "edit", 0, 1003L, "Usergroup & Role Association Update", 2053L, new DateTime(2021, 12, 9, 15, 10, 51, 0, DateTimeKind.Unspecified) },
                    { 3078L, (sbyte)1, new DateTime(2015, 12, 9, 12, 12, 5, 0, DateTimeKind.Unspecified), "index", 0, 1003L, "Role & Page Association", 2054L, new DateTime(2015, 12, 9, 12, 12, 5, 0, DateTimeKind.Unspecified) },
                    { 3079L, (sbyte)1, new DateTime(2021, 12, 9, 15, 10, 51, 0, DateTimeKind.Unspecified), "edit", 0, 1003L, "Role & Page Association Update", 2054L, new DateTime(2021, 12, 9, 15, 10, 51, 0, DateTimeKind.Unspecified) },
                    { 3080L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 51, 0, DateTimeKind.Unspecified), "index", 0, 1003L, "Company Module List", 2055L, new DateTime(2015, 12, 9, 12, 10, 51, 0, DateTimeKind.Unspecified) },
                    { 3081L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "create", 0, 1003L, "Add New Company Module", 2055L, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified) },
                    { 3082L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "edit", 2, 1003L, "Modify Company Module", 2055L, new DateTime(2019, 3, 27, 15, 3, 28, 0, DateTimeKind.Unspecified) },
                    { 3083L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "destroy", 2, 1003L, "Delete Company Module", 2055L, new DateTime(2019, 3, 26, 22, 42, 31, 0, DateTimeKind.Unspecified) },
                    { 3084L, (sbyte)0, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified), "show", 0, 1003L, "View Company Module", 2055L, new DateTime(2015, 12, 9, 12, 10, 52, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "acl_role_pages",
                columns: new[] { "id", "created_at", "page_id", "role_id", "updated_at" },
                values: new object[,]
                {
                    { 1L, null, 3001L, 1L, null },
                    { 2L, null, 3002L, 1L, null },
                    { 3L, null, 3003L, 1L, null },
                    { 4L, null, 3004L, 1L, null },
                    { 5L, null, 3005L, 1L, null },
                    { 6L, null, 3015L, 1L, null },
                    { 7L, null, 3016L, 1L, null },
                    { 8L, null, 3017L, 1L, null },
                    { 9L, null, 3018L, 1L, null },
                    { 10L, null, 3019L, 1L, null },
                    { 11L, null, 3025L, 1L, null },
                    { 12L, null, 3026L, 1L, null },
                    { 13L, null, 3027L, 1L, null },
                    { 14L, null, 3028L, 1L, null },
                    { 15L, null, 3029L, 1L, null },
                    { 16L, null, 3035L, 1L, null },
                    { 17L, null, 3036L, 1L, null },
                    { 18L, null, 3037L, 1L, null },
                    { 19L, null, 3038L, 1L, null },
                    { 20L, null, 3039L, 1L, null },
                    { 21L, null, 3080L, 1L, null },
                    { 22L, null, 3081L, 1L, null },
                    { 23L, null, 3082L, 1L, null },
                    { 24L, null, 3083L, 1L, null },
                    { 25L, null, 3084L, 1L, null }
                });

            migrationBuilder.InsertData(
                table: "acl_roles",
                columns: new[] { "id", "company_id", "created_at", "created_by_id", "name", "status", "title", "updated_at", "updated_by_id" },
                values: new object[] { 1L, 1L, new DateTime(2019, 3, 21, 20, 38, 30, 0, DateTimeKind.Unspecified), null, "", (sbyte)1, "super-super-admin", new DateTime(2015, 11, 9, 7, 17, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "acl_states",
                columns: new[] { "id", "created_at", "created_by_id", "description", "name", "sequence", "status", "updated_at", "updated_by_id" },
                values: new object[] { 1L, new DateTime(2019, 3, 22, 8, 38, 12, 0, DateTimeKind.Unspecified), 1L, "Dhaka city of BD", "Dhaka", 100L, (sbyte)1, new DateTime(2023, 11, 1, 19, 17, 0, 0, DateTimeKind.Unspecified), 1L });

            migrationBuilder.InsertData(
                table: "acl_sub_modules",
                columns: new[] { "id", "controller_name", "created_at", "default_method", "display_name", "icon", "module_id", "name", "sequence", "updated_at" },
                values: new object[,]
                {
                    { 2001L, "CompanyController", new DateTime(2015, 12, 9, 12, 10, 47, 0, DateTimeKind.Unspecified), "index", "Company Management", "<i class=\"fa fa-angle-double-right\"></i>", 1001L, "Company Management", 100, new DateTime(2015, 12, 9, 12, 10, 47, 0, DateTimeKind.Unspecified) },
                    { 2020L, "ModuleController", new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified), "index", "Module Management", "<i class=\"fa fa-angle-double-right\"></i>", 1002L, "Module Management", 100, new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified) },
                    { 2021L, "SubModuleController", new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified), "index", "Sub Module Management", "<i class=\"fa fa-angle-double-right\"></i>", 1002L, "Sub Module Management", 101, new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified) },
                    { 2022L, "PageController", new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified), "index", "Page Management", "<i class=\"fa fa-angle-double-right\"></i>", 1002L, "Page Management", 102, new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified) },
                    { 2050L, "UserController", new DateTime(2015, 12, 9, 12, 10, 49, 0, DateTimeKind.Unspecified), "index", "User Management", "<i class=\"fa fa-angle-double-right\"></i>", 1003L, "User Management", 18, new DateTime(2015, 12, 9, 12, 10, 49, 0, DateTimeKind.Unspecified) },
                    { 2051L, "RoleController", new DateTime(2015, 12, 9, 12, 10, 49, 0, DateTimeKind.Unspecified), "index", "Role Management", "<i class=\"fa fa-angle-double-right\"></i>", 1003L, "Role Management", 101, new DateTime(2015, 12, 23, 14, 35, 45, 0, DateTimeKind.Unspecified) },
                    { 2052L, "UsergroupController", new DateTime(2015, 12, 9, 12, 10, 49, 0, DateTimeKind.Unspecified), "index", "User Group Management", "<i class=\"fa fa-angle-double-right\"></i>", 1003L, "User Group Management", 102, new DateTime(2015, 12, 9, 12, 10, 49, 0, DateTimeKind.Unspecified) },
                    { 2053L, "UsergroupRoleController", new DateTime(2015, 12, 9, 12, 10, 49, 0, DateTimeKind.Unspecified), "index", "Usergroup & Role Association", "<i class=\"fa fa-angle-double-right\"></i>", 1003L, "Usergroup & Role Association", 103, new DateTime(2015, 12, 9, 12, 10, 49, 0, DateTimeKind.Unspecified) },
                    { 2054L, "RolePageController", new DateTime(2015, 12, 9, 12, 10, 50, 0, DateTimeKind.Unspecified), "index", "Role & Page Association", "<i class=\"fa fa-angle-double-right\"></i>", 1003L, "Role & Page Association", 104, new DateTime(2015, 12, 9, 12, 10, 50, 0, DateTimeKind.Unspecified) },
                    { 2055L, "CompanyModuleController", new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified), "index", "Company Module Management", "<i class=\"fa fa-angle-double-right\"></i>", 1003L, "Company Module Management", 105, new DateTime(2015, 12, 9, 12, 10, 48, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "acl_user_usergroups",
                columns: new[] { "id", "company_id", "created_at", "updated_at", "user_id", "usergroup_id" },
                values: new object[] { 1L, 1L, new DateTime(2024, 1, 24, 7, 23, 21, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 24, 7, 23, 23, 0, DateTimeKind.Unspecified), 1L, 1L });

            migrationBuilder.InsertData(
                table: "acl_usergroup_roles",
                columns: new[] { "id", "company_id", "created_at", "role_id", "updated_at", "usergroup_id" },
                values: new object[] { 1L, 1L, null, 1L, null, 1L });

            migrationBuilder.InsertData(
                table: "acl_usergroups",
                columns: new[] { "id", "category", "company_id", "created_at", "dashboard_url", "group_name", "status", "updated_at" },
                values: new object[] { 1L, (sbyte)0, 1L, new DateTime(2019, 3, 22, 8, 38, 12, 0, DateTimeKind.Unspecified), null, "super-super-admin-group", (sbyte)1, new DateTime(2023, 11, 1, 19, 17, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "acl_users",
                columns: new[] { "id", "activated_at", "address", "auth_identifier", "avatar", "city", "company_id", "country", "created_at", "created_by_id", "dob", "email", "first_name", "gender", "img_path", "is_admin_verified", "language", "last_name", "login_at", "otp_channel", "password", "permission_version", "phone", "remember_token", "status", "updated_at", "user_type", "username" },
                values: new object[] { 1L, null, "Dhaka", null, "users/admin/c41353d1c1fcbdbd39f96ea46a3f769136952e79.png", "19", 1, 0, new DateTime(2018, 7, 10, 16, 21, 24, 0, DateTimeKind.Unspecified), 1, new DateTime(1994, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ssadmin@sipay.com.tr", "admin1", (sbyte)1, "storage/users/1/2019-04-18-07-49-28-ba4fe9be59df7b82f8243d2126070d76f5305b3e.png", (sbyte)1, "en", "admin1", null, (sbyte)0, "Nop@ss1234", 1, "+8801788343704", "", (sbyte)1, new DateTime(2021, 8, 25, 5, 46, 27, 0, DateTimeKind.Unspecified), 0, "rajibecbb" });

            migrationBuilder.InsertData(
                table: "acl_usertype_submodules",
                columns: new[] { "id", "created_at", "sub_module_id", "updated_at", "user_type_id" },
                values: new object[,]
                {
                    { 1L, null, 2001, null, (sbyte)0 },
                    { 2L, null, 2020, null, (sbyte)0 },
                    { 3L, null, 2021, null, (sbyte)0 },
                    { 4L, null, 2022, null, (sbyte)0 },
                    { 5L, null, 2050, null, (sbyte)1 },
                    { 6L, null, 2051, null, (sbyte)1 },
                    { 7L, null, 2052, null, (sbyte)1 },
                    { 8L, null, 2053, null, (sbyte)1 },
                    { 9L, null, 2054, null, (sbyte)1 }
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
                name: "_efmigrationshistory");

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
