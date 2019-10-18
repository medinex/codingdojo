using DatabaseMigration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrationTool
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseMigration.DatabaseMigration dbm = new DatabaseMigration.DatabaseMigration();
            foreach(string nodeName in dbm.ListChangesets(dbm.LoadDocument("..\\..\\changelog.xml")))
            {
                Console.WriteLine(nodeName);
            }
            Console.ReadKey();
        }
    }
}
