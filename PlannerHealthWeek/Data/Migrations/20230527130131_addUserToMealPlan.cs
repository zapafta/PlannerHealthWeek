using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannerHealthWeek.Data.Migrations
{
    /// <inheritdoc />
    public partial class addUserToMealPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MealPlan",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlan_UserId",
                table: "MealPlan",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlan_AspNetUsers_UserId",
                table: "MealPlan",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlan_AspNetUsers_UserId",
                table: "MealPlan");

            migrationBuilder.DropIndex(
                name: "IX_MealPlan_UserId",
                table: "MealPlan");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MealPlan");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
