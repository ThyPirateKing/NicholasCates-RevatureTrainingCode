using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharacterData.Repo.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationTest5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterClassItem_CharacterClass_characterClassIDid",
                table: "CharacterClassItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterClassItem_Item_itemIDid",
                table: "CharacterClassItem");

            migrationBuilder.RenameColumn(
                name: "itemIDid",
                table: "CharacterClassItem",
                newName: "itemid");

            migrationBuilder.RenameColumn(
                name: "characterClassIDid",
                table: "CharacterClassItem",
                newName: "characterClassid");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterClassItem_itemIDid",
                table: "CharacterClassItem",
                newName: "IX_CharacterClassItem_itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterClassItem_CharacterClass_characterClassid",
                table: "CharacterClassItem",
                column: "characterClassid",
                principalTable: "CharacterClass",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterClassItem_Item_itemid",
                table: "CharacterClassItem",
                column: "itemid",
                principalTable: "Item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterClassItem_CharacterClass_characterClassid",
                table: "CharacterClassItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterClassItem_Item_itemid",
                table: "CharacterClassItem");

            migrationBuilder.RenameColumn(
                name: "itemid",
                table: "CharacterClassItem",
                newName: "itemIDid");

            migrationBuilder.RenameColumn(
                name: "characterClassid",
                table: "CharacterClassItem",
                newName: "characterClassIDid");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterClassItem_itemid",
                table: "CharacterClassItem",
                newName: "IX_CharacterClassItem_itemIDid");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterClassItem_CharacterClass_characterClassIDid",
                table: "CharacterClassItem",
                column: "characterClassIDid",
                principalTable: "CharacterClass",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterClassItem_Item_itemIDid",
                table: "CharacterClassItem",
                column: "itemIDid",
                principalTable: "Item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
