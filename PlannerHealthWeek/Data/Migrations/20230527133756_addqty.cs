using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannerHealthWeek.Data.Migrations
{
    /// <inheritdoc />
    public partial class addqty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Qty",
                table: "ReceitaItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qty",
                table: "ReceitaItem");
        }
    }
}
