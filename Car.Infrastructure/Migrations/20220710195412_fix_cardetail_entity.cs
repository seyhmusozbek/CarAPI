using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Car.Infrastructure.Migrations
{
    public partial class fix_cardetail_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "CarDetails");

            migrationBuilder.AddColumn<bool>(
                name: "Navigation",
                table: "CarDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4cb2f6a-4e61-4434-86c7-912b7474a39b", "AQAAAAEAACcQAAAAELDlMy4kY3UsfXA4Vt4LBNyOSpJuv0LpnpXDhTrS9HJq3I7jMMzWg4wGREjlBAIVGw==", "7cac1c34-123e-440c-a524-5e1fd2704e44" });

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "Navigation",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Navigation",
                table: "CarDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CarDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CarDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "CarDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4616dc0d-8bd0-4943-8af9-6fbebee4fcf1", "AQAAAAEAACcQAAAAEMsbsVAbBadjgmDXJLRV9ALLpGF9wyTs+8NQ6LZAkxAKznSLS0DMVBh/U6g0tlzEUA==", "f367238b-fa77-47e3-986a-533b5f965152" });

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "Year" },
                values: new object[] { new DateTime(2022, 7, 10, 22, 9, 8, 518, DateTimeKind.Local).AddTicks(7024), "Seyhmus", 2022 });
        }
    }
}
