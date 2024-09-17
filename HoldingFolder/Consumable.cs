using CharacterData.Models;

namespace CharacterData.Models
{
    public class Consumables : Equipment
    {
        public string name;
        public string description;
        public double weight;
        public EquipmentSlot slot;
        public int strRequirement;
        public int dexRequirement;
        public int wisRequirement;
        public int magicRequirement;
        public bool equipped = false;

        

    public override string getName(){return name;}

    public override void setName(string value){name = value;}

    public override string getDescription(){return description;}

    public override void setDescription(string value){description = value;}

    public override double getWeight(){return weight;}

    public override void setWeight(double value){weight = value;}

    public override EquipmentSlot getSlot(){return slot;}

    public override void setSlot(EquipmentSlot value){slot = value;}

    public override int getStrRequirement(){return strRequirement;}

    public override void setStrRequirement(int value){strRequirement = value;}

    public override int getDexRequirement(){return dexRequirement;}

    public override void setDexRequirement(int value){dexRequirement = value;}

    public override int getWisRequirement(){return wisRequirement;}

    public override void setWisRequirement(int value){wisRequirement = value;}

    public override int getMagicRequirement(){return magicRequirement;}

    public override void setMagicRequirement(int value){magicRequirement = value; }

    public override bool isEquipped(){return equipped;}

    public override void setEquipped(bool value){equipped = value;}
    }
}