using Microsoft.EntityFrameworkCore.Migrations;

namespace Pabeda_Odev.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ogretmen",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(nullable: true),
                    Soyisim = table.Column<string>(nullable: true),
                    TCKimlikNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Okul",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OkulAdi = table.Column<string>(nullable: true),
                    Adresi = table.Column<string>(nullable: true),
                    Sehir = table.Column<string>(nullable: true),
                    Ilce = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okul", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenci",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(nullable: true),
                    Soyisim = table.Column<string>(nullable: true),
                    TCKimlikNo = table.Column<int>(nullable: false),
                    OkulID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenci", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ogrenci_Okul_OkulID",
                        column: x => x.OkulID,
                        principalTable: "Okul",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OgretmenOkul",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgretmenID = table.Column<int>(nullable: false),
                    OkulID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgretmenOkul", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OgretmenOkul_Ogretmen_OgretmenID",
                        column: x => x.OgretmenID,
                        principalTable: "Ogretmen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgretmenOkul_Okul_OkulID",
                        column: x => x.OkulID,
                        principalTable: "Okul",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciOgretmen",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciID = table.Column<int>(nullable: false),
                    OgretmenID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciOgretmen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OgrenciOgretmen_Ogrenci_OgrenciID",
                        column: x => x.OgrenciID,
                        principalTable: "Ogrenci",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciOgretmen_Ogretmen_OgretmenID",
                        column: x => x.OgretmenID,
                        principalTable: "Ogretmen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenci_OkulID",
                table: "Ogrenci",
                column: "OkulID");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciOgretmen_OgrenciID",
                table: "OgrenciOgretmen",
                column: "OgrenciID");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciOgretmen_OgretmenID",
                table: "OgrenciOgretmen",
                column: "OgretmenID");

            migrationBuilder.CreateIndex(
                name: "IX_OgretmenOkul_OgretmenID",
                table: "OgretmenOkul",
                column: "OgretmenID");

            migrationBuilder.CreateIndex(
                name: "IX_OgretmenOkul_OkulID",
                table: "OgretmenOkul",
                column: "OkulID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciOgretmen");

            migrationBuilder.DropTable(
                name: "OgretmenOkul");

            migrationBuilder.DropTable(
                name: "Ogrenci");

            migrationBuilder.DropTable(
                name: "Ogretmen");

            migrationBuilder.DropTable(
                name: "Okul");
        }
    }
}
