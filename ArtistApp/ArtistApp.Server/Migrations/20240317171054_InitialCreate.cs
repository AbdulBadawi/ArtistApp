using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtistApp.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ArtistId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReleaseYear = table.Column<int>(type: "INTEGER", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Zain Javadd Malik (born 12 January 1993), known professionally as Zayn Malik or simply Zayn, is a British singer. Malik auditioned as a solo contestant for the British music competition television series The X Factor in 2010", "Zayn Malik" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Robyn Rihanna Fenty born February 20, 1988) is a Barbadian singer, businesswoman, and actress", "Robyn Rihana Fenty" });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "ArtistId", "Description", "ReleaseYear", "Title" },
                values: new object[] { 1, 1, "Gold Pharaoh (Original Mix) is a song by Proof Db, available on SoundCloud. It is also available on Amazon UK, where it appears on the album Gold Pharoah along with other songs by Proof Db and Zayn Malik", 2020, "Gold Pharoah" });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "ArtistId", "Description", "ReleaseYear", "Title" },
                values: new object[] { 2, 2, "Anti is the eighth studio album by Barbadian singer Rihanna. It was released on 28 January 2016 by Roc Nation and Westbury Road", 2016, "Anti" });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "AlbumId", "Description", "Title" },
                values: new object[] { 1, 1, "Remember the time When you were here inside my dream I wish you'll be mine, You're understanding what I mean", "Deep Spirit" });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "AlbumId", "Description", "Title" },
                values: new object[] { 2, 2, "Needed Me is a mellowish dubstep-flavored electro-R&B song with trippy, trappy production, and a length of three minutes and five seconds", "Needed Me" });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumId",
                table: "Tracks",
                column: "AlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
