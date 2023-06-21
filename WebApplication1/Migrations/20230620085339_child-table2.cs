using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class childtable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cabinet",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfSpecialty = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cabinet",
                columns: new[] { "Id", "Number" },
                values: new object[] { 3, "12" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "CabinetId", "FullName", "RegionId", "SpecialtyId" },
                values: new object[] { 3, 3, "full name", 3, 3 });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Number" },
                values: new object[] { 3, "123" });

            migrationBuilder.InsertData(
                table: "Specialty",
                columns: new[] { "Id", "NameOfSpecialty" },
                values: new object[] { 3, "abc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DeleteData(
                table: "Cabinet",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Cabinet",
                columns: new[] { "Id", "Number" },
                values: new object[] { 1, "123" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "CabinetId", "FullName", "RegionId", "SpecialtyId" },
                values: new object[] { 2, 1, "full name", 0, 0 });
        }
    }
}
