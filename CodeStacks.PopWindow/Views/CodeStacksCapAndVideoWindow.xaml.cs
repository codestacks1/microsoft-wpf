using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Input;
using Xiaowen.CodeStacks.Data;
using Xiaowen.CodeStacks.Data.SenSingModels;
using Xiaowen.CodeStacks.PopWindow.Utilities;

namespace Xiaowen.CodeStacks.PopWindow.Views
{
    /// <summary>
    /// CodeStacksCapAndVideoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CodeStacksCapAndVideoWindow : Window
    {
        List<string> listVideo = new List<string>();
        List<byte[]> listCap = new List<byte[]>();

        public CodeStacksCapAndVideoWindow()
        {
            InitializeComponent();

        }
        public CodeStacksCapAndVideoWindow(string strTitle, List<byte[]> listcap, List<string> listvideo)
        {
            InitializeComponent();
            this.Name = strTitle;
            this.Title = strTitle;
            this.listCap = listcap;
            this.listVideo = listvideo;

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
                    this.Cursor = Cursors.Arrow;
                }
                else
                {
                    gridCap.Visibility = Visibility.Collapsed;
                    gridVideo.Visibility = Visibility.Visible;
                    this.Height = 500;
                    this.Width = 700;

                    string pluginPath = System.Environment.CurrentDirectory + "\\vlc\\plugins\\";
                    vlc_player_ = new VlcVideoPlayer(pluginPath);
                    IntPtr render_wnd = this.wfh.Child.Handle;
                    vlc_player_.SetRenderWindow((int)render_wnd);

                    VideoPlay(listVideo);
                    this.Cursor = Cursors.Arrow;
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
        private VlcVideoPlayer vlc_player_;

        void VideoPlay(List<string> list)
        {
            if (list.Count > 0)
            {
                List<string> listNewVideo = new List<string>();
                List<string> listName = new List<string>();
                string strPath = System.Windows.Forms.Application.StartupPath + "\\Video";

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
                            while (IsFileInUse(i.FullName))
                            {

                            }
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

                vlc_player_.PlayFile(strPath);
                playBtn.Content = "Stop";
                playBtn.IsEnabled = true;
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
            vlc_player_.Pause();
            if (playBtn.Content.ToString() == "Stop")
                playBtn.Content = "Play";
            else
                playBtn.Content = "Stop";
        }

        private void listPlays_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string strPath = System.Windows.Forms.Application.StartupPath + "\\Video\\" + listPlays.SelectedItem.ToString();
            vlc_player_.PlayFile(strPath);
            playBtn.Content = "Stop";
            playBtn.IsEnabled = true;
        }
        /// <summary>
        /// 判断文件是否被占用
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool IsFileInUse(string fileName)
        {
            bool inUse = true;

            FileStream fs = null;
            try
            {

                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read,

                FileShare.None);

                inUse = false;
            }
            catch
            {

            }
            finally
            {
                if (fs != null)

                    fs.Close();
            }
            return inUse;//true表示正在使用,false没有使用  
        }

        #endregion

    }
}
