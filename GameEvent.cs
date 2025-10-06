using System;
using System.Collections.Generic;

public class GameEvent
{
    public string Description;
    public Action<Player> ApplyEffect;

    public GameEvent(string description, Action<Player> effect)
    {
        Description = description;
        ApplyEffect = effect;
    }

    public static List<GameEvent> GenerateEvents()
    {
        return new List<GameEvent>
        {
            new GameEvent("Ви знайшли скриню зі скарбами! Отримуєте 50 золота.", player => player.Gold += 50),
            new GameEvent("Ви натрапили на пастку! Втрачаєте 20 здоров'я.", player => player.Health -= 20),
            new GameEvent("Ви знайшли цілющий еліксир! Відновлюєте 30 здоров'я.", player => player.Health += 30),
            new GameEvent("Ви потрапили в засідку! Втрачаєте 15 золота.", player => player.Gold = Math.Max(0, player.Gold - 15)),
            new GameEvent("Ви знайшли стародавній артефакт! Отримуєте 100 золота.", player => player.Gold += 100),
            new GameEvent("Ви потрапили в засідку! Втрачаєте 25 здоров'я.", player => player.Health -= 25),
            new GameEvent("Ви знайшли цілющий еліксир! Відновлюєте 40 здоров'я.", player => player.Health += 40),
            new GameEvent("Почався чарівний дощ.Ви отримали Ману",player=>player.Mana+=20),
            new GameEvent("Ви знайшли зілля мани! Отримуєте 50 мани.", player => player.Mana += 50)
        };
    }
}
