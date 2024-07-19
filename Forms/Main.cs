using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace evony_manager.Forms
{
    public partial class Main : Form
    {
        Bitmap aaPng;

        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aaPng = new Bitmap("aa.png");
            Common.ADB.Connect("127.0.0.1:5555");
            timerMonitor.Start();
        }


        void Console_Write(string text)
        {
            textBox1.AppendText(text);
        }

        private void timerMonitor_Tick(object sender, EventArgs e)
        {
            Mat src = Common.ADB.CaptureScreenshot().ToMat();

            Mat gray = new Mat();
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

            Mat edges = new Mat();
            Cv2.Canny(gray, edges, 100, 200);

            Bitmap processedBitmap = BitmapConverter.ToBitmap(edges);

            picDeviceMonitor.Image = processedBitmap;

            src.Dispose();
            gray.Dispose();
            edges.Dispose();
        }
    }
}
