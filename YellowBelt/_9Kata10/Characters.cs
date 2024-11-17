namespace _9Kata10;

public interface ICharacter
{
    string Name { get; }
}

public interface ISpeakable
{
    void Speak();
}

public interface IDamagable
{
    int Health { get; }
    void TakeDamage(int damage);
}
public class Player : ICharacter, IDamagable
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Level { get; private set; }

    public Player(string name, int health, int level)
    {
        Name = name;
        Health = health;
        Level = level;
    }

    public void Attack(Enemy enemy, int damage)
    {
        Console.WriteLine($"{Name} attacks {enemy.Type} and deals {damage} damage.");
        enemy.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
        Console.WriteLine($"{Name} takes {damage} damage. Remaining health: {Health}");
    }
}
public class Enemy : ICharacter
{
    public string Name { get; }
    public string Type { get; private set; }
    public int Health { get; private set; }
    public int Damage { get; private set; }

    public Enemy(string type, int health, int damage)
    {
        Type = type;
        Health = health;
        Damage = damage;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
        Console.WriteLine($"{Type} takes {damage} damage. Remaining health: {Health}");
    }
}
public class NPC : ICharacter, ISpeakable
{
    public string Name { get; private set; }
    public string Dialogue { get; private set; }

    public NPC(string name, string dialogue)
    {
        Name = name;
        Dialogue = dialogue;
    }
    public void Speak()
    {
        Console.WriteLine($"{Name} says: {Dialogue}");
    }
}
public class Merchant : ICharacter, ISpeakable
{
    public string Name { get; private set; }
    public List<string> Inventory { get; private set; }

    public Merchant(string name, List<string> inventory)
    {
        Name = name;
        Inventory = inventory;
    }
    public void Trade()
    {
        Console.WriteLine($"{Name}'s inventory: {string.Join(", ", Inventory)}");
    }

    public void Speak()
    {
        Console.WriteLine($"{Name} is ready to trade!");
    }
}