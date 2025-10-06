using System.Collections.Generic;

public class Armor
{
    public string Name;
    public int Price;
    public int DefenseBonus;
    public static List<Armor> AllArmors = new List<Armor>();
    public Armor() { }
    public Armor(string name, int price, int bonus)
    {
        Name = name;
        Price = price;
        DefenseBonus = bonus;
        AllArmors.Add(this);
    }
    public override string ToString()
    {
        return $"{Name} (+{DefenseBonus} захисту) - {Price} золота";
    }
}
