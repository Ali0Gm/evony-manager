using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace evony_manager.Common
{
    public static class ADB
    {
        private static string adbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "adb", "adb.exe");
        private static string activeDevice = "";

        public static void Connect(string strDeviceID)
        {
            ExecuteAdbCommand($"connect {strDeviceID}");
            activeDevice = strDeviceID;
        }

        public static void Disconnect(string strDeviceID)
        {
            ExecuteAdbCommand($"disconnect {strDeviceID}");
            activeDevice = "";
        }

        public static string Command(string strCommand)
        {
            return ExecuteAdbCommand(strCommand);
        }

        public static List<string> DeviceList()
        {
            var output = ExecuteAdbCommand("devices");
            var devices = new List<string>();
            var lines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            foreach (var line in lines)
            {
                if (line.EndsWith("device"))
                {
                    var device = line.Split('\t')[0];
                    devices.Add(device);
                }
            }
            return devices;
        }

        public static byte[] CaptureScreenshot()
        {
            return ExecuteAdbCommandForBinary("shell screencap -p");
        }

        private static string ExecuteAdbCommand(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = adbPath;
            process.StartInfo.Arguments = $"-s {activeDevice} {command}";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return result;
        }

        private static byte[] ExecuteAdbCommandForBinary(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = adbPath;
            process.StartInfo.Arguments = $"-s {activeDevice} {command}";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            using (var ms = new MemoryStream())
            {
                process.StandardOutput.BaseStream.CopyTo(ms);
                process.WaitForExit();
                return ms.ToArray();
            }
        }
    }
}
