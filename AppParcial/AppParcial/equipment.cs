using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParcial
{
    using System;

    public enum EquipmentClass
    {
        Human,
        Beast,
        Hybrid,
        Any
    }

    public abstract class Equipment
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int Durability { get; set; }
        public EquipmentClass EquipClass { get; set; }

        public Equipment(string name, int power, int durability, EquipmentClass equipClass)
        {
            Name = name;
            Power = power;
            Durability = durability;
            EquipClass = equipClass;
        }

        

        public abstract void OnEquip(Character character);
        public abstract void OnUnequip(Character character);
    }


}
