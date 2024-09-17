using CharacterData.Models;
using Newtonsoft.Json;

namespace CharacterData.Repo
{
    //Agreement/Contract
    //Terms - the things that both parties agree to
    //Like a template
    //"we" (the class that extends this interface) are agreeing to use all of the methods that are laid out in the interface
    public interface IRepository
    {
        public static void WriteToJsonFile<Character>(string filePath, Character objectToWrite, bool append = false) where Character : new(){}
        public static Character ReadFromJsonFile<Character>(string filePath) where Character : new(){}
    }
}
