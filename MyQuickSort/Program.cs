using System;
using System.Linq;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Threading;

namespace scrambler
{
    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        static public int Partition(int[] array, int left, int right) {
         int pivot;
         pivot = array[left];
         while (true) {
            while (array[left] < pivot) {
               left++;
            }
            while (array[right] > pivot) {
               right--;
            }
            if (left < right) {
               int temp = array[right];
               array[right] = array[left];
               array[left] = temp;
            } else {
               return right;
            }
         }
      }
      static public void quickSort(int[] array, int left, int right) {
         int pivot;
         if (left < right) {
            pivot = Partition(array, left, right);
            if (pivot > 1) {
               quickSort(array, left, pivot - 1);
            }  
            if (pivot + 1 < right) {
               quickSort(array, pivot + 1, right);
            }
         }
      }
        
        static void Main(string[] args)
        {
            //Scrambler
            int length = 8000;
            int[] array = new int[length];

            for (int o = 0; o <= length - 1; o++)
            {
                array[o] = o + 1;
            }
            Random random = new Random();
            array = array.OrderBy(x => random.Next()).ToArray();
            Console.WriteLine("Scrambled: ");
            foreach (var o in array)
            {
                Console.WriteLine(o);
            }
            //Scrambler

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //Sortering
             
             Partition(array, 0, length-1);
             quickSort(array, 0, length-1);

     
     
            
            //Sortering

            stopwatch.Stop();

            Console.WriteLine("Sorted: ");
            foreach(var e in array)
            {
                Console.WriteLine(e);
            }
                
                Console.WriteLine("Elapsed Time is: {0} ms", stopwatch.ElapsedMilliseconds);
        }
    }
}
