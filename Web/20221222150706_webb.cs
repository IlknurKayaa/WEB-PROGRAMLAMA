using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZİWeb.Migrations
{
    /// <inheritdoc />
    public partial class webb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminss");

            migrationBuilder.DropTable(
                name: "okuyucus");

            migrationBuilder.DropTable(
                name: "yazars");

            migrationBuilder.CreateTable(
                name: "kullanicis",
                columns: table => new
                {
                    YazarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KullaniciSoyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kullanicisifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanicis", x => x.YazarID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kullanicis");

            migrationBuilder.CreateTable(
                name: "adminss",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rolid = table.Column<int>(type: "int", nullable: false),
                    sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soyad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminss", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "okuyucus",
                columns: table => new
                {
                    OkuyucuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rolid = table.Column<int>(type: "int", nullable: false),
                    sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soyad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_okuyucus", x => x.OkuyucuId);
                });

            migrationBuilder.CreateTable(
                name: "yazars",
                columns: table => new
                {
                    YazarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rolid = table.Column<int>(type: "int", nullable: false),
                    sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soyad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yazars", x => x.YazarId);
                });
        }
    }
}
