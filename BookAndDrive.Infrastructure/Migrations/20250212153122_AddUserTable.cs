using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAndDrive.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverLicenceFirst = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DriverLicenceSecond = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsDriverLicenceVerified = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DriverLicenceFirst", "DriverLicenceSecond", "Email", "FirstName", "IsDriverLicenceVerified", "LastName", "Password", "PhoneNumber", "Role" },
                values: new object[] { 1, null, null, "petro.shchur@gmail.com", "Petro", null, "Shchur", "12344321", "+48732657392", "User" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
