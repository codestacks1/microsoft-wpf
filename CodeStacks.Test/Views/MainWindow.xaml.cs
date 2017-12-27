using log4net;
using System.Windows;
using Xiaowen.CodeStacks.PopWindow;
using Xiaowen.CodeStacks.PopWindow.Views;

namespace CodeStacks.Test.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly ILog log = LogManager.GetLogger(typeof(MainWindow).FullName);

        public double WindowWidth { get; set; }
        public double WindowHeight { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;

            switch (i)
            {
                case 1:
                    MessageBox.Show("1");
                    break;
                default:
                    MessageBox.Show("default");
                    break;
            }


            //var s = CodeStacksWindow.MessageBox.Invoke(true, false, 2, "Welcome to codestacks!");

            //CodeStacksAlarmWindow alarm = new CodeStacksAlarmWindow();
            //alarm.ShowDialog();

            //CodeStacksWindow.MessageBoxSta.Invoke(false, false, 2, "9090".ToString());

            //string s1 = string.Empty;

            //CodeStacksDataHandler.UIThread.Invoke(() =>
            //{
            //    var sh = new CodeStacksMessageBox(isConfirm: true, err: "Welcome to codestacks!").ShowWindow();

            //    var sh1 = sh;
            //});

            //CodeStacksDataHandler.UIThread.Invoke(() =>
            //{
            //    var sh = new CodeStacksMessageBox(isConfirm: true, err: "Welcome to codestacks!").ShowWindow();

            //    var sh1 = sh;
            //});

            //log.Info("Entering application");
            //log.Error("ddddd");
            //log.Debug("debug");

            //try
            //{

            //}
            //catch (System.Exception)
            //{

            //    throw;
            //}
            
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            WindowWidth = e.NewSize.Width;

            WindowHeight = e.NewSize.Height;
        }
    }
}
