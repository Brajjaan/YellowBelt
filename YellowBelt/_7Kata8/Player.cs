namespace _7Kata8;

public class Player
{
    private int Health {get; set;}
    private int Experience { get; set; }
    private int Level { get; set; }
    private string Name { get; set; }

    public Player(string name, int health)
    {
        Name = name;
        Health = health;
        Level = 1;
        Experience = 0;
    }
    
    public int Attack(int damage)
    {
        Console.WriteLine($"{Name} attacks and deals {damage} damage!");
        return damage;
    }

    private void LevelUp()
    {
        Level++;
        Experience = 0;
        Console.WriteLine($"{Name} level up! \n" +
                          $"Level: {Level}. Experience: {Experience}");
    }
    public void GainExperience(int exp)
    {
        Experience += exp;

        Console.WriteLine($"{Name} gained {exp} experience!");
        if (Experience >= 100) 
            LevelUp();
    }
}