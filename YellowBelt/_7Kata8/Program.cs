namespace _7Kata8;

class Program
{
    static void Main()
    {
        Player player = new("Arin", 100, 1);
        Enemy enemy = new("Orc");

        int damageDealt = player.Attack(35);
        enemy.TakeDamage(damageDealt);
        player.GainExperience(50);
        player.Attack(35);
        enemy.TakeDamage(damageDealt);
        player.GainExperience(75);
    }
}
