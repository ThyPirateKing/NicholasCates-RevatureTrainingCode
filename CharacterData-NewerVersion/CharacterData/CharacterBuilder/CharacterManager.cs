using System;
using System.IO;
using CharacterData.Repo;
using CharacterData.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace CharacterBuilder
{
    public class CharacterManager
    {
        //Character Manager Fields Needed to operate and perform specific calculations and character sheet updates
        int id;
        int oldDex;
        int oldStr;
        int oldWis;
        int oldMagic;
        int oldMagicResist;

        //List of character objects needed to store the database characters locally to then manipulate their values if necessary
        public List<Character> characters = new List<Character>();
        Character newCharacter;
        public string characterFilePath;
        public IRepository file;
        public string pickClass = "";

        //Character Manager Constructor
        public CharacterManager(string filePath)
        {
            Console.Clear();
            characterFilePath = filePath;

            //Database Connection And Manipulation
            file = new EFCore();
            LoadCharactersFromDatabase();

            //JSON File Connection And Manipulation
            // file = new Serialization(characterFilePath);
            // LoadCharactersFromJson();

            Console.Clear();
        }

        /// <summary>
        /// This method runs the character manager menu.
        /// </summary>
        public void RunCharacterMenu()
        {
            bool exit = false;

            //While loop to iterate through the menu until the user exits or presses the correct key
            while (!exit)
            {

                //The character manager menu graphical interfaceK            
                string characterManagerDisplay =
                "╔═════════════════════════════════════════════════╗\n" +
                "║                Character Manager                ║\n" +
                "╠═════════════════════════════════════════════════╣\n" +
                "║          1. Show Available Characters           ║\n" +
                "║          2. Create New Character                ║\n" +
                "║          3. Update Character Name               ║\n" +
                "║          4. Level Up                            ║\n" +
                "║          5. Display Character Sheet             ║\n" +
                "║          6. Delete Character                    ║\n" +
                "║          7. Exit                                ║\n" +
                "╠═════════════════════════════════════════════════╣\n" +
                "║Select An Option: ";

                //Printing out the GUI Menu
                Console.Write(characterManagerDisplay);

                //Get user input
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            //Show characters
                            Console.Clear();
                            ShowAvailableCharacters();
                            //Shows all available characters in the database
                            break;
                        }
                    case "2":
                        {
                            //Create new character
                            Console.Clear();
                            CreateNewCharacter();
                            //Creates a new character in the database
                            break;
                        }
                    case "3":
                        {
                            //Update character name
                            Console.Clear();
                            UpdateCharacterName();
                            //Updates the name of a character in the database
                            UpdateCharacters();
                            break;
                        }
                    case "4":
                        {
                            //Level up
                            Console.Clear();
                            LevelUp();
                            //Levels up a character in the database
                            UpdateCharacters();
                            break;
                        }
                    case "5":
                        {
                            //Display character sheet
                            DisplayCharacterSheetLogic();
                            //Displays the character sheet of a character in the database
                            break;
                        }
                    case "6":
                        {
                            //Delete character
                            Console.Clear();
                            DeleteCharacter();
                            //Deletes a character from the database
                            UpdateCharacters();
                            break;
                        }
                    case "7":
                        {
                            //Exit the program
                            exit = true;
                            UpdateCharacters();
                            Console.WriteLine("\nUntil Next Time Adventurer!");
                            break;
                        }
                    default:
                        {
                            //Invalid choice
                            Console.Clear();
                            Console.WriteLine("\n***Invalid choice. Please Choose Again.***");
                            //Prints out an error message if the user inputs an invalid option
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Allows the user to select a character to level up.
        /// </summary>
        public void LevelUp()
        {
            if (characters.Count > 0)
            {
                bool validSelection = false;
                int selection;

                while (!validSelection) // Loop until a valid selection is made
                {
                    Console.WriteLine("Select Character To Level Up (1, 2, 3, etc.): ");
                    Console.WriteLine("---------------------------------------------");
                    for (int i = 0; i < characters.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {characters[i].name}");
                    }

                    try
                    {
                        Console.Write("\nEnter Selection: ");
                        string input = Console.ReadLine();
                        selection = int.Parse(input) - 1;

                        // Check if selection is within valid range
                        if (selection >= 0 && selection < characters.Count)
                        {
                            validSelection = true; // Selection is valid, break out of the loop

                            //Updating the character stats
                            oldDex = characters[selection].dex;
                            oldStr = characters[selection].str;
                            oldWis = characters[selection].wis;
                            oldMagic = characters[selection].magic;
                            oldMagicResist = characters[selection].magicResist;

                            // Create a temporary list containing the selected character
                            List<Character> tempList = new List<Character>();
                            tempList.Add(characters[selection]);

                            // Level up the character
                            characters[selection].LevelUp();

                            // Update the character's stats
                            LevelUpUpdateStats(selection);

                            Console.Clear();
                            Console.WriteLine($"Congratulations, you have finished leveling up.");
                            Console.WriteLine("-----------------------------------------------");
                            Console.WriteLine("What's next adventurer?\n");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("***Invalid selection. Please enter a number between 1 and {0}.***\n", characters.Count);
                        }
                    }
                    catch (FormatException) // Handle invalid input format (e.g., entering text instead of a number)
                    {
                        Console.Clear();
                        Console.WriteLine("***Invalid selection. Please enter a number between 1 and {0}.***\n", characters.Count);
                    }
                }
            }
            else
            {
                Console.WriteLine("\n***No Characters Found***");
            }
        }

        /// <summary>
        /// Updates the character's stats after leveling up.
        /// </summary>
        /// <param name="index">The index of the character in the list of characters.</param>
        public void LevelUpUpdateStats(int index)
        {
            // Update armor class
            characters[index].SetArmorClass(characters[index].GetArmorClass() +
                        ((characters[index].dex + characters[index].str) -
                        (oldStr + oldDex)));

            // Update hit points
            characters[index].SetMaxHitPoints(characters[index].GetMaxHitPoints() +
                        ((characters[index].str + characters[index].wis) -
                        (oldStr + oldWis)));


            

            // Update melee attack bonus and damage
            characters[index].SetMeleeDamageBonus( characters[index].GetMeleeDamageBonus() +
                        ((characters[index].str - 10) -
                        (oldStr - 10)));

            characters[index].SetMeleeAttackBonus(characters[index].GetMeleeAttackBonus() +
                        (((characters[index].str - 10) + (characters[index].dex - 10)) -
                        ((oldStr - 10) + (oldDex - 10))));

            // Update ranged attack bonus
            characters[index].SetRangedAttackBonus(characters[index].GetRangedAttackBonus() +
                        (((characters[index].str - 10) + (characters[index].dex - 10)) -
                        ((oldStr - 10) + (oldDex - 10))));

            // Update ranged attack damage
            characters[index].SetRangedDamageBonus(characters[index].GetRangedDamageBonus() +
                        ((characters[index].dex - 10) -
                        (oldDex - 10)));

            // Update magic attack bonus
            characters[index].SetMagicAttackBonus(characters[index].GetMagicAttackBonus() +
                        (((characters[index].wis - 10) + (characters[index].magic - 10)) -
                        ((oldWis - 10) + (oldMagic - 10))));

            // Update magic attack damage
            characters[index].SetMagicDamageBonus(characters[index].GetMagicDamageBonus() +
                        ((characters[index].magic - 10) -
                        (oldMagic - 10)));

            // Update the character in the file
            file.UpdateCharacter(characters[index]);
        }

        /// <summary>
        /// Displays the available characters by iterating through the list 
        /// and printing out their names. If there are no characters, it prints 
        /// a message indicating that there are no characters found.
        /// </summary>
        public void ShowAvailableCharacters()
        {
            // Check if characters list is not null and has at least one character
            if (characters != null && characters.Count > 0)
            {
                Console.WriteLine("\n\tAvailable Characters\n");

                // Iterate through the characters list and print out their names
                for (int i = 0; i < characters.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {characters[i].name}");
                    Console.WriteLine($"\t╚ {characters[i].GetCharacterClassName()}: Level {characters[i].level}\n");
                }
                Console.WriteLine("---------------------"); // Add a separator line
            }
            else
            {
                Console.WriteLine("\nNo Characters Found! Let's Make Your First Character!"); // Print a message if no characters are found
            }
        }

        /// <summary>
        /// Loads characters from the database and displays the available characters.
        /// If no characters are found, it prompts the user to create a new character.
        /// </summary>
        public void LoadCharactersFromDatabase()
        {
            var fileInfo = new FileInfo(characterFilePath);

            if (file.LoadAllCharacters() != null)
            {
                characters = file.LoadAllCharacters();
                UpdateCharacters();
                ShowAvailableCharacters();
            }
            else
                Console.WriteLine("\nNo Characters Found! Let's Make Your First Character!");
        }

        /// <summary>
        /// Loads characters from a JSON file and displays the available characters.
        /// If the file does not exist, is empty, or contains an empty array, it prompts the user to create a new character.
        /// </summary>romJson()
        public void LoadCharactersFromJson()
        {
            var fileInfo = new FileInfo(characterFilePath);
            string fileText = File.ReadAllText(characterFilePath);

            if (File.Exists(characterFilePath) && fileInfo.Length != 0 && fileText != "[]")
            {
                characters = file.LoadAllCharacters();
                Console.WriteLine("\nHere Are Your Available Characters:\n");
                ShowAvailableCharacters();
            }
            else
                Console.WriteLine("\nNo Characters Found! Let's Make Your First Character!");
        }

        /// <summary>
        /// Updates the characters and saves them to the database or JSON file.
        /// </summary>
        public void UpdateCharacters()
        {
            Console.WriteLine("\nSaving Characters...");
            file.UpdateAllCharacters(characters);
        }

        /// <summary>
        /// Saves the given character to the database or JSON file.
        /// </summary>
        /// <param name="savedCharacter">The character to be saved.</param>
        public void SaveCharacter(Character savedCharacter)
        {
            var test = new Serialization(characterFilePath).GetType();
            // Save the character to the file using the file object.
            if (file.GetType() == new Serialization(characterFilePath).GetType())
                file.SaveAllCharacters(characters);
            else
                file.SaveCharacter(savedCharacter);
        }

        /// <summary>
        /// Creates a new character with the user's input and adds it to the list of characters.
        /// The user is prompted to enter the character's name and select a class (Fighter, Wizard, or Shadow Weaver).
        /// The character's inventory and equipped items are also set based on the selected class.
        /// The character is then saved to the character file.
        /// </summary>
        public void CreateNewCharacter()
        {
            //Item as proof of concept for adding to inventory and equipping items
            // Item longsword = new Item()
            // {
            //     name = "Broadsword",
            //     description = "I am a longsword.",
            //     kindOfWeapon = "melee",
            //     weight = 10,
            //     meleeDamageBonus = 5,
            //     attackType = "Slashing",
            //     typeOfDamage = "Physical",
            //     strRequirement = 13,
            //     dexRequirement = 13,
            //     rightHandSlot = true,
            //     leftHandSlot = true,
            // };

            CharacterClass newFighter = new CharacterClass("fighter", 3, 5, 1, 1, 5);
            CharacterClass newWizard = new CharacterClass("wizard", 1, 1, 5, 5, 3);
            CharacterClass newShadowWeaver = new CharacterClass("shadow weaver",5,1,3,5,1);

            // Prompt user for character details (name, class, etc.)
            Console.WriteLine("Great Choice! Let's Make Your Character!");
            Console.WriteLine("----------------------------------------");
            Console.Write("Enter Character Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("----------------------------------------");

            bool validSelection = false;
            /// This function is used to select a selection of characters.
            while (!validSelection) // Loop until a valid selection is made
            {
                Console.WriteLine("Pick Your Class:");
                Console.WriteLine("1. Fighter");
                Console.WriteLine("2. Wizard");
                Console.WriteLine("3. Shadow Weaver");
                Console.Write("\nEnter 1, 2, or 3: ");
                pickClass = Console.ReadLine();

                /// This method is called by the user to select a character.
                switch (pickClass)
                {
                    case "1":
                        newCharacter = new Character(newFighter);
                        //newCharacter.AddToInventory(longsword);
                        //newCharacter.EquipItem(longsword);
                        newCharacter.name = name;
                        characters.Add(newCharacter);
                        validSelection = true;
                        break;
                    case "2":
                        newCharacter = new Character(newWizard);
                        //newCharacter.AddToInventory(longsword);
                        //newCharacter.EquipItem(longsword);
                        newCharacter.name = name;
                        characters.Add(newCharacter);
                        validSelection = true;
                        break;
                    case "3":
                        newCharacter = new Character(newShadowWeaver);
                        //newCharacter.AddToInventory(longsword);
                        //newCharacter.EquipItem(longsword);
                        newCharacter.name = name;
                        characters.Add(newCharacter);
                        validSelection = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Please Choose Again.");
                        Console.WriteLine("----------------------------------------");
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine($"{name} Created Successfully!");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("What Next Adventurer?");

            SaveCharacter(newCharacter);
        }

        /// <summary>
        /// Updates the name of a selected character. If there are characters available, prompts the user to select a character and enter a new name. 
        /// The function loops until a valid selection is made. If the selection is within the valid range, updates the character's name and saves it to the file. 
        /// If the selection is invalid, displays an error message. If there are no characters available, displays a message indicating that no characters were found.
        /// </summary>
        public void UpdateCharacterName()
        {
            if (characters.Count > 0)
            {
                bool validSelection = false;
                int selection;

                Console.WriteLine("Great Choice! Let's Change Your Character's Name!");
                Console.WriteLine("-------------------------------------------------");

                while (!validSelection) // Loop until a valid selection is made
                {
                    Console.WriteLine("Select Character (1, 2, 3, etc.): \n");
                    for (int i = 0; i < characters.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {characters[i].name}");
                    }

                    Console.Write("\nEnter Selection: ");

                    try
                    {
                        string input = Console.ReadLine();
                        selection = int.Parse(input) - 1;

                        // Check if selection is within valid range
                        if (selection >= 0 && selection < characters.Count)
                        {
                            Console.Write("Enter The Character's New Name: ");
                            string newName = Console.ReadLine();

                            validSelection = true; // Selection is valid, break out of the loop

                            Console.Clear();
                            Console.WriteLine($"Character named {characters[selection].name} has been changed to {newName}!");
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("What Next Adventurer?");

                            characters[selection].name = newName;
                            file.UpdateCharacter(characters[selection]);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid selection. Please enter a number between 1 and {0}.", characters.Count);
                            Console.WriteLine("-------------------------------------------------");
                        }
                    }
                    catch (FormatException) // Handle invalid input format (e.g., entering text instead of a number)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid selection. Please enter a number between 1 and {0}.", characters.Count);
                        Console.WriteLine("-------------------------------------------------");
                    }
                }
            }
            else
            {
                Console.WriteLine("\n***No Characters Found***");
            }
        }

        /// <summary>
        /// Allows the user to select a character to delete. If there are characters available, prompts the user to select a character and deletes it from the database.
        /// </summary>
        public void DeleteCharacter()
        {
            // Check if there are any characters to delete
            if (characters.Count > 0)
            {
                bool validSelection = false;
                int selection;

                // Loop until a valid selection is made
                while (!validSelection)
                    while (!validSelection) // Loop until a valid selection is made
                    {
                        // Display the list of characters for selection
                        Console.WriteLine("Select Character To Delete (Enter \"0\" To Cancel):");
                        for (int i = 0; i < characters.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {characters[i].name}");
                        }

                        try
                        {
                            Console.Write("Make Selection: ");
                            string input = Console.ReadLine();
                            selection = int.Parse(input) - 1;

                            // Check if selection is within valid range
                            if (selection >= 0 && selection < characters.Count)
                            {
                                Console.Clear();
                                Console.WriteLine($"The Character {characters[selection].name} Was Deleted.");
                                Console.WriteLine("-------------------------------------------------------\n");
                                validSelection = true; // Selection is valid, break out of the loop
                                int deleteId = characters[selection].id;

                                // Delete the character from the list
                                characters.RemoveAt(selection);

                                // Delete the character from the file or database
                                file.DeleteCharacterById(deleteId);

                                //file.DeleteCharacterInventoryById(deleteId);
                            }
                            else if (input == "0")
                            {
                                Console.Clear();
                                Console.WriteLine("Canceled Character Deletion.");
                                Console.WriteLine("----------------------------");
                                validSelection = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid selection. Please select character's number.", characters.Count);
                                Console.WriteLine("--------------------------------------------------------------------\n");
                            }
                        }
                        catch (FormatException) // Handle invalid input format (e.g., entering text instead of a number)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid selection. Please select character's number.", characters.Count);
                            Console.WriteLine("--------------------------------------------------------------------\n");
                        }
                    }
            }
            else
            {
                // Display message if there are no characters to delete
                Console.Clear();
                Console.WriteLine("\n***No Characters Found To Delete***\n");
            }
        }

        /// <summary>
        /// Displays the inventory items of a given character.
        /// </summary>
        /// <param name="newCharacter">The character whose inventory items will be displayed.</param>
        /// <returns>A string containing the numbered list of inventory items.</returns>
        public string displayInventory(Character newCharacter)
        {
            string inventoryItemList = "";
            int itemNumber = 0;

            foreach (Item e in newCharacter.inventory)
            {
                if (e != null)
                {
                    itemNumber++;
                    inventoryItemList += (itemNumber + ". " + e.name + "\n");
                }
            }
            return inventoryItemList;
        }

        /// <summary>
        /// Displays the equipped items of a given character.
        /// </summary>
        /// <param name="newCharacter">The character whose equipped items will be displayed.</param>
        /// <returns>A string containing the numbered list of equipped items.</returns>
        public string displayEquipped(Character newCharacter)
        {
            string equippedItemList = "";
            int itemNumber = 1;

            foreach (Item e in newCharacter.inventory)
            {
                if (e != null && e.isEquipped == true)
                {
                    equippedItemList += (itemNumber + ". " + e.name + "\n");
                }
            }
            return equippedItemList;
        }

        /// <summary>
        /// Displays the character sheet of a given character.
        /// </summary>
        /// <param name="newCharacter">The character whose character sheet will be displayed.</param>
        public void DisplayCharacterSheet(Character newCharacter)
        {
            string inventoryDisplay = displayInventory(newCharacter);
            string equippedDisplay = displayEquipped(newCharacter);

            // string inventoryDisplay = " ";
            // string equippedDisplay = " ";

            Console.Clear();

            //Message for the User
            Console.WriteLine($"{newCharacter.GetArmorClass()}'s Character Sheet:");

            string characterSheet =
                "╔═════════════════════════════════════════════════╗\n" +
                "║                Character Sheet                  ║\n" +
                "╠═════════════════════════════════════════════════╣\n" +
                $"║ Name: {newCharacter.name}         Class: {newCharacter.GetCharacterClassName()}       ║\n" +
                $"║ Level: {newCharacter.level}                   XP: {newCharacter.experience}                ║\n" +
                "╠═════════════════════════════════════════════════╣\n" +
                $"║  - HP: {newCharacter.GetMaxHitPoints()}                                       ║\n" +
                $"║  - AC: {newCharacter.GetArmorClass()}                                       ║\n" +
                "╠═════════════════════════════════════════════════╣\n" +
                "║                Ability Scores                   ║\n" +
                $"║  - Str: {newCharacter.str}                    - Magic: {newCharacter.magic}       ║\n" +
                $"║  - Dex: {newCharacter.dex}                    - Magic Res: {newCharacter.magicResist}   ║\n" +
                $"║  - Wis: {newCharacter.wis}                                      ║\n" +
                "╠═════════════════════════════════════════════════╣\n" +
                "║                  Attack Bonuses                 ║\n" +
                $"║  - Melee Attack Bonus:  +{newCharacter.GetMeleeAttackBonus()}                      ║\n" +
                $"║  - Melee Damage Bonus:  +{newCharacter.GetMeleeDamageBonus()}                      ║\n" +
                $"║-------------------------------------------------║\n" +
                $"║  - Ranged Attack Bonus: +{newCharacter.GetRangedAttackBonus()}                      ║\n" +
                $"║  - Ranged Damage Bonus: +{newCharacter.GetRangedDamageBonus()}                      ║\n" +
                $"║-------------------------------------------------║\n" +
                $"║  - Magic Attack Bonus:  +{newCharacter.GetMagicAttackBonus()}                      ║\n" +
                $"║  - Magic Damage Bonus:  +{newCharacter.GetMeleeDamageBonus()}                      ║\n" +
                "╠═════════════════════════════════════════════════╣\n" +
                "║                  Equipped Items                 ║\n" +
                $"║   {equippedDisplay}                                                  ║ \n" +
                "╠═════════════════════════════════════════════════╣\n" +
                "║                  Inventory                      ║\n" +
                $"║   {inventoryDisplay}                                                  ║ \n" +
                "╠═════════════════════════════════════════════════╣\n";
            Console.WriteLine(characterSheet);

            Console.Write("Press Enter To Continue");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Displays the character sheet for a selected character.
        /// Prompts the user to select a character from a list of available characters.
        /// Displays an error message if the selection is invalid.
        /// </summary>
        public void DisplayCharacterSheetLogic()
        {
            if (characters.Count > 0)
            {
                Console.Clear();
                bool validSelection = false;
                int selection;

                while (!validSelection) // Loop until a valid selection is made
                {
                    Console.WriteLine("Select Which Character To Display Character Sheet (1, 2, 3, etc.): ");
                    for (int i = 0; i < characters.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {characters[i].name}");
                    }

                    try
                    {
                        Console.Write("\nMake Selection: ");
                        string input = Console.ReadLine();
                        selection = int.Parse(input) - 1;

                        // Check if selection is within valid range
                        if (selection >= 0 && selection < characters.Count)
                        {
                            validSelection = true; // Selection is valid, break out of the loop
                            DisplayCharacterSheet(characters[selection]);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid selection. Please enter a number between 1 and {0}.", characters.Count);
                            Console.WriteLine("--------------------------------------------------------------");
                        }
                    }
                    catch (FormatException) // Handle invalid input format (e.g., entering text instead of a number)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid selection. Please enter a number between 1 and {0}.", characters.Count);
                        Console.WriteLine("--------------------------------------------------------------");
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n***No Characters Found! Let's Make One!***");
            }
        }
    }
}