﻿namespace _8Kata9;

class Program
{
    static void Main()
    {
        Player player = new("Arin", 100, 5);
        Enemy goblin = new("Goblin", 50, 10);
            
        player.Attack(goblin, 20);
            
        NPC villager = new("Villager", "Welcome to our village!");
        villager.Speak();
            
        Merchant blacksmith = new("Blacksmith", ["Sword", "Shield", "Potion"]);
        blacksmith.Trade();
    }
}