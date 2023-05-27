using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannerHealthWeek.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlanoAlimentacao_Recipe_ReceitaId",
                table: "ItemPlanoAlimentacao");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaItem_Ingredient_IngredienteId",
                table: "ReceitaItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaItem_Recipe_ReceitaId",
                table: "ReceitaItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.RenameTable(
                name: "Recipe",
                newName: "Receita");

            migrationBuilder.RenameTable(
                name: "Ingredient",
                newName: "Ingrediente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receita",
                table: "Receita",
                column: "ReceitaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingrediente",
                table: "Ingrediente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlanoAlimentacao_Receita_ReceitaId",
                table: "ItemPlanoAlimentacao",
                column: "ReceitaId",
                principalTable: "Receita",
                principalColumn: "ReceitaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaItem_Ingrediente_IngredienteId",
                table: "ReceitaItem",
                column: "IngredienteId",
                principalTable: "Ingrediente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaItem_Receita_ReceitaId",
                table: "ReceitaItem",
                column: "ReceitaId",
                principalTable: "Receita",
                principalColumn: "ReceitaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlanoAlimentacao_Receita_ReceitaId",
                table: "ItemPlanoAlimentacao");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaItem_Ingrediente_IngredienteId",
                table: "ReceitaItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaItem_Receita_ReceitaId",
                table: "ReceitaItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receita",
                table: "Receita");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingrediente",
                table: "Ingrediente");

            migrationBuilder.RenameTable(
                name: "Receita",
                newName: "Recipe");

            migrationBuilder.RenameTable(
                name: "Ingrediente",
                newName: "Ingredient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "ReceitaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlanoAlimentacao_Recipe_ReceitaId",
                table: "ItemPlanoAlimentacao",
                column: "ReceitaId",
                principalTable: "Recipe",
                principalColumn: "ReceitaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaItem_Ingredient_IngredienteId",
                table: "ReceitaItem",
                column: "IngredienteId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaItem_Recipe_ReceitaId",
                table: "ReceitaItem",
                column: "ReceitaId",
                principalTable: "Recipe",
                principalColumn: "ReceitaId");
        }
    }
}
