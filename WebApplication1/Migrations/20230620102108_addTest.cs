using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class addTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Region_RegionId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Region",
                table: "Region");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cabinet",
                table: "Cabinet");

            migrationBuilder.RenameTable(
                name: "Specialty",
                newName: "Specialties");

            migrationBuilder.RenameTable(
                name: "Region",
                newName: "Regions");

            migrationBuilder.RenameTable(
                name: "Cabinet",
                newName: "Cabinets");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Regions",
                newName: "NumberOfRegion");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Cabinets",
                newName: "NumberOfCab");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cabinets",
                table: "Cabinets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Regions_RegionId",
                table: "Patients",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Regions_RegionId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cabinets",
                table: "Cabinets");

            migrationBuilder.RenameTable(
                name: "Specialties",
                newName: "Specialty");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "Region");

            migrationBuilder.RenameTable(
                name: "Cabinets",
                newName: "Cabinet");

            migrationBuilder.RenameColumn(
                name: "NumberOfRegion",
                table: "Region",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "NumberOfCab",
                table: "Cabinet",
                newName: "Number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Region",
                table: "Region",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cabinet",
                table: "Cabinet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Region_RegionId",
                table: "Patients",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
