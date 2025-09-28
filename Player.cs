public class Player
{
    public string Name;
    public int Level = 1;
    public int Experience = 0;
    public int ExperienceToLevelUp => Level * 100;

    public int Strength;
    public int Endurance;
    public int Agility;
    public int Intelligence;

    public int MaxHealth => Endurance * 10;
    public int MaxMana => Intelligence * 5;
    public int Health;
    public int Mana;

    public int Gold;

    public Weapon Weapon;
    public Armor Armor;

    public double CriticalChance => Agility * 0.5;

    public Player(string name, int strength, int endurance, int agility, int intelligence)
    {
        Name = name;
        Strength = strength;
        Endurance = endurance;
        Agility = agility;
        Intelligence = intelligence;

        Health = MaxHealth;
        Mana = MaxMana;
        Gold = 100;
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

    public void TakeDamage(int dmg)
    {
        Health -= dmg;
        if (Health < 0) Health = 0;
    }

    public void Heal(int amount)
    {
        Health += amount;
        if (Health > MaxHealth) Health = MaxHealth;
    }
}