using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACL.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAddedafterauthfromrifatvaiya : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "claims",
                table: "acl_users",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "refresh_token",
                table: "acl_users",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "salt",
                table: "acl_users",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "acl_users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "claims", "refresh_token", "salt" },
                values: new object[] { "[]", "{\"Value\":null,\"Active\":false,\"ExpirationDate\":\"0001-01-01T00:00:00\"}", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "claims",
                table: "acl_users");

            migrationBuilder.DropColumn(
                name: "refresh_token",
                table: "acl_users");

            migrationBuilder.DropColumn(
                name: "salt",
                table: "acl_users");
        }
    }
}
