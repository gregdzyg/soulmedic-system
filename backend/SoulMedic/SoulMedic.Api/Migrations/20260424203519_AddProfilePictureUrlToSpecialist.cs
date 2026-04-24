using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulMedic.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilePictureUrlToSpecialist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "Specialists",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "Specialists");
        }
    }
}
