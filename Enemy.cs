using System;

public class Enemy
{
    public string Name;
    public int Level;
    public int Health;
    public int MaxHealth;
    public int Attack;
    public int Defense;

    public int RewardGold;
    public int RewardXP;
    public string SpecialAbility;

    public Enemy(string name, int level, int attack, int defense, int health, int xp, int gold, string ability)
    {
        Name = name;
        Level = level;
        Attack = attack;
        Defense = defense;
        MaxHealth = health;
        Health = health;
        RewardXP = xp;
        RewardGold = gold;
        SpecialAbility = ability;
    }

    public static Enemy GenerateEnemy(int playerLevel)
    {
        Random rnd = new Random();
        int level = playerLevel + rnd.Next(-1, 2); // ±1
        if (level < 1) level = 1;

        int attack = 5 + level * 2;
        int defense = 3 + level * 2;
        int health = 30 + level * 10;

        int xp = 20 + level * 10;
        int gold = 10 + level * 5;

        string[] names = { "Гоблін" };
        string name = names[rnd.Next(names.Length)];
        string ability = "None"; 

        return new Enemy(name, level, attack, defense, health, xp, gold, ability);
    }
}
