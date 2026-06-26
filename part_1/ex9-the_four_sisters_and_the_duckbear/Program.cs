int sistersCount = 4;

int eggCount;
Console.WriteLine("How many chocolate eggs?");
eggCount = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

int sisterEggs = eggCount / sistersCount;
Console.WriteLine("Each sister gets " + sisterEggs + " chocolate eggs");

int duckbearEggs = eggCount % sistersCount;
Console.WriteLine("The duckbear gets " + duckbearEggs + " chocolate eggs");

// A:
// 1, 2, 3
