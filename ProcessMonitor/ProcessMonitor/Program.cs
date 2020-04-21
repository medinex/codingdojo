using System;

namespace ProcessMonitor
{
    class Program
    {
        public static void Main(string[] args)
        {

            PerformanceMonitor pm = new PerformanceMonitor();
            pm.start();

            Console.WriteLine("Press any key to exit");
            while (!Console.KeyAvailable) System.Threading.Thread.Sleep(50);

            pm.stop();
        }
    }
}
