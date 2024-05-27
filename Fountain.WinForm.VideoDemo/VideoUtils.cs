using AForge.Controls;
using AForge.Video.DirectShow;
using AForge.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Fountain.WinForm.VideoDemo
{
    public class VideoUtils
    {
        /// <summary>
        /// 开始录制
        /// </summary>       
        private bool startRecord = false;
        /// <summary>
        /// 暂停录制
        /// </summary>
        private bool pauseRecord = false;
        /// <summary>
        /// 视频捕获
        /// </summary>
        private VideoCaptureDevice videoCapture;
        /// <summary>
        /// 写视频文件
        /// </summary>
        private VideoFileWriter videoWriter;
        /// <summary>
        /// 
        /// </summary>
        private Thread writeTread;
        private VideoSourcePlayer videoplayer = new VideoSourcePlayer();
        /// <summary>
        /// 
        /// </summary>
        private Queue<Bitmap> frameQueue = new Queue<Bitmap>();
        /// <summary>
        /// 字幕
        /// </summary>
        public string SubTitle { get; set; }
        /// <summary>
        /// 界面同步显示委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ShowImageEventHandler(object sender, EventArgs e);
        /// <summary>
        /// 界面同步显示
        /// </summary>
        public event ShowImageEventHandler ShowImageEvent;
        // 触发事件的方法
        protected virtual void OnShowImaageEvent(object frame, EventArgs e)
        {
            try
            {
                ShowImageEventHandler handler = ShowImageEvent;
                Bitmap bitmap = (Bitmap)frame;
                handler?.Invoke(bitmap, e);
                bitmap = null;
            }
            catch
            {

            }
            finally
            {
                frame = null;
                GC.Collect();
            }
        }
        /// <summary>
        /// 打开设备
        /// </summary>
        public bool Open(int index,int videoCapabilitiesIdnex)
        {
            try
            {
                // 获取视频输入设备
                FilterInfoCollection devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                // 创建摄像头对象
                videoCapture = new VideoCaptureDevice(devices[index].MonikerString);
                // 指定视频大小
                videoCapture.VideoResolution = videoCapture.VideoCapabilities[videoCapabilitiesIdnex];
                // 指定视频帧率
                videoCapture.DesiredFrameRate = 30;
                // 挂载帧处理事件
                videoplayer.VideoSource = videoCapture;
                videoCapture.NewFrame += new AForge.Video.NewFrameEventHandler(VideoCapture_NewFrame);
                videoplayer.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 定义帧处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void VideoCapture_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = eventArgs.Frame;
            lock (bitmap)
            {
                if (startRecord)
                {
                    //写到文件
                    if (videoWriter.IsOpen==true)
                    {
                        frameQueue.Enqueue((Bitmap)bitmap.Clone());
                    }
                }
                this.OnShowImaageEvent(bitmap.Clone(), EventArgs.Empty);
            }
            bitmap.Dispose();
            GC.Collect();
        }
        /// <summary>
        /// 断开设备
        /// </summary>
        public void Close()
        {
            this.startRecord = false;
            this.pauseRecord = false;
            while (frameQueue.Count>0)
            {
                continue;
            }
            // 
            this.videoCapture.SignalToStop();
            //
            this.videoCapture?.WaitForStop();
            // 
            this.videoWriter?.Close();
            GC.Collect();
        }
        /// <summary>
        /// 暂停
        /// </summary>   
        public void Pause()
        {
            if (this.startRecord)
            {
                this.pauseRecord = true;
                this.startRecord = false;
            }
        }
        /// <summary>
        /// 开始录制
        /// </summary>  
        public void Start(string videoFileName)
        {
            if (!this.startRecord)
            {
                if (this.pauseRecord)
                {
                    this.startRecord = true;
                    this.pauseRecord = false;
                    return;
                }
                // 
                string videoPath = string.Format("{0}Camera{1}", AppDomain.CurrentDomain.BaseDirectory,Path.DirectorySeparatorChar);
                if (!Directory.Exists(videoPath))
                {
                    Directory.CreateDirectory(videoPath);
                }
                // 
                int width = this.videoCapture.VideoResolution.FrameSize.Width;
                int heigth = this.videoCapture.VideoResolution.FrameSize.Height;
                this.videoWriter =new VideoFileWriter();
                // 
                this.videoWriter.Open(string.Format("{0}{1}",videoPath,videoFileName), width, heigth,15, VideoCodec.H264, 6000);
                //
                this.startRecord = true;
                this.pauseRecord = false;
                // 
                Task.Run(() => SaveFrame());
            }
        }
        /// <summary>
        /// 停止录制
        /// </summary>
        public void Stop()
        {
            this.startRecord = false;
            this.pauseRecord = false;
            Thread.Sleep(20);
            this.videoWriter?.Close();
        }
        /// <summary>
        /// 截图拍照
        /// </summary>   
        public Bitmap TakePhoto()
        {
            try
            {
                Bitmap bitmap = (Bitmap)this.videoplayer.GetCurrentVideoFrame().Clone();
                return bitmap;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        /// <summary>
        /// 保存帧到视频文件
        /// </summary>
        private void SaveFrame()
        {
            while (startRecord || frameQueue.Count > 0)
            {
                if (frameQueue.Count > 0)
                {
                    using (Bitmap frame= frameQueue.Dequeue())
                    {
                        if (videoWriter != null && videoWriter.IsOpen == true)
                        {
                            // 写入
                            videoWriter?.WriteVideoFrame(frame);
                        }
                    }
                    GC.Collect();
                }
            }
            if (frameQueue.Count == 0)
            {
                videoWriter?.Close();
            }
        }
    }
}
