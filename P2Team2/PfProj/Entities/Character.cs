namespace PfProj.Entities;

using System.Text.Json.Serialization;

public class Character
{
    public int Id { get; set; }
    // Required Input
    public required string name { get; set; } // Name of the character
    public required string characterClassName { get; set; }
    // Optional Input
    public int? level { get; set; } = 1; // Level of the character
    public int? experience { get; set; } = 0; // Experience points of the character // Class of the character
    public int? currentHitPoints {get; set;} = 0; // Current hit points for the character
    public int? maxHitPoints {get; set;} = 0; // Max hit points for the character
    public int? armorClass {get; set;} = 0; // Armor class for the character
    public int? gold { get; set; } = 0; // Gold of the character   
    public int? baseScore {get; set;} = 10;
    public int? str {get; set;} = 10;
    public int? dex {get; set;} = 10;
    public int? wis {get; set;} = 10;
    public int? magic {get; set;} = 10;
    public int? magicResist {get; set;} = 10;
    public int? meleeAttackBonus {get; set;} = 10;
    public int? meleeDamageBonus {get; set;} = 10;
    public int? rangedAttackBonus {get; set;} = 10;
    public int? rangedDamageBonus {get; set;} = 10;
    public int? magicAttackBonus {get; set;} = 10;
    public int? magicDamageBonus {get; set;} = 10;
    // Output (Looks the same as optional inputs here, but we distinquish them by omitting output variables from our request models found in Models/.)
}