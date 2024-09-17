namespace PfProj.Entities;

using System.Text.Json.Serialization;

public class CharacterClassItem
{
    public int Id { get; set; }
    // Required Input
    public required string className { get; set; }
    public required int itemID {get; set;}
    // Optional Input
    // Output (Looks the same as optional inputs here, but we distinquish them by omitting output variables from our request models found in Models/.)
}
