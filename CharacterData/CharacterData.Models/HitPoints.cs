using CharacterData.Models;

namespace CharacterData.Models
{
    /// <summary>
    /// Represents the hit points of a character.
    /// </summary>

    public class HitPoints
    {
        /// <summary>
        /// Gets or sets the unique identifier of the hit points.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the character.
        /// </summary>
        public int characterID { get; set; }

        /// <summary>
        /// Gets or sets the character associated with the hit points.
        /// </summary>
        public Character character { get; set; }

        /// <summary>
        /// Gets or sets the current hit points of the character.
        /// </summary>
        public int hitPoints { get; set; }

        public HitPoints(int hitPoints)
        {
            this.hitPoints = hitPoints;
        }
    }
}