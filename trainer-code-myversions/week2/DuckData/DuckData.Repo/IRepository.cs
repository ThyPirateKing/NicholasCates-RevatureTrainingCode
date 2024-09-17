using DuckData.Models;

namespace DuckData.Repo
{
    //Agreement/Contract
    //Terms - the things that both parties agree to
    //Like a template
    //"we" (the class that extends this interface) are agreeing to use all of the methods that are laid out in the interface
    public interface IRepository
    {
        public void ReadAndWriteWithFile(string path);
        public void StreamReaderReadLine(string path);
        public void StreamReaderReadToEnd(string path);
        public List<Duck> ReadDuckFromFile(string path);
        public void SaveDuck(Duck myDuck, string path);
        public void SaveAllDucks(List<Duck> duckList, string path);
        public List<Duck> LoadAllDucks(string path);
    }
}
