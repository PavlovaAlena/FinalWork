// Итоговая задача. Напишите программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых меньше, либо равна 3 символам.
//***********************
bool InputDannyh(string text, int size, out string[] array)
{
    Console.Write($"{text} через пробел: ");
    array = Console.ReadLine().Split(' ', size, StringSplitOptions.RemoveEmptyEntries).ToArray();
    if (array.Length < size)
    {
        Console.WriteLine(
            $"Вводимые данные должны состоять из {size} строковых элементов, разделенных пробелом!!!"
        );
        Console.Write("Хотите повторно ввести данные? (y - да): ");
        string otvet = Console.ReadLine();
        if (otvet == "y" || otvet == "Y")
        {
            return InputDannyh(text, size, out array);
        }
        return false;
    }
    return true;
}

//***********************
bool InputSize(out int size)
{
    size = 0;
    Console.Write("Введите размерность массива: ");
    if (int.TryParse(Console.ReadLine(), out int itemp))
    {
        size = Convert.ToInt32(itemp);
        return true;
    }
    else
    {
        Console.WriteLine("Элемент должен быть числовой!");
        Console.Write("Хотите повторно ввести данные? (y - да): ");
        string otvet = Console.ReadLine();
        if (otvet == "y" || otvet == "Y")
        {
            return InputSize(out size);
        }

        return false;
    }
}

//************************
void FormatArray(string[] array1, string[] array2)
{
    int index2 = 0;
    for (int i = 0; i < array1.Length; i++)
    {
        if (array1[i].Length <= 3)
        {
            array2[index2] = array1[i];
            index2++;
        }
    }
    // Array.Resize(ref array2, index2 + 1);
}

//***********************
Console.Clear();
Console.Write(
    "Программа принимает на вход массив из строк и из него формирует новый массив из строк, длина которых меньше, либо равна 3 символам."
);
Console.WriteLine("");

int size = 0;
string[] array1 = { };
string[] array2 = { };

if (!InputSize(out size) || size < 1)
{
    Console.WriteLine("Работа прервана из-за отказа ввода размера массива или размер введен < 1");
}
else
{
    Array.Resize(ref array1, size);
    Array.Resize(ref array2, size);
    if (!InputDannyh($"Введите данные массива размерностью {size}", size, out array1))
    {
        Console.WriteLine("Работа с массивом прервана из-за отказа ввода данных");
    }
    else
    {
        FormatArray(array1, array2);
        Console.WriteLine("Исходный массив " + '[' + string.Join(", ", array1) + ']');
        Console.WriteLine("Получен новый массив " + '[' + string.Join(", ", array2) + ']');
    }
}
