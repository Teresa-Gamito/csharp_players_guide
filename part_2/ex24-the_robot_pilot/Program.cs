int round = 1;

int consolasHealthMax = 15;
int consolasHealth = consolasHealthMax;

int manticoreDamage = 1;
int manticoreHealthMax = 10;
int manticoreHealth = manticoreHealthMax;
int manticoreDistance;

Console.Clear();

// robot
Random random = new Random();
manticoreDistance = random.Next(0, 100 + 1);

Console.Clear();

// player 1
while (true)
{
    printSpacing();
    printStatus();
    printCannonExpectedDamage();
    int tryDistance = playerGetCannonDistance();
    cannonShoot(tryDistance);

    if (manticoreHealth >= 0)
    {
        consolasHealth -= manticoreDamage;
    }
    else
    {
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
        break;
    }

    if (consolasHealth <= 0)
    {
        Console.WriteLine("The city of Consolas has been destoyed!");
        break;
    }

    round++;
}

int getIntInput()
{
    string input = Console.ReadLine();
    return Convert.ToInt32(input);
}

int playerGetManticoreDistance()
{
    int distance;
    do
    {
        Console.Write("Player 1, how far away from the city do you want to station the Manticore? ");
        distance = getIntInput();
    } while (distance < 0 || distance > 100);
    return distance;
}

int playerGetCannonDistance()
{
    Console.Write("Enter desired cannon range: ");
    return getIntInput();
}

int cannonGetDamage(int round)
{
    if (round % 3 == 0) return 3;
    else if (round % 5 == 0) return 3;
    else if (round % 3 == 0 && round % 5 == 0) return 10;
    else return 1;
}

void cannonShoot(int shotDistance)
{
    if (shotDistance < manticoreDistance)
    {
        Console.WriteLine("That round FELL SHORT of the target.");
    }
    else if (shotDistance > manticoreDistance)
    {
        Console.WriteLine("That round OVERSHOOT the target.");
    }
    else
    {
        Console.WriteLine("That round was a DIRECT HIT!");
        manticoreHealth -= cannonGetDamage(round);
    }
}

void printStatus()
{
    Console.Write("STATUS: ");
    Console.Write($"Round: {round}");
    Console.Write("  ");
    Console.Write($"City: {consolasHealth}/{consolasHealthMax}");
    Console.Write("  ");
    Console.Write($"Manticore: {manticoreHealth}/{manticoreHealthMax}");
    Console.Write("\n");
}

void printSpacing()
{
    Console.WriteLine("--------------------------------------------------");
}

void printCannonExpectedDamage()
{
    int cannonDamage = cannonGetDamage(round);
    Console.WriteLine($"The cannon is expected to deal {cannonDamage} damage this round.");
}
