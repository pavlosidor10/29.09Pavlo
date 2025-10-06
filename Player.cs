public class Player
{
    public string Name = "Принц";
    public int Level = 1;
    private int Experience = 0;
    private int ExperienceToLevelUp => Level * 100;

    public int Strength = 100;
    public int Endurance = 100;
    public int Agility = 50;
    public int Intelligence = 120;

    public int MaxHealth = 200;
    public int MaxMana => Intelligence * 5;
    public int Health;
    public int Mana;

    public int Gold = 1000;

    public Weapon Weapon;
    public Armor Armor;
    public Enemy Enemy;

    public double CriticalChance => Agility * 0.5;

    public Player(string name, int maxhealth, int strength, int endurance, int agility, int intelligence, int gold)
    {
        name = Name;
        maxhealth = MaxHealth;
        Health = MaxHealth;
        Mana = MaxMana;
        Strength = strength;
        Endurance = endurance;
        Agility = agility;
        Intelligence = intelligence;
        gold = Gold;
    }

    public int CalculateAttackPower()
    {
        return Strength + (Weapon?.AttackBonus ?? 0);
    }

    public int CalculateDefense()
    {
        return Agility + (Armor?.DefenseBonus ?? 0);
    }

    public void GainExperience(int xp)
    {
        Experience += xp;
        while (Experience >= ExperienceToLevelUp)
        {
            Experience -= ExperienceToLevelUp;
            Level++;
            Strength++;
            Endurance++;
            Agility++;
            Intelligence++;
            Health = MaxHealth;
            Mana = MaxMana;
        }
    }
    public void CalculateGold(int amount)
    {
        Gold += amount;
        if (Gold < 0) Gold = 0;

    }
    public void CalculateMana(int amount)
    {
        Mana += amount;
        if (Mana < 0) Mana = 0;
        if (Mana > MaxMana) Mana = MaxMana;
    }
    public void CalculateDefense(int amount)
    {
        Endurance += amount;
        if (Endurance < 0) Endurance = 0;
    }




}
