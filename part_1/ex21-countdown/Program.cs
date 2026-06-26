Countdown(10);

void Countdown(int value)
{
    if (value <= 0) return;
    Console.WriteLine(value);
    Countdown(value - 1);
}
