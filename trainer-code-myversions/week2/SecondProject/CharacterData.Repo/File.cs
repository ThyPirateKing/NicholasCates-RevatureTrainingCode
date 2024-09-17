using CharacterData.Models;

namespace CharacterData.Repo
{
    public class FileReadWrite : IRepository
    {
        public void ReadAndWriteWithFile(string path)
        {
            string text = "Hello World! I am a file!";

            //read, write(overwrite content, or create the file), append(add to the end of the file)
            if(!File.Exists(path))
            {
                File.WriteAllText(path, text);
            }
            else
            {
                text = File.ReadAllText(path);
            }
        }
    
        public void StreamReaderReadToEnd(string path)
        {
            Console.WriteLine("Reading from file with StreamReader (End of File): ");
            StreamReader sr = new StreamReader(path);

            string text = "";

            while((text = sr.ReadToEnd()) != "")
            {
                Console.Write(text);
                Console.WriteLine(" -- ");
            }
            sr.Close();
        }
   
        public List<Character> ReadCharacterFromFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            List<Character> characterList = new List<Character>();
            string text = "";

            while( (text = sr.ReadLine()) != null)
            {
                string[] characterValues = text.Split(" ");
                Character mySavedCharacter = new Character(int.Parse(characterValues[0]), characterValues[1], int.Parse(characterValues[2]));

                characterList.Add(mySavedCharacter);
            }
            sr.Close();

            return characterList;
        }
    
        public void SaveCharacter(Character myCharacter, string path)
        {
            
        }

        public void SaveAllCharacters(List<Character> characterList, string path)
        {
            
        }

        public List<Character> LoadAllCharacters(string path)
        {
            return new List<Character>();
        }
    }
}