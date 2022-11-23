using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMechanics
{
    public static class ItemCollection
    {
        public static readonly List<Item> ItemGroup = new List<Item>();
        public static readonly List<CPUEnemy> CPUGroup = new List<CPUEnemy>();
        public const int ITEMID_PlasticYoyo = 1;
        public const int ITEMID_Hadouken = 2;
        public const int ITEMID_MysticalStick = 3;
        public const int ITEMID_RubberDagger = 4;
        public const int ITEMID_DamagePotion = 5;
        public const int ITEMID_HealthPotion = 6;
        public const int CPUID_EasyCPU = 1;
        public const int CPUID_NormalCPU = 2;
        public const int CPUID_HardCPU = 3;
        static ItemCollection()
        { 
        GenerateItems();
        GenerateCPUEnemies();
        }

        private static void GenerateItems()
        {
            ItemGroup.Add(new Weapon(ITEMID_PlasticYoyo, 1, "Plastic Yoyo", "Plastic yoyos", 2, 5));
            ItemGroup.Add(new Weapon(ITEMID_Hadouken, 1, "Hadouken", "Hadoukens", 3, 4));
            ItemGroup.Add(new Weapon(ITEMID_MysticalStick, 1, "Mystical Stick", "Mystical Sticks", 0, 7));
            ItemGroup.Add(new Weapon(ITEMID_RubberDagger, 1, "Rubber Dagger", "Rubber Daggers", 2, 3));
            ItemGroup.Add(new DamagePotion(ITEMID_DamagePotion, 1, "Damage Potion", "Damage Potions", 10));
            ItemGroup.Add(new HealthPotion(ITEMID_HealthPotion, 1, "Healing potion", "Healing potions", 10));
        }
        private static void GenerateCPUEnemies()
        {
            CPUGroup.Add(new CPUEnemy(CPUID_EasyCPU, "George", 5, 3, 20, 20, 10, 10));
            CPUGroup.Add(new CPUEnemy(CPUID_NormalCPU, "Gregory", 7, 4, 25, 25, 20, 20));
            CPUGroup.Add(new CPUEnemy(CPUID_HardCPU, "Geoff", 9, 7, 30, 30, 35, 35));
        }
        public static Item ItemByID(int id)
        {
            foreach (Item item in ItemGroup)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }
        public static CPUEnemy CPUByID(int id)
        {
            foreach (CPUEnemy cPUEnemy in CPUGroup)
            {
                if (cPUEnemy.ID == id)
                {
                    return cPUEnemy;
                }
            }
            return null;
        }
    }
}
