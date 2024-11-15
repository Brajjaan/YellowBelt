namespace _Kata9;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

    public interface ICharacter
    {
        string Name { get; }
    }

    // Player Class
    public class Player : ICharacter
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
            if (enemy == null)
            {
                Console.WriteLine("No enemy to attack.");
                return;
            }

            Console.WriteLine($"{Name} attacks {enemy.Type} and deals {damage} damage.");
            enemy.TakeDamage(damage);
        }
    }

    // Enemy Class
    public class Enemy : ICharacter
    {
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

    // NPC Class
    public class NPC : ICharacter
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

    // Merchant Class
    public class Merchant : ICharacter
    {
        public string Name { get; private set; }
        public List<string> Inventory { get; private set; }

        public Merchant(string name, List<string> inventory)
        {
            Name = name;
            Inventory = inventory ?? new List<string>();
        }

        public void Trade()
        {
            Console.WriteLine($"{Name}'s inventory: {string.Join(", ", Inventory)}");
        }
    }

    // Main Program to Demonstrate Functionality
    class Program
    {
        static void Main(string[] args)
        {
            // Creating Player
            Player player = new Player("Arin", 100, 5);
            
            // Creating Enemy
            Enemy goblin = new Enemy("Goblin", 50, 10);

            // Player attacks Enemy
            player.Attack(goblin, 20);

            // Creating NPC
            NPC villager = new NPC("Villager", "Welcome to our village!");
            villager.Speak();

            // Creating Merchant with inventory
            Merchant blacksmith = new Merchant("Blacksmith", new List<string> { "Sword", "Shield", "Potion" });
            blacksmith.Trade();
        }
    }