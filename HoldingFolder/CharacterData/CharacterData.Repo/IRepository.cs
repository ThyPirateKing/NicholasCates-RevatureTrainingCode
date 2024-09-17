using CharacterData.Models;

namespace CharacterData.Repo
{
    /// <summary>
    /// Interface for the repository. This will be used as a
    /// template for the actual repository class. Which will
    /// be used to access the database and/or file system.
    /// </summary>
    public interface IRepository
    {
        void SaveCharacter(Character myCharacter);
        void SaveAllCharacters(List<Character> characterList);
        List<Character> LoadAllCharacters ();
        Character GetCharacterById ( int id );
        void DeleteCharacterById ( int id );
        bool UpdateCharacter(Character modifiedCharacter);
        void UpdateAllCharacters(List<Character> modifiedCharacters);
    }
}