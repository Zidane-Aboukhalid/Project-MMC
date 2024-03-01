using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class eventupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileDescription",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "FileSizeInBytes",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Events",
                newName: "URL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "URL",
                table: "Events",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "FileDescription",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FileSizeInBytes",
                table: "Events",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
