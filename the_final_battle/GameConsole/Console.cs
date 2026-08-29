namespace FinalBattle.GameConsole;

using System.Text;
using FinalBattle.Battle;
using FinalBattle.Parties;
using FinalBattle.Characters;
using FinalBattle.Items;
using FinalBattle.Gear;

public static class GameConsole
{
    private static int _width = 80;

    public static void DisplayBattleStatus(Battle battle, Character activeCharacter)
    {

        PrintSpacing(" BATTLE ", '=');
        PrintParty(battle.Heroes, activeCharacter, 0);
        PrintSpacing(" VS ", '-');
        PrintParty(battle.Monsters, activeCharacter, _width / 2);
        PrintSpacing("", '=');
        Console.WriteLine();
    }

    private static void PrintSpacing(string title, char character)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(character, (_width - title.Length) / 2);
        builder.Append($"{title}");
        builder.Append(character, (_width - title.Length) / 2);

        Console.WriteLine(builder.ToString());
    }

    private static void PrintParty(Party party, Character activeCharacter, int spacing)
    {
        ConsoleColor defaultColor = Console.ForegroundColor;

        foreach (Character character in party.Characters)
        {
            ConsoleColor color = ConsoleColor.Yellow;
            StringBuilder builder = new StringBuilder();

            string name = character.ToString();
            string hp = $"( {character.HP}/{character.MaxHP} )";
            string gear = character.HasGear ? $" ({character.Gear})" : "";

            builder.Append(' ', spacing);
            builder.Append(name);
            builder.Append(gear);
            builder.Append(' ', _width / 2 - name.Length - hp.Length - gear.Length);
            builder.Append(hp);
            if (character == activeCharacter)
            {
                Console.ForegroundColor = color;
            }
            Console.WriteLine(builder.ToString(), color);
            Console.ForegroundColor = defaultColor;
        }
    }

    public static void DisplayOptions<T>(List<T> list)
    {
        int i = 1;
        foreach (T item in list)
        {
            Console.WriteLine($"{i} - {item}");
            i++;
        }
    }

    public static T ChooseOption<T>(string prompt, List<T> list)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        int option = Convert.ToInt32(input);
        if (option == 0 || option > list.Count)
        {
            return ChooseOption(prompt, list);
        }
        Console.WriteLine();
        return list[option - 1];
    }

    public static void DisplayList<T>(List<T> list)
    {
        Console.Write("( ");
        foreach (T item in list)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine(")");
    }
}
