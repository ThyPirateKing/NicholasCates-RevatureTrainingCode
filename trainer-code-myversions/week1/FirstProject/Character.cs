/*
    The character class allows for the creation of a character and the initializing of building that character sheet
    This class will also be used to display the character sheet at the end of building the character as well
    May add more functionality in future
*/

public class Character : CharacterStats
{

    //Variables --> will most likely be removed at some point for easier readability and less variables needed to run the program
    int str, dex, con, inte, wis, chari, strM, dexM, conM, intM, wisM, charM = 0;
    int inspiration, prof, armor, initiative, speed, hitPoints, hitPointMax, tempHP, hitDice, deathSaveS, deathSaveF = 0;
    string acrobaticsInput, animalHandlingInput, arcanaInput, athleticsInput, deceptionInput,
               historyInput, insightInput, intimidationInput, investigationInput, medicineInput,
               natureInput, perceptionInput, performanceInput, persuasionInput, religionInput,
               sleightOfHandInput, stealthInput, survivalInput = "n";
    string charName, charClass, level, background, race, alignment = "not specified";

    //Constructor for Class
    public Character()
    {

    }


    //Method to build a new DnD Character with text input
    public void BuildCharacter()
    {
        //Initializing a new Character
        CharacterStats newCharacter = new CharacterStats();

        //Welcome Message for New User
        Console.WriteLine("Welcome to Dungeons & Dragons! Let's make your character!");
        Console.WriteLine("-----------------------------------------------------------\n");

        //Building the Character With Text Prompts
        UserCharacterStatInput(newCharacter);

        //Character Display Object To Display The Character Sheet
        CharacterDisplay myCharacterDisplayed = new CharacterDisplay(newCharacter);
        //Displaying the Character Sheet
        myCharacterDisplayed.Display();
    }

    //This method calls all the methods needed to fill out a character sheet by the user
    public static void UserCharacterStatInput(CharacterStats newCharacter)
    {
        //Setting the top section of the character sheet
        TopSectionOfCharacterSheet(newCharacter);

        //Setting Character Ability Scores
        UserInputAbilityScores(newCharacter);

        //Setting Character Skill Proficiencies
        UserInputSkillProficiencies(newCharacter);
    }

    //This method consolodates the methods to allow for the user to add in the information on the top section of the character sheet
    public static void TopSectionOfCharacterSheet(CharacterStats newCharacter)
    {
        //Setting Character Name
        UserInputName(newCharacter);

        //Setting Character Race
        UserInputRace(newCharacter);

        //Setting Character Class
        UserInputClass(newCharacter);

        //Setting Character Background
        UserInputBackground(newCharacter);

        //Setting Character Alignment
        UserInputAlignment(newCharacter);

        //Setting Character Level
        UserInputLevel(newCharacter);

        //Setting Character Armor Class
        UserInputArmorClass(newCharacter);

        //Setting Character Speed
        UserInputSpeed(newCharacter);

        //Setting Character Hit Points
        UserInputHitPoints(newCharacter);

        //Setting Character Hit Point Maximum (assuming it can be different)
        UserInputHitPointMaximum(newCharacter);

        //Setting Character Temporary Hit Points
        UserInputTemporaryHitPoints(newCharacter);

        //Setting Character Hit Dice
        UserInputHitDice(newCharacter);

        Console.WriteLine();

        //Setting Character Inspiration (assuming boolean value)
        UserInputInspiration(newCharacter);
    }

    //Allows the user to input the ability Scores (Strength, Dexterity, Constitution, Intelligence, Wisdom, and Charisma)
    public static void UserInputAbilityScores(CharacterStats character)
    {
        //Each ability score for the character's stats are added by the user

        Console.WriteLine("\nEnter Character Ability Scores:");
        Console.WriteLine("-------------------------------");

        Console.Write("Strength: ");
        character.SetStrength(int.Parse(Console.ReadLine()));

        Console.Write("Dexterity: ");
        character.SetDexterity(int.Parse(Console.ReadLine()));

        Console.Write("Constitution: ");
        character.SetConstitution(int.Parse(Console.ReadLine()));

        Console.Write("Intelligence: ");
        character.SetIntelligence(int.Parse(Console.ReadLine()));

        Console.Write("Wisdom: ");
        character.SetWisdom(int.Parse(Console.ReadLine()));

        Console.Write("Charisma: ");
        character.SetCharisma(int.Parse(Console.ReadLine()));
    }

    //Allows the user to indicate if their character is proficient in any skills for DnD 5e
    public static void UserInputSkillProficiencies(CharacterStats newCharacter)
    {
        //Each Skill Proficiency is determined with a "Yes(y) or No(n)" and then added as a boolean value to set the skill proficiency as true or false

        //Setting Character Skill Proficiencies
        Console.WriteLine("\nEnter Character Skill Proficiencies (y/n):");
        Console.WriteLine("-----------------------------------------");

        Console.Write("Acrobatics: ");
        newCharacter.SetAcrobatics(Console.ReadLine().ToLower() == "y");

        Console.Write("Animal Handling: ");
        newCharacter.SetAnimalHandling(Console.ReadLine().ToLower() == "y");

        Console.Write("Arcana: ");
        newCharacter.SetArcana(Console.ReadLine().ToLower() == "y");

        Console.Write("Athletics: ");
        newCharacter.SetAthletics(Console.ReadLine().ToLower() == "y");

        Console.Write("Deception: ");
        newCharacter.SetDeception(Console.ReadLine().ToLower() == "y");

        Console.Write("History: ");
        newCharacter.SetHistory(Console.ReadLine().ToLower() == "y");

        Console.Write("Insight: ");
        newCharacter.SetInsight(Console.ReadLine().ToLower() == "y");

        Console.Write("Intimidation: ");
        newCharacter.SetIntimidation(Console.ReadLine().ToLower() == "y");

        Console.Write("Investigation: ");
        newCharacter.SetInvestigation(Console.ReadLine().ToLower() == "y");

        Console.Write("Medicine: ");
        newCharacter.SetMedicine(Console.ReadLine().ToLower() == "y");

        Console.Write("Nature: ");
        newCharacter.SetNature(Console.ReadLine().ToLower() == "y");

        Console.Write("Perception: ");
        newCharacter.SetPerception(Console.ReadLine().ToLower() == "y");

        Console.Write("Performance: ");
        newCharacter.SetPerformance(Console.ReadLine().ToLower() == "y");

        Console.Write("Persuasion: ");
        newCharacter.SetPersuasion(Console.ReadLine().ToLower() == "y");

        Console.Write("Religion: ");
        newCharacter.SetReligion(Console.ReadLine().ToLower() == "y");

        Console.Write("Sleight of Hand: ");
        newCharacter.SetSleightOfHand(Console.ReadLine().ToLower() == "y");

        Console.Write("Stealth: ");
        newCharacter.SetStealth(Console.ReadLine().ToLower() == "y");

        Console.Write("Survival: ");
        newCharacter.SetSurvival(Console.ReadLine().ToLower() == "y");
    }
/*
    These methods allow the user to Input the top section of their character Sheet:
        - Class
        - Name
        - Race
        - Level
        - Background
        - Alignment
        - Armor Class
        - Initiative
        - Speed
        - Current, Temporary, and Maximum Hit Points
        - Inspiration
        - Proficiency Bonus
*/
    public static void UserInputName(CharacterStats character)
    {
        Console.Write("Enter Character Name: ");
        string charName = Console.ReadLine();
        character.SetName(charName);
    }

    public static void UserInputRace(CharacterStats character)
    {
        Console.Write("Enter Character Race: ");
        string race = Console.ReadLine();
        character.SetRace(race);
    }

    public static void UserInputClass(CharacterStats character)
    {
        Console.Write("Enter Character Class: ");
        string charClass = Console.ReadLine();
        character.SetClass(charClass);
    }

    public static void UserInputBackground(CharacterStats character)
    {
        Console.Write("Enter Character Background: ");
        string background = Console.ReadLine();
        character.SetBackground(background);
    }

    public static void UserInputAlignment(CharacterStats character)
    {
        Console.Write("Enter Character Alignment (e.g., Lawful Good, Chaotic Neutral): ");
        string alignment = Console.ReadLine();
        character.SetAlignment(alignment);
    }

    public static void UserInputLevel(CharacterStats character)
    {
        Console.Write("Enter Character Level: ");
        int level = int.Parse(Console.ReadLine());
        character.SetLevel(level);
    }

    public static void UserInputArmorClass(CharacterStats character)
    {
        Console.Write("Enter Character Armor Class: ");
        int armorClass = int.Parse(Console.ReadLine());
        character.SetArmorClass(armorClass);
    }

    public static void UserInputSpeed(CharacterStats character)
    {
        Console.Write("Enter Character Speed: ");
        int speed = int.Parse(Console.ReadLine());
        character.SetSpeed(speed);
    }

    public static void UserInputHitPoints(CharacterStats character)
    {
        Console.Write("Enter Character Hit Points: ");
        int hitPoints = int.Parse(Console.ReadLine());
        character.SetHitPoints(hitPoints);
    }

    public static void UserInputHitPointMaximum(CharacterStats character)
    {
        /*
            Checks if the user inputs Hit Point Maximum
                - If the user inputs a Hit Point Maximum, then make it that
                - If no input is recieved, then make Hit Point Maximum the same as the previously input Hit Points by the user
         */
        Console.Write("Enter Character Hit Point Maximum (if different): ");
        string hitPointMaxInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(hitPointMaxInput))
        {
            int hitPointMax = int.Parse(hitPointMaxInput);
            character.SetHitPointMax(hitPointMax);
        }
        else{
            character.SetHitPointMax(character.GetHitPoints());
        }
    }

    public static void UserInputHitDice(CharacterStats character)
    {
        Console.Write("Enter Character Hit Dice (e.g., 8d6): ");
        string hitDiceInput = Console.ReadLine();
        character.SetHitDice(hitDiceInput);
    }

    public static void UserInputInspiration(CharacterStats character)
    {
        Console.Write("Does the character have Inspiration (y/n)? ");
        string inspirationInput = Console.ReadLine().ToLower();
        character.SetInspiration(inspirationInput == "y");
    }

    public static void UserInputTemporaryHitPoints(CharacterStats character)
    {
        Console.Write("Enter Character Temporary Hit Points: ");
        int tempHitPoints = int.Parse(Console.ReadLine());
        character.SetTemporaryHitPoints(tempHitPoints);
    }
}