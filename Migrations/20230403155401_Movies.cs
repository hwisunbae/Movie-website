using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class Movies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumInStock",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateAdded", "Genre", "Name", "NumInStock", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2016, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comedy", "Hangover", 5, new DateTime(2016, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2012, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action", "Die Hard", 10, new DateTime(2011, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action", "The Terminator", 6, new DateTime(2022, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2016, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family", "Toy Story", 2, new DateTime(2017, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romance", "Titanic", 9, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "NumInStock",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movies");
        }
    }
}
