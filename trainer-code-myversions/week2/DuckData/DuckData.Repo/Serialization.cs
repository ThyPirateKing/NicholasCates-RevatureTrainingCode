using DuckData.Models;
using System.Text.Json;

namespace DuckData.Repo
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

        public List<Duck> ReadDuckFromFile(string path)
        {
            return new List<Duck>();
        }

        public void SaveDuck(Duck myDuck, string path)
        {
            string serializedDuck = JsonSerializer.Serialize(myDuck);
            File.WriteAllText(path, serializedDuck);
        }

        public void SaveAllDucks(List<Duck> duckList, string path)
        {
            string serializedDuck = JsonSerializer.Serialize(duckList);
            File.AppendAllText(path, serializedDuck);
        }

        public List<Duck> LoadAllDucks(string path)
        {
            string json = File.ReadAllText(path);
            List<Duck> duckList = JsonSerializer.Deserialize<List<Duck>>(json);

            return duckList;
        }
    }
}