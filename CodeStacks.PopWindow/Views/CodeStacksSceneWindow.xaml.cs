using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Xiaowen.CodeStacks.PopWindow.Views
{

    /// <summary>
    /// CodeStacksSceneWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CodeStacksSceneWindow : Window
    {

        public ImageSource Source = null;
        public CodeStacksSceneWindow()
        {
            InitializeComponent();

            this.Name = "Scene";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Source != null)
            {
                img.Source = Source;
            }
        }
    }
}
