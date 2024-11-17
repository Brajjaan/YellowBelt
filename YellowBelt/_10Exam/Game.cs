namespace _10Exam;

public class Game
{
    private Player _player;
    private Random _random = new();

    public Game()
    {
        SetupGame();
    }

    private void SetupGame()
    {
        Console.Write("Enter your name: ");
        string playerName = Console.ReadLine();
        _player = new Player(playerName);
        Console.WriteLine($"{_player.Name} says: Ready for battle!");
    }

    public void Start()
    {
        while (_player.IsAlive())
        {
            RandomEncounter();

            if (!_player.IsAlive())
            {
                Console.WriteLine("Game Over!");
                break;
            }
            Console.WriteLine("\nDo you want to continue? (y/n)");
            string continueChoice = Console.ReadLine()?.ToLower();

            if (continueChoice != "y")
            {
                Console.WriteLine("Thanks for playing!");
                break;
            }
        }
    }

    private void RandomEncounter()
    {
        int encounterType = _random.Next(1, 4);

        switch (encounterType)
        {
            case 1:
                EnemyEncounter();
                break;
            case 2:
                NPCEncounter();
                break;
            case 3:
                MerchantEncounter();
                break;
        }
    }

    private void EnemyEncounter()
    {
        Enemy enemy = new("Goblin", 30, 5);
        Console.WriteLine($"\nA wild {enemy.Name} appears with {enemy.Health} health and {enemy.Damage} damage!");

        while (enemy.IsAlive() && _player.IsAlive())
        {
            Console.WriteLine("\nChoose an action:\n1. Attack\n2. Heal");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                _player.Attack(enemy);
            }
            else if (choice == "2")
            {
                _player.Heal();
            }
            else
            {
                Console.WriteLine("Invalid choice, try again.");
                continue;
            }
            if (enemy.IsAlive())
            {
                enemy.Attack(_player);
            }
        }

        if (!enemy.IsAlive())
        {
            Console.WriteLine($"{enemy.Name} is defeated!");
            _player.GainExperience(30);
        }
    }

    private void NPCEncounter()
    {
        NPC villager = new("Villager", "Welcome to our village!");
        Console.WriteLine();
        villager.Speak();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void MerchantEncounter()
    {
        var merchant = new Merchant("Blacksmith");
        Console.WriteLine($"\nYou meet {merchant.Name}.");
        merchant.Speak();
        merchant.Trade(_player);
    }
}
