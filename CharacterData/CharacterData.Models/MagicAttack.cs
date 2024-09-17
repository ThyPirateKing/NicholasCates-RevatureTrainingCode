namespace CharacterData.Models
{
    /// <summary>
    /// Magic Attack: Represents the character's magic attack
    /// </summary>
    public class MagicAttack
    {
        // Properties
        public int id { get; set; } // Magic Attack ID
        public int characterID { get; set; } // Character ID the Magic Attack belongs to
        public Character character { get; set; } // Character the Magic Attack belongs to
        public int magicAttackBonus { get; set; } // Magic Attack Bonus
        public int magicDamageBonus { get; set; } // Magic Damage Bonus
    }
}