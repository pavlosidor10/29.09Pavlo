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
            new GameEvent("Знайдено 20 золота!", p => p.Gold += 20),
            new GameEvent("Знайдено зілля: +10 HP", p => p.Heal(10)),
            new GameEvent("Мудрець підвищив ваш інтелект!", p => p.Intelligence++),
            new GameEvent("Невдача! Втрачено 10 золота", p => p.Gold = Math.Max(0, p.Gold - 10)),
            new GameEvent("Гоблін вкрав ваше зілля (-5 HP)", p => p.TakeDamage(5)),
            
        };
    }
}