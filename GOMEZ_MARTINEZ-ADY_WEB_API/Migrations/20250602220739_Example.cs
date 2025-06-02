using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GOMEZ_MARTINEZ_ADY_WEB_API.Migrations
{
    /// <inheritdoc />
    public partial class Example : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PKRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PKRol);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    PKUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FKRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.PKUser);
                    table.ForeignKey(
                        name: "FK_Users_Roles_FKRol",
                        column: x => x.FKRol,
                        principalTable: "Roles",
                        principalColumn: "PKRol");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PKRol", "Name" },
                values: new object[,]
                {
                    { 1, "a" },
                    { 2, "sa" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "PKUser", "FKRol", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 1, 2, "Ady", "123", "Ady" },
                    { 2, 1, "Josue", "123", "Jou" },
                    { 3, 1, "Cynthia", "123", "Cynti" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FKRol",
                table: "Users",
                column: "FKRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
