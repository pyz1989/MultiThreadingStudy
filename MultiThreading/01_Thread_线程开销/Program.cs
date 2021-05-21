using System;
using System.Threading;

namespace _01_Thread_线程开销
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(() =>
            {

            });
            thread.Start();
            Console.ReadKey();
        }
    }
}
