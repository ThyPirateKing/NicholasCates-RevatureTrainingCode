using System;
using CharacterData.Models;
using Microsoft.EntityFrameworkCore;

namespace CharacterData.Repo
{
    /// <summary>
    /// Represents the Entity Framework Core repository for the CharacterData application.
    /// </summary>
    /// <seealso cref="CharacterData.Repo.IRepository" />
    public class EFCore : IRepository
    {
        /// <summary>
        /// The database context for the CharacterData application.
        /// </summary>
        /// <remarks>
        /// This field is used to interact with the database.
        /// </remarks>
        CharacterContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EFCore"/> class.
        /// </summary>
        public EFCore()
        {
            // Create a new instance of the CharacterContext class.
            // This will be used to interact with the database.
            context = new CharacterContext();
        }


        /// <summary>
        /// Updates a character in the database.
        /// </summary>
        /// <param name="modifiedCharacter">The character to be updated.</param>
        /// <returns>True if the character was successfully updated, false otherwise.</returns>
        public bool UpdateCharacter(Character modifiedCharacter)
        {
            // Find the character with the given id in the database.
            // If the character exists, update its properties with the values from the modified character.
            // If the character does not exist, do nothing and return false.
            Character savedCharacter = context.Characters.Find(modifiedCharacter.id);
      
            // Find the character with the given id in the database.
            // If the character exists, update its properties with the values from the modified character.
            // If the character does not exist, do nothing and return false.
            if (savedCharacter != null)
            {
                // Update the character's name.
                savedCharacter.name = modifiedCharacter.name;

                // Update the character's level.
                savedCharacter.level = modifiedCharacter.level;

                // Update the character's experience points.
                savedCharacter.experience = modifiedCharacter.experience;

                // Update the character's class.
                savedCharacter.characterClassName = modifiedCharacter.characterClassName;

                // Update the character's armor class.
                savedCharacter.armorClass = modifiedCharacter.armorClass;

                // Update the character's ability scores.
                savedCharacter.abilityScores = modifiedCharacter.abilityScores;

                // Update the character's hit points.
                savedCharacter.hitPoints = modifiedCharacter.hitPoints;

                // Update the character's character class.
                savedCharacter.characterClass = modifiedCharacter.characterClass;

                // Update the character's magic attack bonus.
                savedCharacter.magicAttack = modifiedCharacter.magicAttack;

                // Update the character's melee attack bonus.
                savedCharacter.meleeAttack = modifiedCharacter.meleeAttack;

                // Update the character's ranged attack bonus.
                savedCharacter.rangedAttack = modifiedCharacter.rangedAttack;

                /*** NEEDS TO BE FIXED LATER ***/
                //savedCharacter.inventory = modifiedCharacter.inventory;

                // Save the changes to the database.
                // If the update was successful, return true.
                // If the update was not successful, return false.
                context.SaveChanges();

                return true;
            }
            return false;
        }

        /// <summary>
        /// Updates all characters in the database with the given list of modified characters.
        /// </summary>
        /// <param name="modifiedCharacterss">The list of modified characters.</param>
        /// <returns>True if the characters were successfully updated, false otherwise.</returns>
        public void UpdateAllCharacters(List<Character> modifiedCharacterss)
        {
            /// <summary>
            /// Retrieves all characters from the database.
            /// </summary>
            /// <returns>A list of all characters in the database.</returns>
            // Retrieve all characters from the database and store them in the `savedCharacters` list.
            List<Character> savedCharacters = context.Characters.ToList();


            if (savedCharacters != null)
            {
                foreach (Character x in modifiedCharacterss)
                {
                    // Find the corresponding character in the database by ID.
                    // Update the character's properties with the modified character's properties.
                    context.Characters.Find(x.id).name = x.name;
                    context.Characters.Find(x.id).level = x.level;
                    context.Characters.Find(x.id).experience = x.experience;
                    context.Characters.Find(x.id).characterClassName = x.characterClassName;
                    context.Characters.Find(x.id).armorClass = x.armorClass;
                    context.Characters.Find(x.id).abilityScores = x.abilityScores;
                    context.Characters.Find(x.id).hitPoints = x.hitPoints;
                    context.Characters.Find(x.id).characterClass = x.characterClass;
                    context.Characters.Find(x.id).magicAttack = x.magicAttack;
                    context.Characters.Find(x.id).meleeAttack = x.meleeAttack;
                    context.Characters.Find(x.id).rangedAttack = x.rangedAttack;

                    //context.Remove(context.Characters.Find(x.id).inventory);
                    //context.Characters.Find(x.id).inventory = x.inventory;
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Saves a character to the database.
        /// </summary>
        /// <param name="myCharacter">The character to be saved.</param>
        public void SaveCharacter(Character myCharacter)
        {
            // Add the character to the database context.
            context.Characters.Add(myCharacter);

            // Save changes to the database.
            context.SaveChanges();
        }
    
        /// <summary>
        /// Saves all characters in the given list to the database.
        /// </summary>
        /// <param name="characterList">The list of characters to be saved.</param>
        public void SaveAllCharacters(List<Character> characterList)
        {
            // Iterate through the list of characters and add each to the database context.
            foreach (Character d in characterList)
            {
                context.Characters.Add(d);

                // Save changes to the database.
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Loads all characters from the database and returns them as a list.
        /// </summary>
        /// <returns>A list of all characters in the database.</returns>
        public List<Character> LoadAllCharacters()
        {
            List<Character> characters = new List<Character>();
            foreach (var item in context.Characters.Select(c => new
            {
                c.id,
                c.name,
                c.level,
                c.experience,
                c.characterClassName,
                c.armorClass,
                c.abilityScores,
                c.hitPoints,
                c.characterClass,
                c.magicAttack,
                c.meleeAttack,
                c.rangedAttack,
                c.inventory
            }))
            {
                Character character = new Character
                {
                    id = item.id,
                    name = item.name,
                    level = item.level,
                    experience = item.experience,
                    characterClassName = item.characterClassName,
                    armorClass = item.armorClass,
                    abilityScores = item.abilityScores,
                    hitPoints = item.hitPoints,
                    characterClass = item.characterClass,
                    magicAttack = item.magicAttack,
                    meleeAttack = item.meleeAttack,
                    rangedAttack = item.rangedAttack,
                    inventory = item.inventory
                };
                characters.Add(character);
            }
            return characters;
        }

        /// <summary>
        /// Gets a character by ID from the database.
        /// </summary>
        /// <param name="id">The ID of the character to retrieve.</param>
        /// <returns>The character with the specified ID, or null if no character with that ID exists.</returns>
        public Character GetCharacterById(int id)
        {
            Character foundCharacter = context.Characters.Find(id);
            return foundCharacter;
        }

        /// <summary>
        /// Deletes a character from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the character to delete.</param>
        public void DeleteCharacterById(int id)
        {
            Character foundCharacter = context.Characters.Find(id);

            if(foundCharacter.inventory != null)
            {
                foreach (Equipment e in foundCharacter.inventory)
                    context.Equipment.Remove(e);
            }
            context.Characters.Remove(foundCharacter);
            context.SaveChanges();
        }
    }
}


