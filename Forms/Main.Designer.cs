namespace evony_manager.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnRun = new Button();
            logText = new TextBox();
            picDeviceMonitor = new PictureBox();
            timerMonitor = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)picDeviceMonitor).BeginInit();
            SuspendLayout();
            // 
            // btnRun
            // 
            btnRun.Location = new Point(890, 378);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(75, 23);
            btnRun.TabIndex = 0;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // logText
            // 
            logText.Location = new Point(700, 12);
            logText.Multiline = true;
            logText.Name = "logText";
            logText.ScrollBars = ScrollBars.Both;
            logText.Size = new Size(265, 205);
            logText.TabIndex = 1;
            // 
            // picDeviceMonitor
            // 
            picDeviceMonitor.Dock = DockStyle.Left;
            picDeviceMonitor.Location = new Point(0, 0);
            picDeviceMonitor.Name = "picDeviceMonitor";
            picDeviceMonitor.Size = new Size(682, 413);
            picDeviceMonitor.SizeMode = PictureBoxSizeMode.Zoom;
            picDeviceMonitor.TabIndex = 2;
            picDeviceMonitor.TabStop = false;
            // 
            // timerMonitor
            // 
            timerMonitor.Interval = 500;
            timerMonitor.Tick += timerMonitor_Tick;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 413);
            Controls.Add(picDeviceMonitor);
            Controls.Add(logText);
            Controls.Add(btnRun);
            Name = "Main";
            Text = "Main";
            ((System.ComponentModel.ISupportInitialize)picDeviceMonitor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRun;
        private TextBox logText;
        private PictureBox picDeviceMonitor;
        private System.Windows.Forms.Timer timerMonitor;
    }
}