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
        public static CharacterClass newFighter = new CharacterClass("fighter", 3, 5, 1, 1, 5);
        public static  CharacterClass newWizard = new CharacterClass("wizard", 3, 5, 1, 1, 5);
        public static CharacterClass newShadowWeaver = new CharacterClass("shadow weaver", 3, 5, 1, 1, 5);

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

            string filePath = @"./ItemBuildList.txt";
            
            //GenerateItems(filePath);

            CharacterManager manager = new CharacterManager(path);
            manager.RunCharacterMenu();
        }

        public static void GenerateItems(string filePath)
        {
            for(int i =1 ; i<=15;i++ )
            {
                SaveAllItems(CreateItems(i, 80-(i*5), "Bow", filePath, "ranged weapon", 10, "two handed", "piercing", "physical", "shadow weaver"), filePath, false);
                SaveAllItems(CreateItems(i, 80-(i*5), "Magic Staff", filePath, "magic weapon", 10, "two handed", "bludgeoning", "physical", "all"), filePath, false);
                SaveAllItems(CreateItems(i, 80-(i*5), "Greatsword", filePath, "melee weapon", 10, "two handed", "slashing", "physical", "fighter"), filePath, false);
                
                SaveAllItems(CreateItems(i, 80-(i*5), "Helmet", filePath, "armor", 10, "head", "", "", "all"), filePath, false);
                SaveAllItems(CreateItems(i, 80-(i*5), "Chestplate", filePath, "armor", 10, "chest", "", "", "all"), filePath, false);
                SaveAllItems(CreateItems(i, 80-(i*5), "Vembraces", filePath, "armor", 10, "arms", "", "", "all"), filePath, false);
                SaveAllItems(CreateItems(i, 80-(i*5), "Greaves", filePath, "armor", 10, "legs", "", "", "all"), filePath, false);
                SaveAllItems(CreateItems(i, 80-(i*5), "Amulet", filePath, "armor", 10, "necklace", "", "", "all"), filePath, false);
                SaveAllItems(CreateItems(i, 80-(i*5), "Ring", filePath, "armor", 10, "ring", "", "", "all"), filePath, false);
                SaveAllItems(CreateItems(i, 80-(i*5), "Health Potion", filePath, "potion", 10, "", "", "", "all"), filePath, false);
            }
        }
            // List<Item> randomSubset = GetRandomSubset(list, 100);
        public static void SaveAllItems(List<Item> itemList, string filePath, bool append)
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(itemList);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static List<Item> LoadAllItems(string filePath)
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Item>>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        public static List<Item> CreateItems(int itemLevel, int howMany, string itemName, string filePath, string typeOfItem, int weight, string slotType, string attackType, string typeOfDamage, string className)
        {
            List<Item> randomizedItems = new List<Item>();

            randomizedItems = LoadAllItems(filePath);

            Random random = new Random();

            int upperboundDamage = 2;
            int upperboundAttack = 5;
            int upperBoundAC = 2;
            int upperBoundHP = 5;

            int valueAppraisal = 50 + 10*(itemLevel-1);

            int attackBonusRandom = random.Next(1, itemLevel+upperboundAttack);
            int damageBonusRandom = random.Next(1, itemLevel+upperboundDamage);
            int ACBonus = random.Next(1, itemLevel+upperBoundAC);
            int currentHPBonus = random.Next(1, itemLevel+upperBoundHP);

            for(int i = 0; i < howMany; i++)
            {
                //Equipment as proof of concept for adding to inventory and equipping items
                List<CharacterClass> c = new List<CharacterClass>();

                if(className == "fighter")
                    c.Add(newFighter);
                if(className == "wizard")
                    c.Add(newWizard);
                if(className == "shadow weaver")
                    c.Add(newShadowWeaver);
                if(className == "all")
                {
                    c.Add(newFighter);
                    c.Add(newWizard);
                    c.Add(newShadowWeaver);
                }

                attackBonusRandom = random.Next(1, itemLevel+upperboundAttack);
                damageBonusRandom = random.Next(1, itemLevel+upperboundDamage);

                Item newItem = new Item()
                {
                    name = $"{itemName} +Lvl.{itemLevel}",

                    characterClass= c,

                    level = itemLevel,

                    weight = weight,

                    value = valueAppraisal,

                    typeOfItem = typeOfItem,

                    slotType = slotType,

                    isEquipped = false,

                    description = $"I am a {itemName}.",

                    maxHitPointBonus = itemLevel-1,

                    currentHitPointBonus = (typeOfItem.ToLower() == "potion") ? currentHPBonus : 0,

                    meleeDamageBonus = (typeOfItem.ToLower() == "melee weapon") ? damageBonusRandom : 0,

                    rangedDamageBonus = (typeOfItem.ToLower() == "ranged weapon") ? damageBonusRandom : 0,

                    magicDamageBonus = (typeOfItem.ToLower() == "magic weapon" || slotType.ToLower()=="ring") ? damageBonusRandom : 0,

                    meleeAttackBonus = (typeOfItem.ToLower() == "melee weapon") ? attackBonusRandom :0,

                    rangedAttackBonus = (typeOfItem.ToLower() == "ranged weapon") ? attackBonusRandom :0,

                    magicAttackBonus = (typeOfItem.ToLower() == "magic weapon"  || slotType.ToLower()=="necklace") ? attackBonusRandom :0,

                    armorClassBonus = (typeOfItem.ToLower() == "armor") ? ACBonus :0,

                    attackType = attackType,

                    typeOfDamage = typeOfDamage,

                    strRequirement = (typeOfItem.ToLower() == "melee weapon") ? 15+3*(itemLevel-1): (typeOfItem.ToLower() == "armor" && slotType.ToLower() != "necklace" && slotType.ToLower() != "ring") ? 10 + (itemLevel-1): 0,

                    dexRequirement = (typeOfItem.ToLower() == "ranged weapon") ? 15+3*(itemLevel-1): 0,

                    wisRequirement = (typeOfItem.ToLower() == "magic weapon" || slotType.ToLower()=="necklace") ?  15+3*(itemLevel-1): 0,

                    magicRequirement = (typeOfItem.ToLower() == "magic weapon"|| slotType.ToLower()=="ring") ?  15+3*(itemLevel-1): 0,
                };
                randomizedItems.Add(newItem);
            }

            return randomizedItems;
        }  
    }
}