using System;

namespace SORTING
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 4, 3, 2, 1 };
            //int[] arr = { 1, 2, 3, 4, 5 };

            SelectionSort(arr);
            BubbleSort(arr);
            OptimizedBubbleSort(arr);
            Mergesort(arr, 0, arr.Length - 1);
            QuickSort(arr, 0, arr.Length - 1);

            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);

            void Swap(ref int x, ref int y)
            {
                int temp = x; x = y; y = temp;
            }

            //INBUILT SORT
            Array.Sort(arr);

            //SELECTION SORT
            void SelectionSort(int[] a)
            {
                for (int i = 0; i < a.Length - 1; i++)
                {
                    int smallest = i;
                    for (int j = i + 1; j < a.Length; j++)
                    {
                        if (a[j] < a[smallest])
                        {
                            smallest = j;
                        }
                    }

                    if (a[i] > a[smallest])
                    {
                        Swap(ref a[i], ref a[smallest]);
                    }
                }
            }

            //BUBBLE SORT
            void BubbleSort(int[] a)
            {
                for (int j = 0; j < a.Length - 1; j++)
                {
                    for (int i = 0; i < a.Length - 1; i++)
                    {
                        if (a[i] > a[i + 1])
                            Swap(ref a[i], ref a[i + 1]);
                    }
                }
            }

            //OPTIMIZED BUBBLE SORT
            void OptimizedBubbleSort(int[] a)
            {
                bool isSorted = true;
                for (int j = 0; j < a.Length - 1; j++)
                {
                    for (int i = 0; i < a.Length - 1; i++)
                    {
                        if (a[i] > a[i + 1])
                        {
                            isSorted = false;
                            Swap(ref a[i], ref a[i + 1]);
                        }
                    }
                    if (isSorted == true)
                    {
                        Console.WriteLine("Already Sorted");
                        break;
                    }
                }
            }

            //MERGE SORT
            void Mergesort(int[] a, int start, int end)
            {
                //Base Case
                if (start >= end) return;

                if (start < end)
                {
                    int mid = start + (end - start) / 2;
                    //Recursive Case
                    Mergesort(a, start, mid);
                    Mergesort(a, mid + 1, end);

                    //Merge both sorted arrays
                    MergeSortedArrays(a, start, mid, end);
                }
            }
            void MergeSortedArrays(int[] a, int start, int mid, int end)
            {
                int i = start;
                int j = mid + 1;
                int k = start;
                int[] newArray = new int[end + 1];


                while (i <= mid && j <= end)
                {
                    if (a[i] < a[j])
                    {
                        newArray[k] = a[i];
                        i++;
                    }
                    else
                    {
                        newArray[k] = a[j];
                        j++;
                    }
                    k++;
                }
                while (i <= mid)
                {
                    newArray[k] = a[i];
                    i++;
                    k++;
                }
                while (j <= end)
                {
                    newArray[k] = a[j];
                    j++;
                    k++;
                }

                for (int x = start; x < end + 1; x++)
                {
                    a[x] = newArray[x];
                }
            }


            //QUICK SORT
            void QuickSort(int[] a, int start, int end)
            {
                if (start >= end) return;

                int p = Partition(a, start, end);

                QuickSort(a, start, p - 1);
                QuickSort(a, p + 1, end);
            }
            int Partition(int[] a, int start, int end)
            {
                int i = start;
                int pivot = end;

                for (int j = start; j < end; j++)
                {
                    if (a[j] < a[pivot])
                    {
                        Swap(ref a[i], ref a[j]);
                        i++;
                    }
                }
                Swap(ref a[i], ref a[end]);
                return i;
            }
        }
    }
}
