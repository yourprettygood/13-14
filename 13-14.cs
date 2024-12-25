using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_14
{
    internal class Program
    {
        static void zadacha1()//Задание №1. Нахождение максимума и минимума:
                              //9.	Дан двумерный массив.Определить координаты минимального элемента массива.
                              //Если элементов с минимальным значением несколько,
                              //то должны быть найдены координаты самого нижнего и самого правого из них.
        {
            // Инициализация двумерного массива
            int[,] array = new int[5, 6];
            Random rand = new Random();

            // Заполнение массива случайными числами и вывод на экран
            Console.WriteLine("Двумерный массив:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(1, 21); // значения от 1 до 20
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Инициализация переменных для поиска минимума
            int minValue = array[0, 0];
            int minRow = 0;
            int minCol = 0;

            // Инициализация переменных для поиска максимума
            int maxValue = array[0, 0];
            int maxRow = 0;
            int maxCol = 0;

            // Поиск минимального и максимального элементов
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    // Если найден новый минимум или минимум с предпочтением самого нижнего и правого
                    if (array[i, j] < minValue ||
                       (array[i, j] == minValue && (i > minRow || (i == minRow && j > minCol))))
                    {
                        minValue = array[i, j];
                        minRow = i;
                        minCol = j;
                    }

                    // Если найден новый максимум или максимум с предпочтением самого верхнего и левого
                    if (array[i, j] > maxValue ||
                       (array[i, j] == maxValue && (i < maxRow || (i == maxRow && j < maxCol))))
                    {
                        maxValue = array[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            // Вывод результатов
            Console.WriteLine($"\nМинимальное значение: {minValue}");
            Console.WriteLine($"Координаты минимума (строка, столбец): ({minRow + 1}, {minCol + 1})");

            Console.WriteLine($"\nМаксимальное значение: {maxValue}");
            Console.WriteLine($"Координаты максимума (строка, столбец): ({maxRow + 1}, {maxCol + 1})");
        }

        static void zadacha2()//Задание №2. Решить задачу на проверку условий после выполнения расчетов:
                              //9.	Дан двумерный массив целых чисел.Составить программу, определяющую,
                              //верно ли что сумма элементов строки массива с известным номером оканчивается цифрой 0.
        {
            // Инициализация двумерного массива
            int[,] array = new int[5, 6];
            Random rand = new Random();

            // Заполнение массива случайными числами и вывод на экран
            Console.WriteLine("Двумерный массив:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(-20, 21); // значения от -20 до 20
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Запрос номера строки у пользователя
            Console.Write("\nВведите номер строки для проверки (от 1 до 5): ");
            int rowNumber = int.Parse(Console.ReadLine());

            if (rowNumber < 1 || rowNumber > array.GetLength(0))
            {
                Console.WriteLine("Неверный номер строки. Попробуйте снова.");
                return;
            }

            // Вычисление суммы элементов выбранной строки
            int rowIndex = rowNumber - 1; // Преобразование к индексации с 0
            int sum = 0;

            for (int j = 0; j < array.GetLength(1); j++)
            {
                sum += array[rowIndex, j];
            }

            // Проверка, оканчивается ли сумма на цифру 0
            Console.WriteLine($"\nСумма элементов строки №{rowNumber}: {sum}");
            if (sum % 10 == 0)
            {
                Console.WriteLine("Сумма оканчивается на цифру 0.");
            }
            else
            {
                Console.WriteLine("Сумма НЕ оканчивается на цифру 0.");
            }
        }

        static void zadacha3()
        {
            //Задание №3.Решить задачу по изменению исходного массива:
            //9.	В каждой строке двумерного массива поменять местами первый элемент и любой из максимальных.

            // Размеры массива
            int rows = 5;
            int cols = 6;
            int[,] array = new int[rows, cols];

            // Диапазон уникальных чисел
            int minValue = 1;
            int maxValue = rows * cols + minValue - 1;

            // Генерация уникальных чисел
            List<int> uniqueNumbers = new List<int>();
            for (int i = minValue; i <= maxValue; i++)
            {
                uniqueNumbers.Add(i);
            }

            // Перемешивание уникальных чисел
            Random rand = new Random();
            for (int i = 0; i < uniqueNumbers.Count; i++)
            {
                int randomIndex = rand.Next(i, uniqueNumbers.Count);
                (uniqueNumbers[i], uniqueNumbers[randomIndex]) = (uniqueNumbers[randomIndex], uniqueNumbers[i]);
            }

            // Заполнение массива уникальными числами
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = uniqueNumbers[index++];
                }
            }

            // Вывод исходного массива
            Console.WriteLine("Исходный двумерный массив:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Замена первого элемента с максимальным в каждой строке
            for (int i = 0; i < rows; i++)
            {
                int maxIndex = 0; // Индекс максимального элемента

                // Поиск индекса максимального элемента в строке
                for (int j = 1; j < cols; j++)
                {
                    if (array[i, j] > array[i, maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                // Обмен первого элемента и максимального элемента
                int temp = array[i, 0];
                array[i, 0] = array[i, maxIndex];
                array[i, maxIndex] = temp;
            }

            // Вывод измененного массива
            Console.WriteLine("\nИзмененный двумерный массив:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void zadacha4()//Задание №4. Работа с несколькими массивами:
        {
            Console.Write("Введите количество строк массива: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов массива: ");
            int cols = int.Parse(Console.ReadLine());

            // Проверяем, чтобы массив был квадратным
            if (rows != cols)
            {
                Console.WriteLine("Массив должен быть квадратным (количество строк = количество столбцов).");
                return;
            }

            // Создаем и заполняем двумерный массив случайными числами
            int[,] matrix = new int[rows, cols];
            Random rand = new Random();

            Console.WriteLine("\nСформированный массив:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.Next(1, 101); // Заполняем числами от 1 до 100
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Подсчет элементов над главной диагональю
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = i + 1; j < cols; j++)
                {
                    count++;
                }
            }

            // Создаем одномерный массив для хранения элементов
            int[] result = new int[count];
            int index = 0;

            // Сохраняем элементы над главной диагональю
            for (int i = 0; i < rows; i++)
            {
                for (int j = i + 1; j < cols; j++)
                {
                    result[index++] = matrix[i, j];
                }
            }

            // Вывод результата
            Console.WriteLine("\nОдномерный массив элементов над главной диагональю:");
            Console.WriteLine(string.Join(", ", result));

        }


        static void Main(string[] args)
        {
            Console.Write("Введите номер задачи: ");
            byte numb = byte.Parse(Console.ReadLine());
            switch (numb)
            {
                case 1:
                    zadacha1();
                    break;


                    case 2:
                    zadacha2();
                    break;


                case 3:
                    zadacha3();
                    break;


                case 4:
                    zadacha4();
                    break;

            }
        }
    }
}
