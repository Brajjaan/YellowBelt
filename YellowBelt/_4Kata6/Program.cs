namespace _4Kata6;

class Program
{
    static void Main(string[] args)
    {
        string[] enemies = ["Goblin", "Orc", "Troll", "Skeleton", "Dragon"];
        for (int i = 0; i < enemies.Length; i++)
        {
            Console.WriteLine(enemies[i]);
        }
        Console.WriteLine();

        List<string> inventory = new List<string>
        {
            "Sword",
            "Shield",
            "Potion"
        };
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine(inventory[i]);
        }
        Console.WriteLine();
        inventory.Add("Helmet");
        inventory.Add("Armor");
        inventory.Remove("Potion");

        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine(inventory[i]);
        }

        Console.WriteLine("Number of items in inventory: " + inventory.Count);
    }
}