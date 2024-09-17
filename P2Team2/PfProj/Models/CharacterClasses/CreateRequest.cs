namespace PfProj.Models.CharacterClasses;

using System.ComponentModel.DataAnnotations;
using PfProj.Entities;

public class CreateRequest
{
    public required string className { get; set; }
    // Optional Input
    public int? baseScore { get; set; } = 10;
    public int? dex { get; set; }
    public int? str { get; set; }
    public int? wis { get; set; }
    public int? magic { get; set; }
    public int? magicResist { get; set; }
}
