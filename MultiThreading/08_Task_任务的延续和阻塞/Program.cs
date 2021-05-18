using System;
using System.Threading;
using System.Threading.Tasks;

namespace _08_Task_任务的延续和阻塞
{
    /*
     *  1. 阻塞
     *  Thread  => Join方法【让调用线程阻塞】
     *      参考： Demo_1
     *  Task
     *      - WaitAll方法：必须所有的Task执行完才算完成
     *      - WaitAny方法：只要其中一个Task执行完成就算完成
     *      
     *      Task.Wait方法：等待操作
     *      上面这些等待操作，返回值都是void...
     *  2. 延续    
     *      现在有一个想法就是：我不想阻塞主线程，实现一个WaitAll的操作
     *          t1执行完成之后，执行t2,这就是延续的概念
     *          延续 = 它的基础就是Wait...
     *      - WhenAll
     *      - WhenAny
     *  TaskFactory
     *      Task工厂中的一些延续操作
     *      - ContinueWhenAll
     *      - ContinueWhenAny
     *  介绍Task的7种阻塞方式 +  延续 
     *  学打组合拳，Task异步任务会写的非常漂亮
     */

    class Program
    {
        static void Main(string[] args)
        {
            // Thread的阻塞 【Join】
            // Demo_1();

            // Task的阻塞—【WaitAll】
            // Demo_2();

            // Task的阻塞—【WaitAny】
            // Demo_3();

            // Task的阻塞与延续—【WhenAll，ContinueWith】
            // Demo_4();

            // Task的阻塞与延续—【WhenAny，ContinueWith】
            // Demo_5();

            // Task.Factory阻塞与延续—【ContinueWhenAll】
            // Demo_6();

            // Task.Factory阻塞与延续—【ContinueWhenAny】
            // Demo_7();

            Console.WriteLine("我是主线程");
            Console.ReadKey();
        }

        public static void Demo_1()
        {
            Thread t1 = new Thread(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                Console.WriteLine("我是工作线程-1");
            });

            Thread t2 = new Thread(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                Console.WriteLine("我是工作线程-2");
            });

            t1.Start();
            t2.Start();

            // t1 && t2: WaitAll操作【相当于】
            // t1 || t2: WaitAny操作【相当于】
            t1.Join();
            t2.Join();
        }


        public static void Demo_2()
        {

            Task task1 = new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                Console.WriteLine($"我是工作线程-1, {DateTime.Now}");
            });

            Task task2 = new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                Console.WriteLine($"我是工作线程-2, {DateTime.Now}");
            });

            task1.Start();
            task2.Start();

            Task.WaitAll(new[] { task1, task2 });
        }

        public static void Demo_3()
        {

            Task task1 = new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"我是工作线程-1, {DateTime.Now}");
            });

            Task task2 = new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.2));
                Console.WriteLine($"我是工作线程-2, {DateTime.Now}");
            });

            task1.Start();
            task2.Start();

            Task.WaitAny(new[] { task1, task2 });
        }

        public static void Demo_4()
        {

            Task task1 = new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"我是工作线程-1, {DateTime.Now}");
            });

            Task task2 = new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"我是工作线程-2, {DateTime.Now}");
            });

            task1.Start();
            task2.Start();

            Task.WhenAll(task1, task2).ContinueWith(t =>
            {
                // 执行“工作线程-3”的内容
                Console.WriteLine($"我是工作线程-3, {DateTime.Now}");
            });
        }

        public static void Demo_5()
        {

            Task task1 = new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"我是工作线程-1, {DateTime.Now}");
            });

            Task task2 = new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"我是工作线程-2, {DateTime.Now}");
            });

            task1.Start();
            task2.Start();

            Task.WhenAny(task1, task2).ContinueWith(t =>
            {
                // 执行“工作线程-3”的内容
                Console.WriteLine($"我是工作线程-3, {DateTime.Now}");
            });
        }

        public static void Demo_6()
        {

            Task task1 = new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"我是工作线程-1, {DateTime.Now}");
            });

            Task task2 = new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"我是工作线程-2, {DateTime.Now}");
            });


            task1.Start();
            task2.Start();

            Task.Factory.ContinueWhenAll(new Task[] { task1, task2 }, (task) =>
             {
                 // 执行“工作线程-3”的内容
                 Console.WriteLine($"我是工作线程-3, {DateTime.Now}");
             });
        }

        public static void Demo_7()
        {

            Task task1 = new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"我是工作线程-1, {DateTime.Now}");
            });

            Task task2 = new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine($"我是工作线程-2, {DateTime.Now}");
            });


            task1.Start();
            task2.Start();

            Task.Factory.ContinueWhenAny(new Task[] { task1, task2 }, (task) =>
            {
                // 执行“工作线程-3”的内容
                Console.WriteLine($"我是工作线程-3, {DateTime.Now}");
            });
        }
    }
}
