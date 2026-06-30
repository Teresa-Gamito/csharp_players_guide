RecentNumbers numbers = new RecentNumbers();

Thread thread = new Thread(numbers.GenerateNumbers);
thread.Start();

Thread playerThread = new Thread(numbers.Guess);
playerThread.Start();




public class RecentNumbers
{
    private Random _random = new Random();
    private Object _lock = new Object();

    private int _last;
    private int _lastLast;

    public int Last 
    {
        get { lock (_lock) return _last; }
        private set { lock (_lock) _last = value; }
    }
    public int LastLast
    { 
        get { lock (_lock) return _lastLast; }
        private set { lock (_lock) _lastLast = value; }
    }

    public RecentNumbers()
    {
        Last = _random.Next(10);
        LastLast = _random.Next(10);
    }

    public void Guess()
    {
        while (true)
        {
            Console.ReadKey();
            if (Last == LastLast)
            {
                Console.WriteLine("Correctly pointed out two repeating numbers!");
            }
            else
            {
                Console.WriteLine("The last two numbers were not the same.");
            }
        }
    }

    public void GenerateNumbers()
    {
        while (true)
        {
            LastLast = Last;
            Last = _random.Next(10);
            Console.WriteLine(Last);
            Thread.Sleep(1000);
        }
    }
}
