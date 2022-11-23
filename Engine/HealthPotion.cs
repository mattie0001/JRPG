using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMechanics
{
    public class HealthPotion : Item
    {
        public int AmountToHeal { get; set; }

        public HealthPotion(int id, int quantity, string name, string nameplural, int amountToHeal) : base(id, quantity, name, nameplural)
        {
            AmountToHeal = amountToHeal;
        }
    }
}
