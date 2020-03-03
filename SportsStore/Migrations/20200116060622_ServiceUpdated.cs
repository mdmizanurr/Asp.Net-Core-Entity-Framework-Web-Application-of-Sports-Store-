using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsStore.Migrations
{
    public partial class ServiceUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Orders_OrderID",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_OrderID",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Services");

            migrationBuilder.AlterColumn<string>(
                name: "ReciveDate",
                table: "Services",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReciveDate",
                table: "Services",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Services",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_OrderID",
                table: "Services",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Orders_OrderID",
                table: "Services",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
