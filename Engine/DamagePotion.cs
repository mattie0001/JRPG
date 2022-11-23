using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMechanics
{
    public class DamagePotion : Item
    {
        public int AmountToDamage;
        public DamagePotion(int id, int quantity, string name, string nameplural, int amountToDamage) : base(id, quantity, name, nameplural)
        {
            AmountToDamage = amountToDamage;
        }
    }
}
