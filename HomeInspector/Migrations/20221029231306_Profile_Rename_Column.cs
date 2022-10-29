using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeInspector.Migrations
{
    public partial class Profile_Rename_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Devices_DeviceId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "Download",
                table: "Profiles",
                newName: "DownloadSpeed");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeviceId",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Devices_DeviceId",
                table: "Profiles",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Devices_DeviceId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "DownloadSpeed",
                table: "Profiles",
                newName: "Download");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeviceId",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Devices_DeviceId",
                table: "Profiles",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id");
        }
    }
}
