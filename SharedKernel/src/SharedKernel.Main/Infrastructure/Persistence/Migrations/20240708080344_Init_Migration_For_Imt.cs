#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SharedKernel.App.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init_Migration_For_Imt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_banks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    display_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    url = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    logo = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: false, defaultValueSql: "'1'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    country_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    iso_code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_currencies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    iso_code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    symbol = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_customer_banks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    customer_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    country_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    city_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    bank_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    account_title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    account_no = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    branch_iban = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, comment: "can't delete if already exist"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    tckn = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "tckn is government national id"),
                    type = table.Column<sbyte>(type: "tinyint(4)", nullable: true, comment: "1=individual, 2=corporate etc"),
                    category = table.Column<sbyte>(type: "tinyint(4)", nullable: true, comment: "1=verified, 2=not verified, 3=verified+"),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, comment: "1=approved,2= not approvec, 3=active, 4=inactive, 5=suspended, 6=banned etc"),
                    dob = table.Column<DateTime>(type: "date", nullable: true),
                    address1 = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    address2 = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    username = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    customer_number = table.Column<int>(type: "int(20)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_money_transfers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    payment_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    transaction_state_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    reason_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    payment_method_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    transfer_type = table.Column<sbyte>(type: "tinyint(4)", nullable: true, comment: "1=instant, 2=regular, 3=same_day etc."),
                    reason_code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    type = table.Column<sbyte>(type: "tinyint(4)", nullable: true, comment: "type 1 = b2b, 2 = c2c, 3=c2b, 4=b2c etc"),
                    sender_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    receiver_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    sender_currency_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    receiver_currency_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    exchange_rate = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    send_amount = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    receive_amount = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    exchanged_amount = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    fee = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    vat = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    commission_paid_by = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    sender_customer_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    receiver_customer_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    source = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    order_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    remote_order_id = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    invoice_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_payment_methods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    method_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, comment: "must be soft delete, possible entries=> wallet, debit card, credit card etc"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_provider_commissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    provider_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    from_currency_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    to_currency_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    sender_commission_percentage = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    sender_commission_fixed = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    receiver_commission_percentage = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    receiver_commission_fixed = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_provider_error_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    imt_provider_id = table.Column<int>(type: "int(11)", nullable: false),
                    type = table.Column<sbyte>(type: "tinyint(4)", nullable: false, comment: "1: quotation,2: money_transfer"),
                    reference_id = table.Column<int>(type: "int(11)", nullable: false, comment: "type-reference table primary key id"),
                    error_code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    error_message = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_provider_payers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    imt_provider_id = table.Column<int>(type: "int(11)", nullable: false),
                    imt_country_id = table.Column<int>(type: "int(11)", nullable: false),
                    imt_currency_id = table.Column<int>(type: "int(11)", nullable: false),
                    imt_provider_service_id = table.Column<int>(type: "int(11)", nullable: true),
                    remote_payer_id = table.Column<int>(type: "int(11)", nullable: true),
                    precision = table.Column<sbyte>(type: "tinyint(4)", nullable: true, comment: "for declaring precision point after decimal"),
                    increment = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, comment: "still not clear, asked client"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_provider_services",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    imt_provider_id = table.Column<int>(type: "int(11)", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "BankAccount, WalletTransfer etc"),
                    created_by_id = table.Column<int>(type: "int(11)", nullable: true),
                    updated_by_id = table.Column<int>(type: "int(11)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_providers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    base_url = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    api_key = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "api key and secret must be encrypted"),
                    api_secret = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_quotations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    order_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    payer_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    mode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "DESTINATION_AMOUNT, SOURCE_AMOUNT"),
                    transaction_type = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, comment: "B2B,B2C,C2C,C2B"),
                    source_amount = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    imt_source_currency_id = table.Column<int>(type: "int(11)", nullable: true),
                    imt_provider_id = table.Column<int>(type: "int(11)", nullable: true),
                    imt_provider_service_id = table.Column<int>(type: "int(11)", nullable: true),
                    imt_source_country_id = table.Column<int>(type: "int(11)", nullable: true),
                    destination_amount = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    imt_destination_currency_id = table.Column<int>(type: "int(11)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_reasons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'0'", comment: "default value 0 means \"Others\""),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_transaction_limits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    transaction_type = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    user_category = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    daily_total_number = table.Column<int>(type: "int(11)", nullable: true),
                    daily_total_amount = table.Column<decimal>(type: "decimal(16,4)", precision: 16, scale: 4, nullable: true),
                    monthly_total_number = table.Column<int>(type: "int(11)", nullable: true),
                    monthly_total_amount = table.Column<decimal>(type: "decimal(16,4)", precision: 16, scale: 4, nullable: true),
                    currency_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_transaction_states",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, comment: "1=completed, 2=pending, 3=approved, 4="),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_transaction_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "send money, receive money, withdrawal etc"),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imt_transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    payment_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    customer_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    transaction_state_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    transaction_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    transaction_type = table.Column<sbyte>(type: "tinyint(4)", nullable: true, comment: "transaction_type = 1 for send, 2 for receive"),
                    money_flow = table.Column<sbyte>(type: "tinyint(4)", nullable: true, comment: "1 for incoming, 2 for outgoing"),
                    amount = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    fee = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    gross = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    currency_id = table.Column<int>(type: "int(11) unsigned", nullable: true),
                    current_balance = table.Column<decimal>(type: "decimal(16,4)", precision: 16, scale: 4, nullable: true),
                    previous_balance = table.Column<decimal>(type: "decimal(16,4)", precision: 16, scale: 4, nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, comment: "send money request, send money approved, etc"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                },
                comment: "transaction_type = 1,2,3; 1= send money, 2=receive money etc.transaction_id is sender table id.money_flow = 1/2; 1= incoming and 2 = outgoing, event_type = send money request, send money approved, send money rejected etc.")
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imt_banks");

            migrationBuilder.DropTable(
                name: "imt_cities");

            migrationBuilder.DropTable(
                name: "imt_countries");

            migrationBuilder.DropTable(
                name: "imt_currencies");

            migrationBuilder.DropTable(
                name: "imt_customer_banks");

            migrationBuilder.DropTable(
                name: "imt_customers");

            migrationBuilder.DropTable(
                name: "imt_money_transfers");

            migrationBuilder.DropTable(
                name: "imt_payment_methods");

            migrationBuilder.DropTable(
                name: "imt_provider_commissions");

            migrationBuilder.DropTable(
                name: "imt_provider_error_details");

            migrationBuilder.DropTable(
                name: "imt_provider_payers");

            migrationBuilder.DropTable(
                name: "imt_provider_services");

            migrationBuilder.DropTable(
                name: "imt_providers");

            migrationBuilder.DropTable(
                name: "imt_quotations");

            migrationBuilder.DropTable(
                name: "imt_reasons");

            migrationBuilder.DropTable(
                name: "imt_transaction_limits");

            migrationBuilder.DropTable(
                name: "imt_transaction_states");

            migrationBuilder.DropTable(
                name: "imt_transaction_types");

            migrationBuilder.DropTable(
                name: "imt_transactions");
        }
    }
}
