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
        public string ErrText { get; set; }

        public CodeStacksMessageBox()
        {
            InitializeComponent();
            btnClose.CommandParameter = this;
            btnconfirm.CommandParameter = this;
            btncancel.CommandParameter = this;
        }

        public CodeStacksMessageBox(int delay, string err) : this()
        {
            SetWindowSize();
            SetkWindowApear(false, err);
            AutoCloseWindow.CloseWindow(this, delay);
        }

        public CodeStacksMessageBox(Window owner, int delay, string err) : this(delay, err)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isConfirm"></param>
        /// <param name="isAnimation"></param>
        /// <param name="delay"></param>
        /// <param name="err"></param>
        public CodeStacksMessageBox(bool isAnimation, int delay, string err) : this()
        {
            SetWindowSize();
            SetkWindowApear(false, err);
            if (isAnimation)
            {
                AutoCloseWindow.CloseWindow(this, gradient, "ClosedBrush", "ClosedStoryboard", delay);
            }
            else
            {
                AutoCloseWindow.CloseWindow(this, delay);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isConfirm"></param>
        /// <param name="isAnimation"></param>
        /// <param name="delay"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        internal static bool ShowMessageBox(bool isConfirm, bool isAnimation, int delay, string err)
        {
            bool result = false;
            if (isConfirm)
                result = new CodeStacksMessageBox(isConfirm, err).ShowWindow();
            else
                new CodeStacksMessageBox(isAnimation, delay, err).Show();
            return result;
        }


        private void SetWindowSize()
        {
            this.Height = 120;
            this.Width = 320;
        }

        private void SetkWindowApear(bool isConfirm, string err)
        {
            if (isConfirm)
            {
                errInfo.Text = err;
                confirmmsgwindow.Visibility = Visibility.Visible;
                notgradient.Visibility = Visibility.Collapsed;
                gradient.Visibility = Visibility.Collapsed;
            }
            else
            {
                errInfogradient.Text = err;
                errInfonotgradient.Text = err;
                confirmmsgwindow.Visibility = Visibility.Collapsed;
                notgradient.Visibility = Visibility.Visible;
                gradient.Visibility = Visibility.Visible;
            }
        }

        public CodeStacksMessageBox(bool isConfirm, string err) : this()
        {
            SetkWindowApear(isConfirm, err);
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

        public bool ShowWindow()
        {
            this.ShowDialog();
            return Convert.ToBoolean(btnconfirm.Tag);
        }
    }
}
