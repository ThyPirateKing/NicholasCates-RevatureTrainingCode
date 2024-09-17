using DuckData.Models;

namespace DuckData.Repo
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
                //File.WriteAllLines(path, string[]);
            }
            else
            {
                text = File.ReadAllText(path);
            }
        }

        public void StreamReaderReadLine(string path)
        {
            /*
                StreamReader doesn't load the entire file, it provides a route to the file.
                Rather than retrieving the entire file to memory, we can read each line one at a time (such as File.WriteAllText or File.ReadAllText),
                    reducing the memory required.

                The question mark at the end of StreamReader allows for the object to be null without causing an error
            */
            StreamReader? sr = new StreamReader(path);

            string text = "";
            

            string[] lines = text.Split("\n");

            Console.WriteLine();
            Console.WriteLine("Reading from file with StreamReader (line by line): ");
            while( (text = sr.ReadLine()) != null)
            {
                Console.Write(text);
                Console.WriteLine(" -- ");
            }

            //Close the file object
            sr.Close();
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
   
        public List<Duck> ReadDuckFromFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            List<Duck> duckList = new List<Duck>();
            string text = "";

            while( (text = sr.ReadLine()) != null)
            {
                string[] duckValues = text.Split(" ");
                Duck mySavedDuck = new Duck(int.Parse(duckValues[0]), duckValues[1], int.Parse(duckValues[2]));

                duckList.Add(mySavedDuck);
            }
            sr.Close();

            return duckList;
        }
    
        public void SaveDuck(Duck myDuck, string path)
        {
            
        }

        public void SaveAllDucks(List<Duck> duckList, string path)
        {
            
        }

        public List<Duck> LoadAllDucks(string path)
        {
            return new List<Duck>();
        }
    }
}