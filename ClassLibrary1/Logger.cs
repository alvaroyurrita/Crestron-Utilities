﻿using System;
using System.Runtime.CompilerServices;
using Crestron.SimplSharp;


namespace CrestronUtilities
{
    public static class Logger
    {
        static string format(string path, long linenumber, string member, string message)
        {
            return String.Format("[*TCL*] {0}: {1} [{2}] - {3}", path, linenumber, member, message);
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
