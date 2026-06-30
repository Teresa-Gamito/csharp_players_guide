namespace Players
{

public class HumanPlayer : Player
{
    public override int ChooseOption(int optionCount)
    {
        int option;
        Console.Write("Option: ");
        try
        {
            string input = Console.ReadLine()!;
            option = int.Parse(input);
            if (option < 0 || option >= optionCount)
            {
                Console.WriteLine("Invalid option.");
                return ChooseOption(optionCount);
            }
        }
        catch
        {
            Console.WriteLine("Invalid format.");
            return ChooseOption(optionCount);
        }
        return option;
    }
}

}
