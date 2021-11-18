using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace matrix2
{

    class Program
    {
        public static int[,] arr1, arr2, arr3, arr4, arr5 ;
        public static int[,] arr6, arr7;
        static void Main(string[] args)
        {
            Thread ENTER = new Thread(() =>Ennter());
            ENTER.Start();
            ENTER.Join();
            Thread addd = new Thread(() => add());
            addd.Start();
            addd.Join();
            Thread ad= new Thread(() => add2());
            ad.Start();
            ad.Join();
            Thread mm = new Thread(() => mult());
            mm.Start();
            mm.Join();
            Console.Write("\naddition of two   matrices: \n");
            Thread pri = new Thread(() => prinad(arr5));
            pri.Start();
            pri.Join();
           Console.Write("\naddition of two   matrices: \n");
            Thread p = new Thread(() => prinad(arr6));
            p.Start();
            p.Join();
            Console.Write("\n multplition of two   matrices: \n");
            Thread m = new Thread(() => prinad(arr7));
            m.Start();
            Console.ReadKey();
        }
        static void Ennter()
        {
            arr1 = new int[20, 30];
            arr2 = new int[20, 30];
            arr3 = new int[20, 30];
            arr4 = new int[20, 30];
            Random rd = new Random();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    arr1[i, j] = rd.Next(1,10);
                    arr2[i, j] = rd.Next(1,10);
                    arr3[i, j] = rd.Next(1,10);
                    arr4[i, j] = rd.Next(1,10);

                }
            }
        }
        static void add()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            arr5 = new int[20, 30];

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                  
                    arr5[i, j] = arr1[i, j] + arr2[i, j];
                }
            }
            watch.Stop();
            Console.WriteLine($"Execution Time addtion1: {watch.ElapsedMilliseconds} ms");

        }
        static void add2()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();


            arr6 = new int[20, 30];

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 30; j++)
                {

                    arr6[i, j] = arr3[i, j] + arr4[i, j];
                    Thread.SpinWait(100);

                }
            }
                watch.Stop();
                Console.WriteLine($"Execution Time addtion2: {watch.ElapsedMilliseconds} ms");


            
        }

        static void prinad(int[,] arr)
        {  
                for (int i = 0; i < 20; i++)
                {
                    Console.Write("\n");
                    for (int j = 0; j < 30; j++)
                    { Console.Write("{0}\t", arr[i, j]);
                        
                    }
                }

        }
        static void mult()
        {
            arr7 = new int[20, 30];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 30; j++)
                {

                    arr7[i, j] = arr6[i, j] * arr5[i, j];
                }
            }
        }
    }
}