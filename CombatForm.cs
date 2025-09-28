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

        txtCombatLog = new TextBox() { Left = 10, Top = 100, Width = 560, Height = 200, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };

        btnAttack = new Button() { Text = "Атака", Left = 10, Top = 320 };
        btnPowerAttack = new Button() { Text = "Сильна атака", Left = 100, Top = 320 };
        btnDefend = new Button() { Text = "Захист", Left = 220, Top = 320 };
        btnHeal = new Button() { Text = "Зцілення", Left = 320, Top = 320 };

        btnAttack.Click += (s, e) => PlayerAttack(1.0);
        btnPowerAttack.Click += (s, e) => PlayerAttack(1.5);
        btnDefend.Click += (s, e) => { playerDefending = true; AppendLog("Гравець обороняється!"); EnemyTurn(); };
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
        Random rnd = new Random();
        int baseDmg = player.CalculateAttackPower();
        if (rnd.NextDouble() < player.CriticalChance / 100)
        {
            baseDmg *= 2;
            AppendLog("Критичний удар!");
        }

        int dmg = (int)(baseDmg * multiplier) - enemy.Defense;
        if (dmg < 1) dmg = 1;
        enemy.Health -= dmg;

        AppendLog($"Гравець наносить {dmg} шкоди ворогу.");

        if (enemy.Health <= 0)
        {
            AppendLog($"Перемога! Отримано {enemy.RewardXP} XP і {enemy.RewardGold} золота.");
            player.GainExperience(enemy.RewardXP);
            player.Gold += enemy.RewardGold;
            this.Close();
        }
        else
        {
            EnemyTurn();
        }

        UpdateStats();
    }

    private void PlayerHeal()
    {
        if (player.Mana >= 10)
        {
            player.Mana -= 10;
            player.Heal(15);
            AppendLog("Гравець відновив 15 HP.");
        }
        else
        {
            AppendLog("Недостатньо мани!");
        }

        EnemyTurn();
        UpdateStats();
    }

    private void EnemyTurn()
    {
        int damage = enemy.Attack - player.CalculateDefense();
        if (playerDefending)
        {
            damage /= 2;
            playerDefending = false;
        }

        if (damage < 1) damage = 1;

        player.TakeDamage(damage);
        AppendLog($"Ворог наносить {damage} шкоди.");

        if (player.Health <= 0)
        {
            AppendLog("Поразка! Ви загинули.");
            MessageBox.Show("Ви загинули!", "Кінець гри");
            Application.Exit(); // або Close();
        }

        UpdateStats();
    }

    private void AppendLog(string text)
    {
        txtCombatLog.AppendText(text + Environment.NewLine);
    }

    private void UpdateStats()
    {
        lblPlayerStats.Text = $"Гравець\nHP: {player.Health}/{player.MaxHealth}\nMana: {player.Mana}/{player.MaxMana}";
        lblEnemyStats.Text = $"Ворог: {enemy.Name}\nHP: {enemy.Health}/{enemy.MaxHealth}";
    }
}
