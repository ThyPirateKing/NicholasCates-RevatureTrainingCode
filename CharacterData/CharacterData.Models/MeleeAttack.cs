namespace CharacterData.Models
{
    /// <summary>
    /// Represents a character's melee attack in a DnD 5e game.
    /// </summary>
    public class MeleeAttack
    {
        /// <summary>
        /// The unique identifier of the melee attack.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// The unique identifier of the character this melee attack belongs to.
        /// </summary>
        public int characterID { get; set; }

        /// <summary>
        /// The character this melee attack belongs to.
        /// </summary>
        public Character character { get; set; }

        /// <summary>
        /// The melee attack bonus of the character.
        /// This is the bonus to the attack roll.
        /// </summary>
        public int meleeAttackBonus { get; set; }

        /// <summary>
        /// The melee damage bonus of the character.
        /// This is the bonus to the damage roll.
        /// </summary>
        /// <remarks>
        /// See the DnD 5e rules for more details on melee damage bonus.
        /// </remarks>
        public int meleeDamageBonus { get; set; }
    }
}
