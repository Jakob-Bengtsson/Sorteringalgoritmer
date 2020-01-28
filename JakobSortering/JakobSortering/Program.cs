using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace JakobSortering
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hur många tal vill du sortera?");
            int tal = Convert.ToInt32(Console.ReadLine());

            int[] talarray = new int[tal];
            Random random = new Random();

            for (int i = 0; i < talarray.Length; i++)
            {
                talarray[i] = random.Next();
            }


            int[] copy1 = new int[talarray.Length];
            int[] copy2 = new int[talarray.Length];
            int[] copy3 = new int[talarray.Length];
            int[] copy4 = new int[talarray.Length];

            Array.Copy(talarray, 0, copy1, 0, talarray.Length);
            Array.Copy(talarray, 0, copy2, 0, talarray.Length);
            Array.Copy(talarray, 0, copy3, 0, talarray.Length);
            Array.Copy(talarray, 0, copy4, 0, talarray.Length);

            Console.WriteLine("\n" + "Antal tal: " + talarray.Length + "\n");

            Stopwatch timer = new Stopwatch();
            timer.Start();
            Bubblesort(copy1);
            timer.Stop();

            Console.WriteLine("Bubblesort: " + timer.Elapsed.TotalSeconds + " Sekunder");

            timer.Restart();
            Selectionsort(copy2);
            timer.Stop();

            Console.WriteLine("Selectionsort: " + timer.Elapsed.TotalSeconds + " Sekunder");

            timer.Restart();
            Mergesort(copy3, 0, copy3.Length - 1);
            timer.Stop();

            Console.WriteLine("Mergesort: " + timer.Elapsed.TotalSeconds + " Sekunder");

            timer.Restart();
            Quicksort(copy4, 0, talarray.Length - 1);
            timer.Stop();

            Console.WriteLine("Quicksort: " + timer.Elapsed.TotalSeconds + " Sekunder");

            Console.ReadKey();
        }

        public static void Selectionsort(int[] talarray)
        {
            for (int i = 0; i < talarray.Length - 1; i++)
            {
                int minelement = i;

                for (int j = i + 1; j < talarray.Length; j++)
                {
                    if (talarray[j] < talarray[minelement])
                    {
                        minelement = j;
                    }
                }
                int tal = talarray[minelement];
                talarray[minelement] = talarray[i];
                talarray[i] = tal;
            }
        }

        public static void Bubblesort(int[] talarray)
        {
            for (int i = 0; i < talarray.Length - 1; i++)
            {
                for (int j = 0; j < talarray.Length - 1 - i; j++)
                {
                    if (talarray[j] > talarray[j + 1])
                    {
                        int tal = talarray[j];
                        talarray[j] = talarray[j + 1];
                        talarray[j + 1] = tal;
                    }
                }
            }
        }

        public static void Mergesort(int[] talarray, int l, int r)
        {
            if (l < r)
            {
                int m = (l + (r - 1)) / 2;

                Mergesort(talarray, l, m);
                Mergesort(talarray, m + 1, r);

                Merge(talarray, l, m, r);
            }
        }

        static void Merge(int[] talarray, int l, int m, int r)
        {
            int[] leftArray = new int[m - l + 1];
            int[] rightArray = new int[r - m];

            Array.Copy(talarray, l, leftArray, 0, m - l + 1);
            Array.Copy(talarray, m + 1, rightArray, 0, r - m);

            int i = 0;
            int j = 0;
            for (int k = l; k < r + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    talarray[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    talarray[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    talarray[k] = leftArray[i];
                    i++;
                }
                else
                {
                    talarray[k] = rightArray[j];
                    j++;
                }
            }
        }

        public static void Quicksort(int[] talarray, int l, int r)
        {
            if (l < r)
            {
                int p = Partition(talarray, l, r);
                Quicksort(talarray, l, p - 1);
                Quicksort(talarray, p + 1, r);
            }
        }

        private static int Partition(int[] talarray, int l, int r)
        {
            int pivot = talarray[r];
            int i = l;

            for (int j = l; j < r; j++)
            {
                if (talarray[j] < pivot)
                {
                    int tal2 = talarray[j];
                    talarray[j] = talarray[i];
                    talarray[i] = tal2;
                    i++;
                }
            }

            int tal = talarray[r];
            talarray[r] = talarray[i];
            talarray[i] = tal;
            return i;
        }
    }
}


