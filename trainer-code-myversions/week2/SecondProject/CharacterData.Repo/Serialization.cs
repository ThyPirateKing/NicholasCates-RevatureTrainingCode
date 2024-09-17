using CharacterData.Models;
using System.Text.Json;

namespace CharacterData.Repo
{
    public class Serialization : IRepository
    {
        public void ReadAndWriteWithFile(string path)
        {
        }

        public void StreamReaderReadLine(string path)
        {
        }

        public void StreamReaderReadToEnd(string path)
        {
        }

        public List<Character> ReadCharacterFromFile(string path)
        {
            return new List<Character>();
        }

        public void SaveCharacter(Character myCharacter, string path)
        {
            string serializedCharacter = JsonSerializer.Serialize(myCharacter);
            File.WriteAllText(path, serializedCharacter);
        }

        public void SaveAllCharacters(List<Character> characterList, string path)
        {
            string serializedCharacter = JsonSerializer.Serialize(characterList);
            File.AppendAllText(path, serializedCharacter);
        }

        public List<Character> LoadAllCharacters(string path)
        {
            string json = File.ReadAllText(path);
            List<Character> characterList = JsonSerializer.Deserialize<List<Character>>(json);

            return characterList;
        }
    }
}