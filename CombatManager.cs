using System;
using System.Collections.Generic;

public static class GameManager
{
    private static Random rnd = new Random();
    private static List<GameEvent> events = GameEvent.GenerateEvents();

    public static string NextTurn(Player player, out object result)
    {
        int roll = rnd.Next(100);
        if (roll < 25)
        {
            result = null;
            return "Нічого не сталося.";
        }
        else if (roll < 50)
        {
            var ev = events[rnd.Next(events.Count)];
            ev.ApplyEffect(player);
            result = ev;
            return $"Подія: {ev.Description}";
        }
        else if (roll < 75)
        {
            var enemy = Enemy.GenerateEnemy(player.Level);
            result = enemy;
            return $"Зустріч з ворогом: {enemy.Name} (Рівень {enemy.Level})";
        }
        else
        {
            result = rnd.Next(2) == 0
                ? (object)ShopForm.GenerateWeapons(5)
                : (object)ShopForm.GenerateArmors(5);
            return "Зустріли торговця.";
        }
    }
}