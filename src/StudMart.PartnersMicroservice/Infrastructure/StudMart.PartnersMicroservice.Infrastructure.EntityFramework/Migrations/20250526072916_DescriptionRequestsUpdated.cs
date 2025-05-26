using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudMart.PartnersMicroservice.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionRequestsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionRequests_Partners_PartnerId",
                table: "DescriptionRequests");

            migrationBuilder.RenameColumn(
                name: "PartnerId",
                table: "DescriptionRequests",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_DescriptionRequests_PartnerId",
                table: "DescriptionRequests",
                newName: "IX_DescriptionRequests_EmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "DescriptionRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionRequests_Employees_EmployeeId",
                table: "DescriptionRequests",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionRequests_Employees_EmployeeId",
                table: "DescriptionRequests");

            migrationBuilder.DropColumn(
                name: "State",
                table: "DescriptionRequests");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "DescriptionRequests",
                newName: "PartnerId");

            migrationBuilder.RenameIndex(
                name: "IX_DescriptionRequests_EmployeeId",
                table: "DescriptionRequests",
                newName: "IX_DescriptionRequests_PartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionRequests_Partners_PartnerId",
                table: "DescriptionRequests",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
