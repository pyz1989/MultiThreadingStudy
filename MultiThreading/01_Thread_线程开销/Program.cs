using System;
using System.Threading;

namespace _01_Thread_线程开销
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread = new Thread(() =>
            //{

            //});
            //thread.Start();
            //Console.ReadKey();
            int temp = 1;
            int mum = temp + 9;
            Console.WriteLine(mum);

            int a1 = 1;
            a1 = a1 + mum;
            Console.WriteLine(a1);
            int s1 = 1;
            s1 += mum;
            Console.WriteLine(s1);

           s1 = a1 + mum;
            Console.WriteLine(s1);
            Console.ReadKey();
        }
    }
}
