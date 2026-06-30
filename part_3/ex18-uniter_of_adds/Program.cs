Console.WriteLine("int: " + Add(12, 34));
Console.WriteLine("double: " + Add(1.2, 3.4));
Console.WriteLine("string: " + Add("12", "34"));
Console.WriteLine("DateTime: " + Add(new DateTime(1, 2, 3), new TimeSpan(4, 5, 6)));

static dynamic Add(dynamic a, dynamic b) => a + b;
