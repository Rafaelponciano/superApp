using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveSuperHero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SuperHeroes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SuperHeroes");
        }
    }
}
