using System;
using Crestron.SimplSharp;
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
                        var SlotNo = InitialParametersClass.RoomId;
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
