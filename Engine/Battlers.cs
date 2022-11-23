using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMechanics
{
    public class Battlers
    {
        public int CurrentHP;
        public int MaxHP;
        public int CurrentMP;
        public int MaxMP;

        public Battlers(int currentHP, int maxHP, int currentMP, int maxMP)
        {
            CurrentHP = currentHP;
            MaxHP = maxHP;
            CurrentMP = currentMP;
            MaxMP = maxMP;
        }
    }
}
