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
            var test = "/simpl/app01/path/test.txt";
            var outTest = test.Split('/');
            Console.ReadKey();
        }
    }
}
