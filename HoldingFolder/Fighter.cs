namespace CharacterData.Models
{
    public class Fighter : ICharacterClass
    {
        int baseScore = 10;
        public string characterClassName { get; set; } = "Fighter";
        public int dex { get; set; }
        public int str { get; set;}
        public int wis { get; set;}
        public int magic { get; set;}
        public int magicResist { get; set;}

        public void generateAbilityScores()
        {
            this.dex = baseScore+3;
            this.str = baseScore+5;
            this.wis = baseScore+1;
            this.magic = baseScore+1;
            this.magicResist = baseScore+5;
        }
    }
}