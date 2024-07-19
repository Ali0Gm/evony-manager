using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using System.Diagnostics;

namespace evony_manager.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var process = new System.Diagnostics.Process();
            var start = new System.Diagnostics.ProcessStartInfo()
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "adb", "adb.exe"),
                Arguments = "-s 127.0.0.1:5555 shell screencap -p"
            };
            process.StartInfo = start;
            process.Start();
            var stream = process.StandardOutput.BaseStream;
            List<byte> data = new List<byte>(1024);

            int read = 0;
            bool isCR = false;
            do
            {
                byte[] buf = new byte[1024];
                read = stream.Read(buf, 0, buf.Length);

                for (int i = 0; i < read; i++) //convert CRLF to LF 
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
                Console_Write("fail");
                return;
            }

            picDeviceMonitor.Image = new System.Drawing.Bitmap(new MemoryStream(data.ToArray()));
        }
    

        void Console_Write(string text)
        {
            textBox1.AppendText(text);
        }
    }
}
