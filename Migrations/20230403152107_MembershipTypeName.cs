using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class MembershipTypeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MembershipType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "MembershipType",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "Name",
                value: "Pay as You Go");

            migrationBuilder.UpdateData(
                table: "MembershipType",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "Name",
                value: "Monthly");

            migrationBuilder.UpdateData(
                table: "MembershipType",
                keyColumn: "Id",
                keyValue: (byte)3,
                column: "Name",
                value: "Quarterly");

            migrationBuilder.UpdateData(
                table: "MembershipType",
                keyColumn: "Id",
                keyValue: (byte)4,
                column: "Name",
                value: "Yearly");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MembershipType");
        }
    }
}
