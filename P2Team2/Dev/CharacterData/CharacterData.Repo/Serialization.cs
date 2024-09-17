using CharacterData.Models;
using System.Text.Json;
using Newtonsoft.Json;

namespace CharacterData.Repo
{
    public class Serialization : IRepository
    {
        Character test;
        List<Character> test1;
        string filePath;
        bool append = false;

        /// <summary>
        /// Constructor for the Serialization class.
        /// </summary>
        /// <param name="filePath">The file path to save and load the data from.</param>
        public Serialization(string filePath, bool append = false)
        {
            this.filePath = filePath;
            this.append = append;
        }
        
        //If APPEND == True, append the contents of the list to the end of the file
        //If APPEND == False, overwrite the file with new list
        public void SaveAllCharacters(List<Character> characterList)
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(characterList);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        
        //Read in a file of List<Character> Objects
        //Return a List<Character> Object
        public List<Character> LoadAllCharacters()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Character>>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        public bool UpdateCharacter(Character modifiedCharacter){return false;}
       
       
        public void UpdateAllCharacters(List<Character> characterList)
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(characterList);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }


        public void SaveCharacter(Character myCharacter)
        {
            TextWriter writer = null;
            try
            {
                List<Character> characterList = new List<Character>();
                characterList.Add(myCharacter);
                var contentsToWriteToFile = JsonConvert.SerializeObject(myCharacter);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        public Character GetCharacterById ( int id ){return test;}
        public void DeleteCharacterById ( int id ){}
    }
}