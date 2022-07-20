using Microsoft.EntityFrameworkCore.Migrations;

namespace NewApiService.Migrations
{
    public partial class InitializeRoleUserNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NewsAuthor",
                table: "news",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_news_NewsAuthor",
                table: "news",
                column: "NewsAuthor");

            migrationBuilder.AddForeignKey(
                name: "FK_news_user_NewsAuthor",
                table: "news",
                column: "NewsAuthor",
                principalTable: "user",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_news_user_NewsAuthor",
                table: "news");

            migrationBuilder.DropIndex(
                name: "IX_news_NewsAuthor",
                table: "news");

            migrationBuilder.AlterColumn<string>(
                name: "NewsAuthor",
                table: "news",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
