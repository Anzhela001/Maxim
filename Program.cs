using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Получаем строку от пользователя
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        // Проверка на наличие неподходящих символов
        var invalidChars = input.Where(c => !IsValidCharacter(c)).Distinct().ToArray();

        if (invalidChars.Length > 0)
        {
            Console.WriteLine("Ошибка: строка содержит неподходящие символы: " + string.Join(", ", invalidChars));
            return;
        }

        string result;

        // Проверка на чётность длины строки
        if (input.Length % 2 == 0)
        {
            int middle = input.Length / 2;
            string firstPart = ReverseString(input.Substring(0, middle));
            string secondPart = ReverseString(input.Substring(middle));
            result = firstPart + secondPart;
        }
        else
        {
            string reversedInput = ReverseString(input);
            result = reversedInput + input;
        }

        Console.WriteLine("Обработанная строка: " + result);

        var characterCounts = CountCharacterOccurrences(result);
        Console.WriteLine("Количество повторений каждого символа:");
        foreach (var entry in characterCounts)
        {
            Console.WriteLine($"'{entry.Key}': {entry.Value}");
        }

        string longestSubstring = FindLongestVowelSubstring(result);
        Console.WriteLine("Самая длинная подстрока, начинающаяся и заканчивающаяся на гласную: " +
                          (longestSubstring.Length > 0 ? longestSubstring : "не найдена"));

        Console.WriteLine("Выберите метод сортировки: 1 - Быстрая сортировка, 2 - Сортировка деревом");
        int choice = int.Parse(Console.ReadLine());
        string sortedResult;

        if (choice == 1)
        {
            sortedResult = Quicksort(result);
            Console.WriteLine("Отсортированная строка (Быстрая сортировка): " + sortedResult);
        }
        else if (choice == 2)
        {
            sortedResult = TreeSort(result);
            Console.WriteLine("Отсортированная строка (Сортировка деревом): " + sortedResult);
        }
        else
        {
            Console.WriteLine("Неверный выбор метода сортировки.");
            return;
        }

        // Генерация случайного числа
        int randomIndex;
        try
        {
            randomIndex = await GetRandomNumberAsync(sortedResult.Length);
        }
        catch
        {
            randomIndex = new Random().Next(0, sortedResult.Length);
            Console.WriteLine($"Ошибка при обращении к API. Случайное число сгенерировано локально: {randomIndex}");
        }

        // Удаляем символ на позиции randomIndex
        string reducedResult = RemoveCharacterAt(sortedResult, randomIndex);
        Console.WriteLine($"«Урезанная» строка (удалён символ на позиции {randomIndex}): {reducedResult}");
    }

    // Получение случайного числа через API
    static async Task<int> GetRandomNumberAsync(int max)
    {
        using HttpClient client = new HttpClient();
        string url = $"https://www.randomnumberapi.com/api/v1.0/random?min=0&max={max - 1}";
        string response = await client.GetStringAsync(url);
        return int.Parse(response.Trim('[', ']'));
    }

    // Удаление символа на заданной позиции
    static string RemoveCharacterAt(string str, int index)
    {
        if (index < 0 || index >= str.Length)
            throw new ArgumentOutOfRangeException(nameof(index), "Индекс вне допустимого диапазона.");
        return str.Remove(index, 1);
    }

    static string ReverseString(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    static bool IsValidCharacter(char c)
    {
        return c >= 'a' && c <= 'z';
    }

    static Dictionary<char, int> CountCharacterOccurrences(string str)
    {
        var characterCounts = new Dictionary<char, int>();
        foreach (char c in str)
        {
            if (characterCounts.ContainsKey(c))
                characterCounts[c]++;
            else
                characterCounts[c] = 1;
        }
        return characterCounts;
    }

    static string FindLongestVowelSubstring(string str)
    {
        HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'y' };
        int maxLength = 0;
        string longestSubstring = "";

        for (int i = 0; i < str.Length; i++)
        {
            if (vowels.Contains(str[i]))
            {
                for (int j = str.Length - 1; j > i; j--)
                {
                    if (vowels.Contains(str[j]))
                    {
                        int length = j - i + 1;
                        if (length > maxLength)
                        {
                            maxLength = length;
                            longestSubstring = str.Substring(i, length);
                        }
                        break;
                    }
                }
            }
        }

        return longestSubstring;
    }

    static string Quicksort(string str)
    {
        if (str.Length <= 1)
            return str;

        char pivot = str[str.Length / 2];
        var less = str.Where(x => x < pivot).ToArray();
        var equal = str.Where(x => x == pivot).ToArray();
        var greater = str.Where(x => x > pivot).ToArray();

        return new string(Quicksort(new string(less)) + new string(equal) + Quicksort(new string(greater)));
    }

    static string TreeSort(string str)
    {
        SortedSet<char> sortedSet = new SortedSet<char>(str);
        return new string(sortedSet.ToArray());
    }
}

