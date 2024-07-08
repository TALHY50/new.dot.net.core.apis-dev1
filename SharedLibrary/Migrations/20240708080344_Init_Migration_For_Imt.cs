using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SharedLibrary.Migrations
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
                    code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, defaultValueSql: "'NULL'"),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    display_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    url = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    logo = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, defaultValueSql: "'NULL'"),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: false, defaultValueSql: "'1'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, defaultValueSql: "'NULL'"),
                    country_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    iso_code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, defaultValueSql: "'NULL'"),
                    iso_code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, defaultValueSql: "'NULL'"),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    symbol = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    customer_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    country_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    city_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    bank_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    account_title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    account_no = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    branch_iban = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'", comment: "can't delete if already exist"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    first_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, defaultValueSql: "'NULL'"),
                    tckn = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'", comment: "tckn is government national id"),
                    type = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'", comment: "1=individual, 2=corporate etc"),
                    category = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'", comment: "1=verified, 2=not verified, 3=verified+"),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'", comment: "1=approved,2= not approvec, 3=active, 4=inactive, 5=suspended, 6=banned etc"),
                    dob = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "'NULL'"),
                    address1 = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    address2 = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    username = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    customer_number = table.Column<int>(type: "int(20)", nullable: true, defaultValueSql: "'NULL'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    payment_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    transaction_state_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    reason_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    payment_method_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    transfer_type = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'", comment: "1=instant, 2=regular, 3=same_day etc."),
                    reason_code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, defaultValueSql: "'NULL'"),
                    type = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'", comment: "type 1 = b2b, 2 = c2c, 3=c2b, 4=b2c etc"),
                    sender_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    receiver_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    sender_currency_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    receiver_currency_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    exchange_rate = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    send_amount = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    receive_amount = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    exchanged_amount = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    fee = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    vat = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    commission_paid_by = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    sender_customer_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    receiver_customer_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    source = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    order_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    remote_order_id = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true, defaultValueSql: "'NULL'"),
                    invoice_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    method_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'", comment: "must be soft delete, possible entries=> wallet, debit card, credit card etc"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    provider_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    from_currency_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    to_currency_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    sender_commission_percentage = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    sender_commission_fixed = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    receiver_commission_percentage = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    receiver_commission_fixed = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    error_code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, defaultValueSql: "'NULL'"),
                    error_message = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    imt_provider_service_id = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    remote_payer_id = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    precision = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'", comment: "for declaring precision point after decimal"),
                    increment = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'", comment: "still not clear, asked client"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'", comment: "BankAccount, WalletTransfer etc"),
                    created_by_id = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    updated_by_id = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    base_url = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    api_key = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'", comment: "api key and secret must be encrypted"),
                    api_secret = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'"),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    source_amount = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    imt_source_currency_id = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    imt_provider_id = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    imt_provider_service_id = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    imt_source_country_id = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    destination_amount = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    imt_destination_currency_id = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, defaultValueSql: "'NULL'"),
                    title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'0'", comment: "default value 0 means \"Others\""),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    transaction_type = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'"),
                    user_category = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'"),
                    daily_total_number = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    daily_total_amount = table.Column<decimal>(type: "decimal(16,4)", precision: 16, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    monthly_total_number = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    monthly_total_amount = table.Column<decimal>(type: "decimal(16,4)", precision: 16, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    currency_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'", comment: "1=completed, 2=pending, 3=approved, 4="),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'", comment: "send money, receive money, withdrawal etc"),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'"),
                    created_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    updated_by_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
                    payment_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    customer_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    transaction_state_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    transaction_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    transaction_type = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'", comment: "transaction_type = 1 for send, 2 for receive"),
                    money_flow = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'", comment: "1 for incoming, 2 for outgoing"),
                    amount = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    fee = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    gross = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    currency_id = table.Column<int>(type: "int(11) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    current_balance = table.Column<decimal>(type: "decimal(16,4)", precision: 16, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    previous_balance = table.Column<decimal>(type: "decimal(16,4)", precision: 16, scale: 4, nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'NULL'", comment: "send money request, send money approved, etc"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
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
