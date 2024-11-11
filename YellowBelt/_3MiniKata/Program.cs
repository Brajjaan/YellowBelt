namespace _3MiniKata;

class Program
{
    static void Main()
    {
        string[] races = ["Goblin", "Orc", "Troll"];
        for (int i = 0; i < races.Length; i++)
        {
            Console.WriteLine(races[i]);
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

        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine(inventory[i]);
        }
    }
}