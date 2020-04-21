using System;
using System.Diagnostics;
using System.Threading;

namespace ProcessMonitor
{
    class Program
    {
        public static void Main(string[] args)
        {
            // TODO create interface for APM (application performance management) data

            // TODO find out more on how to use System.Diagnostics
            // TODO create a tracing like for NL

            // starts fetching process information
            /*
            PerformanceMonitor pm = new PerformanceMonitor();
            pm.start();

            Console.WriteLine("Press any key to exit");
            while (!Console.KeyAvailable) System.Threading.Thread.Sleep(50);

            pm.stop();
            */

            // lists performance counter categories
            // TODO please put this in a method inside either the PerformanceMonitor or new Library
            // TODO optionally extend this to not only localhost (".")
            PerformanceCounterCategory[] categories;
            categories = PerformanceCounterCategory.GetCategories(".");

            // Create and sort an array of category names.
            string[] categoryNames = new string[categories.Length];
            int objX;
            for (objX = 0; objX < categories.Length; objX++)
            {
                categoryNames[objX] = categories[objX].CategoryName;
            }
            Array.Sort(categoryNames);

            for (objX = 0; objX < categories.Length; objX++)
            {
                Console.WriteLine("{0,4} - {1}", objX + 1, categoryNames[objX]);
            }

            // get counter names to create KPIs
            // TODO create some methods to read out specific KPIs
            //https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2003/cc780836(v=ws.10)?redirectedfrom=MSDN


            // TODO fetch UPD data from "log2console"
            // TODO consider extend this into Info, Debug, etc. methods (filters)

            Console.ReadKey();
        }
    }
}
