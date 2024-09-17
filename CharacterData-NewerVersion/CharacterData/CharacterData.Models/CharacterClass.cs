namespace CharacterData.Models
{
    public class CharacterClass
    {
        public int id { get; set; }
        public List<Item> item { get; set; }

        public string className { get; set; }
        public int dex { get; set; } = 0;
        public int str { get; set; } = 0;
        public int wis { get; set; } = 0;
        public int magic { get; set; } = 0;
        public int magicResist { get; set; } = 0;

        public int baseScore {get; set;} = 10;

        public CharacterClass(){}

        // Examples:
        // "Fighter", 3, 5, 1, 1, 5
        // "Wizard", 1, 1, 5, 5, 3
        // "Shadow Weaver", 5, 1, 3, 5, 1
        public CharacterClass(string name, int dexMod, int strMod, int wisMod, int magicMod, int magicResistMod)
        {
            this.className = name;
            this.dex = baseScore+dexMod;
            this.str = baseScore+strMod;
            this.wis = baseScore+wisMod;
            this.magic = baseScore+magicMod;
            this.magicResist = baseScore+magicResistMod;
        }

        // public virtual void generateAbilityScores()
        // {
        //     this.dex = baseScore+1;
        //     this.str = baseScore+1;
        //     this.wis = baseScore+5;
        //     this.magic = baseScore+5;
        //     this.magicResist = baseScore+3;
        // }

        // public virtual string GetCharacterClassName() // Getter for characterClassName
        // {
        //     return characterClassName;
        // }

        // public virtual int GetDexBonus() // Getter for dex
        // {
        //     return dex;
        // }

        // public virtual int GetStrBonus() // Getter for str
        // {
        //     return str;
        // }

        // public virtual int GetWisBonus() // Getter for 
        // {
        //     return wis;
        // }

        // public virtual int GetMagicBonus() // Getter for magic
        // {
        //     return magic;
        // }

        // public virtual int GetMagicResist() // Getter for magicResist
        // {
        //     return magicResist;
        // }
    }
}