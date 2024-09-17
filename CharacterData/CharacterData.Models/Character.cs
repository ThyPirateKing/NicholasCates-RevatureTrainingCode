using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CharacterData.Models
{
    public class Character
    {
        public List<Equipment> inventory { get; set; }

        //Character Properties from the Character class
        public int id { get; set; } // Unique identifier for the character
        public string? name { get; set; } = "Test 6"; // Name of the character
        public int? level { get; set; } // Level of the character
        public int? experience { get; set; } // Experience points of the character
        public string? characterClassName { get; set; } // Class of the character

        //Character properties from other classes
        public ArmorClass? armorClass { get; set; }
        public AbilityScores abilityScores { get; set; }
        public HitPoints hitPoints { get; set; }
        public CharacterClass? characterClass { get; set; }
        public MagicAttack? magicAttack { get; set; }
        public MeleeAttack? meleeAttack { get; set; }
        public RangedAttack? rangedAttack { get; set; }

        public Character() { }

        public Character(CharacterClass newCharacterClass)
        {
            this.characterClass = newCharacterClass;

            abilityScores = new AbilityScores();

            magicAttack = new MagicAttack();
            meleeAttack = new MeleeAttack();
            rangedAttack = new RangedAttack();

            inventory = new List<Equipment>();
            //equippedSlots = new List<Equipment>();
            //equippedSlots.Add(null);

            experience = 0;
            level = 1;
            this.characterClassName = this.characterClass.GetCharacterClassName();

            abilityScores.dex = characterClass.GetDex();
            abilityScores.str = characterClass.GetStr();
            abilityScores.wis = characterClass.GetWis();
            abilityScores.magic = characterClass.GetMagic();
            abilityScores.magicResist = characterClass.GetMagicResist();

            armorClass = new ArmorClass((abilityScores.dex + abilityScores.str));
            hitPoints = new HitPoints((abilityScores.str + abilityScores.wis));

            magicAttack.magicDamageBonus = abilityScores.magic - 10;
            magicAttack.magicAttackBonus = (abilityScores.wis - 10) + (abilityScores.magic - 10);

            meleeAttack.meleeDamageBonus = abilityScores.str - 10;
            meleeAttack.meleeAttackBonus = (abilityScores.str - 10) + (abilityScores.dex - 10);

            rangedAttack.rangedDamageBonus = (abilityScores.dex - 10);
            rangedAttack.rangedAttackBonus = (abilityScores.str - 10) + (abilityScores.dex - 10);
        }

        /// <summary>
        /// Increases the level of the character and adjusts ability scores accordingly based on the character's class.
        /// </summary>
        /// <remarks>
        /// The method increments the character's level by one and resets the experience points to zero. It then displays a congratulatory message for leveling up.
        /// Depending on the character's class (Wizard, Fighter, Shadow Weaver), specific ability scores are increased by 3 points, and the player can allocate an additional point to any other ability score.
        /// The player is prompted to choose which ability score to increase and the method handles the allocation accordingly.
        /// </remarks>
        public void LevelUp()
        {
            bool exit = false;
            string choice = "";
            level++;
            experience = 0;

            Console.Clear();

            Console.WriteLine($"\nCongratulations! You have just leveled up from {level - 1} to {level}!");
            Console.WriteLine($"------------------------------------------------------");

            if (characterClassName == "Wizard")
            {
                abilityScores.wis += 3;
                abilityScores.magic += 3;
                Console.WriteLine($"As a {characterClassName}, your Wisdom and Magic ability scores increased by 3 and you get 1 additional point to add to any other ability score.\n");

                exit = false;
                while (!exit)
                {
                    Console.WriteLine($"Your Current Ability Scores Are Now:");
                    Console.WriteLine($"Str: {abilityScores.str} \nDex: {abilityScores.dex} \nWis: {abilityScores.wis} \nMagic: {abilityScores.magic} \nMagic Resistance: {abilityScores.magicResist}\n");

                    Console.WriteLine("Which Ability Score Would You Like To Increase?");
                    Console.WriteLine("1. Str");
                    Console.WriteLine("2. Dex");
                    Console.WriteLine("3. Wis");
                    Console.WriteLine("4. Magic");
                    Console.WriteLine("5. Magic Resistance");
                    Console.Write("Choose An Ability Score: ");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            {
                                abilityScores.str++;
                                exit = true;
                                break;
                            }
                        case "2":
                            {
                                abilityScores.dex++;
                                exit = true;
                                break;
                            }
                        case "3":
                            {
                                abilityScores.wis++;
                                exit = true;
                                break;
                            }
                        case "4":
                            {
                                abilityScores.magic++;
                                exit = true;
                                break;
                            }
                        case "5":
                            {

                                abilityScores.magicResist++;
                                exit = true;
                                break;
                            }
                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("\n***Invalid choice. Please Choose Again.***\n");
                                break;
                            }
                    }
                }
                Console.Clear();
                Console.WriteLine($"Congratulations, you have finished leveling up.");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("What's next adventurer?\n");
            }

            if (characterClassName == "Fighter")
            {
                abilityScores.str += 3;
                abilityScores.magicResist += 3;

                Console.WriteLine($"As a {characterClassName}, your Strength and Magic Resist ability scores increased by 3 and you get 1 additional point to add to any other ability score.\n");

                exit = false;
                while (!exit)
                {
                    Console.WriteLine($"Your Current Ability Scores Are Now:");
                    Console.WriteLine($"Str: {abilityScores.str}, \nDex: {abilityScores.dex}, \nWis: {abilityScores.wis} \nMagic: {abilityScores.magic}, \nMagic Resistance: {abilityScores.magicResist}\n");

                    Console.WriteLine("Which Ability Score Would You Like To Increase?");
                    Console.WriteLine("1. Str");
                    Console.WriteLine("2. Dex");
                    Console.WriteLine("3. Wis");
                    Console.WriteLine("4. Magic");
                    Console.WriteLine("5. Magic Resistance");
                    Console.Write("Choose An Ability Score: ");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            {
                                abilityScores.str++;
                                exit = true;
                                break;
                            }
                        case "2":
                            {
                                abilityScores.dex++;
                                exit = true;
                                break;
                            }
                        case "3":
                            {
                                abilityScores.wis++;
                                exit = true;
                                break;
                            }
                        case "4":
                            {
                                abilityScores.magic++;
                                exit = true;
                                break;
                            }
                        case "5":
                            {
                                abilityScores.magicResist++;
                                exit = true;
                                break;
                            }
                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("\n***Invalid choice. Please Choose Again.***\n");
                                break;
                            }
                    }
                }

                Console.Clear();
                Console.WriteLine($"Congratulations, you have finished leveling up.");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("What's next adventurer?\n");
            }

            if (characterClassName == "Shadow Weaver")
            {
                abilityScores.dex += 3;
                abilityScores.magic += 3;
                Console.WriteLine($"I see you are a {characterClassName}!");
                Console.WriteLine($"\nYour Current Ability Scores Are Now:");
                Console.WriteLine($"Str: {abilityScores.str}, \nDex: {abilityScores.dex}, \nWis: {abilityScores.wis} \nMagic: {abilityScores.magic}, \nMagic Resistance: {abilityScores.magicResist}\n");

                exit = false;
                while (!exit)
                {
                    Console.WriteLine($"As a {characterClassName}, your Dexterity and Magic ability scores increased by 3 and you get 1 additional point to add to any other ability score.\n");

                    Console.WriteLine("Which Ability Score Would You Like To Increase?");
                    Console.WriteLine("1. Str");
                    Console.WriteLine("2. Dex");
                    Console.WriteLine("3. Wis");
                    Console.WriteLine("4. Magic");
                    Console.WriteLine("5. Magic Resistance");
                    Console.Write("Choose An Ability Score: ");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            {
                                abilityScores.str++;
                                exit = true;
                                break;
                            }
                        case "2":
                            {
                                abilityScores.dex++;
                                exit = true;
                                break;
                            }
                        case "3":
                            {
                                abilityScores.wis++;
                                exit = true;
                                break;
                            }
                        case "4":
                            {
                                abilityScores.magic++;
                                exit = true;
                                break;
                            }
                        case "5":
                            {
                                abilityScores.magicResist++;
                                exit = true;
                                break;
                            }
                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("\n***Invalid choice. Please Choose Again.***\n");
                                break;
                            }
                    }
                }
            }
        }

        /// <summary>Displays the names of items in the inventory.</summary>
        /// <returns>A string containing the names of items in the inventory.</returns>
        public string displayInventory()
        {
            string inventoryItemList = "";

            foreach (Equipment e in inventory)
            {
                if (e == null) { }
                else
                    inventoryItemList += (e.name + " ");
            }

            return inventoryItemList;
        }


        /// <summary>
        /// Display the currently equipped items.
        /// </summary>
        /// <returns>A string representing the currently equipped items.</returns>
        public string displayEquipped()
        {
            string equippedItemList = "";

            foreach (Equipment e in inventory)
            {
                if (e.isEquipped == true)
                    equippedItemList += (e.name + " ");
            }

            return equippedItemList;
        }

        //This method adds an equipment object to the inventory list
        public void AddToInventory(Equipment equipment)
        {
            //Add the equipment object to the inventory list
            inventory.Add(equipment);
        }

        public void RemoveFromInventory(Equipment equipment)
        {
            inventory.Remove(equipment);
        }

        public bool EquipItem(Equipment equipment)
        {
            if (inventory.Contains(equipment) && equipment.isEquipped == false)
            {
                foreach (Equipment p in inventory)
                {
                    if (p.whatIsSlot() == equipment.whatIsSlot())
                    {
                        UnequipItem( inventory[ inventory.IndexOf(p) ] );
                        inventory[ inventory.IndexOf(p) ].isEquipped = true;
                        UpdateCharacterStats(equipment);
                        return true;
                    }
                    else
                    {
                        inventory[ inventory.IndexOf(p) ].isEquipped = true;
                        UpdateCharacterStats(equipment);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool UnequipItem(Equipment equippedItem)
        {
            if (inventory.Contains(equippedItem) && equippedItem.isEquipped == true)
            {
                inventory[ inventory.IndexOf(equippedItem) ].isEquipped = false;
                // Clear the equipped slot
                UpdateCharacterStats(inventory[ inventory.IndexOf(equippedItem) ], false); // Update stats with negative equipment bonuses
                return true;
            }
            return false;
        }

        
        //NEED TO IMPLEMENT EVENTUALLY
        // private bool CanEquip(Equipment equipment) // Replace with actual logic for character checks
        // {
        //     // Implement checks based on character class, stats, etc.
        //     return true; // Replace with actual implementation
        // }

        public void UpdateCharacterStats(Equipment equipment, bool isEquipping = true)
        {
            // Update character stats based on equipment bonuses (positive or negative based on isEquipping)

            // Update character stats based on equipment bonuses/penalties
            if (isEquipping)
            {
                armorClass.AC += equipment.armorClassBonus;

                meleeAttack.meleeAttackBonus += equipment.meleeAttackBonus;

                meleeAttack.meleeDamageBonus += equipment.meleeDamageBonus;

                rangedAttack.rangedAttackBonus += equipment.rangedAttackBonus;

                rangedAttack.rangedDamageBonus += equipment.rangedDamageBonus;

                magicAttack.magicAttackBonus += equipment.magicAttackBonus;

                magicAttack.magicDamageBonus += equipment.magicDamageBonus;

                hitPoints.hitPoints += equipment.hitPoints;
            }
            else
            {
                armorClass.AC -= equipment.armorClassBonus;

                meleeAttack.meleeAttackBonus -= equipment.meleeAttackBonus;

                meleeAttack.meleeDamageBonus -= equipment.meleeDamageBonus;

                rangedAttack.rangedAttackBonus -= equipment.rangedAttackBonus;

                rangedAttack.rangedDamageBonus -= equipment.rangedDamageBonus;

                magicAttack.magicAttackBonus -= equipment.magicAttackBonus;

                magicAttack.magicDamageBonus -= equipment.magicDamageBonus;

                hitPoints.hitPoints -= equipment.hitPoints;
            }
        }

        public void DisplayCharacter()
        {
            // Get the strings for the inventory and equipped items
            string inventoryDisplay = displayInventory();
            string equippedDisplay = displayEquipped();

            // Display message to the user
            //Message for the User
            Console.WriteLine($"{this.name}'s Character Sheet:");
            Console.WriteLine("----------------------------------------\n");

            string characterSheet =
    "╔═════════════════════════════════════════════════╗\n" +
    "║                Character Sheet                  ║\n" +
    "╠═════════════════════════════════════════════════╣\n" +
    $"║ Name: {name}         Class: {this.characterClassName}       ║\n" +
    $"║ Level: {this.level}                   XP: {this.experience}                ║\n" +
    "╠═════════════════════════════════════════════════╣\n" +
    $"║  - HP: {this.hitPoints.hitPoints}                                       ║\n" +
    $"║  - AC: {this.armorClass.AC}                                       ║\n" +
    "╠═════════════════════════════════════════════════╣\n" +
    "║                Ability Scores                   ║\n" +
    $"║  - Str: {this.abilityScores.str}                    - Magic: {this.abilityScores.magic}       ║\n" +
    $"║  - Dex: {this.abilityScores.dex}                    - Magic Res: {this.abilityScores.magicResist}   ║\n" +
    $"║  - Wis: {this.abilityScores.wis}                                      ║\n" +
    "╠═════════════════════════════════════════════════╣\n" +
    "║                  Attack Bonuses                 ║\n" +
    $"║  - Melee Attack Bonus:  +{this.meleeAttack.meleeAttackBonus}                      ║\n" +
    $"║  - Melee Damage Bonus:  +{this.meleeAttack.meleeDamageBonus}                      ║\n" +
    $"║-------------------------------------------------║\n" +
    $"║  - Ranged Attack Bonus: +{this.rangedAttack.rangedAttackBonus}                      ║\n" +
    $"║  - Ranged Damage Bonus: +{this.rangedAttack.rangedDamageBonus}                      ║\n" +
    $"║-------------------------------------------------║\n" +
    $"║  - Magic Attack Bonus:  +{this.magicAttack.magicAttackBonus}                      ║\n" +
    $"║  - Magic Damage Bonus:  +{this.magicAttack.magicDamageBonus}                      ║\n" +
    "╠═════════════════════════════════════════════════╣\n" +
    "║                  Equipped Items                 ║\n" +
    $"║           {equippedDisplay}                                      ║ \n" +
    "╠═════════════════════════════════════════════════╣\n" +
    "║                  Inventory                      ║\n" +
    $"║           {inventoryDisplay}                                      ║ \n" +
    "╠═════════════════════════════════════════════════╣\n"


;
            Console.WriteLine(characterSheet);
        }
    }
}