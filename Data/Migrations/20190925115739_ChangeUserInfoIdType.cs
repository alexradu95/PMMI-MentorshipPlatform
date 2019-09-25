using Microsoft.EntityFrameworkCore.Migrations;

namespace Siemens.MP.Data.Migrations
{
    public partial class ChangeUserInfoIdType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_UserInfoId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserInfoId1",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserInfoId1",
                table: "Tasks");

            migrationBuilder.AlterColumn<string>(
                name: "UserInfoId",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserInfoId",
                table: "Tasks",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_UserInfoId",
                table: "Tasks",
                column: "UserInfoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_UserInfoId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserInfoId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "UserInfoId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserInfoId1",
                table: "Tasks",
                type: "nvarchar(450)",
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
    }
}
