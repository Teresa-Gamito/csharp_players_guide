Color black = new Color(0, 0, 0);
Color purple = Color.Purple;

black.Print();
purple.Print();


public class Color
{
    private byte R { get; set; }
    private byte G { get; set; }
    private byte B { get; set; }

    public static Color White => new Color(255, 255, 255);
    public static Color Black => new Color(0, 0, 0);
    public static Color Red => new Color(255, 0, 0);
    public static Color Orange => new Color(255, 165, 0);
    public static Color Yellow => new Color(255, 255, 0);
    public static Color Green => new Color(0, 128, 0);
    public static Color Blue => new Color(0, 0, 255);
    public static Color Purple => new Color(128, 0, 128);

    public Color(byte red, byte green, byte blue)
    {
        R = red;
        G = green;
        B = blue;
    }

    public void Print()
    {
        Console.WriteLine($"r: {R} g: {G} b: {B}");
    }
}
