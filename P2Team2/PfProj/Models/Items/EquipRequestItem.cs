namespace PfProj.Models.Items;

using System.ComponentModel.DataAnnotations;
using PfProj.Entities;

public class EquipRequestItem
{
    // Required Input
     public required string name { get; set; } // The name of the item
     
    // Optional Input
     public bool isEquipped {get; set;} = false;
}