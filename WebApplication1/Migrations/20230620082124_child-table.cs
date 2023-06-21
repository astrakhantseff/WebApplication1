using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class childtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Cabinet_CabinetId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Region_RegionId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialty_SpecialtyId",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_CabinetId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_RegionId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "SpecialtyId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CabinetId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Cabinet",
                columns: new[] { "Id", "Number" },
                values: new object[] { 1, "123" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "CabinetId", "FullName", "RegionId", "SpecialtyId" },
                values: new object[] { 2, 1, "full name", 0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cabinet",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "SpecialtyId",
                table: "Doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CabinetId",
                table: "Doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                table: "Doctors",
                columns: new[] { "Id", "CabinetId", "FullName", "RegionId", "SpecialtyId" },
                values: new object[] { 1, null, "full name", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CabinetId",
                table: "Doctors",
                column: "CabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RegionId",
                table: "Doctors",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Cabinet_CabinetId",
                table: "Doctors",
                column: "CabinetId",
                principalTable: "Cabinet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Region_RegionId",
                table: "Doctors",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialty_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId",
                principalTable: "Specialty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
