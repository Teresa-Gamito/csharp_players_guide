Console.WriteLine("Triangle area calculator");
Console.WriteLine();

double triangleBase;
Console.WriteLine("Base:");
triangleBase = Convert.ToDouble(Console.ReadLine());

double triangleHeight;
Console.WriteLine("Height:");
triangleHeight = Convert.ToDouble(Console.ReadLine());

Console.WriteLine();
Console.WriteLine("Base: " + triangleBase + " | Height: " + triangleHeight);

double triangleArea = (triangleBase * triangleHeight) / 2;
Console.WriteLine("Area: " + triangleArea);
