using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_algorithms_csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 9,8,7,6,5,4,3,2,1};
            QuickSort(arr, 0, arr.Length-1);            
            Console.WriteLine(String.Join(" ", arr));
            Console.ReadLine();
        }
        
        //Bubble sort
        //Bubble Sort is the simplest sorting algorithm that works by repeatedly swapping the adjacent elements if they are in the wrong order.
        // Almost never used, only used for educational purposes
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length; 
            for(int i = 0; i < n - 1; i++)
            {
                for(int j = 0; j < n - 1 - i; j++)
                {
                    if(arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);                                                
                    }
                }
            }
        }       
        
        //Selection sort
        //The selection sort algorithm sorts an array by repeatedly finding the minimum element (considering ascending order) from unsorted part and putting it at the beginning
        // Mostly used as a teaching mechanism
        static void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n - i; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                (arr[minIndex], arr[i]) = (arr[i], arr[minIndex]);
            }
        }
       
        //Insertion sort
        //The array is virtually split into a sorted and an unsorted part. Values from the unsorted part are picked and placed at the correct position in the sorted part.
        // Use when the input is small or items are mostly sorted
        static void InsertionSort(int[] arr) // 9 8 7 6 5 4 3 2 1
        {
            int n = arr.Length;
            for(int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while(j >= 0 && arr[j] > key)
                {
                    arr[j+1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }        
       
        //Merge Sort 
        //In this algorithm, the array is initially divided into two equal halves and then they are combined in a sorted manner.
        //We can think of it as a recursive algorithm that continuously splits the array in half until it cannot be further divided.
        // Time complexity is O(nlogn) for best, average and worst cases, use if you are worried about worst case time complexity
        // Space complexity is O(n) if you are worried about space complexity merge sort is really expensive
        static void MergeSort(int[] arr)
        {
            int length = arr.Length;
            if(length <= 1) { return; }
            int mid = length / 2;
            int[] leftArray = new int[mid];
            int[] rightArray = new int[length - mid];
            
            for(int i = 0; i < leftArray.Length; i++)
            {
                leftArray[i] = arr[i];
            }
            for(int i = 0; i < rightArray.Length; i++)
            {
                rightArray[i] = arr[mid + i];
            }

            MergeSort(leftArray);
            MergeSort(rightArray);
            Merge(leftArray, rightArray, arr);
        }
        static void Merge(int[] leftArray, int[] rightArray, int[] array)
        {
            int leftSize = leftArray.Length;
            int rightSize = rightArray.Length;
            int i = 0, l= 0, r = 0;
            while(l < leftSize && r < rightSize)
            {
                if(leftArray[l] < rightArray[r])
                {
                    array[i++] = leftArray[l++];
                }
                else
                {
                    array[i++] = rightArray[r++];
                }
            }
            
            while (l < leftSize)
            {
                array[i++] = leftArray[l++];
            }
            while(r < rightSize)
            {
                array[i++] = rightArray[r++];
            }
        }

        //Quick Sort
        // Quick sort picks an element as a pivot and partitions the given array around the picked pivot.
        //The key process in quickSort is a partition().
        //The target of partitions is, given an array and an element x of an array as the pivot,
        //put x at its correct position in a sorted array and put all smaller elements (smaller than x) before x, and put all greater elements (greater than x) after x.
        //Time complexity is O(nlogn) (same with merge sort) for best and average cases but space complexity O(logn)
        //So If you don't pick the pivot properly you could have a really slow process
        static void QuickSort(int[] array, int start, int end)
        {
            if(end <= start) { return; }
            int pivot = Partition(array, start, end);   
            QuickSort(array, start, pivot-1);
            QuickSort(array, pivot, end);
        }
        static int Partition(int[] array, int start, int end)
        {
            int pivot = array[end];
            int i = start - 1;
            for(int j = start; j <= end - 1; j++)
            {
                if(array[j] < pivot)
                {
                    i++;
                    (array[i], array[j]) = (array[j], array[i]);

                }
            }
            i++;
            (array[i], array[end]) = (array[end], array[i]);
            return i; //location of pivot
        }
    }
}
