using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildRPG.Migrations
{
    /// <inheritdoc />
    public partial class MakeImageOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Monster",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageType",
                table: "Monster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Monster",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageData", "ImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Monster",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageData", "ImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Monster",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageData", "ImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Monster",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageData", "ImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Monster",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageData", "ImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Monster",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageData", "ImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Monster",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImageData", "ImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Monster",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImageData", "ImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Monster",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ImageData", "ImageType" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Monster");

            migrationBuilder.DropColumn(
                name: "ImageType",
                table: "Monster");
        }
    }
}
