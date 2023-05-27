using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannerHealthWeek.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewForgeinKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlanoAlimentacao_PlanoAlimentacao_PlanoAlimentacaoIdPlanoAlimentacao",
                table: "ItemPlanoAlimentacao");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaItem_Receita_ReceitaId",
                table: "ReceitaItem");

            migrationBuilder.DropIndex(
                name: "IX_ReceitaItem_ReceitaId",
                table: "ReceitaItem");

            migrationBuilder.DropIndex(
                name: "IX_ItemPlanoAlimentacao_PlanoAlimentacaoIdPlanoAlimentacao",
                table: "ItemPlanoAlimentacao");

            migrationBuilder.DropColumn(
                name: "ReceitaId",
                table: "ReceitaItem");

            migrationBuilder.DropColumn(
                name: "PlanoAlimentacaoIdPlanoAlimentacao",
                table: "ItemPlanoAlimentacao");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "IdReceita",
                table: "ReceitaItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("677ec28a-3d7f-4258-8b16-dd22963f1e47"));

            migrationBuilder.AddColumn<int>(
                name: "IdPlanoAlimentacao",
                table: "ItemPlanoAlimentacao",
                type: "int",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaItem_IdReceita",
                table: "ReceitaItem",
                column: "IdReceita");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlanoAlimentacao_IdPlanoAlimentacao",
                table: "ItemPlanoAlimentacao",
                column: "IdPlanoAlimentacao");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlanoAlimentacao_PlanoAlimentacao_IdPlanoAlimentacao",
                table: "ItemPlanoAlimentacao",
                column: "IdPlanoAlimentacao",
                principalTable: "PlanoAlimentacao",
                principalColumn: "IdPlanoAlimentacao",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaItem_Receita_IdReceita",
                table: "ReceitaItem",
                column: "IdReceita",
                principalTable: "Receita",
                principalColumn: "ReceitaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlanoAlimentacao_PlanoAlimentacao_IdPlanoAlimentacao",
                table: "ItemPlanoAlimentacao");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaItem_Receita_IdReceita",
                table: "ReceitaItem");

            migrationBuilder.DropIndex(
                name: "IX_ReceitaItem_IdReceita",
                table: "ReceitaItem");

            migrationBuilder.DropIndex(
                name: "IX_ItemPlanoAlimentacao_IdPlanoAlimentacao",
                table: "ItemPlanoAlimentacao");

            migrationBuilder.DropColumn(
                name: "IdReceita",
                table: "ReceitaItem");

            migrationBuilder.DropColumn(
                name: "IdPlanoAlimentacao",
                table: "ItemPlanoAlimentacao");

            migrationBuilder.AddColumn<Guid>(
                name: "ReceitaId",
                table: "ReceitaItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanoAlimentacaoIdPlanoAlimentacao",
                table: "ItemPlanoAlimentacao",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaItem_ReceitaId",
                table: "ReceitaItem",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlanoAlimentacao_PlanoAlimentacaoIdPlanoAlimentacao",
                table: "ItemPlanoAlimentacao",
                column: "PlanoAlimentacaoIdPlanoAlimentacao");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlanoAlimentacao_PlanoAlimentacao_PlanoAlimentacaoIdPlanoAlimentacao",
                table: "ItemPlanoAlimentacao",
                column: "PlanoAlimentacaoIdPlanoAlimentacao",
                principalTable: "PlanoAlimentacao",
                principalColumn: "IdPlanoAlimentacao");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaItem_Receita_ReceitaId",
                table: "ReceitaItem",
                column: "ReceitaId",
                principalTable: "Receita",
                principalColumn: "ReceitaId");
        }
    }
}
