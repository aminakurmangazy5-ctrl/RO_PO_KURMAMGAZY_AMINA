int[] numbers = { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
int result = 0;
foreach (int number in numbers)
{
    if (number > 0)
    {
        result++;
    }
}
Console.WriteLine($"Число элементов больше нуля: {result}");

int[] number2 = { -4, -3, -2, -1, 0, 1, 2, 3, 4 };

int n = number2.Length; // длина массива
int k = n / 2;          // середина массива
int temp;               // вспомогательный элемент для обмена значениями
for (int i = 0; i < k; i++)
{
    temp = number2[i];
    numbers[i] = numbers[n - i - 1];
    numbers[n - i - 1] = temp;
}
foreach (int i in number2)
{
    Console.Write($"{i} \t");
}
int[] nums = { 54, 7, -41, 2, 4, 2, 89, 33, -5, 12 };

// сортировка

for (int i = 0; i < nums.Length - 1; i++)
{
    for (int j = i + 1; j < nums.Length; j++)
    {
        if (nums[i] > nums[j])
        {
            temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}

// вывод
Console.WriteLine("Вывод отсортированного массива");
for (int i = 0; i < nums.Length; i++)
{
    Console.WriteLine(nums[i]);
}
for (int i = 0; i < nums.Length - 1; i++)
    for (int j = i + 1; j < nums.Length; j++)
        if (nums[i] > nums[j])
        {
            temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
