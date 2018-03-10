using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedConfigurationLibrary
{
    public class UsbConnection
    {
        public void M()
        {
            var drives = DriveInfo.GetDrives()
                         .Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable)
                         .OrderBy(drive => drive.Name)
                         .Select(drive => drive.Name);

            if (drives.Count<string>() > 0)
            {
                if (!File.Exists(drives.First() + "\\test.txt"))
                {
                    FileStream fs = new FileStream(drives.First() + "\\test.txt", FileMode.CreateNew, FileAccess.ReadWrite);
                    StreamWriter sr = new StreamWriter(fs);
                    sr.WriteLine("Hello !");
                    sr.Close();
                }
            }

        }
    }
}
