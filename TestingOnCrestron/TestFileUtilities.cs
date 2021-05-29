using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrestronUtilities;
using Crestron.SimplSharp.CrestronIO;

namespace TestingOnCrestron
{
    public static class TestFileUtilities
    {
        public static void GetFullPath()
        {
            string PathToTest = Path.Combine("Path1", "file.txt");
            var FullPath = FileUtilities.GetFullPath(PathToTest);
            Logger.Notice(FullPath);
            Logger.Console(FullPath);

            string PathToTest2 = Path.Combine("Path1", "file.txt");
            var FullPath2 = FileUtilities.GetFullPath(PathToTest, true);
            Logger.Notice(FullPath);
            Logger.Console(FullPath);
        }
    }
}
