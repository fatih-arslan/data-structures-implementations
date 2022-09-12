﻿using System;
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
            int[] arr = { 1, 7, 4, 9, 8, 2, 6, 3, 5 };
            arr[1] = arr[2];
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
                for(int j = 0; j < n- i - 1; j++)
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
            for (int i = 0; i < n; i++)
            {
                int minIndex = i; // the index where the min element will be transferred to
                int indexOfMin = i; // index of the min element
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[indexOfMin])
                    {
                        indexOfMin = j;
                    }
                }
                (arr[minIndex], arr[indexOfMin]) = (arr[indexOfMin], arr[minIndex]);
            }
        }
       
        //Insertion sort
        //The array is virtually split into a sorted and an unsorted part. Values from the unsorted part are picked and placed at the correct position in the sorted part.
        // Use when the input is small or items are mostly sorted
        static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for(int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while(arr[j] > key && j >= 0)
                {
                    (arr[j], arr[j + 1]) = (key, arr[j]);
                    j--;
                }
            }
        }
        static void InsertionSort(List<int> lst)
        {
            int n = lst.Count;
            for(int i = 1; i < n; i++)
            {
                int key = lst[i];
                int j = i - 1;
                while (lst[j] > key && j >= 0) // going backwards until we find the correct place for key
                {
                    j--;
                }
                lst.Remove(key);           // removing the key and inserting to the correct place
                lst.Insert(j + 1, key);
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
            int i = 0, j = 0;
            for(; i < length; i++)
            {
                if(i < mid)
                {
                    leftArray[i] = arr[i];
                }
                else
                {
                    rightArray[j++] = arr[i];
                }
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
            // There is probably going to be one element remaining that we can't compare to another because there is only one left
            while (l < leftSize)
            {
                array[i] = leftArray[l++];
            }
            while(r < rightSize)
            {
                array[i] = rightArray[r++];
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
