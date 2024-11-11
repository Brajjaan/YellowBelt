namespace _1MiniKata;

class Program
{    
    static void Main(string[] args)
    {
        Attack(15);
        Heal(15);
    }
    public static void Attack(int damage)
    {
        Console.WriteLine($"Player dealt {damage} damage!");
    }

    public static void Heal(int heal)
    {
        Console.WriteLine($"Player healed for {heal} hp!");
    }
}
