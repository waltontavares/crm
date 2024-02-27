using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crm.webapi.Migrations
{
    /// <inheritdoc />
    public partial class NullableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_Banco",
                table: "Tb_Contratos");

            migrationBuilder.DropColumn(
                name: "Id_Pessoa",
                table: "Tb_Contratos");

            migrationBuilder.DropColumn(
                name: "Id_Contrato",
                table: "Tb_Clausulas_Abusivas");

            migrationBuilder.DropColumn(
                name: "Id_clausula",
                table: "Tb_Clausulas_Abusivas");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor_Tutela",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor_Parcela",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor_Financiar",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor_Entrada",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor_Bem",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total_Financiamento",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total_Clausulas_Abusivas_Iof",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total_Acao",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Taxa_Media_Juros",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Saldo_Financiar",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Parcelas",
                table: "Tb_Contratos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Num_Contrato",
                table: "Tb_Contratos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "Juros_Mensal",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Juros_Anual",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Iof",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dt_Upd",
                table: "Tb_Contratos",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dt_Ins",
                table: "Tb_Contratos",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cet_Mensal",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cet_Anual",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<int>(
                name: "BancoId",
                table: "Tb_Contratos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Tb_Contratos",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor_Clausula",
                table: "Tb_Clausulas_Abusivas",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<int>(
                name: "ClausulaId",
                table: "Tb_Clausulas_Abusivas",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContratoId",
                table: "Tb_Clausulas_Abusivas",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Uf",
                table: "Tb_Bancos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Razao",
                table: "Tb_Bancos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Fantasia",
                table: "Tb_Bancos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Tb_Bancos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Tb_Bancos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Tb_Bancos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Tb_Bancos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Tb_Bancos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Contratos_BancoId",
                table: "Tb_Contratos",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Contratos_PessoaId",
                table: "Tb_Contratos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Clausulas_Abusivas_ClausulaId",
                table: "Tb_Clausulas_Abusivas",
                column: "ClausulaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Clausulas_Abusivas_ContratoId",
                table: "Tb_Clausulas_Abusivas",
                column: "ContratoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Clausulas_Abusivas_Tb_Clausulas_ClausulaId",
                table: "Tb_Clausulas_Abusivas",
                column: "ClausulaId",
                principalTable: "Tb_Clausulas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Clausulas_Abusivas_Tb_Contratos_ContratoId",
                table: "Tb_Clausulas_Abusivas",
                column: "ContratoId",
                principalTable: "Tb_Contratos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Contratos_Tb_Bancos_BancoId",
                table: "Tb_Contratos",
                column: "BancoId",
                principalTable: "Tb_Bancos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Contratos_Tb_Pessoas_PessoaId",
                table: "Tb_Contratos",
                column: "PessoaId",
                principalTable: "Tb_Pessoas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Clausulas_Abusivas_Tb_Clausulas_ClausulaId",
                table: "Tb_Clausulas_Abusivas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Clausulas_Abusivas_Tb_Contratos_ContratoId",
                table: "Tb_Clausulas_Abusivas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Contratos_Tb_Bancos_BancoId",
                table: "Tb_Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Contratos_Tb_Pessoas_PessoaId",
                table: "Tb_Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Contratos_BancoId",
                table: "Tb_Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Contratos_PessoaId",
                table: "Tb_Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Clausulas_Abusivas_ClausulaId",
                table: "Tb_Clausulas_Abusivas");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Clausulas_Abusivas_ContratoId",
                table: "Tb_Clausulas_Abusivas");

            migrationBuilder.DropColumn(
                name: "BancoId",
                table: "Tb_Contratos");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Tb_Contratos");

            migrationBuilder.DropColumn(
                name: "ClausulaId",
                table: "Tb_Clausulas_Abusivas");

            migrationBuilder.DropColumn(
                name: "ContratoId",
                table: "Tb_Clausulas_Abusivas");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor_Tutela",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor_Parcela",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor_Financiar",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor_Entrada",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor_Bem",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total_Financiamento",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total_Clausulas_Abusivas_Iof",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total_Acao",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Taxa_Media_Juros",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Saldo_Financiar",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Parcelas",
                table: "Tb_Contratos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Num_Contrato",
                table: "Tb_Contratos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Juros_Mensal",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Juros_Anual",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Iof",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dt_Upd",
                table: "Tb_Contratos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dt_Ins",
                table: "Tb_Contratos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cet_Mensal",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cet_Anual",
                table: "Tb_Contratos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Banco",
                table: "Tb_Contratos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Pessoa",
                table: "Tb_Contratos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor_Clausula",
                table: "Tb_Clausulas_Abusivas",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Contrato",
                table: "Tb_Clausulas_Abusivas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_clausula",
                table: "Tb_Clausulas_Abusivas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Uf",
                table: "Tb_Bancos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Razao",
                table: "Tb_Bancos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fantasia",
                table: "Tb_Bancos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Tb_Bancos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Tb_Bancos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Tb_Bancos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Tb_Bancos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Tb_Bancos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
