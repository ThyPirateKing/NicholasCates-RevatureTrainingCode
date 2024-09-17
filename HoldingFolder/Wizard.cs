namespace CharacterData.Models
{
    public class Wizard : ICharacterClass
    {
        int baseScore = 10;
        public string characterClassName { get; set; } = "Wizard";
        public int dex { get; set; }
        public int str { get; set;}
        public int wis { get; set;}
        public int magic { get; set;}
        public int magicResist { get; set;}
        
        public void generateAbilityScores()
        {
            this.dex = baseScore+1;
            this.str = baseScore+1;
            this.wis = baseScore+5;
            this.magic = baseScore+5;
            this.magicResist = baseScore+3;
        }
    }
}