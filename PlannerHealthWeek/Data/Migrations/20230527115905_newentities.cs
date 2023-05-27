using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannerHealthWeek.Data.Migrations
{
    /// <inheritdoc />
    public partial class newentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealPlan",
                columns: table => new
                {
                    IdPlanoAlimentacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlan", x => x.IdPlanoAlimentacao);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    ReceitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.ReceitaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoDieta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDieta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPlano",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPlano", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealPlanItem",
                columns: table => new
                {
                    MealPlanItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealType = table.Column<int>(type: "int", nullable: false),
                    ReceitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MealPlanIdPlanoAlimentacao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlanItem", x => x.MealPlanItemId);
                    table.ForeignKey(
                        name: "FK_MealPlanItem_MealPlan_MealPlanIdPlanoAlimentacao",
                        column: x => x.MealPlanIdPlanoAlimentacao,
                        principalTable: "MealPlan",
                        principalColumn: "IdPlanoAlimentacao");
                    table.ForeignKey(
                        name: "FK_MealPlanItem_Recipe_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Recipe",
                        principalColumn: "ReceitaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceitaItem",
                columns: table => new
                {
                    ReceitaItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitOfMeasure = table.Column<int>(type: "int", nullable: false),
                    IngredienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitaItem", x => x.ReceitaItemId);
                    table.ForeignKey(
                        name: "FK_ReceitaItem_Ingredient_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceitaItem_Recipe_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Recipe",
                        principalColumn: "ReceitaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanItem_MealPlanIdPlanoAlimentacao",
                table: "MealPlanItem",
                column: "MealPlanIdPlanoAlimentacao");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanItem_ReceitaId",
                table: "MealPlanItem",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaItem_IngredienteId",
                table: "ReceitaItem",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaItem_ReceitaId",
                table: "ReceitaItem",
                column: "ReceitaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealPlanItem");

            migrationBuilder.DropTable(
                name: "ReceitaItem");

            migrationBuilder.DropTable(
                name: "TipoDieta");

            migrationBuilder.DropTable(
                name: "TipoPlano");

            migrationBuilder.DropTable(
                name: "MealPlan");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Recipe");
        }
    }
}
