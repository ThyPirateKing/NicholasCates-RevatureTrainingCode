using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloEF.Migrations
{
    /// <inheritdoc />
    public partial class Add_Owners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetOwnerid",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Owner_PetOwnerid",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PetOwnerid",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetOwnerid",
                table: "Pets");
        }
    }
}
