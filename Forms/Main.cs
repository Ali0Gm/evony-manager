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
using evony_manager.Common;

namespace evony_manager.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            // Initialize ADB connection
            Common.ADB.Connect("127.0.0.1:5555");

            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        void Console_Write(string text)
        {
            textBox1.AppendText(text);

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Capture screenshot on the device
            byte[] screenshotData = Common.ADB.CaptureScreenshot();

            Console_Write(screenshotData.ToString());

            // Process the screenshot using OpenCV
            ProcessScreenshot(screenshotData);
        }

        private void ProcessScreenshot(byte[] imageData)
        {
            // Load the screenshot from memory
            using (var ms = new MemoryStream(imageData))
            {
                Mat src = Mat.FromStream(ms, ImreadModes.Color);

                // Check if the image is loaded
                if (src.Empty())
                {
                    Console_Write("Could not open or find the image!");
                    return;
                }

                // Convert the image to grayscale
                Mat gray = new Mat();
                Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

                // Process the grayscale image (example: detect edges)
                Mat edges = new Mat();
                Cv2.Canny(gray, edges, 100, 200);

                // Display or further process the edges Mat as needed

                // Cleanup
                src.Dispose();
                gray.Dispose();
                edges.Dispose();
            }
        }
    }
}
