using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CharacterData.Models
{
    public class Equipment
    {
        /// <summary>
        /// The primary key for the Equipment database table
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Determines whether the equipment is currently equipped
        /// </summary>
        public bool? isEquipped { get; set; } = false;

        /// <summary>
        /// The slot that the equipment is currently in
        /// </summary>
        public string? equipmentSlot = "No Slot Given";

        /// <summary>
        /// Determines whether the equipment is in the head slot
        /// </summary>
        public bool? headSlot { get; set; } = false;

        /// <summary>
        /// Determines whether the equipment is in the chest slot
        /// </summary>
        public bool? chestSlot { get; set; } = false;

        /// <summary>
        /// Determines whether the equipment is in the arms slot
        /// </summary>
        public bool? armsSlot { get; set; } = false;

        /// <summary>
        /// Determines whether the equipment is in the legs slot
        /// </summary>
        public bool? legsSlot { get; set; } = false;

        /// <summary>
        /// Determines whether the equipment is in the right hand slot
        /// </summary>
        public bool? rightHandSlot { get; set; } = false;

        /// <summary>
        /// Determines whether the equipment is in the left hand slot
        /// </summary>
        public bool? leftHandSlot { get; set; } = false;

        /// <summary>
        /// Determines whether the equipment is in the necklace slot
        /// </summary>
        public bool? necklaceSlot { get; set; } = false;

        /// <summary>
        /// Determines whether the equipment is in the ring slot
        /// </summary>
        public bool? ringSlot { get; set; } = false;

        /// <summary>
        /// The name of the equipment
        /// </summary>
        public string? name { get; set; } = "No Name Given";

        /// <summary>
        /// The description of the equipment
        /// </summary>
        public string? description { get; set; } = "No Description Given";

        /// <summary>
        /// The weight of the equipment
        /// </summary>
        public double? weight { get; set; } = 0;

        /// <summary>
        /// The kind of weapon that the equipment is, if it is a weapon
        /// </summary>
        public string? kindOfWeapon { get; set; } = "No Kind Of Weapon Given";

        /// <summary>
        /// The kind of armor that the equipment is, if it is armor
        /// </summary>
        public string? kindOfArmor { get; set; } = "No Kind Of Armor Given";

        /// <summary>
        /// The hit points of the equipment
        /// </summary>
        public int hitPoints { get; set; } = 0;

        /// <summary>
        /// The melee damage bonus of the equipment
        /// </summary>
        public int meleeDamageBonus { get; set; } = 0;

        /// <summary>
        /// The ranged damage bonus of the equipment
        /// </summary>
        public int rangedDamageBonus { get; set; } = 0;

        /// <summary>
        /// The magic damage bonus of the equipment
        /// </summary>
        public int magicDamageBonus { get; set; } = 0;

        /// <summary>
        /// The melee attack bonus of the equipment
        /// </summary>
        public int meleeAttackBonus { get; set; } = 0;

        /// <summary>
        /// The ranged attack bonus of the equipment
        /// </summary>
        public int rangedAttackBonus { get; set; } = 0;

        /// <summary>
        /// The magic attack bonus of the equipment
        /// </summary>
        public int magicAttackBonus { get; set; } = 0;

        /// <summary>
        /// The armor class bonus of the equipment
        /// </summary>
        public int armorClassBonus { get; set; } = 0;

        /// <summary>
        /// The attack type of the equipment
        /// </summary>
        public string? attackType { get; set; } = "No Attack Type Given";

        /// <summary>
        /// The type of damage that the equipment deals
        /// </summary>
        public string? typeOfDamage { get; set; } = "No Damage Type Given";

        /// <summary>
        /// The strength requirement of the equipment
        /// </summary>
        public int strRequirement { get; set; } = 0;

        /// <summary>
        /// The dexterity requirement of the equipment
        /// </summary>
        public int dexRequirement { get; set; } = 0;

        /// <summary>
        /// The wisdom requirement of the equipment
        /// </summary>
        public int wisRequirement { get; set; } = 0;

        /// <summary>
        /// The magic requirement of the equipment
        /// </summary>
        public int magicRequirement { get; set; } = 0;

        public string whatIsSlot()
        {
            if (leftHandSlot.HasValue && leftHandSlot.Value == true && rightHandSlot.HasValue && rightHandSlot.Value == true)
                return "two-handed";

            if (headSlot.HasValue && headSlot.Value == true)
                return "head";

            if (chestSlot.HasValue && chestSlot.Value == true)
                return "chest";

            if (armsSlot.HasValue && armsSlot.Value == true)
                return "arms";

            if (legsSlot.HasValue && legsSlot.Value == true)
                return "legs";

            if (leftHandSlot.HasValue && leftHandSlot.Value == true)
                return "left hand";

            if (rightHandSlot.HasValue && rightHandSlot.Value == true)
                return "right hand";

            if (necklaceSlot.HasValue && necklaceSlot.Value == true)
                return "necklace";

            if (ringSlot.HasValue && ringSlot.Value == true)
                return "ring";

            return "None"; // Add a default case to return "None" if no slot is active
        }

        /*Extra Equipment To Implement At A Later Date
                public Equipment greatsword = new Equipment(){
                    name = "Greatsword",
                    description = "I am a greatsword.",
                    kindOfWeapon = "melee",
                    weight = 15,
                    meleeDamageBonus = 10,
                    attackType = "Slashing",
                    typeOfDamage = "Physical",
                    strRequirement = 15,
                    dexRequirement = 15,
                    rightHandSlot = true,
                    leftHandSlot = true,


                };

                public Equipment shortsword = new Equipment(){
                    name = "Shortsword",
                    description = "I am a shortsword.",
                    kindOfWeapon = "melee",
                    weight = 5,
                    meleeDamageBonus = 3,
                    attackType = "Slashing",
                    typeOfDamage = "Physical",
                    strRequirement = 12,
                    dexRequirement = 15,
                    rightHandSlot = true,


                };

                public Equipment bow = new Equipment(){
                    name = "Bow",
                    description = "I am a bow.",
                    kindOfWeapon = "ranged",
                    weight = 5,
                    rangedDamageBonus = 5,
                    attackType = "Piercing",
                    typeOfDamage = "Physical",
                    strRequirement = 13,
                    dexRequirement = 15,
                    rightHandSlot = true,
                    leftHandSlot = true,


                };

                public Equipment leatherChest = new Equipment(){
                    name = "Leather Armor",
                    description = "I am a leather chest.",
                    kindOfArmor = "medium armor",
                    weight = 5,
                    strRequirement = 10,
                    dexRequirement = 13,
                    armorClassBonus = 3,
                    chestSlot = true,

                };

                public Equipment clothChest = new Equipment(){
                    name = "Leather Armor",
                    description = "I am a cloth chest.",
                    kindOfArmor = "light armor",
                    weight = 1,
                    strRequirement = 10,
                    dexRequirement = 10,
                    armorClassBonus = 1,
                    chestSlot = true,

                };

                public Equipment woodenShield = new Equipment(){
                    name = "Wooden Shield",
                    description = "I am a wodden shield.",
                    kindOfArmor = "shield",
                    weight = 2,
                    strRequirement = 13,
                    dexRequirement = 12,
                    armorClassBonus = 2,
                    leftHandSlot = true,

                };

                public Equipment staff = new Equipment(){
                    name = "Staff",
                    description = "I am a staff.",
                    kindOfWeapon = "melee",
                    weight = 2,
                    magicDamageBonus = 5,
                    meleeDamageBonus = 1,
                    attackType = "bludgeoning",
                    typeOfDamage = "physical",
                    strRequirement = 10,
                    dexRequirement = 10,
                    magicRequirement = 15,
                    rightHandSlot = true,
                    leftHandSlot = true,


                };
        */
    }
}
