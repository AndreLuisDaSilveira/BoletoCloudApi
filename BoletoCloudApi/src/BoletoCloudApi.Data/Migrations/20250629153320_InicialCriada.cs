using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoletoCloudApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InicialCriada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boletos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(14)", nullable: false),
                    Sequencial = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Emissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Token = table.Column<string>(type: "varchar(500)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoletoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cprf = table.Column<string>(type: "varchar(14)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    Uf = table.Column<string>(type: "varchar(2)", nullable: false),
                    Localidade = table.Column<string>(type: "varchar(30)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(30)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(30)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiarios_Boletos_BoletoId",
                        column: x => x.BoletoId,
                        principalTable: "Boletos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContaBancarias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoletoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", nullable: false),
                    Sequencial = table.Column<int>(type: "int", nullable: false),
                    Banco = table.Column<string>(type: "varchar(50)", nullable: false),
                    Agencia = table.Column<string>(type: "varchar(20)", nullable: false),
                    Carteira = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaBancarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaBancarias_Boletos_BoletoId",
                        column: x => x.BoletoId,
                        principalTable: "Boletos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pagadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoletoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    CpfCnpj = table.Column<string>(type: "varchar(14)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    Uf = table.Column<string>(type: "varchar(2)", nullable: false),
                    Localidade = table.Column<string>(type: "varchar(30)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(30)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(30)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagadores_Boletos_BoletoId",
                        column: x => x.BoletoId,
                        principalTable: "Boletos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiarios_BoletoId",
                table: "Beneficiarios",
                column: "BoletoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContaBancarias_BoletoId",
                table: "ContaBancarias",
                column: "BoletoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagadores_BoletoId",
                table: "Pagadores",
                column: "BoletoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beneficiarios");

            migrationBuilder.DropTable(
                name: "ContaBancarias");

            migrationBuilder.DropTable(
                name: "Pagadores");

            migrationBuilder.DropTable(
                name: "Boletos");
        }
    }
}
