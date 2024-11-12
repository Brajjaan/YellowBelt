namespace _5Kata7;

class Program
{
    static void Main(string[] args)
    {
        Player player = new();
        Enemy enemy = new();

        player.Name = "Arin";
        player.Health = 100;
        player.Level = 1;
        enemy.Type = "Goblin";
        enemy.Health = 50;
        enemy.Damage = 10;
        
        Console.WriteLine($"Player Info: \nName: {player.Name} \nHealth: {player.Health} \nLevel: {player.Level}");
        Console.WriteLine();
        Console.WriteLine($"Enemy Info \nType: {enemy.Type} \nHealth: {enemy.Health} \nDamage: {enemy.Damage}");

    }
}

class Player
{
    public string Name;
    public int Health;
    public int Level;
}

class Enemy
{
    public string Type;
    public int Health;
    public int Damage;
}