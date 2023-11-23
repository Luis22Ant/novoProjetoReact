using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiLojaEletronicos.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
             name: "Login",
             columns: table => new
             {
                 Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                 Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                 Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                 Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                 Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                 HoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                 DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false) // Alterado para varchar
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Login", x => x.Id);
             });


            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
