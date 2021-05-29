using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Crestron.SimplSharp;
using Crestron.SimplSharp.CrestronIO;


namespace CrestronUtilities
{
    public static class Logger
    {
        private static string SlotNo = "";
       // private static string ProgName = "";

        static Logger()
        {
            var CurrentDirectory = Directory.GetApplicationDirectory();
            var NewLine = CrestronEnvironment.NewLine;
            var Files = String.Join(NewLine, Directory.GetFiles(CurrentDirectory));
            SlotNo = String.Format("{0:00}", InitialParametersClass.RoomId);
            //SlotNo = Regex.Match(CurrentDirectory, @"(?<=[aA]pp)\d\d").Value;
            /* Finds the running program name. No longer needed. Use SlotNo instead. 
            var Found = Regex.Match(Files, @"(?<=[aA]pp\d\d[\\\/]).*(?=.bin)", System.Text.RegularExpressions.RegexOptions.Multiline);
            if (Found.Success)
            {
                var ProgName = Found.Value;
            }
            if (Files.Contains("ProgramInfo.config"))
            {
                var ProgramInfo = File.ReadToEnd(Path.Combine(CurrentDirectory, "ProgramInfo.config"), System.Text.Encoding.UTF8);
                ProgName = Regex.Match(ProgramInfo, @"(?<=SystemName>).*(?=<)").Value;
            }*/
        }
        static string format(string path, long linenumber, string member, string message)
        {
            var ProgName = Regex.Match(path, @"([^\\\/]+)$").Value;
            return String.Format($"[{SlotNo}-{ProgName}-{member}-{linenumber}] {message}");
        }

        public static void Error(String message,
            [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] long callerLineNumber = 0,
            [CallerMemberName] string callerMember = "")
        {
            ErrorLog.Error(format(callerFilePath, callerLineNumber, callerMember, message));
        }

        public static void Notice(String message,
            [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] long callerLineNumber = 0,
            [CallerMemberName] string callerMember = "")
        {
            ErrorLog.Notice(format(callerFilePath, callerLineNumber, callerMember, message));
        }

        public static void Warn(String message,
            [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] long callerLineNumber = 0,
            [CallerMemberName] string callerMember = "")
        {
            ErrorLog.Warn(format(callerFilePath, callerLineNumber, callerMember, message));
        }

        public static void Console(String message,
            [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] long callerLineNumber = 0,
            [CallerMemberName] string callerMember = "")
        {
            CrestronConsole.PrintLine(format(callerFilePath, callerLineNumber, callerMember, message));
        }
    }
}
