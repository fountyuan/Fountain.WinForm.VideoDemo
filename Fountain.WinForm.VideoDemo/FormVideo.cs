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
        /// ��Ƶ¼����
        /// </summary>
        VideoUtils videoUtils = new VideoUtils();
        /// <summary>
        /// ���췽��
        /// </summary>
        public FormVideo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVideo_Load(object sender, EventArgs e)
        {
            videoUtils.ShowImageEvent += EventHandler;
            this.GetCameras();
        }
        /// <summary>
        /// ��ȡ����ͷ�豸
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
        /// ���豸
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
                        MessageBox.Show("����ͷ����ʧ�ܣ�");
                        return;
                    }
                    MessageBox.Show("����ͷ���ӳɹ���");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// ��ʼ¼��
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
        /// ��ͣ¼��
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
        /// ֹͣ¼��
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
        /// ����
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
                MessageBox.Show($"���ճɹ��ļ�������{imageFileName}");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// �Ͽ��豸
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
        /// ��ʾ��Ƶ
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
