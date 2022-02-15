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
            int j, key, i;
            for (i = 0; i < array.Length; i++)
            {
                key = array[i];
                j = i - 1;
                
                while(j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }

            
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
