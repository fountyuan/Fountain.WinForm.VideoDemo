using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Management;
using System.Windows.Forms;

namespace Fountain.WinForm.VideoDemo
{
    public partial class FormVideo : Form
    {
        /// <summary>
        /// 视频录制类
        /// </summary>
        VideoUtils videoUtils = new VideoUtils();
        /// <summary>
        /// 构造方法
        /// </summary>
        public FormVideo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVideo_Load(object sender, EventArgs e)
        {
            videoUtils.ShowImageEvent += EventHandler;
            this.GetCameras();
        }
        /// <summary>
        /// 获取摄像头设备
        /// </summary>
        public void GetCameras()
        {
            List<string> vidoeDevices = new List<string>();

            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE (PNPClass = 'Image' OR PNPClass = 'Camera')"))
            {
                foreach (var device in searcher.Get())
                {
                    if (device["Caption"] != null)
                    {
                        vidoeDevices.Add(Convert.ToString(device["Caption"]));
                    }
                }
            }
            this.comboBoxVideoInputDevice.DataSource = vidoeDevices;
        }
        /// <summary>
        /// 打开设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxVideoInputDevice.Items.Count > 0)
                {
                    bool result = videoUtils.Open(comboBoxVideoInputDevice.SelectedIndex,3);
                    if (!result)
                    {
                        MessageBox.Show("摄像头连接失败！");
                        return;
                    }
                    MessageBox.Show("摄像头连接成功！");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// 开始录制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                videoUtils.Start(DateTime.Now.ToString("yyyyMMddHHmmss")+".mp4");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// 暂停录制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPause_Click(object sender, EventArgs e)
        {
            try
            {
                videoUtils.Pause();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// 停止录制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            try
            {
                videoUtils.Stop();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTakePhoto_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmap = videoUtils.TakePhoto();
                string imagePath = string.Format("{0}Image{1}", AppDomain.CurrentDomain.BaseDirectory, Path.DirectorySeparatorChar);
                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                }
                string imageFileName = string.Format("{0}{1}.bmp", imagePath, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                bitmap.Save(imageFileName);
                MessageBox.Show($"拍照成功文件保存在{imageFileName}");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// 断开设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                videoUtils.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// 显示视频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventHandler(object sender, EventArgs e)
        {
            try
            {
                this.pictureBox.Image = (Bitmap)sender;
            }
            catch
            {

            }
        }
    }
}
