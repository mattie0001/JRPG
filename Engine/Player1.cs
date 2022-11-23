using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace SystemMechanics
{
    public class Player : Battlers
    {
        public string PlayerName { get; set; }
        public List<InventoryItem> Inventory { get; set; }

        public Player(string name, int currentHP, int maxHP, int currentMP, int maxMP)
            : base(currentHP, maxHP, currentMP, maxMP)
        {
            PlayerName = name;
            Inventory = new List<InventoryItem>();
        }
        public void AddItemToInventory(Item itemToAdd)
        {
            foreach (InventoryItem ii in Inventory)
            {
                if (ii.ID == itemToAdd.ID)
                {
                    ii.Quantity++;

                    return;
                }
            }
            Inventory.Add(new InventoryItem(itemToAdd, 1));
        }

    }
}
