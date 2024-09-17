namespace PfProj.Models.Items;

using System.ComponentModel.DataAnnotations;
using PfProj.Entities;

public class CreateRequestItem
{
    // Required Input
     public required string name { get; set; } // The name of the item
    public required double weight { get; set; } // The weight of the item
    public required int value {get;set;} // The gold value of the item
    public required string typeOfItem { get; set; } // The type of item (melee weapon, ranged weapon, armor, consumable, misc)
    // ^^^ New value used for kindOfWeapon and kindOfArmor (deprecated)

    // Optional Input
    public int? characterID { get; set; }
    public string? slotType { get; set; } // The slot that the item is able to be equipped in (head, chest, arms, rightHand, leftHand, twoHanded, legs, ring)
    public bool isEquipped {get; set;} = false;
    public string? description { get; set; } = "No Description Given"; // The description of the equipment
    public int? maxHitPointBonus { get; set; } = 0; 
    public int? currentHitPointBonus { get; set; } = 0;
    public int? meleeDamageBonus { get; set; } = 0;
    public int? rangedDamageBonus { get; set; } = 0;
    public int? magicDamageBonus { get; set; } = 0;
    public int? meleeAttackBonus { get; set; } = 0;
    public int? rangedAttackBonus { get; set; } = 0;
    public int? magicAttackBonus { get; set; } = 0;
    public int? armorClassBonus { get; set; } = 0;
    public string? attackType { get; set; } = "No Attack Type Given"; // The type of attack (slashing, piercing, bludgeoning)
    public string? typeOfDamage { get; set; } = "No Damage Type Given"; // The type of damage (physical, magical, necrotic)
    public int? strRequirement { get; set; } = 0;
    public int? dexRequirement { get; set; } = 0;
    public int? wisRequirement { get; set; } = 0;
    public int? magicRequirement { get; set; } = 0;
}
