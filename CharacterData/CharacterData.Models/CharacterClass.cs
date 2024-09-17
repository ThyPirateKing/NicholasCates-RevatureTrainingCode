namespace CharacterData.Models
{
    public class CharacterClass
    {
        public int id { get; set; }
        public int characterID { get; set; }
        public Character character { get; set; }
        int baseScore = 10;
        private string characterClassName { get; set; }
        private int dex { get; set; }
        private int str { get; set;}
        private int wis { get; set;}
        private int magic { get; set;}
        private int magicResist { get; set;}

        public virtual void generateAbilityScores()
        {
            this.dex = baseScore+1;
            this.str = baseScore+1;
            this.wis = baseScore+5;
            this.magic = baseScore+5;
            this.magicResist = baseScore+3;
        }

        public virtual string GetCharacterClassName() // Getter for characterClassName
        {
            return characterClassName;
        }

        public virtual int GetDex() // Getter for dex
        {
            return dex;
        }

        public virtual int GetStr() // Getter for str
        {
            return str;
        }

        public virtual int GetWis() // Getter for 
        {
            return wis;
        }

        public virtual int GetMagic() // Getter for magic
        {
            return magic;
        }

        public virtual int GetMagicResist() // Getter for magicResist
        {
            return magicResist;
        }
    }
}