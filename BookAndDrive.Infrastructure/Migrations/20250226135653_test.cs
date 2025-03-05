using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookAndDrive.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDriverLicenceVerified",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DriverLicenceFirst", "DriverLicenceSecond", "Email", "FirstName", "IsDriverLicenceVerified", "LastName", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, null, null, "tomvinto@gmail.com", "Tom", false, "Vinto", "479b0b6509920e075f50000e3a1f6deb44a50303c9d8ecfa66f4ff16e66e60a2", "+380231231231", "User" },
                    { 2, null, null, "alexvinto@gmail.com", "Alex", false, "Vinto", "479b0b6509920e075f50000e3a1f6deb44a50303c9d8ecfa66f4ff16e66e60a2", "+380631887836", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDriverLicenceVerified",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
