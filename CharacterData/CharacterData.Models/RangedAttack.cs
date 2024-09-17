namespace CharacterData.Models
{
    /// <summary>
    /// Represents a character's ranged attack.
    /// </summary>
    public class RangedAttack
    {
        /// <summary>
        /// The unique identifier for the ranged attack.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// The ID of the character associated with this ranged attack.
        /// </summary>
        public int characterID { get; set; }

        /// <summary>
        /// The character associated with this ranged attack.
        /// </summary>
        public Character character {get; set;}

        /// <summary>
        /// The bonus to the character's ranged attack roll.
        /// </summary>
        public int rangedAttackBonus { get; set; }

        /// <summary>
        /// The bonus to the character's ranged attack damage.
        /// </summary>
        public int rangedDamageBonus { get; set; }
    }
}
