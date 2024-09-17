using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharacterData.Repo.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    level = table.Column<int>(type: "int", nullable: true),
                    experience = table.Column<int>(type: "int", nullable: true),
                    characterClassName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AbilityScores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    characterID = table.Column<int>(type: "int", nullable: false),
                    dex = table.Column<int>(type: "int", nullable: false),
                    str = table.Column<int>(type: "int", nullable: false),
                    wis = table.Column<int>(type: "int", nullable: false),
                    magic = table.Column<int>(type: "int", nullable: false),
                    magicResist = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityScores", x => x.id);
                    table.ForeignKey(
                        name: "FK_AbilityScores_Characters_characterID",
                        column: x => x.characterID,
                        principalTable: "Characters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArmorClass",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AC = table.Column<int>(type: "int", nullable: false),
                    characterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorClass", x => x.id);
                    table.ForeignKey(
                        name: "FK_ArmorClass_Characters_characterID",
                        column: x => x.characterID,
                        principalTable: "Characters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClass",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    characterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClass", x => x.id);
                    table.ForeignKey(
                        name: "FK_CharacterClass_Characters_characterID",
                        column: x => x.characterID,
                        principalTable: "Characters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isEquipped = table.Column<bool>(type: "bit", nullable: true),
                    headSlot = table.Column<bool>(type: "bit", nullable: true),
                    chestSlot = table.Column<bool>(type: "bit", nullable: true),
                    armsSlot = table.Column<bool>(type: "bit", nullable: true),
                    legsSlot = table.Column<bool>(type: "bit", nullable: true),
                    rightHandSlot = table.Column<bool>(type: "bit", nullable: true),
                    leftHandSlot = table.Column<bool>(type: "bit", nullable: true),
                    necklaceSlot = table.Column<bool>(type: "bit", nullable: true),
                    ringSlot = table.Column<bool>(type: "bit", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weight = table.Column<double>(type: "float", nullable: true),
                    kindOfWeapon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kindOfArmor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hitPoints = table.Column<int>(type: "int", nullable: false),
                    meleeDamageBonus = table.Column<int>(type: "int", nullable: false),
                    rangedDamageBonus = table.Column<int>(type: "int", nullable: false),
                    magicDamageBonus = table.Column<int>(type: "int", nullable: false),
                    meleeAttackBonus = table.Column<int>(type: "int", nullable: false),
                    rangedAttackBonus = table.Column<int>(type: "int", nullable: false),
                    magicAttackBonus = table.Column<int>(type: "int", nullable: false),
                    armorClassBonus = table.Column<int>(type: "int", nullable: false),
                    attackType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeOfDamage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strRequirement = table.Column<int>(type: "int", nullable: false),
                    dexRequirement = table.Column<int>(type: "int", nullable: false),
                    wisRequirement = table.Column<int>(type: "int", nullable: false),
                    magicRequirement = table.Column<int>(type: "int", nullable: false),
                    Characterid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Equipment_Characters_Characterid",
                        column: x => x.Characterid,
                        principalTable: "Characters",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "HitPoints",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    characterID = table.Column<int>(type: "int", nullable: false),
                    hitPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HitPoints", x => x.id);
                    table.ForeignKey(
                        name: "FK_HitPoints_Characters_characterID",
                        column: x => x.characterID,
                        principalTable: "Characters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MagicAttack",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    characterID = table.Column<int>(type: "int", nullable: false),
                    magicAttackBonus = table.Column<int>(type: "int", nullable: false),
                    magicDamageBonus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicAttack", x => x.id);
                    table.ForeignKey(
                        name: "FK_MagicAttack_Characters_characterID",
                        column: x => x.characterID,
                        principalTable: "Characters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeleeAttack",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    characterID = table.Column<int>(type: "int", nullable: false),
                    meleeAttackBonus = table.Column<int>(type: "int", nullable: false),
                    meleeDamageBonus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeleeAttack", x => x.id);
                    table.ForeignKey(
                        name: "FK_MeleeAttack_Characters_characterID",
                        column: x => x.characterID,
                        principalTable: "Characters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RangedAttack",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    characterID = table.Column<int>(type: "int", nullable: false),
                    rangedAttackBonus = table.Column<int>(type: "int", nullable: false),
                    rangedDamageBonus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangedAttack", x => x.id);
                    table.ForeignKey(
                        name: "FK_RangedAttack_Characters_characterID",
                        column: x => x.characterID,
                        principalTable: "Characters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbilityScores_characterID",
                table: "AbilityScores",
                column: "characterID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArmorClass_characterID",
                table: "ArmorClass",
                column: "characterID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClass_characterID",
                table: "CharacterClass",
                column: "characterID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Characterid",
                table: "Equipment",
                column: "Characterid");

            migrationBuilder.CreateIndex(
                name: "IX_HitPoints_characterID",
                table: "HitPoints",
                column: "characterID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MagicAttack_characterID",
                table: "MagicAttack",
                column: "characterID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeleeAttack_characterID",
                table: "MeleeAttack",
                column: "characterID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RangedAttack_characterID",
                table: "RangedAttack",
                column: "characterID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityScores");

            migrationBuilder.DropTable(
                name: "ArmorClass");

            migrationBuilder.DropTable(
                name: "CharacterClass");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "HitPoints");

            migrationBuilder.DropTable(
                name: "MagicAttack");

            migrationBuilder.DropTable(
                name: "MeleeAttack");

            migrationBuilder.DropTable(
                name: "RangedAttack");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
