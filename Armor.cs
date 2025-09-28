public class Armor
{
    public string Name;
    public int Price;
    public int DefenseBonus;

    public override string ToString() => $"{Name} (+{DefenseBonus} захисту) - {Price} золота";
}


