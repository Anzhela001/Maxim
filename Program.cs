
using System;

class Program
{
    static void Main()
    {
        // Получаем строку от пользователя
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

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
    }

    // Метод для переворачивания строки
    static string ReverseString(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
