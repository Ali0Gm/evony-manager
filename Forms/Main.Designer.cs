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
            button1 = new Button();
            textBox1 = new TextBox();
            picDeviceMonitor = new PictureBox();
            timerMonitor = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)picDeviceMonitor).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(890, 378);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(700, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(265, 205);
            textBox1.TabIndex = 1;
            // 
            // picDeviceMonitor
            // 
            picDeviceMonitor.Location = new Point(12, 12);
            picDeviceMonitor.Name = "picDeviceMonitor";
            picDeviceMonitor.Size = new Size(682, 393);
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
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Main";
            Text = "Main";
            ((System.ComponentModel.ISupportInitialize)picDeviceMonitor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private PictureBox picDeviceMonitor;
        private System.Windows.Forms.Timer timerMonitor;
    }
}