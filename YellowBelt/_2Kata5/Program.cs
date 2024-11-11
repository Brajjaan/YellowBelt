namespace _2Kata5;

class Program
{
    static void Main(string[] args)
    {
        AttackEnemy("Goblin", 20 );
        HealPlayer("Player", 15);
    }

    static void AttackEnemy(string enemyName, int damage)
    {
        Console.WriteLine($"Attacked {enemyName} and dealt {damage} damage");
    }

    static void HealPlayer(string playerName, int healAmount)
    {
        Console.WriteLine($"Healed {playerName} for {healAmount} hp!");
    }
}