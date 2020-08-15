using Microsoft.EntityFrameworkCore.Migrations;

namespace LuckyPierre.Migrations
{
    public partial class Quintile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatsFlavors_Flavors_FlavorId",
                table: "TreatsFlavors");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatsFlavors_Treats_TreatId",
                table: "TreatsFlavors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TreatsFlavors",
                table: "TreatsFlavors");

            migrationBuilder.RenameTable(
                name: "TreatsFlavors",
                newName: "TreatFlavors");

            migrationBuilder.RenameIndex(
                name: "IX_TreatsFlavors_TreatId",
                table: "TreatFlavors",
                newName: "IX_TreatFlavors_TreatId");

            migrationBuilder.RenameIndex(
                name: "IX_TreatsFlavors_FlavorId",
                table: "TreatFlavors",
                newName: "IX_TreatFlavors_FlavorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TreatFlavors",
                table: "TreatFlavors",
                column: "TreatFlavorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatFlavors_Flavors_FlavorId",
                table: "TreatFlavors",
                column: "FlavorId",
                principalTable: "Flavors",
                principalColumn: "FlavorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatFlavors_Treats_TreatId",
                table: "TreatFlavors",
                column: "TreatId",
                principalTable: "Treats",
                principalColumn: "TreatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatFlavors_Flavors_FlavorId",
                table: "TreatFlavors");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatFlavors_Treats_TreatId",
                table: "TreatFlavors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TreatFlavors",
                table: "TreatFlavors");

            migrationBuilder.RenameTable(
                name: "TreatFlavors",
                newName: "TreatsFlavors");

            migrationBuilder.RenameIndex(
                name: "IX_TreatFlavors_TreatId",
                table: "TreatsFlavors",
                newName: "IX_TreatsFlavors_TreatId");

            migrationBuilder.RenameIndex(
                name: "IX_TreatFlavors_FlavorId",
                table: "TreatsFlavors",
                newName: "IX_TreatsFlavors_FlavorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TreatsFlavors",
                table: "TreatsFlavors",
                column: "TreatFlavorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatsFlavors_Flavors_FlavorId",
                table: "TreatsFlavors",
                column: "FlavorId",
                principalTable: "Flavors",
                principalColumn: "FlavorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatsFlavors_Treats_TreatId",
                table: "TreatsFlavors",
                column: "TreatId",
                principalTable: "Treats",
                principalColumn: "TreatId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
