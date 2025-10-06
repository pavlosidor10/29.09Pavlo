using System;
using System.Collections.Generic;
public class Item
{
    public string Name =null;
    public int Price = 0;
    public int Bonus = 0;
    public Item(string name, int price, int bonus)
    {
        Name = name;
        Price = price;
        Bonus = bonus;
    }
}
public class Shop
{
    public List<Item> Items;

    public Shop()
    {
        Items = new List<Item>();
    }

    public void GenerateItems()
    {
        Items.Clear();
        Items.Add(new Item("Sword", 150, 50));
        Items.Add(new Item("Axe", 120, 20));
        Items.Add(new Item("Bow", 170, 60));
        Items.Add(new Item("Shield", 75, 50));
        Items.Add(new Item("Helmet", 50, 5));
        Items.Add(new Item("Metal Armor", 200, 100));
        Items.Add(new Item("Wooden Armor", 100, 70));
        Items.Add(new Item("Health Potion", 30, 50));
        Items.Add(new Item("Mana Potion", 25, 30));
    }

    public Item BuyRandomItem(Player player)
    {
        if (Items.Count == 0) return null;

        Random random = new Random();
        Item item = Items[random.Next(Items.Count)];

        if (player.Gold < item.Price)
        {
            return null;
        }

        player.Gold -= item.Price;

        if (item.Name == "Sword" || item.Name == "Axe" || item.Name == "Bow")
        {
            Weapon weapon = new Weapon(item.Name, item.Price, item.Bonus);
        }
        else if (item.Name == "Shield" || item.Name == "Helmet" ||
                 item.Name == "Metal Armor" || item.Name == "Wooden Armor")
        {
            Armor armor = new Armor(item.Name, item.Price, item.Bonus);
        }
        else if (item.Name == "Health Potion")
        {
            player.Health += 50;
        }
        else if (item.Name == "Mana Potion")
        {
            player.Mana += 30;
        }

            return item;
    }



}
