using System;
using System.IO;
using DuckData.Repo;
using DuckData.Models;

namespace FileIO
{
    class Program
    {
        public static void Main(string[] args)
        {
            string path = @"./Ducks.txt";

            //IRepository file = new FileReadWrite();
            IRepository file = new Serialization();

/*
            // if(xyz)
            // {
            //     file = new FileReadWrite();
            // }
            // else if(abc)
            // {
            //     file = new serialization();
            // }
            // else
            // {
            //     file = new databaseConnection();
            // }

*/

/*
            file.ReadAndWriteWithFile(path);
            Console.WriteLine("----------------------------------");

            file.StreamReaderReadLine(path);
            Console.WriteLine("----------------------------------");

            file.StreamReaderReadToEnd(path);
            
            // text = sr.ReadToEnd();
            // Console.WriteLine(text);

*/

    
            Duck myDuck = new Duck("red", 20);

            //file.SaveDuck(myDuck, path);

            List<Duck> duckList = new List<Duck>();

            Console.WriteLine("\n\n\n");
            //Duck myDuck = new Duck("purple", 20);
            //myDuck.Quack();
            //Console.WriteLine(myDuck.ToString());

            path = @"./Ducks.txt";
            //File.WriteAllText(path, myDuck.ToString());

            //string ducks = File.ReadAllText(path);
            //Console.WriteLine(ducks);

            //List<Duck> duckList = file.ReadDuckFromFile(path);
            //string[] duckValues = ducks.Split(" ");
            //Duck mySavedDuck = new Duck(duckValues[0], int.Parse(duckValues[1]));

            //mySavedDuck.Quack();
            
            duckList = file.LoadAllDucks(path);

            foreach(Duck d in duckList)
            {
                d.Quack();
            }
        }
    }
}