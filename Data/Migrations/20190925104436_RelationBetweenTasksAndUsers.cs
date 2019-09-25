using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Siemens.MP.Data.Migrations
{
    public partial class RelationBetweenTasksAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IdAsignee",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IdReporter",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserInfoId1",
                table: "Tasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserInfoId1",
                table: "Tasks",
                column: "UserInfoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_UserInfoId1",
                table: "Tasks",
                column: "UserInfoId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_UserInfoId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserInfoId1",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserInfoId1",
                table: "Tasks");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdAsignee",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdReporter",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
