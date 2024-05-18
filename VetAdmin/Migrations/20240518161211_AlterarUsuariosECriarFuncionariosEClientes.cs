using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace VetAdmin.Migrations
{
    public partial class AlterarUsuariosECriarFuncionariosEClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Profissao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CanalDeComunicacaoEscolhido = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EVeterinario = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EAdministrativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CNPJ = table.Column<string>(type: "text", nullable: true),
                    Area = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Especialidade = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Senha = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<string>(type: "text", nullable: true),
                    RG = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Celular = table.Column<string>(type: "text", nullable: true),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    EstadoCivil = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ClienteId",
                table: "Usuario",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_FuncionarioId",
                table: "Usuario",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(type: "text", nullable: true),
                    Senha = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }
    }
}
