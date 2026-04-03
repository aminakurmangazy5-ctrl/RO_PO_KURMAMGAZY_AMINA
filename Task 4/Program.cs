Console.WriteLine("Task 1");
int sum = 0;
int[] numbers = { 3, 7, 2, 9, 5, 1 };
foreach (int number in numbers)
{
    sum += number;
}
Console.WriteLine(sum);

Console.WriteLine("Task 2");
int[] temps = { 12, -3, 45, 0, 28, -10, 33 };
Array.Sort(temps);
int max = temps[temps.Length - 1];
int min = temps[0];
Console.WriteLine("min = " + min + "max = " + max);

Console.WriteLine("Task 4");
int[] data = { 4, 7, 2, 11, 6, 9, 14, 3, 8 };
int even = 0;
int odd = 0;
for (int i = 0; i < data.Length; i++)
{
    if (data[i] % 2 == 0)
    {
        even++;
    }
    else
    {
        odd++;
    }
}

Console.WriteLine("Even = " + even + ", Odd = " + odd);

Console.WriteLine("task 7");
Console.WriteLine(IsPalindrome("madam"));   
Console.WriteLine(IsPalindrome("hello"));   
Console.WriteLine(IsPalindrome("racecar"));
static bool IsPalindrome(string s)
{
    for (int i = 0; i < s.Length / 2; i++)
    {
        if (s[i] != s[s.Length - 1 - i])
        {
            return false;
        }
    }
    return true;
}

Console.WriteLine("Task 8");
Console.WriteLine(Factorial(5)); 
Console.WriteLine(Factorial(7)); 
Console.WriteLine(Factorial(0)); 
    static long Factorial(int n)
{
    long result = 1;

    for (int i = 2; i <= n; i++)
    {
        result *= i;
    }

    return result;
}

Console.WriteLine("Task 3");
string[] words = { "apple", "banana", "cherry", "date" };
Array.Reverse(words);
for (int i = 0; i < words.Length / 2; i++)
{
    {
        string temp = words[i];
        words[i] = words[words.Length - 1 - i];
        words[words.Length - 1 - i] = temp;
    }

    foreach (var word in words)
    {
        Console.Write(word + " ");
    }
}
Console.WriteLine("Task 3");
string[] slova = { "apple", "banana", "cherry", "date" };
Array.Reverse(slova);

foreach (var slova in slova)
{
    Console.Write(slova + " ");
}
   
