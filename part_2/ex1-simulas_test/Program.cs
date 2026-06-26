State chestState = State.Locked;

while (true)
{
    string chestStateName = stateGetName(chestState);
    Console.Write($"The chest is {chestStateName}. What do you want to do? ");

    string input = Console.ReadLine();
    chestSetState(input);
}

string stateGetName(State state)
{
    return state switch
    {
        State.Open => "open",
        State.Closed => "closed",
        State.Locked => "locked",
        _ => "invalid"
    };
}

void chestSetState(string input)
{
    if (chestState == State.Locked)
    {
        if (input == "unlock") chestState = State.Closed;
    }
    else if (chestState == State.Open)
    {
        if (input == "close") chestState = State.Closed;
    }
    else if (chestState == State.Closed)
    {
        if (input == "open") chestState = State.Open;
        if (input == "lock") chestState = State.Locked;
    }
}

enum State
{
    Open,
    Closed,
    Locked
};
