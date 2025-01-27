using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username", "Email", "Phone", "Password", "Role", "Status", "CreatedAt" },
                values: new object[,]
                {
                        {
                            Guid.NewGuid(),
                            "admin",
                            "admin@example.com",
                            "+1234567890",
                            "admin123!@", // Store hashed passwords
                            "Admin",
                            "Active",
                            DateTime.UtcNow
                        },
                        {
                            Guid.NewGuid(),
                            "user",
                            "user@example.com",
                            "+0987654321",
                            "user123!@",
                            "User",
                            "Active",
                            DateTime.UtcNow
                        }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
