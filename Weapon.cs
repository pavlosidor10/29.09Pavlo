public class Weapon
{
    public string Name;
    public int Price;
    public int AttackBonus;

    public override string ToString() => $"{Name} (+{AttackBonus} атаки) - {Price} золота";
}
