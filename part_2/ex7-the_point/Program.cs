Point point1 = new Point(2, 3);
Point point2 = new Point(-4, 0);

point1.Print();
point2.Print();

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point()
    {
        X = 0;
        Y = 0;
    }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Print()
    {
        Console.WriteLine($"({X}, {Y})");
    }
}
