namespace PfProj.Entities;

using System.Text.Json.Serialization;

public class CharacterClass
{
    public int Id { get; set; }
    // Required Input
    public required string className { get; set; }
    // Optional Input
    public int? baseScore { get; set; } = 10;
    public int? dex { get; set; }
    public int? str { get; set; }
    public int? wis { get; set; }
    public int? magic { get; set; }
    public int? magicResist { get; set; }
    // Output (Looks the same as optional inputs here, but we distinquish them by omitting output variables from our request models found in Models/.)
}
