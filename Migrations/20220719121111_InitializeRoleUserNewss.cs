using Microsoft.EntityFrameworkCore.Migrations;

namespace NewApiService.Migrations
{
    public partial class InitializeRoleUserNewss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "news",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_RoleId",
                table: "user",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_news_ApprovedBy",
                table: "news",
                column: "ApprovedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_news_user_ApprovedBy",
                table: "news",
                column: "ApprovedBy",
                principalTable: "user",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_user_role_RoleId",
                table: "user",
                column: "RoleId",
                principalTable: "role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_news_user_ApprovedBy",
                table: "news");

            migrationBuilder.DropForeignKey(
                name: "FK_user_role_RoleId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_RoleId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_news_ApprovedBy",
                table: "news");

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "news",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
