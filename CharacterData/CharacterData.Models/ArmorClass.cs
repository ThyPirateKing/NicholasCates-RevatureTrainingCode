using CharacterData.Models;

namespace CharacterData.Models
{
    //Class for Armor Class
    //This class is a representation of a character's armor class
    //It contains the AC (Armor Class) and a characterID to associate it with a character
    //The AC is calculated by 10 + Dexterity Modifier + Equipment Modifier
    public class ArmorClass
    {
        //The Armor Class
        public int AC{get;set;}
        //The ID of the Armor Class
        public int id { get; set; }
        //The ID of the Character associated with the Armor Class
        public int characterID { get; set; }
        //The Character associated with the Armor Class
        public Character character { get; set; }

        //Constructor for Armor Class
        //This constructor takes in an AC value and sets it to the AC field
        public ArmorClass(int AC) 
        {
            this.AC = AC;
        }
    }
}
