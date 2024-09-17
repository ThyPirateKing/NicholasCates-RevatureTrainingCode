using CharacterData.Models;

namespace CharacterData.Models
{
    /// <summary>
    /// Class to hold the ability scores of a character
    /// </summary>
    public class AbilityScores
    {
        /// <summary>
        /// The ID of the ability score
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// The ID of the character that this ability score belongs to
        /// </summary>
        public int characterID { get; set; }
        /// <summary>
        /// The character that this ability score belongs to
        /// </summary>
        public Character character { get; set; }
        /// <summary>
        /// The dexterity ability score of the character
        /// </summary>
        public int dex{get;set;}
        /// <summary>
        /// The strength ability score of the character
        /// </summary>
        public int str{get;set;}
        /// <summary>
        /// The wisdom ability score of the character
        /// </summary>
        public int wis{get;set;}
        /// <summary>
        /// The magic ability score of the character
        /// </summary>
        public int magic{get;set;}
        /// <summary>
        /// The magic resist ability score of the character
        /// </summary>
        public int magicResist{get;set;}
    }
}
