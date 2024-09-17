using System;
using System.IO;
using CharacterData.Repo;
using CharacterData.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace CharacterBuilder
{
    public class Program
    {
      /*  public static Character CreateCharacter(Character newCharacter)
        {
            using (var context = new CharacterContext())
            {
                //we introduce the object to the context
                //The "context.Add(); method does not add to the database yet
                context.Characters.Add(newCharacter); 

                /// Saves changes to the data model. This is called after a user clicks the OK button
                context.SaveChanges();

                // Needs to retrieve from the database!!!
                return newCharacter;
            }
        }
        */

        public static void Main(string[] args)
        {
            string path = @"./Characters.txt";

            CharacterManager manager = new CharacterManager(path);
            manager.RunCharacterMenu();
        }   
    }
}