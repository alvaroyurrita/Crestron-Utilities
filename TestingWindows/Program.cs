using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWindows
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = 1;
            var outTest = string.Format("{0:00}", test);
            Console.WriteLine(outTest);
            var test2 = "room1";
            var outTest2 = string.Format("{0:00}", test2);
            Console.WriteLine(outTest2);
            Console.ReadKey();
        }
    }
}
