using System;
using System.Text;
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
}
