namespace CharacterData.Models
{
    public class Fighter : CharacterClass
    {
        public int id { get; set; }
        public Character character {get; set;}
        int baseScore = 10;
        private string characterClassName { get; set; } = "Fighter";
        private int dex { get; set; }
        private int str { get; set;}
        private int wis { get; set;}
        private int magic { get; set;}
        private int magicResist { get; set;}

        public Fighter()
        {
            generateAbilityScores();
        }

        public override void generateAbilityScores()
        {
            this.dex = baseScore+3;
            this.str = baseScore+5;
            this.wis = baseScore+1;
            this.magic = baseScore+1;
            this.magicResist = baseScore+5;
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