string input;
int code;

Console.Write("Provide a passcode: ");
input = Console.ReadLine()!;
code = Convert.ToInt32(input);

Door door = new Door(code);

while (true)
{
    Console.WriteLine($"Door is {door.State}");
    input = Console.ReadLine()!;
    switch (input)
    {
        case "Close":
        case "close":
            door.Close();
            break;
        case "Open":
        case "open":
            door.Open();
            break;
        case "Lock":
        case "lock":
            door.Lock();
            break;
        case "Unlock":
        case "unlock":
            Console.Write("Code to unlock: ");
            input = Console.ReadLine()!;
            code = Convert.ToInt32(input);
            door.Unlock(code);
            break;
        case "change code":
            Console.Write("Current code: ");
            input = Console.ReadLine()!;
            int currentCode = Convert.ToInt32(input);

            Console.Write("New code: ");
            input = Console.ReadLine()!;
            int newCode = Convert.ToInt32(input);

            door.ChangeCode(currentCode, newCode);
            break;
    }
}

public class Door
{
    public State State { get; private set; }= State.Closed;
    private int _code;

    public Door(int code)
    {
        _code = code;
    }

    public void Open()
    {
        if (State == State.Opened)
        {
            Console.WriteLine("Door is already opened.");
            return;
        }
        if (State != State.Closed)
        {
            Console.WriteLine("Could not open door.");
            return;
        }
        State = State.Opened;
        Console.WriteLine("Opened door.");
    }

    public void Close()
    {
        if (State == State.Closed)
        {
            Console.WriteLine("Door is already closed.");
            return;
        }
        if (State != State.Opened)
        {
            Console.WriteLine("Could not close door.");
            return;
        }
        State = State.Closed;
        Console.WriteLine("Closed door.");
    }

    public void Lock()
    {
        if (State == State.Locked)
        {
            Console.WriteLine("Door is already locked.");
            return;
        }
        if (State != State.Closed)
        {
            Console.WriteLine("Could not lock door.");
            return;
        }
        State = State.Locked;
        Console.WriteLine("Locked door.");
    }

    public void Unlock(int code)
    {
        if (State == State.Closed)
        {
            Console.WriteLine("Door is already unlocked.");
            return;
        }
        if (_code != code)
        {
            Console.WriteLine("Provided passcode is incorrect, couldn't unlock");
        }
        if (State != State.Locked)
        {
            Console.WriteLine("Could not unlock door.");
            return;
        }
        State = State.Closed;
        Console.WriteLine("Unlocked door.");
    }

    public void ChangeCode(int currentCode, int newCode)
    {
        if (_code != currentCode)
        {
            Console.WriteLine("The provided current passcode is not correct, couldn't change the passcode.");
            return;
        }
        _code = newCode;
        Console.WriteLine("Passcode changed!");
    }

}

public enum State
{
    Opened,
    Closed,
    Locked
}
