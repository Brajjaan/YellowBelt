namespace _9Kata10;

class Program
{
    static void Main()
    {
        Player player = new("Arin", 100, 5);
        Enemy goblin = new("Goblin", 50, 10);
            
        player.Attack(goblin, 20);
            
        NPC villager = new("Villager", "Welcome to our village!");
        villager.Speak();
            
        Merchant merchant = new("Merchant", ["Sword", "Shield", "Potion"]);
        merchant.Speak();
        merchant.Trade();
    }
}