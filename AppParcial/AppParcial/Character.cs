using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParcial
{
    using System;

    public enum CharacterClass
    {
        Human,
        Beast,
        Hybrid
    }

    public class Character
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int BaseAtk { get; set; }
        public int BaseDef { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public CharacterClass Class { get; set; }

        public Character(string name, int hp, int baseAtk, int baseDef, Weapon equippedWeapon, Armor equippedArmor, CharacterClass characterClass)
        {
            Name = name;
            HP = hp;
            BaseAtk = baseAtk;
            BaseDef = baseDef;
            EquippedWeapon = equippedWeapon;
            EquippedArmor = equippedArmor;
            Class = characterClass;
        }

        public int GetTotalAtk()
        {
            if (EquippedWeapon != null)
            {
                return BaseAtk + EquippedWeapon.Power;
            }
            return BaseAtk;
        }

        public int GetTotalDef()
        {
            if (EquippedArmor != null)
            {
                return BaseDef + EquippedArmor.Power;
            }
            return BaseDef;
        }
        public int Attack(Character target)
        {
            int totalDamage = this.BaseAtk + this.EquippedWeapon.Power;
            int totalDefense = target.BaseDef;
            int damageDealt = Math.Max(totalDamage - totalDefense, 0);

            if (this.EquippedWeapon.Durability > 0)
            {
                this.EquippedWeapon.Durability--;
                if (this.EquippedWeapon.Durability == 0)
                {
                    this.EquippedWeapon = null;
                }
            }

            if (target.EquippedArmor != null)
            {
                int armorDamage = damageDealt / 2;
                target.EquippedArmor.Durability -= armorDamage;
                if (target.EquippedArmor.Durability <= 0)
                {
                    target.EquippedArmor = null;
                }
            }

            target.HP -= damageDealt;
            return damageDealt;
        }

    }
}
