using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy.Infrastracture.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disease",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Dosage = table.Column<decimal>(type: "numeric(18,5)", nullable: false),
                    Company = table.Column<int>(type: "int", nullable: false),
                    ScientificName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicine_Category",
                        column: x => x.Category,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medicine_Company",
                        column: x => x.Company,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientDisease",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient = table.Column<int>(type: "int", nullable: false),
                    Disease = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDisease", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientDisease_Disease",
                        column: x => x.Disease,
                        principalTable: "Disease",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientDisease_Patient",
                        column: x => x.Patient,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiseaseMedicine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disease = table.Column<int>(type: "int", nullable: false),
                    Medicine = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseMedicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiseaseMedicine_Disease",
                        column: x => x.Disease,
                        principalTable: "Disease",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiseaseMedicine_Medicine",
                        column: x => x.Medicine,
                        principalTable: "Medicine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicienIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medicine = table.Column<int>(type: "int", nullable: false),
                    Ingredient = table.Column<int>(type: "int", nullable: false),
                    Ratio = table.Column<decimal>(type: "numeric(10,7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicienIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicienIngredient_Ingredient",
                        column: x => x.Ingredient,
                        principalTable: "Ingredient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicienIngredient_Medicine",
                        column: x => x.Medicine,
                        principalTable: "Medicine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseMedicine_Disease",
                table: "DiseaseMedicine",
                column: "Disease");

            migrationBuilder.CreateIndex(
                name: "IX_PersonMedicine",
                table: "DiseaseMedicine",
                columns: new[] { "Medicine", "Disease" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicienIngredient_Ingredient",
                table: "MedicienIngredient",
                column: "Ingredient");

            migrationBuilder.CreateIndex(
                name: "IX_MedicienIngredient_Medicine",
                table: "MedicienIngredient",
                column: "Medicine");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_Category",
                table: "Medicine",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_Company",
                table: "Medicine",
                column: "Company");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDisease_Disease",
                table: "PatientDisease",
                column: "Disease");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDisease_Patient",
                table: "PatientDisease",
                column: "Patient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiseaseMedicine");

            migrationBuilder.DropTable(
                name: "MedicienIngredient");

            migrationBuilder.DropTable(
                name: "PatientDisease");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Disease");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
