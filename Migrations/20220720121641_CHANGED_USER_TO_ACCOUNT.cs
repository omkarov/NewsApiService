using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewApiService.Migrations
{
    public partial class CHANGED_USER_TO_ACCOUNT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_news_user_ApprovedBy",
                table: "news");

            migrationBuilder.DropForeignKey(
                name: "FK_news_user_NewsAuthor",
                table: "news");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    EmpId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsCount = table.Column<int>(type: "int", nullable: false),
                    UserIsApprovedByAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.EmpId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_news_account_ApprovedBy",
                table: "news",
                column: "ApprovedBy",
                principalTable: "account",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_news_account_NewsAuthor",
                table: "news",
                column: "NewsAuthor",
                principalTable: "account",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_news_account_ApprovedBy",
                table: "news");

            migrationBuilder.DropForeignKey(
                name: "FK_news_account_NewsAuthor",
                table: "news");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    EmpId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsCount = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserIsApprovedByAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_user_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_RoleId",
                table: "user",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_news_user_ApprovedBy",
                table: "news",
                column: "ApprovedBy",
                principalTable: "user",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_news_user_NewsAuthor",
                table: "news",
                column: "NewsAuthor",
                principalTable: "user",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
