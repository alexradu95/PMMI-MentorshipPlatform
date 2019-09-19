using Microsoft.EntityFrameworkCore.Migrations;

namespace Siemens.MP.Data.Migrations
{
    public partial class addedarticlecategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleCategory",
                table: "Articles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleCategory",
                table: "Articles");
        }
    }
}
