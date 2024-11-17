namespace _10Exam;

public interface ICharacter
{
    string Name { get; }
}
public interface IDamageable : ICharacter
{
    int Health { get; }
    void TakeDamage(int damage);
    bool IsAlive();
}
public interface IAttackable
{
    void Attack(IDamageable target);
}
public interface ISpeakable
{
    void Speak();
}
public interface ITradable
{
    List<string> Inventory { get; }
    void Trade(Player player);
}


public class Player : ICharacter, IDamageable, IAttackable
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Level { get; private set; }
    public int Experience { get; private set; }
    public int Currency { get; private set; }

    public Player(string name, int health = 50, int level = 1, int startingCurrency = 100)
    {
        Name = name;
        Health = health;
        Level = level;
        Experience = 0;
        Currency = startingCurrency;
    }

    public void Attack(IDamageable target)
    {
        int damage = 20;
        Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage.");
        target.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} takes {damage} damage. Health left: {Health}");
    }

    public bool IsAlive() => Health > 0;

    public void Heal()
    {
        int healAmount = 15;
        Health += healAmount;
        Console.WriteLine($"{Name} heals for {healAmount} points. Health is now {Health}");
    }

    public void GainExperience(int amount)
    {
        Experience += amount;
        Console.WriteLine($"{Name} gains {amount} experience points.");
    }

    public bool SpendCurrency(int amount)
    {
        if (Currency >= amount)
        {
            Currency -= amount;
            Console.WriteLine($"{Name} spends {amount} coins. Remaining balance: {Currency} coins.");
            return true;
        }
        Console.WriteLine($"Not enough coins. {Name} has only {Currency} coins.");
        return false;
    }
}
public class Enemy : ICharacter, IDamageable
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Damage { get; private set; }

    public Enemy(string name, int health, int damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

    public void Attack(IDamageable target)
    {
        Console.WriteLine($"{Name} attacks {target.Name} for {Damage} damage.");
        target.TakeDamage(Damage);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
        Console.WriteLine($"{Name} takes {damage} damage. Remaining health: {Health}");
    }

    public bool IsAlive() => Health > 0;
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
public class Merchant : ICharacter, ISpeakable, ITradable
{
    public string Name { get; private set; }
    public List<string> Inventory => ItemPrices.Keys.ToList();
    private Dictionary<string, int> ItemPrices { get; set; }

    public Merchant(string name)
    {
        Name = name;
        ItemPrices = new Dictionary<string, int>
        {
            { "sword", 50 },
            { "shield", 40 },
            { "potion", 20 }
        };
    }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: Welcome! Take a look at what I have in stock.");
    }

    public void Trade(Player player)
    {
        Console.WriteLine($"{Name}'s inventory:");
        foreach (var item in ItemPrices)
        {
            Console.WriteLine($"- {item.Key}: {item.Value} coins");
        }

        bool shopping = true;
        while (shopping && ItemPrices.Count > 0)
        {
            Console.WriteLine($"\nYour current balance: {player.Currency} coins");
            Console.WriteLine("What would you like to buy? (Enter item name or type 'exit' to leave)");
            string choice = Console.ReadLine()?.Trim().ToLower();

            if (choice?.ToLower() == "exit")
            {
                shopping = false;
                Console.WriteLine("You leave the merchant.");
            }
            else if (ItemPrices.ContainsKey(choice))
            {
                int price = ItemPrices[choice];
                if (player.SpendCurrency(price))
                {
                    ItemPrices.Remove(choice);
                    Console.WriteLine($"You bought the {choice}. Remaining balance: {player.Currency} coins.");
                }
            }
            else
            {
                Console.WriteLine("Invalid item or insufficient funds. Please try again.");
            }
        }
        if (ItemPrices.Count == 0)
        {
            Console.WriteLine("The merchant has sold out all items.");
        }
    }
}