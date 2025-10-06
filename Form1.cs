using System;
using System.Windows.Forms;


namespace RPGGame.Forms
{
    public partial class MainForm : Form
    {
        private Player player;

        public MainForm()
        {
            InitializeComponent();
            CreatePlayer();
        }

        private void CreatePlayer()
        {

            player = new Player("Принц", 200, 100, 100, 50, 120, 1000);
            listBox1.Items.Add($"Вітаю у грі!:{player.Name}");
            listBox1.Items.Add($"Здоров'я:{player.MaxHealth}, Сила: {player.Strength},Витривалість: {player.Endurance}, Спритність{player.Agility}, Інтелект: {player.Intelligence}, Золото: {player.Gold},Мана:{player.Mana}");

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }


        private void buttonShop_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Shop shop = new Shop();
            shop.GenerateItems();
            DialogResult result = MessageBox.Show("Вітаю у магазині!.Бажаєте щось придбати","Shop",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            { 
                listBox1.Items.Add("Доступні товари в магазині:");
                foreach (var item in shop.Items)
                {
                    listBox1.Items.Add($"{item.Name} - {item.Price} золота");
                }

                Item boughtItem = shop.BuyRandomItem(player);

                if (boughtItem != null)
                {
                    listBox1.Items.Add($"{player.Name} купив  товар: {boughtItem.Name} за {boughtItem.Price} золота.");
                    listBox1.Items.Add($"Залишок золота: {player.Gold}");
                    if (boughtItem.Name == "Sword" || boughtItem.Name == "Axe" || boughtItem.Name == "Bow")
                    {
                        player.Weapon = new Weapon
                        {
                            Name = boughtItem.Name,
                            Price = boughtItem.Price,
                            AttackBonus = boughtItem.Bonus
                        };
                        listBox1.Items.Add($"{player.Name} отримав зброю: {player.Weapon}");
                        Weapon wItem = player.Weapon;
                    }
                    else if (boughtItem.Name == "Shield" || boughtItem.Name == "Helmet" ||
                             boughtItem.Name == "Metal Armor" || boughtItem.Name == "Wooden Armor")
                    {
                        player.Armor = new Armor
                        {
                            Name = boughtItem.Name,
                            Price = boughtItem.Price,
                            DefenseBonus = boughtItem.Bonus
                        };
                        listBox1.Items.Add($"{player.Name} отримав броню: {player.Armor}");

                    }
                    else if (boughtItem.Name == "Health Potion")
                    {
                        player.Health = Math.Min(player.MaxHealth, player.Health + boughtItem.Bonus);
                        listBox1.Items.Add($"{player.Name} купив зілля здоров'я. Здоров'я відновлено до {player.Health}.");
                    }
                    else if (boughtItem.Name == "Mana Potion")
                    {
                        player.Mana = Math.Min(player.MaxMana, player.Mana + boughtItem.Bonus);
                        listBox1.Items.Add($"{player.Name} купив зілля мани. Мана відновлена до {player.Mana}.");
                    }
                }
                else
                {
                    listBox1.Items.Add($"{player.Name} не вистачає золота на покупку.");
                }
            }
            else
            {
                listBox1.Items.Add("Ви вийшли з магазину.");
            }
            listBox1.Items.Add($"Здоров'я: {player.Health}, Сила: {player.Strength}, Витривалість: {player.Endurance}, Спритність: {player.Agility}, Інтелект: {player.Intelligence}, Золото: {player.Gold}, Мана: {player.Mana}");

        }
        private void buttonFight_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var events = GameEvent.GenerateEvents();
            var random = new Random();
            var gameEvent = events[random.Next(events.Count)];

            listBox1.Items.Add("Подорож...");
            listBox1.Items.Add(" Подія: " + gameEvent.Description);

            gameEvent.ApplyEffect(player);

            listBox1.Items.Add($" Здоров'я: {player.Health}, 🪙 Золото: {player.Gold}");

            if (random.NextDouble() < 0.3) 
            {
                listBox1.Items.Add("Виник ворог!");

                Enemy enemy = Enemy.GenerateEnemy(player.Level);
                enemy.Health = enemy.MaxHealth; 

                CombatForm combatForm = new CombatForm(player, enemy);
                combatForm.ShowDialog();

                listBox1.Items.Add($" Бій завершено. Здоров'я: {player.Health}, Золото: {player.Gold}");
            }
            else
            {
                listBox1.Items.Add(" Подорож завершена без бою.");
            }
            listBox1.Items.Add($"Здоров'я: {player.Health}, Сила: {player.Strength}, Витривалість: {player.Endurance}, Спритність: {player.Agility}, Інтелект: {player.Intelligence}, Золото: {player.Gold}, Мана: {player.Mana}");
        }
         

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            bool hasWeapons = Weapon.AllWeapons.Count > 0;
            bool hasArmors = Armor.AllArmors.Count > 0;
            if (!hasWeapons && !hasArmors)
            {
                listBox1.Items.Add("У вас в інвентарі порожньо.");
                return;
            }

            if (hasWeapons)
            {
                listBox1.Items.Add("Уся зброя:");
                foreach (var weapon in Weapon.AllWeapons)
                {
                    listBox1.Items.Add(weapon.ToString());
                }
            }

            if (hasArmors)
            {
                listBox1.Items.Add(" Уся броня:");
                foreach (var armor in Armor.AllArmors)
                {
                    listBox1.Items.Add(armor.ToString());
                }
            }
            listBox1.Items.Add($"Здоров'я: {player.Health}, Сила: {player.Strength}, Витривалість: {player.Endurance}, Спритність: {player.Agility}, Інтелект: {player.Intelligence}, Золото: {player.Gold}, Мана: {player.Mana}");
        }

      
    }
}
