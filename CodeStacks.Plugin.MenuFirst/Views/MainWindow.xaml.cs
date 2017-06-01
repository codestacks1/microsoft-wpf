using System.ComponentModel.Composition;
using System.Windows;
using xiaowen.codestacks.data.Interfaces;

namespace codectacks.plugin.menufirst.Views
{
    [Export(typeof(IMainWindowContract))]
    [ExportMetadata("Title", "Plugin.First")]
    [ExportMetadata("MenuText", "FirstMenu")]
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
            get { return "FirstMenu"; }
        }

        public string SubWindowTitle
        {
            get { return "Plugin.First"; }
        }

    }
}
