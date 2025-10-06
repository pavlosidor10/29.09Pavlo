public class Enemy
{
    public string Name = "Розбійник";
    public int Level = 5;
    public int MaxHealth = 200;
    public int Health;
    public int Attack=70;
    private int Defense=50;
    private int RewardGold = 4000;
    private int RewardXP=100;
    private string SpecialAbility="None";
    public Player player;
    public Enemy(string name, int level, int attack, int defense, int maxhealth, int xp, int gold, string ability)
    {
        Name = name;
        level = Level;
        attack = Attack;
        defense = Defense;
        maxhealth = MaxHealth;
        Health= MaxHealth;

        xp = RewardXP;
        gold = RewardGold;
        ability = SpecialAbility;
    }
    public static Enemy GenerateEnemy(int playerLevel)
    {
        return new Enemy(ability: "None", gold: 4000, xp: 500, maxhealth: 200, defense: 50, attack: 70, level: playerLevel, name: "Розбійник")
        {

        };
    }
    public int CalculateAttackPower()
    {
        return Attack;
    }
    public int CalculateDefense()
    {
        return Defense;
    }

}
