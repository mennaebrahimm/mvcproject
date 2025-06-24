using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcproject.Migrations
{
    /// <inheritdoc />
    public partial class enumNotification_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "customerId",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_customerId",
                table: "Notifications",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_customerId",
                table: "Notifications",
                column: "customerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_customerId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_customerId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "Notifications");

            migrationBuilder.AlterColumn<int>(
                name: "category",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
