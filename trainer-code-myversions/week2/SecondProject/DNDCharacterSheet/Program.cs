//Main class in order to run the program to build a Dungeons and Dragons' 5th Edition Character Sheet
//May need to add more functionality in the future
using System;
using System.IO;
using CharacterData.Repo;
using CharacterData.Models;

namespace DNDCharacterSheet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Initializing a new Character to build
            Character newCharacter = new Character();

            //Initializing the application to build a new DnD Character
            newCharacter.BuildCharacter();
        }
    }
}