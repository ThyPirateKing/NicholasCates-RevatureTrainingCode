using CharacterData.Models;

namespace CharacterData.Repo
{
    //Agreement/Contract
    //Terms - the things that both parties agree to
    //Like a template
    //"we" (the class that extends this interface) are agreeing to use all of the methods that are laid out in the interface
    public interface IRepository
    {
        public void ReadAndWriteWithFile(string path);
        public void StreamReaderReadToEnd(string path);
        public List<Character> ReadCharacterFromFile(string path);
        public void SaveCharacter(Character myCharacter, string path);
        public void SaveAllCharacters(List<Character> characterList, string path);
        public List<Character> LoadAllCharacters(string path);
    }
}
