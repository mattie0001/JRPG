using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMechanics
{
    public class Weapon : Item
    {
        public int WeaponMaxDamage { get; set; }
        public int WeaponMinDamage { get; set; }

        public Weapon(int id, int quantity, string name, string nameplural, int maxDmg, int minDmg): base(id, quantity, name, nameplural)
        {
            WeaponMaxDamage = maxDmg;
            WeaponMinDamage = minDmg;
        }
    }
}
