using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzaria.Data.Migrations
{
    public partial class InitialCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Projeto");

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "Projeto",
                columns: table => new
                {
                    IDCLIENTE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<string>(maxLength: 15, nullable: false),
                    NOME = table.Column<string>(maxLength: 150, nullable: false),
                    TELEFONE = table.Column<string>(maxLength: 15, nullable: false),
                    DTNASCIMENTO = table.Column<DateTime>(nullable: false),
                    LOGRADOURO = table.Column<string>(maxLength: 250, nullable: false),
                    NUMERO = table.Column<int>(nullable: false),
                    COMPLEMENTO = table.Column<string>(maxLength: 50, nullable: true),
                    BAIRRO = table.Column<string>(maxLength: 50, nullable: false),
                    CIDADE = table.Column<string>(maxLength: 50, nullable: false),
                    UF = table.Column<string>(maxLength: 2, nullable: false),
                    DTINCLUSAO = table.Column<DateTime>(nullable: false),
                    DTALTERACAO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IDCLIENTE", x => x.IDCLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "PIZZA_SABORES",
                schema: "Projeto",
                columns: table => new
                {
                    IDPIZZA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DESCRICAO = table.Column<string>(maxLength: 50, nullable: false),
                    VALORES = table.Column<double>(nullable: false),
                    STATUS = table.Column<bool>(nullable: false),
                    DTINCLUSAO = table.Column<DateTime>(nullable: false),
                    DTALTERACAO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IDPIZZA", x => x.IDPIZZA);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                schema: "Projeto",
                columns: table => new
                {
                    IDPEDIDOS = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IDCLIENTE = table.Column<int>(nullable: false),
                    TOTAL = table.Column<double>(nullable: false),
                    DTINCLUSAO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IDPEDIDOS", x => x.IDPEDIDOS);
                    table.ForeignKey(
                        name: "FK_Pedidos_Cliente_IDCLIENTE",
                        column: x => x.IDCLIENTE,
                        principalSchema: "Projeto",
                        principalTable: "Cliente",
                        principalColumn: "IDCLIENTE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ITENS_PEDIDOS",
                schema: "Projeto",
                columns: table => new
                {
                    IDITENSPEDIDOS = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IDPEDIDOS = table.Column<int>(nullable: false),
                    INTEIRA = table.Column<bool>(nullable: false),
                    IDPIZZA = table.Column<int>(nullable: false),
                    TOTAL = table.Column<double>(nullable: false),
                    DTINCLUSAO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IDITENSPEDIDOS", x => x.IDITENSPEDIDOS);
                    table.ForeignKey(
                        name: "FK_ITENS_PEDIDOS_Pedidos_IDPEDIDOS",
                        column: x => x.IDPEDIDOS,
                        principalSchema: "Projeto",
                        principalTable: "Pedidos",
                        principalColumn: "IDPEDIDOS",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITENS_PEDIDOS_PIZZA_SABORES_IDPIZZA",
                        column: x => x.IDPIZZA,
                        principalSchema: "Projeto",
                        principalTable: "PIZZA_SABORES",
                        principalColumn: "IDPIZZA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PEDIDOS_IDPEDIDOS",
                schema: "Projeto",
                table: "ITENS_PEDIDOS",
                column: "IDPEDIDOS");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PEDIDOS_IDPIZZA",
                schema: "Projeto",
                table: "ITENS_PEDIDOS",
                column: "IDPIZZA");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IDCLIENTE",
                schema: "Projeto",
                table: "Pedidos",
                column: "IDCLIENTE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITENS_PEDIDOS",
                schema: "Projeto");

            migrationBuilder.DropTable(
                name: "Pedidos",
                schema: "Projeto");

            migrationBuilder.DropTable(
                name: "PIZZA_SABORES",
                schema: "Projeto");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "Projeto");
        }
    }
}
