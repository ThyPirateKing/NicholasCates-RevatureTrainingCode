namespace PfProj.Services;

using Microsoft.VisualBasic;
using PfProj.Models.Characters;
using WebApi.Controllers;
using PfProj.Entities;
using System.Formats.Tar;

class intermediateServices{
    public String[] classes;
    Dictionary<string, int[]> attributeDictionary = [];

    // Example of instantiation:
    // param 1 = String[] -> ["Fighter"];
    // param 2 = Dictionary<string, int[]> -> ["Fighter", [14,12,10,8]];
    // order: str, dex, wis, mag
    public intermediateServices(){ // instantiate with some example values
        classes = ["Fighter", "Wizard", "Shadow Weaver"];
        attributeDictionary.Add("Fighter", [14,12,10,8]);
        attributeDictionary.Add("Wizard", [8,10,14,12]);
        attributeDictionary.Add("Shadow Weaver", [10,8,12,14]);
    }
    // primary
    public intermediateServices(String[] classArray, Dictionary<string, int[]> attributeDict){
        classes = classArray;
        attributeDictionary = attributeDict;
    }
    // input character, instantiates attributes
    public Character UpdateAttributes(Character model)
    {
        if (attributeDictionary.ContainsKey(model.characterClassName)){ // abort if unknown class
            int[] attributes = attributeDictionary[model.characterClassName];
            model.str = attributes[0];
            model.dex = attributes[1];
            model.wis = attributes[2];
            model.magic = attributes[3];
        }
        return model;
    }
    // input character, instantiates stats
    public Character UpdateStats(Character model)
    {
        if (model.str != 0) { // abort of attributes uninstantiated
        // Update armor class
            model.armorClass = (model.dex + model.str);

            // Update hit points
            model.maxHitPoints = (model.str + model.wis);

            // Update melee attack bonus and damage

            model.meleeAttackBonus = (model.str - 10) + (model.dex - 10);

            model.meleeDamageBonus = (model.str - 10);

            // Update ranged attack bonus and damage
            model.rangedAttackBonus = (model.str - 10) + (model.dex - 10);

            model.rangedDamageBonus = (model.dex - 10);

            // Update magic attack bonus and damage
            model.magicAttackBonus = (model.wis - 10) + (model.magic - 10);

            model.magicDamageBonus = (model.magic - 10);
        }
        return model;
    }
        // items dont have foreign keys with characters so we cannot pull character attributes or equipment
        public Item EquipItem(Item target, Character character)
        {
            if (CanEquip(target))
                target.isEquipped = !target.isEquipped;
            else
                target.isEquipped = false;
            return target;
        }
        public bool CanEquip(Item equipment)
        {
            if(equipment.typeOfItem == "potion")
                return false;
            else
                return true;
        }
        public bool LevelUp(Character target){
            return false;
        }
}

