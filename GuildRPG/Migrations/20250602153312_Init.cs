using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuildRPG.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mercenary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ExperiencePoints = table.Column<double>(type: "float", nullable: false),
                    MaxHealth = table.Column<double>(type: "float", nullable: false),
                    CurrentHealth = table.Column<double>(type: "float", nullable: false),
                    Damage = table.Column<double>(type: "float", nullable: false),
                    Gold = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercenary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Health = table.Column<double>(type: "float", nullable: false),
                    Damage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diff = table.Column<int>(type: "int", nullable: false),
                    EnemyId = table.Column<int>(type: "int", nullable: false),
                    RewardXP = table.Column<double>(type: "float", nullable: false),
                    RewardMoney = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quest_Monster_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Monster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Mercenary",
                columns: new[] { "Id", "CurrentHealth", "Damage", "ExperiencePoints", "Gold", "Level", "MaxHealth", "Name" },
                values: new object[,]
                {
                    { 1, 100.0, 15.0, 100.0, 42198.0, 5, 100.0, "Arthur" },
                    { 2, 120.0, 20.0, 100.0, 42198.0, 7, 120.0, "Lancelot" },
                    { 3, 10000.0, 1500.0, 100.0, 42198.0, 25, 10000.0, "Paulina Heros" },
                    { 4, 100000.0, 100000.0, 100.0, 42198.0, 99, 100000.0, "Cieć Boss" },
                    { 5, 100.0, 15.0, 100.0, 42198.0, 8, 100.0, "Zwykły Maciek" },
                    { 6, 100.0, 15.0, 100.0, 42198.0, 1, 100.0, "Kasztan ze wsi" },
                    { 7, 100.0, 15.0, 100.0, 42198.0, 9, 100.0, "Dres spod żabki" },
                    { 8, 100.0, 15.0, 100.0, 42198.0, 5, 100.0, "Nie mam Więcej pomysłów" }
                });

            migrationBuilder.InsertData(
                table: "Monster",
                columns: new[] { "Id", "Damage", "Health", "Name" },
                values: new object[,]
                {
                    { 1, 200.0, 2000.0, "Smokuch" },
                    { 2, 5.0, 100.0, "Goblin" },
                    { 3, 100.0, 800.0, "Paulina Wiedźma" },
                    { 4, 50.0, 500.0, "Ork" },
                    { 5, 150.0, 1500.0, "Czerwony Ork" },
                    { 6, 200.0, 2000.0, "Bestia z Groty" },
                    { 7, 1.0, 10.0, "Żul Mietek" },
                    { 8, 1000.0, 10000.0, "Mamlambo" },
                    { 9, 999999.0, 999999.0, "Diabeł" }
                });

            migrationBuilder.InsertData(
                table: "Quest",
                columns: new[] { "Id", "Description", "Diff", "EnemyId", "Location", "Name", "RewardMoney", "RewardXP" },
                values: new object[,]
                {
                    { 1, "aaaaaaaaaaaaaaaaaaaa", 5, 1, "Góry Mroczne", "Smocza Grota", 0.0, 0.0 },
                    { 2, "BBBBBBBBBBBBBBBB", 3, 2, "Las Cienia", "Goblińska Wioska", 0.0, 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quest_EnemyId",
                table: "Quest",
                column: "EnemyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mercenary");

            migrationBuilder.DropTable(
                name: "Quest");

            migrationBuilder.DropTable(
                name: "Monster");
        }
    }
}
