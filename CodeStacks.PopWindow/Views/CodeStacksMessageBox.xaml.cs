using System;
using System.Windows;
using System.Windows.Input;
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
            btnClose.CommandParameter = this;
        }

        public CodeStacksMessageBox(int delay) : this()
        {
            SetWindowSize();
            AutoCloseWindow.CloseWindow(this, 3);
        }

        public CodeStacksMessageBox(Window owner, int delay) : this(delay)
        {
            SetWindowSize();
        }

        public CodeStacksMessageBox(bool isAnimation, int delay) : this()
        {
            SetWindowSize();
            AutoCloseWindow.CloseWindow(this, gradient, "ClosedBrush", "ClosedStoryboard", delay);
        }

        private void SetWindowSize()
        {
            this.Height = 120;
            this.Width = 320;
        }

        public CodeStacksMessageBox(bool isCommon, string err) : this()
        {

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch (Exception)
            {
            }
        }
    }
}
