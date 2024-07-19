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
            //Process.Start("cmd.exe", "/c taskkill /F /IM adb.exe");
            //Thread.Sleep(1500);
            //Application.DoEvents();

            Process process = new Process();
            process.StartInfo.FileName = adbPath;
            process.StartInfo.Arguments = $"connect {strDeviceID}";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            activeDevice = strDeviceID;
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

        public static Bitmap CaptureScreenshot()
        {
            Process process = new Process();
            process.StartInfo.FileName = adbPath;
            process.StartInfo.Arguments = $"-s {activeDevice} shell screencap -p";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            var stream = process.StandardOutput.BaseStream;

            List<byte> data = new List<byte>(1024);

            int read = 0;
            bool isCR = false;
            do
            {
                byte[] buf = new byte[1024];
                read = stream.Read(buf, 0, buf.Length);

                for (int i = 0; i < read; i++)
                {
                    if (isCR && buf[i] == 0x0A)
                    {
                        isCR = false;
                        data.RemoveAt(data.Count - 1);
                        data.Add(buf[i]);
                        continue;
                    }
                    isCR = buf[i] == 0x0D;
                    data.Add(buf[i]);
                }
            }
            while (read > 0);

            if (data.Count == 0)
            {
                return null;
            }

            return new System.Drawing.Bitmap(new MemoryStream(data.ToArray()));
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
    }
}
