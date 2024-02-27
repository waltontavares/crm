using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace crm.webapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Bancos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fantasia = table.Column<string>(type: "text", nullable: false),
                    Razao = table.Column<string>(type: "text", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: false),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Uf = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    telefone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Bancos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Clausulas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Desc_Clausula = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Clausulas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Clausulas_Abusivas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_clausula = table.Column<int>(type: "integer", nullable: false),
                    Id_Contrato = table.Column<int>(type: "integer", nullable: false),
                    Valor_Clausula = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Clausulas_Abusivas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Pessoa = table.Column<int>(type: "integer", nullable: false),
                    Id_Banco = table.Column<int>(type: "integer", nullable: false),
                    Num_Contrato = table.Column<string>(type: "text", nullable: false),
                    Valor_Bem = table.Column<decimal>(type: "numeric", nullable: false),
                    Valor_Entrada = table.Column<decimal>(type: "numeric", nullable: false),
                    Valor_Financiar = table.Column<decimal>(type: "numeric", nullable: false),
                    Parcelas = table.Column<int>(type: "integer", nullable: false),
                    Valor_Parcela = table.Column<decimal>(type: "numeric", nullable: false),
                    Juros_Mensal = table.Column<decimal>(type: "numeric", nullable: false),
                    Juros_Anual = table.Column<decimal>(type: "numeric", nullable: false),
                    Cet_Mensal = table.Column<decimal>(type: "numeric", nullable: false),
                    Cet_Anual = table.Column<decimal>(type: "numeric", nullable: false),
                    Iof = table.Column<decimal>(type: "numeric", nullable: false),
                    Saldo_Financiar = table.Column<decimal>(type: "numeric", nullable: false),
                    Total_Clausulas_Abusivas_Iof = table.Column<decimal>(type: "numeric", nullable: false),
                    Total_Acao = table.Column<decimal>(type: "numeric", nullable: false),
                    Taxa_Media_Juros = table.Column<decimal>(type: "numeric", nullable: false),
                    Total_Financiamento = table.Column<decimal>(type: "numeric", nullable: false),
                    Valor_Tutela = table.Column<decimal>(type: "numeric", nullable: false),
                    Dt_Ins = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Dt_Upd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Contratos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Enderecos",
                columns: table => new
                {
                    Cep = table.Column<string>(type: "text", nullable: false),
                    Logradouro = table.Column<string>(type: "text", nullable: false),
                    Bairro = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Uf = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Enderecos", x => x.Cep);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Estado_Civil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Estado = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Estado_Civil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Foruns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Foro = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: true),
                    Uf = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Foruns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Processos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comarca = table.Column<string>(type: "text", nullable: false),
                    Forum = table.Column<string>(type: "text", nullable: false),
                    Status_Financiamento = table.Column<string>(type: "text", nullable: false),
                    Justica_Gratuita = table.Column<bool>(type: "boolean", nullable: false),
                    Id_Contrato = table.Column<int>(type: "integer", nullable: false),
                    Numero_Processo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Processos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Rg = table.Column<string>(type: "text", nullable: true),
                    Exp = table.Column<string>(type: "text", nullable: true),
                    Cpf = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Cep = table.Column<string>(type: "text", nullable: true),
                    Logradouro = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<string>(type: "text", nullable: true),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: true),
                    Cidade = table.Column<string>(type: "text", nullable: true),
                    Uf = table.Column<string>(type: "text", nullable: true),
                    Nacionalidade = table.Column<string>(type: "text", nullable: true),
                    Profissao = table.Column<string>(type: "text", nullable: true),
                    Estado_CivilId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Pessoas_Tb_Estado_Civil_Estado_CivilId",
                        column: x => x.Estado_CivilId,
                        principalTable: "Tb_Estado_Civil",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Tb_Estado_Civil",
                columns: new[] { "Id", "Estado" },
                values: new object[,]
                {
                    { 1, "Solteiro" },
                    { 2, "Casado" },
                    { 3, "Divorciado" },
                    { 4, "Viúvo" },
                    { 5, "União Estavel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Pessoas_Estado_CivilId",
                table: "Tb_Pessoas",
                column: "Estado_CivilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Bancos");

            migrationBuilder.DropTable(
                name: "Tb_Clausulas");

            migrationBuilder.DropTable(
                name: "Tb_Clausulas_Abusivas");

            migrationBuilder.DropTable(
                name: "Tb_Contratos");

            migrationBuilder.DropTable(
                name: "Tb_Enderecos");

            migrationBuilder.DropTable(
                name: "Tb_Foruns");

            migrationBuilder.DropTable(
                name: "Tb_Pessoas");

            migrationBuilder.DropTable(
                name: "Tb_Processos");

            migrationBuilder.DropTable(
                name: "Tb_Estado_Civil");
        }
    }
}
