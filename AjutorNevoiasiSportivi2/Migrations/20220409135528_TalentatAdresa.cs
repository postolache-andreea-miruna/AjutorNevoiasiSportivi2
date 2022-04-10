using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AjutorNevoiasiSportivi2.Migrations
{
    public partial class TalentatAdresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cluburi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeClub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cluburi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competitii",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCompetitie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importanta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitii", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donatori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeDonator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrenumeDonator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pseudonim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donatori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Probe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeProba = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Probe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sporturi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeSport = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sporturi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TalentatNevoiasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gen = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    NumeNevoias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrenumeNevoias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNastere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SportTalent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeAjutat = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentatNevoiasi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Antrenori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeAntrenor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrenumeAntrenor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AniExperienta = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antrenori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Antrenori_Cluburi_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Cluburi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Antrenori_Sporturi_SportId",
                        column: x => x.SportId,
                        principalTable: "Sporturi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adrese",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeStrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumarBloc = table.Column<int>(type: "int", nullable: false),
                    NumarAp = table.Column<int>(type: "int", nullable: false),
                    CodPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TalentatNevoiasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adrese", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adrese_TalentatNevoiasi_TalentatNevoiasId",
                        column: x => x.TalentatNevoiasId,
                        principalTable: "TalentatNevoiasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donari",
                columns: table => new
                {
                    DonatorId = table.Column<int>(type: "int", nullable: false),
                    TalentatNevoiasId = table.Column<int>(type: "int", nullable: false),
                    DataDonatie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ElementDonat = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConfirmarePrimire = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donari", x => new { x.DonatorId, x.TalentatNevoiasId, x.DataDonatie, x.ElementDonat });
                    table.ForeignKey(
                        name: "FK_Donari_Donatori_DonatorId",
                        column: x => x.DonatorId,
                        principalTable: "Donatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donari_TalentatNevoiasi_TalentatNevoiasId",
                        column: x => x.TalentatNevoiasId,
                        principalTable: "TalentatNevoiasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IstoricParticipari",
                columns: table => new
                {
                    TalentatNevoiasId = table.Column<int>(type: "int", nullable: false),
                    CompetitieId = table.Column<int>(type: "int", nullable: false),
                    ProbaId = table.Column<int>(type: "int", nullable: false),
                    LocClasament = table.Column<int>(type: "int", nullable: false),
                    TimpObtinut = table.Column<int>(type: "int", nullable: false),
                    Medaliat = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IstoricParticipari", x => new { x.TalentatNevoiasId, x.CompetitieId, x.ProbaId });
                    table.ForeignKey(
                        name: "FK_IstoricParticipari_Competitii_CompetitieId",
                        column: x => x.CompetitieId,
                        principalTable: "Competitii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IstoricParticipari_Probe_ProbaId",
                        column: x => x.ProbaId,
                        principalTable: "Probe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IstoricParticipari_TalentatNevoiasi_TalentatNevoiasId",
                        column: x => x.TalentatNevoiasId,
                        principalTable: "TalentatNevoiasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscrieri",
                columns: table => new
                {
                    TalentatNevoiasId = table.Column<int>(type: "int", nullable: false),
                    AntrenorId = table.Column<int>(type: "int", nullable: false),
                    DataStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscrieri", x => new { x.TalentatNevoiasId, x.AntrenorId, x.DataStart });
                    table.ForeignKey(
                        name: "FK_Inscrieri_Antrenori_AntrenorId",
                        column: x => x.AntrenorId,
                        principalTable: "Antrenori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscrieri_TalentatNevoiasi_TalentatNevoiasId",
                        column: x => x.TalentatNevoiasId,
                        principalTable: "TalentatNevoiasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adrese_TalentatNevoiasId",
                table: "Adrese",
                column: "TalentatNevoiasId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Antrenori_ClubId",
                table: "Antrenori",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Antrenori_SportId",
                table: "Antrenori",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Donari_TalentatNevoiasId",
                table: "Donari",
                column: "TalentatNevoiasId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscrieri_AntrenorId",
                table: "Inscrieri",
                column: "AntrenorId");

            migrationBuilder.CreateIndex(
                name: "IX_IstoricParticipari_CompetitieId",
                table: "IstoricParticipari",
                column: "CompetitieId");

            migrationBuilder.CreateIndex(
                name: "IX_IstoricParticipari_ProbaId",
                table: "IstoricParticipari",
                column: "ProbaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adrese");

            migrationBuilder.DropTable(
                name: "Donari");

            migrationBuilder.DropTable(
                name: "Inscrieri");

            migrationBuilder.DropTable(
                name: "IstoricParticipari");

            migrationBuilder.DropTable(
                name: "Donatori");

            migrationBuilder.DropTable(
                name: "Antrenori");

            migrationBuilder.DropTable(
                name: "Competitii");

            migrationBuilder.DropTable(
                name: "Probe");

            migrationBuilder.DropTable(
                name: "TalentatNevoiasi");

            migrationBuilder.DropTable(
                name: "Cluburi");

            migrationBuilder.DropTable(
                name: "Sporturi");
        }
    }
}
