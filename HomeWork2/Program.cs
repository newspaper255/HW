namespace HomeWork2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeArray;

            while (true)
            {
                Console.Write("Введите размер массива: ");
                try
                {
                    sizeArray = int.Parse(Console.ReadLine());
                    if (sizeArray < 2)
                    {
                        Console.WriteLine("Массив должен состоять минимум из двух элементов");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Размер массива не может быть отричательным");
                }

            }

            int[] array = new int[sizeArray];
            int minInt = -2147483648;
            int firstMaxVal = minInt;
            int secondMaxVal = minInt;

            while (true)
            {
                try
                {
                    for (int i = 0; i < sizeArray; i++)
                    {
                        Console.Write($"Введите элемент массива {i}: ");
                        array[i] = int.Parse(Console.ReadLine());
                        if (array[i] > firstMaxVal)
                        {
                            secondMaxVal = firstMaxVal;
                            firstMaxVal = array[i];
                        }
                        else if (array[i] > secondMaxVal)
                        {
                            secondMaxVal = array[i];
                        }
                    }
                    Console.WriteLine($"Второй наибольший элемент массива равен: {secondMaxVal}");
                    return;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Числа в массиве должны быть целыми");
                }
            }
        }
    }
}