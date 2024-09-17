/*
    This class has the sole purpose of organizing and displaying the character sheet and and any other information related to the character
    Extends the CharacterStats class since it needs the character information in order to display everything
    This class includes the method Display() which is used to display the information for the character
    May add more functionality in future
*/

public class CharacterDisplay : CharacterStats
{
    //Creating a new CharacterStats object to display the character sheet in the method Display()
    CharacterStats displayedCharacter = new CharacterStats();

    //Constructor which takes in a CharacterStats Object
    public CharacterDisplay(CharacterStats inputCharacter)
    {
        displayedCharacter = inputCharacter;
    }

    //Method To Display a Character's Stats
    public void Display()
    {
        //Message for the User
        Console.WriteLine("\nHere is your new character sheet:");
        Console.WriteLine("----------------------------------------\n");

        //Printing out main top section of the character sheet
        Console.WriteLine("Character Name: " + displayedCharacter.GetName());
        Console.WriteLine("Level: " + displayedCharacter.GetLevel());
        Console.WriteLine("Race: " + displayedCharacter.GetRace());
        Console.WriteLine("Class: " + displayedCharacter.GetClass());
        Console.WriteLine("Background: " + displayedCharacter.GetBackground());
        Console.WriteLine("Alignment: " + displayedCharacter.GetAlignment());

        Console.WriteLine("-------------------------");

        //Printing Out Hit Points, Temporary Hit Points, and Hit Point Maximum
        Console.WriteLine("Hit Points Maximum: " + displayedCharacter.GetHitPointMax());
        Console.WriteLine("Hit Points: " + displayedCharacter.GetHitPoints());
        Console.WriteLine("Temporary Hit Points: " + displayedCharacter.GetTemporaryHitPoints());

        Console.WriteLine("-------------------------");

        //Printing out Armor Class and Calculated Proficiency Bonus
        Console.WriteLine("Armor Class: " + displayedCharacter.GetArmorClass());
        Console.WriteLine("Proficiency Bonus: +" + CalculateProficiencyBonus(displayedCharacter)); 
        Console.WriteLine("Initiative: +" + CalculateInitiativeBonus(displayedCharacter));
    
        //Printing out Character's Inpiration
        if(displayedCharacter.GetInspiration() == true)
            Console.WriteLine("Inspiration: 1");
        else
            Console.WriteLine("Inspiration: 0");

        Console.WriteLine("-------------------------");

        //Printing out Ability Scores and Calculated Ability Score Modifiers
        Console.WriteLine("\tAbility Scores:");
        Console.WriteLine("Strength: " + displayedCharacter.GetStrength() + " || Mod: " + displayedCharacter.CalculateModifier(displayedCharacter.GetStrength()));
        Console.WriteLine("Dexterity: " + displayedCharacter.GetDexterity() + " || Mod: " + displayedCharacter.CalculateModifier(displayedCharacter.GetDexterity())); 
        Console.WriteLine("Constitution: " + displayedCharacter.GetConstitution() + " || Mod: " + displayedCharacter.CalculateModifier(displayedCharacter.GetConstitution()));
        Console.WriteLine("Intelligence: " + displayedCharacter.GetIntelligence() + " || Mod: " + displayedCharacter.CalculateModifier(displayedCharacter.GetIntelligence()));
        Console.WriteLine("Wisdom: " + displayedCharacter.GetWisdom() + " || Mod: " + displayedCharacter.CalculateModifier(displayedCharacter.GetWisdom())); 
        Console.WriteLine("Charisma: " + displayedCharacter.GetCharisma() + " || Mod: " + displayedCharacter.CalculateModifier(displayedCharacter.GetCharisma())); 

        Console.WriteLine("-------------------------");

        //Printing Out Skill Proficiencies
        Console.WriteLine("\tSkill Proficiencies:");

        //Print out the skill as being Proficient or not Proficient dependent on if the value assigned was true or false
        Console.WriteLine($"Acrobatics: " + $"{(displayedCharacter.GetAcrobatics() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Animal Handling: {(displayedCharacter.GetAnimalHandling() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Arcana: {(displayedCharacter.GetArcana() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Athletics: {(displayedCharacter.GetAthletics() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Deception: {(displayedCharacter.GetDeception() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"History: {(displayedCharacter.GetHistory() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Insight: {(displayedCharacter.GetInsight() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Intimidation: {(displayedCharacter.GetIntimidation() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Investigation: {(displayedCharacter.GetInvestigation() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Medicine: {(displayedCharacter.GetMedicine() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Nature: {(displayedCharacter.GetNature() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Perception: {(displayedCharacter.GetPerception() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Performance: {(displayedCharacter.GetPerformance() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Persuasion: {(displayedCharacter.GetPersuasion() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Religion: {(displayedCharacter.GetReligion() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Sleight of Hand: {(displayedCharacter.GetSleightOfHand() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Stealth: {(displayedCharacter.GetStealth() ? "(Proficient)" : "(Not Proficient)")}");
        Console.WriteLine($"Survival: {(displayedCharacter.GetSurvival() ? "(Proficient)" : "(Not Proficient)")}");

        Console.WriteLine("-------------------------");
    }
}