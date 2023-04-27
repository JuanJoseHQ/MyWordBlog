using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWordBlog.Migrations
{
    /// <inheritdoc />
    public partial class NewEntities_Comentary_Post : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comentaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DatePublication = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Desctipton = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    CantLikes = table.Column<int>(type: "int", nullable: true),
                    CantDisLikes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_Title",
                table: "Post",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentaries");

            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
