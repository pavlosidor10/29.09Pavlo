using System;
using System.Collections.Generic;
using RPGGame.Forms;

public static class ShopForm
{
    
    


    private static Random rnd = new Random();
    private static string[] weaponNames = { "Меч", "Кинджал", "Сокира", "Молот" };
    private static string[] armorNames = { "Кираса", "Щит", "Шолом", "Броня" };

    public static List<Weapon> GenerateWeapons(int count)
    {
        var list = new List<Weapon>();
        for (int i = 0; i < count; i++)
        {
            var name = weaponNames[rnd.Next(weaponNames.Length)];
            int bonus = rnd.Next(1, 6);
            int price = bonus * 25;
            list.Add(new Weapon { Name = name, AttackBonus = bonus, Price = price });
        }
        return list;
    }

    public static List<Armor> GenerateArmors(int count)
    {
        var list = new List<Armor>();
        for (int i = 0; i < count; i++)
        {
            var name = armorNames[rnd.Next(armorNames.Length)];
            int bonus = rnd.Next(1, 6);
            int price = bonus * 20;
            list.Add(new Armor { Name = name, DefenseBonus = bonus, Price = price });
        }
        return list;
    }
}
