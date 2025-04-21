using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudMart.PartnersMicroservice.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RenameCompanyNameField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Partners_Name",
                table: "Partners",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Partners_Name",
                table: "Partners");
        }
    }
}
