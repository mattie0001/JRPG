using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMechanics
{
    public class CPUEnemy : Battlers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CPUMaxDmg { get; set; }
        public int CPUMinDmg { get; set; }

        public CPUEnemy(int id, string name, int cPUMaxDmg, int cPUMinDmg, int currentHP, int maxHP, int currentMP, int maxMP) 
            : base(currentHP, maxHP, currentMP, maxMP)
        {
            ID = id;
            Name = name;
            CPUMaxDmg = cPUMaxDmg;
            CPUMinDmg = cPUMinDmg;
        }
    }
}
