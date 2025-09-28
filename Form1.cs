using System;
using System.Windows.Forms;
using System.Collections.Generic;
using RPGGame;
using RPGGame.Forms;


namespace RPGGame.Forms
{
    public partial class MainForm : Form
    {
        private Player player;
        private TextBox txtLog;
        private Button btnNextTurn;
        private Label lblStats;

        public MainForm()
        {
            InitializeComponent();
            CreatePlayer();  // Створення гравця
            SetupUI();
            UpdateStats();
        }

        private void CreatePlayer()
        {
            // Просте створення гравця — можна додати форму вибору класу
            player = new Player("Гравець", 5, 5, 5, 5);
        }

        private void SetupUI()
        {
            this.Text = "RPG Гра";
            this.Width = 600;
            this.Height = 500;

            lblStats = new Label() { Left = 10, Top = 10, Width = 560, Height = 100 };
            btnNextTurn = new Button() { Text = "Наступний хід", Left = 10, Top = 120, Width = 150 };
            btnNextTurn.Click += BtnNextTurn_Click;

            txtLog = new TextBox() { Left = 10, Top = 160, Width = 560, Height = 280, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };

            this.Controls.Add(lblStats);
            this.Controls.Add(btnNextTurn);
            this.Controls.Add(txtLog);
        }

        private void BtnNextTurn_Click(object sender, EventArgs e)
        {
            string logText = GameManager.NextTurn(player, out object result);

            if (result is GameEvent gameEvent)
            {
                AppendLog(logText);
            }
            else if (result is Enemy enemy)
            {
                AppendLog(logText);
                using (CombatForm combatForm = new CombatForm(player, enemy))
                {
                    combatForm.ShowDialog();
                }
            }
            else if (result is List<Weapon> weapons)
            {
                AppendLog("Магазин зброї! (Відображення магазину вимкнено)");
                
            }
            else if (result is List<Armor> armors)
            {
                AppendLog("Магазин броні! (Відображення магазину вимкнено)");
                
            }
            else
            {
                AppendLog(logText);
            }

            UpdateStats();
        }

        private void AppendLog(string message)
        {
            txtLog.AppendText(message + Environment.NewLine);
        }

            private void UpdateStats()
        {
            player.Mana = Math.Min(player.Mana + 1, player.MaxMana); 
            player.Gold += 5;
            player.Experience += 10;
            player.Level = Math.Max(1, player.Level);
            
            player.Health = Math.Min(player.Health + 1, player.MaxHealth); 
            lblStats.Text =
                $"Ім’я: {player.Name} | Рівень: {player.Level} | XP: {player.Experience}/{player.Level}\n" +
                $"Здоров’я: {player.Health}/{player.MaxHealth} | Мана: {player.Mana}/{player.MaxMana} | Золото: {player.Gold}\n" +
                $"Сила: {player.Strength}, Витривалість: {player.Endurance}, Спритність: {player.Agility}, Інтелект: {player.Intelligence}\n" +
                $"Зброя: {(player.Weapon?.Name ?? "Немає")} | Броня: {(player.Armor?.Name ?? "Немає")}";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}