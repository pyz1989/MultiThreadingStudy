using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07_Task_任务启动方式
{
    class Program
    {
        /*
         *  一、Task 【.Net 4.0】
         *   为什么要有Task？
         *      Task => Thread  + ThreadPoll + 优化和功能扩展
         *      Thread: 容易造成时间 + 空间开销，而且使用不当，容易造成线程过多，导致时间片切换...
         *      ThreadPool: 控制能力比较弱，做Thread的延续，阻塞，取消，超时等等功能, 控制权在CLR，而不是在我们这里...
         *      Task 看起来像是一个Thread
         *      Task 是在ThreadPool的基础上进行的封装
         *      .Net 4.0之后，微软是极力的推荐 Task 来作为异步计算
         *  二、 Task的启动方式
         *   1. 实例化启动Task
         *   2. TaskFactory的方式启动Task
         *   3. Task.Run方法
         *   4. Task的同步方法
         *  三、Task是建立在ThreadPool上面的吗？
         *    我们的Task底层都是由不同的TaskScheduler支撑的。。。
         *    TaskScheduler 相当于Task的CPU处理器。。。
         *    默认的TaskScheduler是ThreadPoolTaskScheduler。。。
         *    WPF中的TaskScheduler是 SynchronizationContextTaskScheduler
         *    
         *    ThreadPoolTaskScheduler
         *    m_taskScheduler.InternalQueueTask(this);
         *    大家也可以自定义一些TaskScheduler。。。。
         *    
         *    
                private static readonly TaskScheduler s_defaultTaskScheduler = new ThreadPoolTaskScheduler();
                // System.Threading.Tasks.ThreadPoolTaskScheduler
                protected internal override void QueueTask(Task task)
                {
	                TaskCreationOptions options = task.Options;
	                if ((options & TaskCreationOptions.LongRunning) != 0)
	                {
		                Thread thread = new Thread(s_longRunningThreadWork);
		                thread.IsBackground = true;
		                thread.Start(task);
	                }
	                else
	                {
		                bool preferLocal = (options & TaskCreationOptions.PreferFairness) == TaskCreationOptions.None;
		                ThreadPool.UnsafeQueueUserWorkItemInternal(task, preferLocal);
	                }
                }
        *  四、Task<TResult>
        *   让Task具有返回值，它的父类其实就是Task
        *   具体的启动方式和Task是一样的
        */
        static void Main(string[] args)
        {
            // 1. 实例化启动Task
            Demo_1();
            // 2. TaskFactory的方式启动Task
            Demo_2();
            // 3. Task.Run方法
            Demo_3();
            // 4. Task的同步方法,也就是阻塞执行
            Demo_4();

            // 让Task具有返回值：Task<TResult>
            Demo_5();
            Console.WriteLine($"我是主线程【0】: tid = {Thread.CurrentThread.ManagedThreadId}, {DateTime.Now}");
            Console.ReadKey();
        }


        public static void Demo_1()
        {
            Task t1 = new Task(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"我是工作线程【1】: tid = {Thread.CurrentThread.ManagedThreadId}, {DateTime.Now}");
            });
            t1.Start();
        }

        public static void Demo_2()
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"我是工作线程【2】: tid = {Thread.CurrentThread.ManagedThreadId}, {DateTime.Now}");
            });
        }

        public static void Demo_3()
        {
            Task.Run(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"我是工作线程【3】: tid = {Thread.CurrentThread.ManagedThreadId}, {DateTime.Now}");
            });
        }

        public static void Demo_4()
        {
            Task t1 = new Task(() =>
            {
                Console.WriteLine($"我是工作线程【4】: tid = {Thread.CurrentThread.ManagedThreadId}, {DateTime.Now}");
            });
            t1.RunSynchronously();
        }

        public static void Demo_5()
        {
            // 前后要一致，否则无Result方法
            Task<string> t1 = new Task<string>(() =>
            {
                return "Hello World!";
            });
            t1.Start();

            var msg = t1.Result;
            Console.WriteLine($"收到消息：{msg}");
        }
    }
}
