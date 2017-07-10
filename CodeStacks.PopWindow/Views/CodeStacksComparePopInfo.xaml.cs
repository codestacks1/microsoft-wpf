using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Xiaowen.CodeStacks.Data.SenSingModels;
using Xiaowen.CodeStacks.PopWindow.Utilities;
using Xiaowen.CodeStacks.PopWindow.ViewModels;
using Xiaowen.CodeStacks.Wpf.Utilities;

namespace Xiaowen.CodeStacks.PopWindow.Views
{
    /// <summary>
    /// Interaction logic for CodeStacksComparePopInfo.xaml
    /// </summary>
    public partial class CodeStacksComparePopInfo : Window
    {
        public CodeStacksComparePopInfoViewModel vModel;
        System.Collections.Generic.List<string> listVideo = new System.Collections.Generic.List<string>(); // 视频地址列表

        System.Collections.Generic.List<byte[]> listCap = new System.Collections.Generic.List<byte[]>(); //抓拍照片列表
        public CodeStacksComparePopInfo()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += CompInfo_MouseLeftButtonDown;
            vModel = new CodeStacksComparePopInfoViewModel();
            vModel.Person = new Person();
            vModel.Camera = new Camera();
            this.DataContext = vModel;
        }

        private void CompInfo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="compare"></param>
        public void SetResultValue(Compare compare, params object[] param)
        {
            try
            {
                SolidColorBrush colorBrush = new SolidColorBrush();
                switch (compare.Template.TypeKey)
                {
                    case 0:
                        colorBrush = new SolidColorBrush(Color.FromRgb(0, 109, 132));//蓝
                        break;
                    case 1:
                        colorBrush = new SolidColorBrush(Color.FromRgb(0, 109, 132));
                        break;
                    case 2:
                        colorBrush = new SolidColorBrush(Color.FromRgb(122, 16, 59));//红
                        break;
                    case 3:
                        colorBrush = new SolidColorBrush(Color.FromRgb(214, 121, 10));//橙
                        break;
                    case 4:
                        colorBrush = new SolidColorBrush(Color.FromRgb(194, 184, 15));//黄
                        break;
                    default:
                        colorBrush = new SolidColorBrush(Color.FromRgb(0, 109, 132));
                        break;
                }

                GridAll.Dispatcher.BeginInvoke(new Action(() =>
                {
                    //GridAll.Background = new ImageBrush
                    //{
                    //    ImageSource = new BitmapImage(new Uri(compare.Template.TypePhotoPath))
                    //};
                    GridAll.Background = colorBrush;

                }));

                Captype.Content = compare.Captype;
                image_capImage.Source = compare.Snap.Photo;
                image_cmpImage.Source = compare.Template.PersonInfo.Photo;
                label_Socre.Text = compare.Score.ToString();
                label_TemplateName.Text = vModel.Person.Name = compare.Template.PersonInfo.Name;
                label_TemplateType.Text = compare.Template.TypeValue;
                label_CapTime.Text = compare.Snap.DateTime;
                label_CapChannel.Text = vModel.Camera.Location = compare.Camera.Location;
                image_SenceImg.Source = compare.Snap.EnvironmentPhoto;
                listCap = (System.Collections.Generic.List<byte[]>)compare.Content1;
                listVideo = (System.Collections.Generic.List<string>)compare.Content2;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        Popup popup = new Popup();
        private void label_TemplateName_MouseEnter(object sender, MouseEventArgs e)
        {
            popup.Child = new CodeStacksHintControlView(popup, vModel.Person.Name);
            popup.IsOpen = true;
        }

        private void label_TemplateName_MouseLeave(object sender, MouseEventArgs e)
        {
            popup.IsOpen = false;
        }

        private void btnCap_Click(object sender, RoutedEventArgs e)
        {
            List<Window> windows = new List<Window>();
            foreach (Window window in Application.Current.Windows)
            {
                windows.Add(window);
            }

            if (windows.FirstOrDefault(x => x.Name == "抓拍记录") == null)
            {
                CodeStacksCapAndVideoWindow CapVideo = new CodeStacksCapAndVideoWindow("抓拍记录", listCap, listVideo);
                CapVideo.ShowDialog();
            }
            else
            {
                windows.FirstOrDefault(x => x.Name == "抓拍记录").Activate();
            }
        }

        private void btnVideo_Click(object sender, RoutedEventArgs e)
        {
            List<Window> windows = new List<Window>();
            foreach (Window window in Application.Current.Windows)
            {
                windows.Add(window);
            }

            if (windows.FirstOrDefault(x => x.Name == "视频回放") == null)
            {
                CodeStacksCapAndVideoWindow CapVideo = new CodeStacksCapAndVideoWindow("视频回放", listCap, listVideo);
                CapVideo.ShowDialog();
            }
            else
            {
                windows.FirstOrDefault(x => x.Name == "视频回放").Activate();
            }
        }
        private void SaveAs1_Click(object sender, RoutedEventArgs e)
        {
            CodeStacksDataStorage.ImageSaveAs((BitmapImage)image_capImage.Source);
        }

        private void SaveAs2_Click(object sender, RoutedEventArgs e)
        {
            CodeStacksDataStorage.ImageSaveAs((BitmapImage)image_cmpImage.Source);
        }

        private void GroupBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<Window> windows = new List<Window>();
            foreach (Window window in Application.Current.Windows)
            {
                windows.Add(window);
            }

            if (windows.FirstOrDefault(x => x.Name == "Scene") == null)
            {
                CodeStacksSceneWindow sceneWin = new CodeStacksSceneWindow();
                sceneWin.Source = image_SenceImg.Source;
                sceneWin.Show();
                sceneWin.Activate();
            }
            else
            {
                windows.FirstOrDefault(x => x.Name == "Scene").Activate();
            }
        }
    }
}
