using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Получаем строку от пользователя
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        // Проверка на наличие неподходящих символов
        var invalidChars = input.Where(c => !IsValidCharacter(c)).Distinct().ToArray();

        if (invalidChars.Length > 0)
        {
            // Если найдены неподходящие символы, выводим сообщение об ошибке
            Console.WriteLine("Ошибка: строка содержит неподходящие символы: " + string.Join(", ", invalidChars));
            return;
        }

        string result;

        // Проверка на чётность длины строки
        if (input.Length % 2 == 0)
        {
            // Если строка чётной длины
            int middle = input.Length / 2;

            // Разделяем строку на две подстроки
            string firstPart = input.Substring(0, middle);
            string secondPart = input.Substring(middle);

            // Переворачиваем каждую подстроку
            firstPart = ReverseString(firstPart);
            secondPart = ReverseString(secondPart);

            // Объединяем их обратно
            result = firstPart + secondPart;
        }
        else
        {
            // Если строка нечётной длины
            string reversedInput = ReverseString(input);

            // Объединяем перевёрнутую строку с исходной
            result = reversedInput + input;
        }

        // Выводим результат
        Console.WriteLine("Обработанная строка: " + result);

        // Выводим информацию о повторениях символов
        var characterCounts = CountCharacterOccurrences(result);
        Console.WriteLine("Количество повторений каждого символа:");
        foreach (var entry in characterCounts)
        {
            Console.WriteLine($"'{entry.Key}': {entry.Value}");
        }

        // Находим самую длинную подстроку, которая начинается и заканчивается на гласную
        string longestSubstring = FindLongestVowelSubstring(result);
        Console.WriteLine("Самая длинная подстрока, начинающаяся и заканчивающаяся на гласную: " +
                          (longestSubstring.Length > 0 ? longestSubstring : "не найдена"));

        // Сортировка строки
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
        }
    }

    // Метод для переворачивания строки
    static string ReverseString(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    // Метод для проверки допустимости символа
    static bool IsValidCharacter(char c)
    {
        return c >= 'a' && c <= 'z'; // Проверка, что символ - это буква от 'a' до 'z'
    }

    // Метод для подсчёта количества повторений каждого символа
    static Dictionary<char, int> CountCharacterOccurrences(string str)
    {
        var characterCounts = new Dictionary<char, int>();
        foreach (char c in str)
        {
            if (characterCounts.ContainsKey(c))
            {
                characterCounts[c]++;
            }
            else
            {
                characterCounts[c] = 1;
            }
        }
        return characterCounts;
    }

    // Метод для поиска самой длинной подстроки, начинающейся и заканчивающейся на гласную
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

    // Реализация быстрой сортировки
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

    // Реализация сортировки деревом
    static string TreeSort(string str)
    {
        SortedSet<char> sortedSet = new SortedSet<char>(str);
        return new string(sortedSet.ToArray());
    }
}
