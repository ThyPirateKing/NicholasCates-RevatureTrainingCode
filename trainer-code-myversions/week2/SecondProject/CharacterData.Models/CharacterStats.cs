/*
    This class stores all the character's statistics and values
    These values are the information needed for a DnD 5e Character Sheet
    Does not allow for the addition of spells, spell slots, or items
    May add more functionality in future
*/
namespace CharacterData.Models
{
    public class CharacterStats
    {
        //Variables needed for a character's statistics such as ability scores, proficiencies, level, name, etc.
        string name;
        string race;
        string charClass;
        string background;
        string alignment;
        int level;

        //Ability Scores
        int str, dex, con, inte, wis, chari;

        //Additional Character Stats
        int prof, armor, initiative, speed, hitPoints, hitPointMax, tempHP;
        string hitDice;
        bool inspiration;
        int deathSaveS, deathSaveF;

        //Skills
        bool acrobatics, animalHandling, arcana, athletics, deception, history, insight, intimidation, investigation, medicine, nature, perception, performance;
        bool persuasion, religion, sleightOfHand, stealth, survival;

        //Constructor for Character Stats Class
        public CharacterStats()
        {
        }

        //Calculating the Character's Ability Score Modifiers Automatically
        public int CalculateModifier(int score)
        {
            int modifier = (score - 10) / 2;

            //Only allow the ability score modifier to be a minimum of -5 or a maximum of 10
            return Math.Clamp(modifier, -5, 10);
        }

        //Calculating the Character's Ability Score Modifiers Automatically
        public int CalculateInitiativeBonus(CharacterStats character)
        {
            int initiativeBonus = 0;
            initiativeBonus = character.GetDexterityModifier();

            return initiativeBonus;
        }

        //Method to automatically calculate the proficiency bonus for a character
        public static int CalculateProficiencyBonus(CharacterStats character)
        {
            //These if and else if statements return the correct proficiency bonus based on the level of the character
            //Returning a -1 proficiency bonus if the character is higher than level 20 or lower than level 1 to indicate an error in the character sheet

            if (character.GetLevel() >= 1 && character.GetLevel() <= 4)
            {
                return 2;
            }
            else if (character.GetLevel() >= 5 && character.GetLevel() <= 8)
            {
                return 3;
            }
            else if (character.GetLevel() >= 9 && character.GetLevel() <= 12)
            {
                return 4;
            }
            else if (character.GetLevel() >= 13 && character.GetLevel() <= 16)
            {
                return 5;
            }
            else if (character.GetLevel() >= 17 && character.GetLevel() <= 20)
            {
                return 6;
            }
            else
            {
                return -1;
            }
        }

        /*
            -- The following Methods are classic setter and getter methods
            --Needed to set and access the character's information for the character sheet
        */
        //Setting Character Information
        public void SetName(string value) { name = value; }
        public void SetRace(string value) { race = value; }
        public void SetClass(string value) { charClass = value; }
        public void SetBackground(string value) { background = value; }
        public void SetLevel(int value) { level = value; }
        public void SetAlignment(string value) { alignment = value; }

        //Getting Character Information
        public string GetName() { return name; }
        public string GetRace() { return race; }
        public string GetClass() { return charClass; }
        public string GetBackground() { return background; }
        public string GetAlignment() { return alignment; }
        public int GetLevel() { return level; }

        //Setting Character Ability Scores
        public void SetStrength(int value) { str = value; }
        public void SetDexterity(int value) { dex = value; }
        public void SetConstitution(int value) { con = value; }
        public void SetIntelligence(int value) { inte = value; }
        public void SetWisdom(int value) { wis = value; }
        public void SetCharisma(int value) { chari = value; }

        //Getting Character Ability Scores
        public int GetStrength() { return str; }
        public int GetDexterity() { return dex; }
        public int GetConstitution() { return con; }
        public int GetIntelligence() { return inte; }
        public int GetWisdom() { return wis; }
        public int GetCharisma() { return chari; }

        //Setting Character Ability Modifers
        public int GetStrengthModifier() { return CalculateModifier(str); }
        public int GetDexterityModifier() { return CalculateModifier(dex); }
        public int GetConstitutionModifier() { return CalculateModifier(con); }
        public int GetIntelligenceModifier() { return CalculateModifier(inte); }
        public int GetWisdomModifier() { return CalculateModifier(wis); }
        public int GetCharismaModifier() { return CalculateModifier(chari); }

        //Setting Character's Other Stats
        public void SetInspiration(bool value) { inspiration = value; }
        public void SetProficiencyBonus(int value) { prof = value; }
        public void SetArmorClass(int value) { armor = value; }
        public void SetInitiative(int value) { initiative = value; }
        public void SetSpeed(int value) { speed = value; }
        public void SetHitPoints(int value) { hitPoints = value; }
        public void SetHitPointMax(int value) { hitPointMax = value; }
        public void SetTemporaryHitPoints(int value) { tempHP = value; }
        public void SetHitDice(string value) { hitDice = value; }
        public void SetDeathSavesSuccesses(int value) { deathSaveS = value; }
        public void SetDeathSavesFailures(int value) { deathSaveF = value; }

        //Getting Character's Other Stats
        public bool GetInspiration() { return inspiration; }
        public int GetProficiencyBonus() { return prof; }
        public int GetArmorClass() { return armor; }
        public int GetInitiative() { return initiative; }
        public int GetSpeed() { return speed; }
        public int GetHitPoints() { return hitPoints; }
        public int GetHitPointMax() { return hitPointMax; }
        public int GetTemporaryHitPoints() { return tempHP; }
        public string GetHitDice() { return hitDice; }
        public int GetDeathSavesSuccesses() { return deathSaveS; }
        public int GetDeathSavesFailures() { return deathSaveF; }

        //Setting the Character's Skill Proficiencies
        public void SetAcrobatics(bool value) { acrobatics = value; }
        public void SetAnimalHandling(bool value) { animalHandling = value; }
        public void SetArcana(bool value) { arcana = value; }
        public void SetAthletics(bool value) { athletics = value; }
        public void SetDeception(bool value) { deception = value; }
        public void SetHistory(bool value) { history = value; }
        public void SetInsight(bool value) { insight = value; }
        public void SetIntimidation(bool value) { intimidation = value; }
        public void SetInvestigation(bool value) { investigation = value; }
        public void SetMedicine(bool value) { medicine = value; }
        public void SetNature(bool value) { nature = value; }
        public void SetPerception(bool value) { perception = value; }
        public void SetPerformance(bool value) { performance = value; }
        public void SetPersuasion(bool value) { persuasion = value; }
        public void SetReligion(bool value) { religion = value; }
        public void SetSleightOfHand(bool value) { sleightOfHand = value; }
        public void SetStealth(bool value) { stealth = value; }
        public void SetSurvival(bool value) { survival = value; }

        //Getting the Character's Skill Proficiencies
        public bool GetAcrobatics() { return acrobatics; }
        public bool GetAnimalHandling() { return animalHandling; }
        public bool GetArcana() { return arcana; }
        public bool GetAthletics() { return athletics; }
        public bool GetDeception() { return deception; }
        public bool GetHistory() { return history; }
        public bool GetInsight() { return insight; }
        public bool GetIntimidation() { return intimidation; }
        public bool GetInvestigation() { return investigation; }
        public bool GetMedicine() { return medicine; }
        public bool GetNature() { return nature; }
        public bool GetPerception() { return perception; }
        public bool GetPerformance() { return performance; }
        public bool GetPersuasion() { return persuasion; }
        public bool GetReligion() { return religion; }
        public bool GetSleightOfHand() { return sleightOfHand; }
        public bool GetStealth() { return stealth; }
        public bool GetSurvival() { return survival; }
    }
}