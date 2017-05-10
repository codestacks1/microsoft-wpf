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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using xiaowen.codestacks.popwindow.Utilities;

namespace xiaowen.codestacks.popwindow.Views
{
    /// <summary>
    /// Interaction logic for CodeStacksMessageBox.xaml
    /// </summary>
    public partial class CodeStacksMessageBox : Window
    {
        public CodeStacksMessageBox()
        {
            InitializeComponent();
        }

        public CodeStacksMessageBox(int delay) : this()
        {
            AutoCloseWindow.CloseWindow(this, 3);
        }

        public CodeStacksMessageBox(Window owner, int delay) : this(delay)
        {

        }

        public CodeStacksMessageBox(bool isAnimation) : this()
        {

        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.IsEnabled = false;
            gradient.OpacityMask = this.Resources["ClosedBrush"] as LinearGradientBrush;
            Storyboard stb = this.Resources["ClosedStoryboard"] as Storyboard;
            stb.Completed += delegate { this.Close(); };

            stb.Begin();
        }
    }
}
