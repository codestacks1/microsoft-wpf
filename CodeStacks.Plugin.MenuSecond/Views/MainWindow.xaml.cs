using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
using xiaowen.codestacks.data.Interfaces;

namespace codectacks.plugin.menusecond.Views
{
    [Export(typeof(IMainWindowContract))]
    [ExportMetadata("Title", "Plugin.Second")]
    [ExportMetadata("MenuText", "MenuSecond")]
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowContract
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string MenuItemText
        {
            get
            {
                return "MenuSecond";
            }
        }

        public string SubWindowTitle
        {
            get
            {
                return "Plugin.MenuSecond";
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
