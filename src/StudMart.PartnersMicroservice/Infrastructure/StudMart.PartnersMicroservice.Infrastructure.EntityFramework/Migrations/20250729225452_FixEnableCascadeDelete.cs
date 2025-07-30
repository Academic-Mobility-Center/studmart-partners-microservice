using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudMart.PartnersMicroservice.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class FixEnableCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Partners_PartnerId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Partners_Categories_CategoryId",
                table: "Partners");

            migrationBuilder.DropForeignKey(
                name: "FK_Partners_Countries_CountryId",
                table: "Partners");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Partners_PartnerId",
                table: "Employees",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Categories_CategoryId",
                table: "Partners",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Countries_CountryId",
                table: "Partners",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Partners_PartnerId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Partners_Categories_CategoryId",
                table: "Partners");

            migrationBuilder.DropForeignKey(
                name: "FK_Partners_Countries_CountryId",
                table: "Partners");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Partners_PartnerId",
                table: "Employees",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Categories_CategoryId",
                table: "Partners",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Countries_CountryId",
                table: "Partners",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
