using Entities.Characters;
using Entities;

public static class Display
{
    public static void Battle(Battle battle)
    {
        int length = 200;

        Console.WriteLine();
        Spacer("Battle", '=', length);
        Party(battle, battle.Parties[0], Alignment.Left);
        Spacer("VS", '-', length);
        Party(battle, battle.Parties[1], Alignment.Right);
        Spacer("", '=', length);
    }

    public static void Spacer(string title, char filler, int length)
    {
        string text = title == "" ? title : $" {title} ";
        string fillerText = new string(filler, (length - text.Length) / 2);
        Console.WriteLine(fillerText + text + fillerText);
    }

    public static void WriteRightAlligned(string text, int length)
    {
        string fillerText = new string(' ', length - text.Length);
        Console.WriteLine(fillerText + text);
    }

    public static void Party(Battle battle, Party party, Alignment alignment)
    {
        foreach (Character member in party.Members)
        {
            if (member == battle.ActiveCharacter)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            string output = $"{member.Name} - ({member.HP, 3}/{member.MaxHP, -3})";
            if (alignment == Alignment.Left) Console.WriteLine(output);
            else if (alignment == Alignment.Right) WriteRightAlligned(output, 200);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }

    public enum Alignment { Left, Right, Center }
}
