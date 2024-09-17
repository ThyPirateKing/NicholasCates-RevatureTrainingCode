using System;
using System.IO;

namespace CharacterData.Models
{
    public class EquipmentSlot
    {
        public int id { get; set; }
        public int slotLocation { get; set; }

        public bool? headSlot { get; set; } = null;
        public bool? chestSlot { get; set; } = null;
        public bool? armsSlot { get; set; } = null;
        public bool? legsSlot { get; set; } = null;
        public bool? leftHandSlot { get; set; } = null;
        public bool? rightHandSlot { get; set; } = null;
        public bool? necklaceSlot { get; set; } = null;
        public bool? ringSlot { get; set; } = null;

        public string whatIsSlot()
        {
            if (leftHandSlot.HasValue && leftHandSlot.Value == true && rightHandSlot.HasValue && rightHandSlot.Value == true)
                return "two-handed";

            if (headSlot.HasValue && headSlot.Value == true)
                return "head";

            if (chestSlot.HasValue && chestSlot.Value == true)
                return "chest";

            if(armsSlot.HasValue && armsSlot.Value == true)
                return "arms";

            if(legsSlot.HasValue && legsSlot.Value == true)
                return "legs";

            if (leftHandSlot.HasValue && leftHandSlot.Value == true)
                return "left hand";

            if (rightHandSlot.HasValue && rightHandSlot.Value == true)
                return "right hand";
            
            if(necklaceSlot.HasValue && necklaceSlot.Value == true)
                return "necklace";

            if(ringSlot.HasValue && ringSlot.Value == true)
                return "ring";

            return "None"; // Add a default case to return "None" if no slot is active
        }
    }
}