using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParcial
{
    public class Armor : Equipment
    {
        public Armor(string name, int power, int durability, EquipmentClass equipClass) : base(name, power, durability, equipClass)
        {
        }

        public override void OnEquip(Character character)
        {
            character.EquippedArmor = this;
        }

        public override void OnUnequip(Character character)
        {
            character.EquippedArmor = null;
        }


    }
}
