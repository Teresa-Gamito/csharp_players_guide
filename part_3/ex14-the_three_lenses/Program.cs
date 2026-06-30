int[] array = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };

Console.WriteLine("Original array: " + ArrayToString(array) + "\n");

Console.WriteLine("Procedural code: " + ArrayToString(FilterProcedural(array).ToArray()));
Console.WriteLine("Keyword query expression: " + ArrayToString(FilterQueryKeyword(array).ToArray()));
Console.WriteLine("Method query expression: " + ArrayToString(FilterQueryMethod(array).ToArray()));


IEnumerable<int> FilterProcedural(int[] array)
{
    List<int> filteredArray = new List<int>();

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] % 2 != 0) continue;
        filteredArray.Add(array[i] * 2);
    }
    filteredArray.Sort();

    return filteredArray;
}

IEnumerable<int> FilterQueryKeyword(int[] array)
{
    IEnumerable<int> filteredArray = 
        from a in array
        where a % 2 == 0
        orderby a
        select a * 2;

    return filteredArray;
}

IEnumerable<int> FilterQueryMethod(int[] array)
{
    IEnumerable<int> filteredArray = array
        .Where(a => a % 2 == 0)
        .OrderBy(a => a)
        .Select(a => a * 2);

    return filteredArray;
}

string ArrayToString(int[] array)
{
    string s = "[ ";
    foreach (int i in array) s += i + " ";
    s += "]";
    return s;
}
