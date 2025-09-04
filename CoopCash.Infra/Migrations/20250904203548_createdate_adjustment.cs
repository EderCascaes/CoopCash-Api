using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoopCash.Infra.Migrations
{
    /// <inheritdoc />
    public partial class createdate_adjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CraeteDate",
                table: "User",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CraeteDate",
                table: "Invoices",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CraeteDate",
                table: "InvoiceItems",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CraeteDate",
                table: "Companies",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CraeteDate",
                table: "Categories",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CraeteDate",
                table: "CardMachines",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CraeteDate",
                table: "Associates",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CraeteDate",
                table: "AssociateCards",
                newName: "CreateDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "User",
                newName: "CraeteDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Invoices",
                newName: "CraeteDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "InvoiceItems",
                newName: "CraeteDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Companies",
                newName: "CraeteDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Categories",
                newName: "CraeteDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "CardMachines",
                newName: "CraeteDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Associates",
                newName: "CraeteDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "AssociateCards",
                newName: "CraeteDate");
        }
    }
}
