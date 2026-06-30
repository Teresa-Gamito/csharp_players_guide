int intValue;
while(!int.TryParse(Console.ReadLine(), out intValue));
Console.WriteLine($"int typed: {intValue}");

double doubleValue;
while(!double.TryParse(Console.ReadLine(), out doubleValue));
Console.WriteLine($"double typed: {doubleValue}");

bool boolValue;
while(!bool.TryParse(Console.ReadLine(), out boolValue));
Console.WriteLine($"bool typed: {boolValue}");

