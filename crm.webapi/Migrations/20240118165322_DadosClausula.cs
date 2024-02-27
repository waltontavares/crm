using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crm.webapi.Migrations
{
    /// <inheritdoc />
    public partial class DadosClausula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Desc_Clausula",
                table: "Tb_Clausulas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Desc_Clausula",
                table: "Tb_Clausulas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
