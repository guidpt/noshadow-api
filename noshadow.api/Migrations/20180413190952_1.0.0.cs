using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace noshadow.api.Migrations
{
    public partial class _100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DeviceName = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DeviceId = table.Column<Guid>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    LogDate = table.Column<DateTime>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Speed = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_DeviceId",
                table: "Logs",
                column: "DeviceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
