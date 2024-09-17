using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CharacterData.Models
{
    public class Item
    {
        
        public List<CharacterClass> characterClass { get; set; }

        private List<Item> equippedItems = new List<Item>();
        //public int characterClassId { get; set; }

        public int id { get; set; } // The item PK in the DB
        public string name { get; set; } // The name of the item
        public int level { get; set; } = 1;
        public double weight { get; set; } // The weight of the item
        public int value {get;set;} // The gold value of the item
        public string typeOfItem { get; set; } // The type of item (melee weapon, ranged weapon, armor, consumable, misc)
        // ^^^ New value used for kindOfWeapon and kindOfArmor (deprecated)
        public string slotType { get; set; } = "None"; // The slot that the item is able to be equipped in (head, chest, arms, rightHand, leftHand, twoHanded, legs, ring)
        public bool isEquipped {get; set;} = false;
        public string description { get; set; } = "No Description Given"; // The description of the equipment
        public int maxHitPointBonus { get; set; } = 0; 
        public int currentHitPointBonus { get; set; } = 0;
        public int meleeDamageBonus { get; set; } = 0;
        public int rangedDamageBonus { get; set; } = 0;
        public int magicDamageBonus { get; set; } = 0;
        public int meleeAttackBonus { get; set; } = 0;
        public int rangedAttackBonus { get; set; } = 0;
        public int magicAttackBonus { get; set; } = 0;
        public int armorClassBonus { get; set; } = 0;
        public string attackType { get; set; } = "No Attack Type Given"; // The type of attack (slashing, piercing, bludgeoning)
        public string typeOfDamage { get; set; } = "No Damage Type Given"; // The type of damage (physical, magical, necrotic)
        public int strRequirement { get; set; } = 0;
        public int dexRequirement { get; set; } = 0;
        public int wisRequirement { get; set; } = 0;
        public int magicRequirement { get; set; } = 0;

        public Item()
        {
            characterClass = new List<CharacterClass>();
        }
    }
}
