using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharacterData.Repo.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationTest4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterClassItem_CharacterClass_linkingTableCharacterClassesid",
                table: "CharacterClassItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterClassItem_Item_linkingTableItemsid",
                table: "CharacterClassItem");

            migrationBuilder.RenameColumn(
                name: "linkingTableItemsid",
                table: "CharacterClassItem",
                newName: "itemIDid");

            migrationBuilder.RenameColumn(
                name: "linkingTableCharacterClassesid",
                table: "CharacterClassItem",
                newName: "characterClassIDid");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterClassItem_linkingTableItemsid",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "linkingTableItemsid");

            migrationBuilder.RenameColumn(
                name: "characterClassIDid",
                table: "CharacterClassItem",
                newName: "linkingTableCharacterClassesid");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterClassItem_itemIDid",
                table: "CharacterClassItem",
                newName: "IX_CharacterClassItem_linkingTableItemsid");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterClassItem_CharacterClass_linkingTableCharacterClassesid",
                table: "CharacterClassItem",
                column: "linkingTableCharacterClassesid",
                principalTable: "CharacterClass",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterClassItem_Item_linkingTableItemsid",
                table: "CharacterClassItem",
                column: "linkingTableItemsid",
                principalTable: "Item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
