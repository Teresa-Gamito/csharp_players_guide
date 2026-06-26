int points = 0;

int estatePoints = 1;
int estateCount;
Console.WriteLine("How many estates?");
estateCount = Convert.ToInt32(Console.ReadLine());
points += estatePoints + estateCount;

int duchyPoints = 3;
int duchyCount;
Console.WriteLine("How many duchies?");
duchyCount = Convert.ToInt32(Console.ReadLine());
points += duchyPoints + duchyCount;

int provincePoints = 6;
int provinceCount;
Console.WriteLine("How many provinces?");
provinceCount = Convert.ToInt32(Console.ReadLine());
points += provincePoints + provinceCount;

Console.WriteLine();

Console.WriteLine("Points: " + points);
