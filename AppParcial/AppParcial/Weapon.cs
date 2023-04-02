using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParcial
{
    public class Weapon : Equipment
    {
        public Weapon(string name, int power, int durability, EquipmentClass equipClass) : base(name, power, durability, equipClass)
        {
        }

        public override void OnEquip(Character character)
        {
            character.EquippedWeapon = this;
        }

        public override void OnUnequip(Character character)
        {
            character.EquippedWeapon = null;
        }
    }
}