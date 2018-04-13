using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace noshadow.api.Migrations
{
    public partial class _101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "Devices");

            migrationBuilder.AddColumn<string>(
                name: "DeviceId",
                table: "Devices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Devices");

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceName",
                table: "Devices",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
