using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RegistrationApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Users_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ukraine" },
                    { 2, "Poland" },
                    { 3, "Germany" },
                    { 4, "France" },
                    { 5, "Italy" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Kyiv" },
                    { 2, 1, "Rivne" },
                    { 3, 1, "Kharkiv" },
                    { 4, 1, "Dnipro" },
                    { 5, 1, "Lviv" },
                    { 6, 2, "Warszaw" },
                    { 7, 2, "Gdansk" },
                    { 8, 2, "Krakow" },
                    { 9, 2, "Poznan" },
                    { 10, 2, "Lublin" },
                    { 11, 3, "Berlin" },
                    { 12, 3, "Hamburg" },
                    { 13, 3, "Munich" },
                    { 14, 3, "Cologne" },
                    { 15, 3, "Stuttgart" },
                    { 16, 4, "Paris" },
                    { 17, 4, "Marseille" },
                    { 18, 4, "Lyon" },
                    { 19, 4, "Toulouse" },
                    { 20, 4, "Bordeaux" },
                    { 21, 5, "Rome" },
                    { 22, 5, "Milan" },
                    { 23, 5, "Naples" },
                    { 24, 5, "Turin" },
                    { 25, 5, "Palermo" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "CityId", "CountryId", "Email", "Name", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 18, 1, 1, "elizabeth@gmail.com", "Elizabeth", "elizabethpassword123weq", "+380986815309" },
                    { 2, 32, 2, 1, "flower@gmail.com", "flower", "flower678jhnj", "+380967815495" },
                    { 3, 25, 3, 1, "grimace_shake@gmail.com", "grimace_shake", "grimaceshake89765as", "+380762190863" },
                    { 4, 43, 4, 1, "jumpstyle@gmail.com", "jumpstyle", "jumpstyle009977hj", "+380567812094" },
                    { 5, 21, 5, 1, "keshakaef@gmail.com", "keshakaef", "keshakaef009977hj", "+380876541098" },
                    { 6, 31, 7, 2, "LiveWallpaper@gmail.com", "LiveWallpaper", "LiveWallpaperqweasd123", "+480908765621" },
                    { 7, 25, 10, 2, "Payton@gmail.com", "Payton", "Paytonolewqwe", "+480890017682" },
                    { 8, 19, 8, 2, "onepiece@gmail.com", "One_Piece", "onepiece1234fcd", "+480780981123" },
                    { 9, 29, 6, 2, "isrhaul@gmail.com", "Isrhaul", "isrhaulqwefgvvv223", "+480776671205" },
                    { 10, 36, 9, 2, "username_ideas@gmail.com", "username_ideas", "username_ideas567811", "+480786548821" },
                    { 11, 24, 11, 3, "Yum_Yum@gmail.com", "Yum_Yum", "Yum_Yum87ygh9", "+580872317850" },
                    { 12, 33, 12, 3, "tocaboca@gmail.com", "tocaboca", "tocaboca23edfgy54", "+580907613411" },
                    { 13, 38, 13, 3, "roblox23@gmail.com", "roblox23", "roblox23dcaw231", "+580896641289" },
                    { 14, 20, 14, 3, "efilonova@gmail.com", "efilonova", "efilonovaeqwdase23", "+580987654409" },
                    { 15, 28, 15, 3, "widgetable@gmail.com", "widgetable", "widgetable312ed213edsa", "+580987886520" },
                    { 16, 22, 16, 4, "queencard@gmail.com", "queencard", "queencard67uyhju182", "+180128751677" },
                    { 17, 26, 17, 4, "AfterDark@gmail.com", "AfterDark", "AfterDark213edqaw32", "+180886789012" },
                    { 18, 31, 18, 4, "stray_kids@gmail.com", "stray_kids", "stray_kids123edq2", "+180987655567" },
                    { 19, 19, 19, 4, "DemonSlayer@gmail.com", "DemonSlayer", "DemonSlayer23edaww31", "+180986782162" },
                    { 20, 23, 20, 4, "CapCut56@gmail.com", "CapCut56", "CapCut56312eqwdw", "+180237872134" },
                    { 21, 29, 21, 5, "xbadmix@gmail.com", "xbadmix", "xbadmix34rfwess3", "+280909876751" },
                    { 22, 26, 22, 5, "vendetta@gmail.com", "Vendetta", "vendetta213dghhht", "+280118978905" },
                    { 23, 21, 25, 5, "new_jeans@gmail.com", "new_jeans", "new_jeans32eqda23", "+280896547812" },
                    { 24, 25, 24, 5, "Blackpink@gmail.com", "Blackpink", "Blackpink3eqdw34123", "+280897872134" },
                    { 25, 23, 23, 5, "minecraft@gmail.com", "minecraft", "minecraft23eda23", "+280900761127" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
