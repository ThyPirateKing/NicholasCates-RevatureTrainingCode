using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharacterData.Repo.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationTest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterClass",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    className = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dex = table.Column<int>(type: "int", nullable: false),
                    str = table.Column<int>(type: "int", nullable: false),
                    wis = table.Column<int>(type: "int", nullable: false),
                    magic = table.Column<int>(type: "int", nullable: false),
                    magicResist = table.Column<int>(type: "int", nullable: false),
                    baseScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClass", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    level = table.Column<int>(type: "int", nullable: false),
                    experience = table.Column<int>(type: "int", nullable: false),
                    characterClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currentHitPoints = table.Column<int>(type: "int", nullable: false),
                    gold = table.Column<int>(type: "int", nullable: false),
                    str = table.Column<int>(type: "int", nullable: false),
                    dex = table.Column<int>(type: "int", nullable: false),
                    wis = table.Column<int>(type: "int", nullable: false),
                    magic = table.Column<int>(type: "int", nullable: false),
                    magicResist = table.Column<int>(type: "int", nullable: false),
                    characterClassid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.id);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterClass_characterClassid",
                        column: x => x.characterClassid,
                        principalTable: "CharacterClass",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weight = table.Column<double>(type: "float", nullable: false),
                    value = table.Column<int>(type: "int", nullable: false),
                    typeOfItem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slotType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isEquipped = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maxHitPointBonus = table.Column<int>(type: "int", nullable: false),
                    currentHitPointBonus = table.Column<int>(type: "int", nullable: false),
                    meleeDamageBonus = table.Column<int>(type: "int", nullable: false),
                    rangedDamageBonus = table.Column<int>(type: "int", nullable: false),
                    magicDamageBonus = table.Column<int>(type: "int", nullable: false),
                    meleeAttackBonus = table.Column<int>(type: "int", nullable: false),
                    rangedAttackBonus = table.Column<int>(type: "int", nullable: false),
                    magicAttackBonus = table.Column<int>(type: "int", nullable: false),
                    armorClassBonus = table.Column<int>(type: "int", nullable: false),
                    attackType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typeOfDamage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strRequirement = table.Column<int>(type: "int", nullable: false),
                    dexRequirement = table.Column<int>(type: "int", nullable: false),
                    wisRequirement = table.Column<int>(type: "int", nullable: false),
                    magicRequirement = table.Column<int>(type: "int", nullable: false),
                    Characterid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.id);
                    table.ForeignKey(
                        name: "FK_Item_Characters_Characterid",
                        column: x => x.Characterid,
                        principalTable: "Characters",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CharacterClassItem",
                columns: table => new
                {
                    linkingTableCharacterClassesid = table.Column<int>(type: "int", nullable: false),
                    linkingTableItemsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClassItem", x => new { x.linkingTableCharacterClassesid, x.linkingTableItemsid });
                    table.ForeignKey(
                        name: "FK_CharacterClassItem_CharacterClass_linkingTableCharacterClassesid",
                        column: x => x.linkingTableCharacterClassesid,
                        principalTable: "CharacterClass",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterClassItem_Item_linkingTableItemsid",
                        column: x => x.linkingTableItemsid,
                        principalTable: "Item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClassItem_linkingTableItemsid",
                table: "CharacterClassItem",
                column: "linkingTableItemsid");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_characterClassid",
                table: "Characters",
                column: "characterClassid");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Characterid",
                table: "Item",
                column: "Characterid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterClassItem");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "CharacterClass");
        }
    }
}
