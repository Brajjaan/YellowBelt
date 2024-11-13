namespace _7Kata8;

public class Enemy
{
    public string Type { get; set; }
    public int Health { get; set; }

    public Enemy(string type)
    {
        Type = type;
        Health = 50;
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            EnemyDeath();
        }
        else
        {
            Console.WriteLine($"{Type} takes {damage} damage! Remaining health: {Health}");
        }
    }
    public void EnemyDeath()
    {
        Console.WriteLine($"{Type} is defeated!");
    }
}