string input;

int lenght = 5;
int[] arr = new int[lenght];

Console.WriteLine("Provide " + lenght + " numbers");

// initialize arr
for (int i = 0; i < arr.Length; i++)
{
    Console.Write($"Index {i + 1}: ");
    input = Console.ReadLine();
    arr[i] = Convert.ToInt32(input);
}

int[] arrCopy = new int[arr.Length];

// copy arr to arrCopy
for (int i = 0; i < arr.Length; i++)
{
    arrCopy[i] = arr[i];
}

// display arr contents
Console.WriteLine("User input:");
Console.Write("{ ");
for (int i = 0; i < arr.Length; i++)
{
    Console.Write(arr[i] + " ");
}
Console.WriteLine("}");

// display arrCopy contents
Console.WriteLine("Replicator of D'To:");
Console.Write("{ ");
for (int i = 0; i < arrCopy.Length; i++)
{
    Console.Write(arrCopy[i] + " ");
}
Console.WriteLine("}");
