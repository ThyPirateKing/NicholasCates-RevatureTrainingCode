namespace PfProj.Models.Characters;

using System.ComponentModel.DataAnnotations;
using PfProj.Entities;

public class UpdateRequestChar
{ 
    // TBI
    // Required Input
    public required string name { get; set; } // Name of the character
    public required string characterClassName { get; set; }
    // Optional Input
    public int? level { get; set; } // Level of the character
    public int? experience { get; set; } // Experience points of the character // Class of the character
    public int? currentHitPoints {get; set;} // Current hit points for the character
    public int? maxHitPoints {get; set;} // Max hit points for the character
    public int? armorClass {get; set;} // Armor class for the character
    public int? gold { get; set; } // Gold of the character   
    public int? baseScore {get; set;}
    public int? str {get; set;}
    public int? dex {get; set;}
    public int? wis {get; set;}
    public int? magic {get; set;}
    public int? magicResist {get; set;}
    public int? meleeAttackBonus {get; set;}
    public int? meleeDamageBonus {get; set;}
    public int? rangedAttackBonus {get; set;}
    public int? rangedDamageBonus {get; set;}
    public int? magicAttackBonus {get; set;} 
    public int? magicDamageBonus {get; set;}
    
}
