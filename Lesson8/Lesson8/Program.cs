using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    class Program
    {
        //1. Реализовать сортировку подсчётом.
        //2. Реализовать быструю сортировку.
        //3. *Реализовать сортировку слиянием.
        //4. **Реализовать алгоритм сортировки со списком.
        //5. Проанализировать время работы каждого из вида сортировок для 100, 10000, 1000000
        //элементов.Заполнить таблицу.

        static int arraySize;
        static DateTime start, end;

        static void Main(string[] args)
        {
            arraySize = 100000;
            int TaskNumber = 0;
            int[] myArr = new int[arraySize];// = { 1, 4, 3, 8, 2, 9, 6, 5, 7, 10 };
            int[] myArr1;
            int[] myArr2;
            int[] myArr3;
            int[] myArr4;
            int[] myArr5;
            int[] myArr6;
            int[] myArr7;

            initArray(myArr, arraySize);

            do
            {
                Console.Clear();
                //PrintArr(myArr);
                menu();
                TaskNumber = Convert.ToInt16(Console.ReadLine());
                int index = 0;
                Console.Beep();
                switch (TaskNumber)
                {
                    case 1:
                        myArr1 = (int[])myArr.Clone();
                        BubleSort(myArr1, arraySize);
                        //PrintArr(myArr1);
                        Console.ReadLine();
                        break;
                    case 2:
                        myArr2 = (int[])myArr.Clone();
                        ShakerSort(myArr2, arraySize);
                        Console.ReadLine();
                        break;
                    case 3:
                        myArr3 = (int[])myArr.Clone();
                        SelectSort(myArr3, arraySize);
                        //PrintArr(myArr3);
                        Console.ReadLine();
                        break;
                    case 4:
                        myArr4 = (int[])myArr.Clone();
                        CountingSort(myArr4, arraySize);
                        Console.ReadLine();
                        break;
                    case 5:
                        myArr5 = (int[])myArr.Clone();
                        QuickSort(ref myArr5);
                        Console.ReadLine();
                        break;
                    case 6:
                        myArr6 = (int[])myArr.Clone();
                        MergeSort(myArr6, arraySize);
                        Console.ReadLine();
                        break;
                    case 7:
                        myArr7 = (int[])myArr.Clone();
                        PigeonholeSorting(myArr7, arraySize);
                        Console.ReadLine();
                        break;
                    case 8:
                        myArr3 = (int[])myArr.Clone();
                        SelectSort(myArr3, arraySize);
                        BinarySearch(myArr3, arraySize);
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Неверный ввод!!!\n");
                        break;
                }
            } while (TaskNumber != 0);
            Console.ReadLine();

        }

        static void menu()
        {
            Console.WriteLine("Введите номер задачи!!");
            Console.WriteLine("1 - BubleSort!!");
            Console.WriteLine("2 - ShakerSort!!");
            Console.WriteLine("3 - SelectionSort!!");
            Console.WriteLine("4 - CountingSort!!");
            Console.WriteLine("5 - QuickSort!!");
            Console.WriteLine("6 - MergeSort!!");
            Console.WriteLine("7 - PigeonholeSorting!!");            
            Console.WriteLine("8 - SelectionSort с Бинарным поиском!!");
        }

        static void PrintArr(int[] Arr)
        {
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write(Arr[i] + " ");
            }
            Console.WriteLine();
        }

        static void initArray(int[] Array, int len)
        {
            Random myRand = new Random();
            int i = 0;
            int count = 0;
            int temp = 0;

            int j = 0;
            for (i = 0; i < len; i++)
            {
                temp = myRand.Next(1, len + 1);
                j = 0;
                while (j < count)
                {
                    if (Array[j] == temp)
                    {
                        temp = myRand.Next(1, len + 1);
                        j = -1;
                    }
                    j++;
                }
                Array[i] = temp;
                count++;
            }
        }

        static void BubleSort(int[] Arr, int len)
        {
            long SwapCount = 0;
            start = DateTime.Now;
            int temp;
            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (Arr[j] < Arr[i])
                    {
                        SwapCount++;
                        temp = Arr[i];
                        Arr[i] = Arr[j];
                        Arr[j] = temp;
                    }
                }
            }
            end = DateTime.Now;
            TimeSpan dT = end - start;
            Console.WriteLine("Время работы SelectSort: {0:f10} секунд", (float)dT.Ticks / 10000000);
            Console.WriteLine("Количество операций: {0}", SwapCount);
        }

        static void ShakerSort(int[] Arr, int len)
        {
            long SwapCount = 0;
            int swapFlag = 0;
            start = DateTime.Now;
            int LeftMark = 0, RightMark = len - 1;
            int temp;
            while (LeftMark <= RightMark)
            {
                swapFlag = 0;
                for (int i = RightMark; i > LeftMark; i--)
                {
                    if (Arr[i - 1] > Arr[i])
                    {
                        swapFlag = 1;
                        SwapCount++;
                        temp = Arr[i - 1];
                        Arr[i - 1] = Arr[i];
                        Arr[i] = temp;
                    }
                }
                LeftMark++;
                for (int i = LeftMark; i <= RightMark; i++)
                {
                    if (Arr[i - 1] > Arr[i])
                    {
                        swapFlag = 1;
                        SwapCount++;
                        temp = Arr[i - 1];
                        Arr[i - 1] = Arr[i];
                        Arr[i] = temp;
                    }
                }
                RightMark--;
                if (swapFlag == 0) break;
            }
            //PrintArr(Arr);
            end = DateTime.Now;
            TimeSpan dT = end - start;
            Console.WriteLine("Время работы SelectSort: {0:f10} секунд", (float)dT.Ticks / 10000000);
            Console.WriteLine("Количество операций: {0}", SwapCount);
        }

        static void SelectSort(int[] Arr, int len)
        {
            long SwapCount = 0;
            int j = 0;
            int temp = 0;
            int minIndex = 0;
            start = DateTime.Now;
            for (int i = 0; i < len; i++)
            {
                minIndex = i;
                for (int k = i + 1; k < len; k++)
                {
                    if (Arr[k] < Arr[minIndex])
                    {
                        SwapCount++;
                        minIndex = k;
                    }
                }

                temp = Arr[i];
                Arr[i] = Arr[minIndex];
                Arr[minIndex] = temp;
            }
            end = DateTime.Now;
            TimeSpan dT = end - start;
            Console.WriteLine("Время работы SelectSort: {0:f10} секунд", (float)dT.Ticks / 10000000);
            Console.WriteLine("Количество операций: {0}", SwapCount);
        }

        static void CountingSort(int[] Arr, int len)
        {
            long SwapCount = 0;
            start = DateTime.Now;
            int[] C = new int[len+1];
            for(int i=0; i<len; i++)
            {
                C[i] = 0;
                SwapCount++;
            }
            for(int j=0; j<len; j++)
            {
                C[Arr[j]]++;
                SwapCount++;
            }
            int b = 0;
            for (int i = 1; i <= len; i++)
                for (int j = 0; j < C[i]; j++)
                {
                    SwapCount++;
                    Arr[b++] = i;
                }
            end = DateTime.Now;
            TimeSpan dT = end - start;
            Console.WriteLine("Время работы SelectSort: {0:f10} секунд", (float)dT.Ticks / 10000000);
            Console.WriteLine("Количество операций: {0}", SwapCount);
        }

        public static int Counter = 0;
        static void QuickSort(ref int[] Arr)
        {
            Counter = 0;
            start = DateTime.Now;

            QuickSort(ref Arr, 0, arraySize);

            end = DateTime.Now;
            TimeSpan dT = end - start;
            Console.WriteLine("Время работы SelectSort: {0:f10} секунд", (float)dT.Ticks / 10000000);
            Console.WriteLine("Количество операций: {0}", Counter);
        }

        static void QuickSort(ref int[] Arr, int begin, int end)
        {
            if(begin<end)
            {
                int temp;
                int q = Arr[begin];
                int i = begin;
                for (int j = begin + 1; j < end; j++)
                {
                    if (Arr[j] <= q)
                    {
                        i = i + 1;
                        temp = Arr[i];
                        Arr[i] = Arr[j];
                        Arr[j] = temp;
                        Counter++;
                    }
                }
                temp = Arr[begin];
                Arr[begin] = Arr[i];
                Arr[i] = temp;
                Counter++;
                QuickSort(ref Arr, begin, i);
                QuickSort(ref Arr, i+1, end);
            }            
        }

        static void MergeSort(int[] Arr, int len)
        {
            Counter = 0;
            start = DateTime.Now;

            MergeSort(ref Arr);

            end = DateTime.Now;
            TimeSpan dT = end - start;
            Console.WriteLine("Время работы SelectSort: {0:f10} секунд", (float)dT.Ticks / 10000000);
            Console.WriteLine("Количество операций: {0}", Counter);
        }

        static void MergeSort(ref int[] Arr)
        {           
            if (Arr.Length > 1)
            {
                int LeftCount = Arr.Length / 2;
                int RightCount = Arr.Length - LeftCount;

                int[] LeftArr = new int[LeftCount];
                Array.Copy(Arr, 0, LeftArr, 0, LeftCount);

                int[] RightArr = new int[RightCount];
                Array.Copy(Arr, LeftCount, RightArr, 0, RightCount);

                MergeSort(ref LeftArr);
                MergeSort(ref RightArr);
                Arr = Merge(LeftArr, RightArr);
            }            
        }

        static int[] Merge(int[] left, int[] right)             //Метод, который собирает один массив из двух массивов в порядке возрастания
        {
            int[] merge = new int[left.Length + right.Length];
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    merge[k] = left[i];
                    i++;
                    Counter++;
                }
                else
                {
                    merge[k] = right[j];
                    j++;
                    Counter++;
                }
                k++;
            }
            while (i < left.Length)
            {
                merge[k] = left[i];
                i++;
                k++;
                Counter++;
            }
            while (j < right.Length)
            {
                merge[k] = right[j];
                j++;
                k++;
                Counter++;
            }
            return merge;
        }

        static void PigeonholeSorting(int[] Arr, int len)
        {
            

        }

        static void BinarySearch(int[] Arr, int len)
        {
            int count = 0;
            int searchValue;
            int ValueFinded = 0;
            Console.WriteLine("Введите число для поиска:\n");
            searchValue = Convert.ToInt16(Console.ReadLine());
            int lowIndex = 0;
            int HighIndex = len - 1;
            int currentIndex = 0;

            while (lowIndex < HighIndex)
            {
                count++;
                currentIndex = (HighIndex + lowIndex) / 2;
                if (Arr[currentIndex] == searchValue)
                {
                    ValueFinded = 1;
                    break;
                }
                if (Arr[currentIndex] > searchValue)
                {
                    HighIndex = currentIndex - 1;
                }
                if (Arr[currentIndex] < searchValue)
                {
                    lowIndex = currentIndex + 1;
                }
            }

            if (ValueFinded == 1)
            {
                Console.WriteLine("Значение найдено по индексу: {0}", currentIndex);
                Console.WriteLine("Значение найдено за {0} операции(й).", count);
            }
            if (ValueFinded == 0)
            {
                Console.WriteLine("Значение Не найдено в массиве!!!");
            }
        }
    }
}
