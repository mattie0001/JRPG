using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SystemMechanics;

namespace JRGP
{
    public partial class BattleScreen : Form
    {
        private Player Player1;
        private CPUEnemy CPU1;
        public BattleScreen()
        {
            InitializeComponent();
            // Set up the player and give them their weapons
            Player1 = new Player("You", 30, 30, 20, 20);
            Player1.Inventory.Add(new InventoryItem(ItemCollection.ItemByID(ItemCollection.ITEMID_PlasticYoyo), 1));
            Player1.Inventory.Add(new InventoryItem(ItemCollection.ItemByID(ItemCollection.ITEMID_Hadouken), 1));
            Player1.Inventory.Add(new InventoryItem(ItemCollection.ItemByID(ItemCollection.ITEMID_MysticalStick), 1));
            Player1.Inventory.Add(new InventoryItem(ItemCollection.ItemByID(ItemCollection.ITEMID_RubberDagger), 1));
            //Set up UI to display the player's information
            lblPlayer1Name.Text = Player1.PlayerName.ToString();
            lblP1MaxHealthValue.Text = Player1.MaxHP.ToString();
            lblP1CurrentHealthValue.Text = Player1.CurrentHP.ToString();
            lblP1MaxMPValue.Text = Player1.MaxMP.ToString();
            lblP1CurrentMPValue.Text = Player1.CurrentMP.ToString();

            BattleSim();
        }

        private void BattleSim()
        {
            // Initialises the battle
            InformationText.Text += "Here comes a new challenger!";
            CPUEnemy CPU1 = ItemCollection.CPUByID(1);
            CPU1 = new CPUEnemy(CPUGroup.id, CPUGroup.name, CPUGroup.cPUMaxDmg, CPUGroup.cPUMinDmg, CPUGroup.currentHP, CPUGroup.maxHP, CPUGroup.currentMP, CPUGroup.maxMP);
            cboWeapons.Visible = true;
            cboPotions.Visible = true;
            AttackButton.Enabled = true;
            ItemButton.Enabled = true;
            UpdateWeaponListInUI();
            UpdatePotionListInUI();
            while (Player1.CurrentHP < 0 || CPU1.CurrentHP < 0)
            {
                AttackButton.Enabled = true;
                DefendButton.Enabled = true;
                ItemButton.Enabled = true;
                ForfeitButton.Enabled = true;
            }
            AttackButton.Enabled = false;
            DefendButton.Enabled = false;
            ItemButton.Enabled = false;
            ForfeitButton.Enabled = false;
        }

        private void UpdateWeaponListInUI()
        {
            // Add each weapon to the player's selection menu
            List<Weapon> weapons = new List<Weapon>();

            foreach (InventoryItem inventoryItem in Player1.Inventory)
            {
                if (inventoryItem.Details is Weapon)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Details);
                    }
                }
            }
            cboWeapons.DataSource = weapons;
            cboWeapons.DisplayMember = "Name";
            cboWeapons.ValueMember = "ID";
            cboWeapons.SelectedIndex = 0;
        }
        private void UpdatePotionListInUI()
        {
            // Give the player 1 health potion
            List<HealthPotion> healingPotions = new List<HealthPotion>();

            foreach (InventoryItem inventoryItem in Player1.Inventory)
            {
                if (inventoryItem.Details is HealthPotion)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add((HealthPotion)inventoryItem.Details);
                    }
                }
            }
            cboPotions.DataSource = healingPotions;
            cboPotions.DisplayMember = "Name";
            cboPotions.ValueMember = "ID";

            cboPotions.SelectedIndex = 0;
        }

        private void AttackButton_Click(object sender, EventArgs e)
        {
            //The player attacks with their currently selected weapon and the CPU takes a turn after
            Weapon currentWeapon = (Weapon)cboWeapons.SelectedItem;
            int damageToCPU = RandomIntGen.MedianNumber(currentWeapon.WeaponMinDamage, currentWeapon.WeaponMaxDamage);
            CPU1.CurrentHP -= damageToCPU;
            InformationText.Text = "You attacked " + CPU1.Name + " and did " + damageToCPU + "!";
            if (CPU1.CurrentHP <= 0)
            {
                InformationText.Text = "You defeated " + CPU1.Name + "!";
                lblP1CurrentHealthValue.Text = Player1.CurrentHP.ToString();
                UpdateWeaponListInUI();
                UpdatePotionListInUI();
            }
            else
            {
                // CPU Turn
                int damageToPlayer = RandomIntGen.MedianNumber(CPU1.CPUMinDmg, CPU1.CPUMaxDmg);
                Player1.CurrentHP -= damageToPlayer;
                InformationText.Text = CPU1.Name + "attacked! They did " + damageToPlayer + " damage!";
                lblP1CurrentHealthValue.Text = Player1.CurrentHP.ToString();
                if (Player1.CurrentHP <= 0)
                {
                    InformationText.Text = "You were deafeated by " + CPU1.Name + "...";
                }
            }
        }

        private void ItemButton_Click(object sender, EventArgs e)
        {
            //The player uses and item and the CPU takes a turn
            HealthPotion potion = (HealthPotion)cboPotions.SelectedItem;
            Player1.CurrentHP = (Player1.CurrentHP + potion.AmountToHeal);

            if (Player1.CurrentHP > Player1.MaxHP)
            {
                Player1.CurrentHP = Player1.MaxHP;
            }
            //Takes away one potion when the player consumes it
            foreach (InventoryItem ii in Player1.Inventory)
            {
                if (ii.Details.ID == potion.ID)
                {
                    ii.Quantity--;
                    break;
                }
            }

            InformationText.Text = "You drank a health potion and recovered some HP!";
            //CPU Turn
            int damageToPlayer = RandomIntGen.MedianNumber(CPU1.CPUMinDmg, CPU1.CPUMaxDmg);
            Player1.CurrentHP -= damageToPlayer;
            InformationText.Text = CPU1.Name + "attacked! They did " + damageToPlayer + " damage!";
            lblP1CurrentHealthValue.Text = Player1.CurrentHP.ToString();
            if (Player1.CurrentHP <= 0)
            {
                InformationText.Text = "You were deafeated by " + CPU1.Name + "...";
            }
        }

        private void DefendButton_Click(object sender, EventArgs e)
        {
            //The player defends to take reduced damage and the CPU takes a turn after
            InformationText.Text = "You put up your shield!";
            if (CPU1.CurrentHP <= 0)
            {
                InformationText.Text = "You defeated " + CPU1.Name + "!";
                lblP1CurrentHealthValue.Text = Player1.CurrentHP.ToString();
                UpdateWeaponListInUI();
                UpdatePotionListInUI();
            }
            else
            {
                // CPU Turn
                int damageToPlayer = RandomIntGen.MedianNumber(CPU1.CPUMinDmg, CPU1.CPUMaxDmg);
                float damageToDefend = Convert.ToSingle(damageToPlayer);
                damageToDefend *= 0.75f;
                int defendedDamage = Convert.ToInt32(damageToDefend);
                Player1.CurrentHP -= defendedDamage;
                InformationText.Text = CPU1.Name + "attacked! They did " + defendedDamage + " damage!";
                lblP1CurrentHealthValue.Text = Player1.CurrentHP.ToString();
                if (Player1.CurrentHP <= 0)
                {
                    InformationText.Text = "You were deafeated by " + CPU1.Name + "...";
                }
            }
        }

        private void ForfeitButton_Click(object sender, EventArgs e)
        {
            InformationText.Text = "You forfeited the battle...";
            Player1.CurrentHP = 0;
        }
    }
}