using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Crestron.SimplSharp.CrestronIO;

namespace CrestronUtilities
{
    public static class FileUtilities
    {
        public static string GetFullPath(string PartialFilenamePath, bool isRemote = false)
        {
            string FullFilenamePath;
            if (Path.IsPathRooted(PartialFilenamePath)) FullFilenamePath = PartialFilenamePath;
            else
            {
                string RootDirectory;
                if (isRemote)
                {
                    var ApplicationDirectory = Directory.GetApplicationRootDirectory();
                    if (ApplicationDirectory == "")
                    {
                        ApplicationDirectory = Path.DirectorySeparatorChar.ToString();
                        var NvramDir = Path.Combine(ApplicationDirectory, "nvram");
                        var CurrentDirectory = Directory.GetApplicationDirectory();
                        var SlotNo = Regex.Match(CurrentDirectory, @"(?<=[aA]pp)\d\d").Value;
                        RootDirectory = Path.Combine(NvramDir, string.Format("Slot_{0:00}", SlotNo));
                    }
                    else
                    {
                        RootDirectory = Path.Combine(ApplicationDirectory, "user");
                    }  

                }
                else
                {
                    RootDirectory = Directory.GetApplicationDirectory();
                }
                FullFilenamePath = Path.Combine(RootDirectory, PartialFilenamePath);
            }
            var FilenameDirectoryPath = Path.GetDirectoryName(FullFilenamePath);
            try
            {
                if (!Directory.Exists(FilenameDirectoryPath))
                {
                    Directory.Create(FilenameDirectoryPath);
                    Logger.Warn($"Path {FilenameDirectoryPath} did not exists. It has been created");
                    Logger.Console($"Path {FilenameDirectoryPath} did not exists. It has been created");
                }
            }
            catch (Exception)
            {
                Logger.Warn($"Error Creating full path for {FilenameDirectoryPath}");
                return "";
            }
            if (File.Exists(FullFilenamePath)) return FullFilenamePath;
            return "";
        }
    }
}
