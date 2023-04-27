using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWordBlog.Migrations
{
    /// <inheritdoc />
    public partial class Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistred",
                table: "UsersRegistred",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Salary",
                table: "UsersRegistred",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRegistred",
                table: "UsersRegistred");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "UsersRegistred");
        }
    }
}
