namespace CharacterData.Models;
public class CharacterEquipments
{
    public int CharacterEquipmentID { get; set; }
    public int CharacterID { get; set; }
    public int EquipmentID { get; set; }
    // public List<Character> characters { get; set; }
    
    // public List<Equipment> inventory { get; set; }

    public Character? character { get; set; }
    public Equipment? equipment { get; set; }
}
