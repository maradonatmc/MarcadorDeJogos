using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MarcadorDeJogos.Migrations
{
    public partial class CreateStruct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigGeneral",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlgUtilizaTotal = table.Column<int>(nullable: true),
                    FlgJogoSequencial = table.Column<int>(nullable: true),
                    VlrFula = table.Column<int>(nullable: false),
                    VlrFulaMao = table.Column<int>(nullable: false),
                    VlrSequencia = table.Column<int>(nullable: false),
                    VlrSequenciaMao = table.Column<int>(nullable: false),
                    VlrQuadra = table.Column<int>(nullable: false),
                    VlrQuadraMao = table.Column<int>(nullable: false),
                    VlrGeneral = table.Column<int>(nullable: false),
                    VlrGeneralMao = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_ConfigGeneral", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Jogadores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
					DatCadastro = table.Column<DateTime?>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Jogadores", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "TipoJogo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeTipoJogo = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_TipoJogo", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeJogo = table.Column<string>(nullable: false),
                    TipoJogoId = table.Column<int>(nullable: false)
                },
                constraints: table => 
                { 
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogos_TipoJogo_TipoJogoId",
                        column: x => x.TipoJogoId,
                        principalTable: "TipoJogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "ConfigGeneral");
            migrationBuilder.DropTable(name: "Jogadores");
            migrationBuilder.DropTable(name: "Jogos");
        }
    }
}
