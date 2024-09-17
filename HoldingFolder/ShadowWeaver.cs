namespace CharacterData.Models
{
    public class ShadowWeaver : ICharacterClass
    {
        int baseScore = 10;
        public string characterClassName { get; set; } = "Shadow Weaver";
        public int dex { get; set; }
        public int str { get; set;}
        public int wis { get; set;}
        public int magic { get; set;}
        public int magicResist { get; set;}
        
        public void generateAbilityScores()
        {
            this.dex = baseScore+5;
            this.str = baseScore+1;
            this.wis = baseScore+3;
            this.magic = baseScore+5;
            this.magicResist = baseScore+1;
        }
    }
}