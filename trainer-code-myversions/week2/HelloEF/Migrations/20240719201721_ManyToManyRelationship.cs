using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloEF.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Owner_PetOwnerid",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PetOwnerid",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetOwnerid",
                table: "Pets");

            migrationBuilder.CreateTable(
                name: "OwnerPet",
                columns: table => new
                {
                    Ownersid = table.Column<int>(type: "int", nullable: false),
                    Petsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerPet", x => new { x.Ownersid, x.Petsid });
                    table.ForeignKey(
                        name: "FK_OwnerPet_Owner_Ownersid",
                        column: x => x.Ownersid,
                        principalTable: "Owner",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerPet_Pets_Petsid",
                        column: x => x.Petsid,
                        principalTable: "Pets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwnerPet_Petsid",
                table: "OwnerPet",
                column: "Petsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnerPet");

            migrationBuilder.AddColumn<int>(
                name: "PetOwnerid",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetOwnerid",
                table: "Pets",
                column: "PetOwnerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Owner_PetOwnerid",
                table: "Pets",
                column: "PetOwnerid",
                principalTable: "Owner",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
