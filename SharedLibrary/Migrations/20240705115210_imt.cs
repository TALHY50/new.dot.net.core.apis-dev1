using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SharedLibrary.Migrations
{
    /// <inheritdoc />
    public partial class imt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "imt_provider_error_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ImtProviderId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<sbyte>(type: "tinyint", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: false),
                    ErrorCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    ErrorMessage = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imt_provider_error_details", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imt_provider_error_details");
        }
    }
}
