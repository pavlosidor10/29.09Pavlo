using System;
using System.Windows.Forms;

public partial class CombatForm : Form
{
    private Player player;
    private Enemy enemy;
    private Label lblPlayerStats;
    private Label lblEnemyStats;
    private TextBox txtCombatLog;

    private Button btnAttack;
    private Button btnPowerAttack;
    private Button btnDefend;
    private Button btnHeal;

    private bool playerDefending = false;
    private bool enemyDefending = false; 
    public CombatForm(Player player, Enemy enemy)
    {
        this.player = player;
        this.enemy = enemy;
        SetupUI();
        UpdateStats();
    }

    private void SetupUI()
    {
        this.Text = "Бій";
        this.Width = 600;
        this.Height = 500;

        lblPlayerStats = new Label() { Left = 10, Top = 10, Width = 280, Height = 80 };
        lblEnemyStats = new Label() { Left = 300, Top = 10, Width = 280, Height = 80 };

        txtCombatLog = new TextBox()
        {
            Left = 10,
            Top = 100,
            Width = 560,
            Height = 200,
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical
        };

        btnAttack = new Button() { Text = "Атака", Left = 10, Top = 320 };
        btnPowerAttack = new Button() { Text = "Сильна атака", Left = 100, Top = 320 };
        btnDefend = new Button() { Text = "Захист", Left = 220, Top = 320 };
        btnHeal = new Button() { Text = "Зцілення", Left = 320, Top = 320 };

        btnAttack.Click += (s, e) => PlayerAttack(1.0);
        btnPowerAttack.Click += (s, e) => PlayerAttack(1.5);
        btnDefend.Click += (s, e) =>
        {
            playerDefending = true;
            AppendLog("Гравець обороняється!");
            EnemyTurn();
        };
        btnHeal.Click += (s, e) => { PlayerHeal(); };

        this.Controls.Add(lblPlayerStats);
        this.Controls.Add(lblEnemyStats);
        this.Controls.Add(txtCombatLog);

        this.Controls.Add(btnAttack);
        this.Controls.Add(btnPowerAttack);
        this.Controls.Add(btnDefend);
        this.Controls.Add(btnHeal);
    }

    private void PlayerAttack(double multiplier)
    {
        if (player.Health <= 0)
        {
            AppendLog("Гравець вже повалений і не може атакувати.");
            return;
        }

        if (enemy.Health <= 0)
        {
            AppendLog("Ворог вже повалений.");
            return;
        }

        int attackPower = (int)(player.CalculateAttackPower() * multiplier);

        int defense = enemy.CalculateDefense();
        int damage = Math.Max(0, attackPower - defense);

        enemy.Health -= damage;
        AppendLog($"Гравець завдав {damage} шкоди ворогу.");

        if (enemy.Health <= 0)
        {
            AppendLog("Ворог повалений! Ви перемогли!");
            DisableButtons();
            UpdateStats();
            return;
        }
        EnemyTurn();

        UpdateStats();

        playerDefending = false;
    }

    private void PlayerHeal()
    {
        if (player.Mana >= 10)
        {
            player.Mana -= 10;
            int healAmount = 15;
            player.Health = Math.Min(player.MaxHealth, player.Health + healAmount);
            AppendLog($"Гравець відновив {healAmount} здоров'я.");
            EnemyTurn();
            UpdateStats();
        }
        else
        {
            AppendLog("Недостатньо мани!");
        }
    }

    private void EnemyTurn()
    {
        if (enemy.Health <= 0) return;

        Random random = new Random();
        int action = random.Next(100);

        if (action < 50) 
        {
            int attackPower = enemy.Attack;
            int defense = player.CalculateDefense();

            if (playerDefending)
            {
                defense += 20;
            }

            int damage = Math.Max(0, attackPower - defense);
            player.Health -= damage;

            AppendLog($"Ворог атакує та завдає {damage} шкоди гравцю.");
        }
        else
        {
            AppendLog("Ворог обороняється (нічого не робить цього ходу).");
        }

        if (player.Health <= 0)
        {
            AppendLog("Гравець повалений! Бій завершено.");
            DisableButtons();
        }

        playerDefending = false;
    }


    private void DisableButtons()
    {
        btnAttack.Enabled = false;
        btnPowerAttack.Enabled = false;
        btnDefend.Enabled = false;
        btnHeal.Enabled = false;
    }

    private void AppendLog(string text)
    {
        txtCombatLog.AppendText(text + Environment.NewLine);
    }

    private void UpdateStats()
    {
        lblPlayerStats.Text =
            $"Гравець: {player.Name}\n" +
            $"Рівень: {player.Level}\n" +
            $"Здоров'я: {player.Health} / {player.MaxHealth}\n" +
            $"Мана: {player.Mana} / {player.MaxMana}\n" +
            $"Золото: {player.Gold}\n" +
            $"Зброя: {(player.Weapon != null ? player.Weapon.ToString() : "Немає")}\n" +
            $"Броня: {(player.Armor != null ? player.Armor.ToString() : "Немає")}";

        lblEnemyStats.Text =
            $"Ворог: {enemy.Name}\n" +
            $"Рівень: {enemy.Level}\n" +
            $"Здоров'я: {enemy.Health} / {enemy.MaxHealth}\n" +
            $"Атака: {enemy.Attack}";
    }
}
