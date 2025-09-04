using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoopCash.Infra.Migrations
{
    /// <inheritdoc />
    public partial class createdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CraeteDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CraeteDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CraeteDate",
                table: "InvoiceItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CraeteDate",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CraeteDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CraeteDate",
                table: "CardMachines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CraeteDate",
                table: "Associates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CraeteDate",
                table: "AssociateCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CraeteDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CraeteDate",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CraeteDate",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "CraeteDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CraeteDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CraeteDate",
                table: "CardMachines");

            migrationBuilder.DropColumn(
                name: "CraeteDate",
                table: "Associates");

            migrationBuilder.DropColumn(
                name: "CraeteDate",
                table: "AssociateCards");
        }
    }
}
