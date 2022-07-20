using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewApiService.Migrations
{
    public partial class InitializeRoleUserNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "news",
                columns: table => new
                {
                    NewsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NewsAuthor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsMatter = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NewsTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news", x => x.NewsId);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "user",
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
                    table.PrimaryKey("PK_user", x => x.EmpId);
                    //table.ForeignKey("FK_RoleId");

                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "news");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
