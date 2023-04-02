using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AppParcial;

namespace AppTests
{

    [TestFixture]
    public class InstantiateTest
    {

        [Test]
        public void NonNegativeValue()
        {
            Weapon sword = new Weapon("Sword", 5, 2, EquipmentClass.Human);
            Armor plate = new Armor("Plate", 8, 2, EquipmentClass.Human);
            Character human = new Character("Human", 10, 5, 2, sword, plate, CharacterClass.Human);

            Assert.GreaterOrEqual(human.HP, 1);
            Assert.GreaterOrEqual(human.BaseAtk, 0);
            Assert.GreaterOrEqual(human.BaseDef, 0);
        }

        [Test]
        public void NonZeroValueOnWeapons()
        {
            Weapon sword = new Weapon("Sword", 5, 2, EquipmentClass.Human);
            Weapon staff = new Weapon("Staff", 3, 5, EquipmentClass.Hybrid);
            Weapon bow = new Weapon("Bow", 4, 3, EquipmentClass.Beast);
            Weapon anyWeapon = new Weapon("Any Weapon", 3, 3, EquipmentClass.Any);

            Armor plate = new Armor("Plate", 8, 2, EquipmentClass.Human);
            Armor robe = new Armor("Robe", 4, 4, EquipmentClass.Hybrid);
            Armor leather = new Armor("Leather", 6, 3, EquipmentClass.Beast);
            Armor anyArmor = new Armor("Any Armor", 4, 4, EquipmentClass.Any);

            Assert.GreaterOrEqual(sword.Power, 1);
            Assert.GreaterOrEqual(sword.Durability, 1);
            Assert.GreaterOrEqual(staff.Power, 1);
            Assert.GreaterOrEqual(staff.Durability, 1);
            Assert.GreaterOrEqual(bow.Power, 1);
            Assert.GreaterOrEqual(bow.Durability, 1);
            Assert.GreaterOrEqual(anyWeapon.Power, 1);
            Assert.GreaterOrEqual(anyWeapon.Durability, 1);

            Assert.GreaterOrEqual(plate.Power, 1);
            Assert.GreaterOrEqual(plate.Durability, 1);
            Assert.GreaterOrEqual(robe.Power, 1);
            Assert.GreaterOrEqual(robe.Durability, 1);
            Assert.GreaterOrEqual(leather.Power, 1);
            Assert.GreaterOrEqual(leather.Durability, 1);
            Assert.GreaterOrEqual(anyArmor.Power, 1);
            Assert.GreaterOrEqual(anyArmor.Durability, 1);
        }

        [Test]
        public void HpValueNonLowerThanOne()
        {
            Weapon sword = new Weapon("Sword", 5, 2, EquipmentClass.Human);
            Armor plate = new Armor("Plate", 8, 2, EquipmentClass.Human);
            Character human = new Character("Human", -10, 5, 2, sword, plate, CharacterClass.Human);

            Assert.IsTrue(human.HP < 1);
        }

        [Test]
        public void DurabilityValueNonLowerThanOne()
        {
            Weapon sword = new Weapon("Sword", 5, -2, EquipmentClass.Human);
            Weapon staff = new Weapon("Staff", 3, -5, EquipmentClass.Hybrid);
            Weapon bow = new Weapon("Bow", 4, -3, EquipmentClass.Beast);
            Weapon anyWeapon = new Weapon("Any Weapon", 3, -3, EquipmentClass.Any);

            Armor plate = new Armor("Plate", 8, -2, EquipmentClass.Human);
            Armor robe = new Armor("Robe", 4, -4, EquipmentClass.Hybrid);
            Armor leather = new Armor("Leather", 6, -3, EquipmentClass.Beast);
            Armor anyArmor = new Armor("Any Armor", 4, -4, EquipmentClass.Any);

            Assert.IsTrue(sword.Durability < 1);
            Assert.IsTrue(plate.Durability < 1);
            Assert.IsTrue(staff.Durability < 1);
            Assert.IsTrue(robe.Durability < 1);
            Assert.IsTrue(bow.Durability < 1);
            Assert.IsTrue(leather.Durability < 1);
            Assert.IsTrue(anyArmor.Durability < 1);
            Assert.IsTrue(anyWeapon.Durability < 1);
        }
        
        [Test]
        public void CorrectClassEquipment()
        {
            Weapon sword = new Weapon("Sword", 5, 2, EquipmentClass.Human);
            Weapon staff = new Weapon("Staff", 3, 5, EquipmentClass.Hybrid);
            Weapon bow = new Weapon("Bow", 4, 3, EquipmentClass.Beast);
            Weapon anyWeapon = new Weapon("Any Weapon", 3, 3, EquipmentClass.Any);


            Armor plate = new Armor("Plate", 8, 2, EquipmentClass.Human);
            Armor robe = new Armor("Robe", 4, 4, EquipmentClass.Hybrid);
            Armor leather = new Armor("Leather", 6, 3, EquipmentClass.Beast);
            Armor anyArmor = new Armor("Any Armor", 4, 4, EquipmentClass.Any);


            Character human = new Character("Human", 10, 5, 2, sword, plate, CharacterClass.Human);
            Character hybrid = new Character("Hybrid", 8, 3, 4, staff, robe, CharacterClass.Hybrid);
            Character beast = new Character("Beast", 12, 4, 3, bow, leather, CharacterClass.Beast);
            Character human_A = new Character("Human_A", 10, 5, 2, anyWeapon, anyArmor, CharacterClass.Human);


            Assert.AreEqual(sword, human.EquippedWeapon);
            Assert.AreEqual(staff, hybrid.EquippedWeapon);
            Assert.AreEqual(bow, beast.EquippedWeapon);
            Assert.AreEqual(anyWeapon, human_A.EquippedWeapon);


            Assert.AreEqual(plate, human.EquippedArmor);
            Assert.AreEqual(robe, hybrid.EquippedArmor);
            Assert.AreEqual(leather, beast.EquippedArmor);
            Assert.AreEqual(anyArmor, human_A.EquippedArmor);
        }
        
        [Test]
        public void JustOneWeaponAtOnce()
        {
            Weapon sword = new Weapon("Sword", 5, 2, EquipmentClass.Human);
            Weapon staff = new Weapon("Staff", 3, 5, EquipmentClass.Hybrid);
            Weapon bow = new Weapon("Bow", 4, 3, EquipmentClass.Beast);
            Weapon anyWeapon = new Weapon("Any Weapon", 3, 3, EquipmentClass.Any);


            Armor plate = new Armor("Plate", 8, 2, EquipmentClass.Human);
            Armor robe = new Armor("Robe", 4, 4, EquipmentClass.Hybrid);
            Armor leather = new Armor("Leather", 6, 3, EquipmentClass.Beast);
            Armor anyArmor = new Armor("Any Armor", 4, 4, EquipmentClass.Any);


            Character human = new Character("Human", 10, 5, 2, sword, plate, CharacterClass.Human);
            Character hybrid = new Character("Hybrid", 8, 3, 4, staff, robe, CharacterClass.Hybrid);
            Character beast = new Character("Beast", 12, 4, 3, bow, leather, CharacterClass.Beast);
            Character human_A = new Character("Human", 10, 5, 2, anyWeapon, anyArmor, CharacterClass.Human);

            if (human.EquippedArmor != null && human.EquippedWeapon != null)
            {
                if (human.EquippedWeapon != null && human.EquippedWeapon != null)
                {
                    {
                        Assert.AreEqual(sword, human.EquippedWeapon);
                        Assert.AreEqual(plate, human.EquippedArmor);                       
                    }
                }
            }
            if (hybrid.EquippedArmor != null && hybrid.EquippedWeapon != null)
            {
                if (hybrid.EquippedWeapon != null && hybrid.EquippedWeapon != null)
                {
                    {
                        Assert.AreEqual(staff, hybrid.EquippedWeapon);
                        Assert.AreEqual(robe, hybrid.EquippedArmor);                        
                    }
                }
            }
            if (beast.EquippedArmor != null && beast.EquippedWeapon != null)
            {
                if (beast.EquippedWeapon != null && beast.EquippedWeapon != null)
                {
                    {
                        Assert.AreEqual(bow, beast.EquippedWeapon);
                        Assert.AreEqual(leather, beast.EquippedArmor);
                    }
                }
            }
            if (human_A.EquippedArmor != null && human_A.EquippedWeapon != null)
            {
                if (human_A.EquippedWeapon != null && human_A.EquippedWeapon != null)
                {
                    {
                        Assert.AreEqual(anyWeapon, human_A.EquippedWeapon);
                        Assert.AreEqual(anyArmor, human_A.EquippedArmor);
                    }
                }
            }

        }
    }
    [TestFixture]
    public class CombatTests
    {
        [Test]
        public void alwaysReduceDurability()
        {

            Weapon sword = new Weapon("Sword", 5, 2, EquipmentClass.Human);
            Weapon staff = new Weapon("Staff", 3, 5, EquipmentClass.Hybrid);

            Armor plate = new Armor("Plate", 8, 2, EquipmentClass.Human);
            Armor robe = new Armor("Robe", 4, 4, EquipmentClass.Hybrid);

            Character human = new Character("Human", 10, 5, 2, sword, plate, CharacterClass.Human);
            Character hybrid = new Character("Hybrid", 8, 3, 4, staff, robe, CharacterClass.Hybrid);

            int human_Atack = hybrid.EquippedArmor.Durability - human.BaseAtk;
            int hybridDurabilityRobe = hybrid.EquippedArmor.Durability;

            Assert.IsTrue(hybridDurabilityRobe > 0);

        }

        [Test]
        public void defenderDoesNotHaveArmor()
        {

            Weapon sword = new Weapon("Sword", 5, 2, EquipmentClass.Human);
            Weapon staff = new Weapon("Staff", 3, 5, EquipmentClass.Hybrid);

            Armor plate = new Armor("Plate", 8, 2, EquipmentClass.Human);           

            Character human = new Character("Human", 10, 5, 2, sword, plate, CharacterClass.Human);
            Character hybrid = new Character("Hybrid", 8, 3, 4, staff, null, CharacterClass.Hybrid);

            if (human.EquippedWeapon != null && hybrid.EquippedArmor == null)
            {

                hybrid.HP = human.BaseAtk - hybrid.HP;


            }
            Assert.IsTrue(hybrid.HP > 0);

        }


    }
}
