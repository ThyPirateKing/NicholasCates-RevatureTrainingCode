namespace CharacterData.Models
{
    public class Wizard : CharacterClass
    {
        public int id { get; set; }
        public Character character {get; set;}
        int baseScore = 10;
        private string characterClassName { get; set; } = "Wizard";
        private int dex { get; set; }
        private int str { get; set; }
        private int wis { get; set; }
        private int magic { get; set; }
        private int magicResist { get; set; }

        public Wizard()
        {
            generateAbilityScores();
        }

        public override void generateAbilityScores()
        {
            dex = baseScore + 1;
            str = baseScore + 1;
            wis = baseScore + 5;
            magic = baseScore + 5;
            magicResist = baseScore + 3;
        }

        public override string GetCharacterClassName() // Getter for characterClassName
        {
            return characterClassName;
        }

        public override int GetDex() // Getter for dex
        {
            return dex;
        }

        public override int GetStr() // Getter for str
        {
            return str;
        }

        public override int GetWis() // Getter for wis
        {
            return wis;
        }

        public override int GetMagic() // Getter for magic
        {
            return magic;
        }

        public override int GetMagicResist() // Getter for magicResist
        {
            return magicResist;
        }
    }
}