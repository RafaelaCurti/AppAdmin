using Microsoft.EntityFrameworkCore.Migrations;

namespace VetAdmin.Migrations
{
    public partial class ModificarRelacionamentosEntreModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Cliente_ClienteId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Funcionario_FuncionarioId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ClienteId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_FuncionarioId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Funcionario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_UsuarioId",
                table: "Funcionario",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UsuarioId",
                table: "Cliente",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Usuario_UsuarioId",
                table: "Cliente",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Usuario_UsuarioId",
                table: "Funcionario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Usuario_UsuarioId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Usuario_UsuarioId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_UsuarioId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_UsuarioId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ClienteId",
                table: "Usuario",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_FuncionarioId",
                table: "Usuario",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Cliente_ClienteId",
                table: "Usuario",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Funcionario_FuncionarioId",
                table: "Usuario",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
