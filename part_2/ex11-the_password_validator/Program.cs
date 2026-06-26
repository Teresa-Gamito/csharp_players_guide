while (true)
{
    Console.Write("Provide a password: ");
    string password = Console.ReadLine()!;
    if (PasswordValidator.IsValid(password))
    {
        Console.WriteLine("That password is valid!");
    }
    else
    {
        Console.WriteLine("That password is not valid!");
    }
}

public static class PasswordValidator
{
    public static bool IsValid(string password)
    {
        if (password.Length < 6) return false;
        if (password.Length > 13) return false;

        bool hasUpper = false;
        bool hasLower = false;
        bool hasDigit = false;
        foreach (char letter in password)
        {
            if (letter == 'T') return false;
            if (letter == '&') return false;
            if (char.IsUpper(letter)) hasUpper = true;
            if (char.IsLower(letter)) hasLower = true;
            if (char.IsDigit(letter)) hasDigit = true;
            if (hasUpper && hasLower && hasDigit) return true;
        }

        return false;
    }
}
