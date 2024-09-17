namespace CharacterData.Models
{
    public interface ICharacterClass
    {
        public string characterClassName { get; set; }
        public int dex { get; set; }
        public int str { get; set;}
        public int wis { get; set;}
        public int magic { get; set;}
        public int magicResist { get; set;}

        public virtual void generateAbilityScores(){}
    }
}