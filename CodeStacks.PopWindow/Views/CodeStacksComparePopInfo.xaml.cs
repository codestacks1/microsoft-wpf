using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using xiaowen.codestacks.data;
using xiaowen.codestacks.data.SenSingModels;

namespace xiaowen.codestacks.popwindow.Views
{
    /// <summary>
    /// Interaction logic for CodeStacksComparePopInfo.xaml
    /// </summary>
    public partial class CodeStacksComparePopInfo : Window
    {
        public CodeStacksComparePopInfo()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += CompInfo_MouseLeftButtonDown;
        }

        private void CompInfo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch (Exception)
            {
            }
        }

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="compare"></param>
        public void SetResultValue(Compare compare)
        {
            try
            {
                GridAll.Dispatcher.BeginInvoke(new Action(() =>
                {
                    GridAll.Background = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri(compare.Template.TypePhotoPath))
                    };
                }));
                Captype.Content = compare.Captype;
                image_capImage.Source = compare.Snap.Photo;
                image_cmpImage.Source = compare.Template.PersonInfo.Photo;
                label_Socre.Text = compare.Score.ToString();
                label_TemplateName.Text = compare.Template.PersonInfo.Name;
                label_TemplateType.Text = compare.Template.TypeValue;
                label_CapTime.Text = compare.Snap.DateTime;
                label_CapChannel.Text = compare.Camera.Location;
                image_SenceImg.Source = compare.Snap.EnvironmentPhoto;
            }
            catch (Exception ex)
            {
                CodeStacksWindow.MessageBox.Invoke(true, false, 2, ex.Message);
            }

        }
    }
}
