/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

Console.WriteLine("Введите размер двумерного массива");

Console.WriteLine("Введите количество строк");
bool isParsevasizerow = int.TryParse(Console.ReadLine(), out int sizeRow);

Console.WriteLine("Введите количество столбцов");
bool isParsesizecolumn = int.TryParse(Console.ReadLine(), out int sizeColumn);

if (!isParsevasizerow || !isParsesizecolumn) { Console.WriteLine("Ошибка ввода размености, введено не число"); return; }

int[,] array = Generate2DArray(sizeRow, sizeColumn);
Print2DArray(array);
Console.WriteLine();

SortingArrayToRows(array);
Print2DArray(array);
Console.WriteLine();


int[,] Generate2DArray(int sizeRow, int sizeColumn)
{
    int[,] array = new int[sizeRow, sizeColumn];

    Random random = new Random();

    for (int i = 0; i < sizeRow; i++)
    {
        for (int j = 0; j < sizeColumn; j++)
        {
            array[i, j] = random.Next(0, 10);
        }
    }
    return array;
}


void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j]);
            Console.Write(" ");
        }

        Console.WriteLine();
    }
}


void SortingArrayToRows (int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int max = array[i,j];
            int indexMax = j;

            for (int k = j; k < array.GetLength(1); k++)
            {
                if (max < array[i,k]) { max = array[i,k]; indexMax = k;}
            }

            if (indexMax != j)
            {
                int tmp = array[i, j];
                array[i, j] = array[i, indexMax];
                array[i, indexMax] = tmp;
            }

        }
    }

}

/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

Console.WriteLine("Введите количество строк прямоугольного массива");
bool isParsevasizeRow = int.TryParse(Console.ReadLine(), out int sizeRow);

Console.WriteLine("Введите количество столбцов прямоугольного массива");
bool isParsevasizeColumn = int.TryParse(Console.ReadLine(), out int sizeColumn);

if (!isParsevasizeRow || !isParsevasizeColumn) { Console.WriteLine("Ошибка ввода размености, введено не число"); return; }
if (sizeRow == sizeColumn) { Console.WriteLine("Введенная размерность не соответствует прямоугольному массиву"); return; }

int[,] array = Generate2DArray(sizeRow, sizeColumn);
Print2DArray(array);
Console.WriteLine();

Console.WriteLine($"Индекс строки с минимальной суммой элементов: {FindMinSummElementRow(array)}");


int[,] Generate2DArray(int sizeRow, int sizeColumn)
{
    int[,] array = new int[sizeRow, sizeColumn];

    Random random = new Random();

    for (int i = 0; i < sizeRow; i++)
    {
        for (int j = 0; j < sizeColumn; j++)
        {
            array[i, j] = random.Next(0, 10);
        }
    }
    return array;
}


void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j]);
            Console.Write(" ");
        }

        Console.WriteLine();
    }
}


int FindMinSummElementRow (int[,] array)
{
    int min = 0;
    int indexRowMin = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        int tmp = 0;

        for(int j = 0; j < array.GetLength(1); j++)
        {
            tmp += array[i,j]; 
        }

        if (i == 0) {min = tmp;}
        if (min > tmp) { min = tmp; indexRowMin = i; }

    }

    return indexRowMin;

}

/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

Console.WriteLine("Введите количество строк первой матрицы");
bool isParsesizeRowFirst = int.TryParse(Console.ReadLine(), out int sizeRowFirst);

Console.WriteLine("Введите количество столбцов первой матрицы");
bool isParsesizeColumnFirst = int.TryParse(Console.ReadLine(), out int sizeColumnFirst);

if (!isParsesizeRowFirst || !isParsesizeColumnFirst) { Console.WriteLine("Ошибка ввода размености, введено не число"); return; }

Console.WriteLine("Введите количество строк второй матрицы");
bool isParsesizeRowSecond = int.TryParse(Console.ReadLine(), out int sizeRowSecond);

Console.WriteLine("Введите количество столбцов второй матрицы");
bool isParsesizeColumnSecond = int.TryParse(Console.ReadLine(), out int sizeColumnSecond);

if (!isParsesizeRowSecond || !isParsesizeColumnSecond) { Console.WriteLine("Ошибка ввода размености, введено не число"); return; }

if (sizeRowFirst != sizeColumnSecond) { Console.WriteLine("Количество строк первой матрицы не равно количеству столбцов второй, нахождения произведения невозможно"); return; }

int[,] arrayFirst = Generate2DArray(sizeRowFirst, sizeColumnFirst);
Console.WriteLine("Первая матрица:");
Print2DArray(arrayFirst);
Console.WriteLine();

int[,] arraySecond = Generate2DArray(sizeRowSecond, sizeColumnSecond);
Console.WriteLine("Вторая матрица:");
Print2DArray(arraySecond);
Console.WriteLine();

int[,] arrayComposition = Composition2DMatrix(arrayFirst, arraySecond);
Console.WriteLine("Произведение первой и второй матрицы:");
Print2DArray(arrayComposition);



int[,] Generate2DArray(int sizeRow, int sizeColumn)
{
    int[,] array = new int[sizeRow, sizeColumn];

    Random random = new Random();

    for (int i = 0; i < sizeRow; i++)
    {
        for (int j = 0; j < sizeColumn; j++)
        {
            array[i, j] = random.Next(0, 10);
        }
    }
    return array;
}



void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j]);
            Console.Write(" ");
        }

        Console.WriteLine();
    }
}


int[,] Composition2DMatrix (int[,] arrayFirst, int[,] arraySecond)
{

    int[,] arrayComposition = new int[arrayFirst.GetLength(0), arraySecond.GetLength(1)];

    for (int i = 0; i < arrayFirst.GetLength(0); i++)
    {
        for (int j = 0; j < arraySecond.GetLength(1); j++)
        {
            for (int k = 0; k < arraySecond.GetLength(0); k++)
            {
                arrayComposition[i,j] += arrayFirst[i, k] * arraySecond[k,j];
            }
        }
    }

    return arrayComposition;

}

/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

Console.WriteLine("Введите X:");
bool isParseX = int.TryParse(Console.ReadLine(), out int x);

Console.WriteLine("Введите Y:");
bool isParseY = int.TryParse(Console.ReadLine(), out int y);

Console.WriteLine("Введите Z:");
bool isParseZ = int.TryParse(Console.ReadLine(), out int z);

if (!isParseX || !isParseY || !isParseZ) { Console.WriteLine("Ошибка ввода размености, введено не число"); return; }

int[,,] array3D = Generate3DArray(x, y, z);
Print3DArray(array3D);


int[,,] Generate3DArray(int x, int y, int z)
{
    int[,,] array = new int[x, y, z];
    var tmpDictonary = new Dictionary<int, int>();
    Random random = new Random();

    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            for (int k = 0; k < z;)
            {
                int tmp = random.Next(10, 100);

                if (!tmpDictonary.TryAdd(tmp, 1)) { continue; }

                array[i, j, k] = tmp;
                k++;
            } 
        }
    }
    return array;
}


void Print3DArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.WriteLine($"[{i}, {j}, {k}] - {array[i,j,k]}");
            }
        }
    }
}

/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

int[,] array = GenerateArray(10,10);
Print2DArray(array);



int[,] GenerateArray(int sizeRow, int sizeColumn)
{
    int[,] array = new int [sizeRow, sizeColumn];
    
    int i = 0;
    int j = 0;
    int tmp = 1;
    int indexSizerow = 0;
    int indexSizeColumn = 0;

    bool strat = true;
    int status = 0; // 0 - вправо; 1 - вниз; 2 - влево; 3 - вверх;

    while(strat)
    {
        if (status == 0)
        {
            while (j < sizeColumn - indexSizeColumn)
            {
                array[i,j] = tmp;
                tmp++;
                j++;
            }       

            j = sizeColumn - indexSizeColumn - 1;
            i++;
            status = 1;

        }

        if (status == 1)
        {
            while (i < sizeRow - indexSizerow)
            {
                array[i,j] = tmp;
                tmp++;
                i++;
            }

            i = sizeRow - indexSizerow - 1;
            indexSizerow++;
            j--;
            status = 2;

        }

        if (status == 2)
        {
            while (j >= 0 + indexSizeColumn)
            {
                array[i,j] = tmp;
                tmp++;
                j--;
            }

            j = 0 + indexSizeColumn;
            indexSizeColumn++;
            i--;
            status = 3;
        }

        if (status == 3)
        {
            while (i >= 0 + indexSizerow)
            {
                array[i,j] = tmp;
                tmp++;
                i--;
            }

            i = 0 + indexSizerow;
            j++;  
            status = 0; 
        }

        if (indexSizeColumn == sizeColumn - (sizeColumn/2) || indexSizerow == sizeRow - (sizeRow/2))
        {
            strat = false;
        }

    }
    
    return array;

}



void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j]);
            Console.Write(" ");
        }

        Console.WriteLine();
    }
}