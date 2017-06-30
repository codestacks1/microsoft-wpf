using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Xiaowen.CodeStacks.Data;
using Xiaowen.CodeStacks.Data.SenSingModels;

namespace Xiaowen.CodeStacks.PopWindow.Views
{
    /// <summary>
    /// CodeStacksCapAndVideoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CodeStacksCapAndVideoWindow : Window
    {
        List<string> listVideo = new List<string>();
        List<byte[]> listCap = new List<byte[]>();
        BitmapImage imgPlay = CodeStacksDataHandler.ImageData.ConvertToImageSourceDelegate1("pack://application:,,,/Gallery/play.png");
        BitmapImage imgPause = CodeStacksDataHandler.ImageData.ConvertToImageSourceDelegate1("pack://application:,,,/Gallery/pause.png");

        public CodeStacksCapAndVideoWindow()
        {
            InitializeComponent();
        }
        public CodeStacksCapAndVideoWindow(string strTitle,List<byte[]> listcap,List<string> listvideo)
        {
            InitializeComponent();
            this.Title = strTitle;
            this.listCap = listcap;
            this.listVideo = listvideo;
            try
            {
                imgPlay = new BitmapImage(new Uri(System.Windows.Forms.Application.StartupPath+ @"/Images/play.png"));
                imgPause = new BitmapImage(new Uri(System.Windows.Forms.Application.StartupPath + @"/Images/pause.png"));

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.Title == "抓拍记录")
                {
                    gridCap.Visibility = Visibility.Visible;
                    gridVideo.Visibility = Visibility.Collapsed;
                    ShowCapImg(listCap);
                }
                else
                {
                    gridCap.Visibility = Visibility.Collapsed;
                    gridVideo.Visibility = Visibility.Visible;
                    this.Height = 420;
                    this.Width = 600;
                    VideoPlay(listVideo);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        #region 抓拍记录
        void ShowCapImg(List<byte[]> list)
        {
            List<Person> listImg = new List<Person>();
            foreach (byte[] b in list)
            {
                Person p = new Person();
                p.Photo = CodeStacksDataHandler.ImageData.ConvertToBitmapImageDelegate1(b);
                listImg.Add(p);
            }
            CapList.ItemsSource = listImg;
        }
        #endregion

        #region 视频播放
        void VideoPlay(List<string> list)
        {
            if (list.Count > 0)
            {
                List<string> listNewVideo = new List<string>();
                List<string> listName = new List<string>();
                string strPath = System.Windows.Forms.Application.StartupPath+"\\Video";

                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }
                else
                {
                    DirectoryInfo dir = new DirectoryInfo(strPath);
                    FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                    foreach (FileSystemInfo i in fileinfo)
                    {
                        if (i is DirectoryInfo)            //判断是否文件夹
                        {
                            DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                            subdir.Delete(true);          //删除子目录和文件
                        }
                        else
                        {
                            File.Delete(i.FullName);      //删除指定文件
                        }
                    }
                }

                foreach (string strname in list)
                {
                    listName.Add(System.IO.Path.GetFileName(strname));
                    string strNew = HttpDownloadFile(strname, strPath + "\\" + System.IO.Path.GetFileName(strname));
                    listNewVideo.Add(strNew);
                }

                listPlays.ItemsSource = listName;
                strPath = listNewVideo[0];
                mediaElement.Close();
                mediaElement.LoadedBehavior = MediaState.Manual;
                mediaElement.Source = new Uri(strPath, UriKind.Absolute);
                mediaElement.Play();
            }
        }

        /// <summary>
        /// Http下载文件
        /// </summary>
        public static string HttpDownloadFile(string url, string path)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();
            //创建本地文件写入流
            Stream stream = new FileStream(path, FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            responseStream.Close();
            return path;
        }

        //开始播放
        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
            mediaElement.ToolTip = "开始播放";
        }
        //停止播放
        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
            mediaElement.ToolTip = "停止播放";
        }
        //后退
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = mediaElement.Position - TimeSpan.FromSeconds(10);
        }
        //前进
        private void forwardBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = mediaElement.Position + TimeSpan.FromSeconds(10);
        }

        private void listPlays_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string strPath = System.Windows.Forms.Application.StartupPath + "\\Video\\" + listPlays.SelectedItem.ToString();
            mediaElement.Dispatcher.Invoke(()=>
            {
                mediaElement.Close();
                mediaElement.LoadedBehavior = MediaState.Manual;
                mediaElement.Source = new Uri(strPath, UriKind.Absolute);
                mediaElement.Play();
            } );
        }

        #endregion

        //private void media_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    if (listVideo != null && listVideo.Count > 0)
        //    {
        //        for (int i = 1; i < listVideo.Count; i++)
        //        {
        //            string strPath = listVideo[i];
        //            media.Source = new Uri(strPath, UriKind.Absolute);
        //        }
        //    }
        //}

    }
}
