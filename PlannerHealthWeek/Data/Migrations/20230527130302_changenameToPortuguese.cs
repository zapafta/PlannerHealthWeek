using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannerHealthWeek.Data.Migrations
{
    /// <inheritdoc />
    public partial class changenameToPortuguese : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealPlanItem");

            migrationBuilder.DropTable(
                name: "MealPlan");

            migrationBuilder.CreateTable(
                name: "PlanoAlimentacao",
                columns: table => new
                {
                    IdPlanoAlimentacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoAlimentacao", x => x.IdPlanoAlimentacao);
                    table.ForeignKey(
                        name: "FK_PlanoAlimentacao_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPlanoAlimentacao",
                columns: table => new
                {
                    MealPlanItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealType = table.Column<int>(type: "int", nullable: false),
                    ReceitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanoAlimentacaoIdPlanoAlimentacao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPlanoAlimentacao", x => x.MealPlanItemId);
                    table.ForeignKey(
                        name: "FK_ItemPlanoAlimentacao_PlanoAlimentacao_PlanoAlimentacaoIdPlanoAlimentacao",
                        column: x => x.PlanoAlimentacaoIdPlanoAlimentacao,
                        principalTable: "PlanoAlimentacao",
                        principalColumn: "IdPlanoAlimentacao");
                    table.ForeignKey(
                        name: "FK_ItemPlanoAlimentacao_Recipe_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Recipe",
                        principalColumn: "ReceitaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlanoAlimentacao_PlanoAlimentacaoIdPlanoAlimentacao",
                table: "ItemPlanoAlimentacao",
                column: "PlanoAlimentacaoIdPlanoAlimentacao");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlanoAlimentacao_ReceitaId",
                table: "ItemPlanoAlimentacao",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoAlimentacao_UserId",
                table: "PlanoAlimentacao",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPlanoAlimentacao");

            migrationBuilder.DropTable(
                name: "PlanoAlimentacao");

            migrationBuilder.CreateTable(
                name: "MealPlan",
                columns: table => new
                {
                    IdPlanoAlimentacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlan", x => x.IdPlanoAlimentacao);
                    table.ForeignKey(
                        name: "FK_MealPlan_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealPlanItem",
                columns: table => new
                {
                    MealPlanItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MealPlanIdPlanoAlimentacao = table.Column<int>(type: "int", nullable: true),
                    MealType = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_MealPlan_UserId",
                table: "MealPlan",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanItem_MealPlanIdPlanoAlimentacao",
                table: "MealPlanItem",
                column: "MealPlanIdPlanoAlimentacao");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanItem_ReceitaId",
                table: "MealPlanItem",
                column: "ReceitaId");
        }
    }
}
