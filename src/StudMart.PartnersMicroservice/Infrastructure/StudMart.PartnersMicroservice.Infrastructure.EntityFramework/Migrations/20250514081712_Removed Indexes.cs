using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudMart.PartnersMicroservice.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RemovedIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Partners_Email",
                table: "Partners");

            migrationBuilder.DropIndex(
                name: "IX_Partners_Inn",
                table: "Partners");

            migrationBuilder.DropIndex(
                name: "IX_Partners_Phone",
                table: "Partners");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Partners_Email",
                table: "Partners",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partners_Inn",
                table: "Partners",
                column: "Inn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partners_Phone",
                table: "Partners",
                column: "Phone",
                unique: true);
        }
    }
}
