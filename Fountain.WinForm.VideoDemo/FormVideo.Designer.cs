
namespace Fountain.WinForm.VideoDemo
{
    partial class FormVideo
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelInfo = new System.Windows.Forms.Panel();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.labelLine = new System.Windows.Forms.Label();
            this.buttonTakePhoto = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.labelVideoInputDevice = new System.Windows.Forms.Label();
            this.comboBoxVideoInputDevice = new System.Windows.Forms.ComboBox();
            this.panelImage = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panelInfo.SuspendLayout();
            this.panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.buttonDisconnect);
            this.panelInfo.Controls.Add(this.labelLine);
            this.panelInfo.Controls.Add(this.buttonTakePhoto);
            this.panelInfo.Controls.Add(this.buttonStop);
            this.panelInfo.Controls.Add(this.buttonPause);
            this.panelInfo.Controls.Add(this.buttonStart);
            this.panelInfo.Controls.Add(this.buttonOpen);
            this.panelInfo.Controls.Add(this.labelVideoInputDevice);
            this.panelInfo.Controls.Add(this.comboBoxVideoInputDevice);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(722, 107);
            this.panelInfo.TabIndex = 0;
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(621, 30);
            this.buttonDisconnect.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(96, 31);
            this.buttonDisconnect.TabIndex = 8;
            this.buttonDisconnect.Text = "断开设备";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // labelLine
            // 
            this.labelLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelLine.Location = new System.Drawing.Point(0, 105);
            this.labelLine.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelLine.Name = "labelLine";
            this.labelLine.Size = new System.Drawing.Size(722, 2);
            this.labelLine.TabIndex = 7;
            // 
            // buttonTakePhoto
            // 
            this.buttonTakePhoto.Location = new System.Drawing.Point(511, 69);
            this.buttonTakePhoto.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonTakePhoto.Name = "buttonTakePhoto";
            this.buttonTakePhoto.Size = new System.Drawing.Size(96, 31);
            this.buttonTakePhoto.TabIndex = 6;
            this.buttonTakePhoto.Text = "拍照";
            this.buttonTakePhoto.UseVisualStyleBackColor = true;
            this.buttonTakePhoto.Click += new System.EventHandler(this.buttonTakePhoto_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(403, 69);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(96, 31);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "停止录制";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(295, 69);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(96, 31);
            this.buttonPause.TabIndex = 4;
            this.buttonPause.Text = "暂停录制";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(187, 69);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(96, 31);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "开始录制";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(513, 30);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(96, 31);
            this.buttonOpen.TabIndex = 2;
            this.buttonOpen.Text = "打开设备";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // labelVideoInputDevice
            // 
            this.labelVideoInputDevice.Location = new System.Drawing.Point(6, 31);
            this.labelVideoInputDevice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelVideoInputDevice.Name = "labelVideoInputDevice";
            this.labelVideoInputDevice.Size = new System.Drawing.Size(182, 28);
            this.labelVideoInputDevice.TabIndex = 1;
            this.labelVideoInputDevice.Text = "视频设备";
            this.labelVideoInputDevice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxVideoInputDevice
            // 
            this.comboBoxVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVideoInputDevice.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxVideoInputDevice.FormattingEnabled = true;
            this.comboBoxVideoInputDevice.Location = new System.Drawing.Point(189, 31);
            this.comboBoxVideoInputDevice.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.comboBoxVideoInputDevice.Name = "comboBoxVideoInputDevice";
            this.comboBoxVideoInputDevice.Size = new System.Drawing.Size(323, 28);
            this.comboBoxVideoInputDevice.TabIndex = 0;
            // 
            // panelImage
            // 
            this.panelImage.Controls.Add(this.pictureBox);
            this.panelImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImage.Location = new System.Drawing.Point(0, 107);
            this.panelImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(722, 337);
            this.panelImage.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(189, 10);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(420, 313);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // FormVideo
            // 
            this.ClientSize = new System.Drawing.Size(722, 444);
            this.Controls.Add(this.panelImage);
            this.Controls.Add(this.panelInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVideo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "录制视频";
            this.Load += new System.EventHandler(this.FormVideo_Load);
            this.panelInfo.ResumeLayout(false);
            this.panelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelVideoInputDevice;
        private System.Windows.Forms.ComboBox comboBoxVideoInputDevice;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonTakePhoto;
        private System.Windows.Forms.Label labelLine;
        private System.Windows.Forms.Button buttonDisconnect;
    }
}
