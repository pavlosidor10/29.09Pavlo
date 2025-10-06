using System.Collections.Generic;

public class Weapon
{
    public string Name;
    public int Price;
    public int AttackBonus;
    public static List<Weapon> AllWeapons = new List<Weapon>();
    public Weapon() { }
    public Weapon(string name, int price, int bonus)
    {
        Name = name;
        Price = price;
        AttackBonus = bonus;
        AllWeapons.Add(this);
    }

    public override string ToString()
    {
        return $"{Name} (+{AttackBonus} атаки) - {Price} золота";
    }
}
