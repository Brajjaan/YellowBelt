namespace _6Kata7;

class Program
{
    static void Main(string[] args)
    {
        Player player = new();
        Enemy enemy = new();

        player.Name = "Arin";
        player.Health = 100;
        player.Level = 2;
        int damageDealt = player.Attack(20);
        
        enemy.Type = "Orc";
        enemy.Health = 50;
        enemy.TakeDamage(damageDealt);
        
        player.GainExperience(50);
    }
}

public class Player
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }

    public int Attack(int damage)
    {
        Console.WriteLine($"{Name} attacks and deals {damage} damage!");
        return damage;
    }
    public void GainExperience(int exp)
    {
        Experience = exp;
        Console.WriteLine($"{Name} gained {exp} experience!");
    }
}

public class Enemy
{
    public string Type { get; set; }
    public int Health { get; set; }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Type} takes {damage} damage! Remaining health: {Health}");
    }
}