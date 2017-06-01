using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
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

namespace codestacks.mef.wpf.Views
{



    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [ImportMany]
        public Lazy<IMainWindowContract, IDictionary<string, object>>[] ImportedMainFormContracts { get; set; }

        private CompositionContainer _container;
        string _extensionDir = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\";

        private CompositionContainer GetContainerFromDirectory()
        {
            var catalog = new AggregateCatalog();
            var thisAssembly = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            catalog.Catalogs.Add(thisAssembly);
            catalog.Catalogs.Add(new DirectoryCatalog(_extensionDir));
            var container = new CompositionContainer(catalog);
            return container;
        }


        private bool Compose()
        {
            _container = GetContainerFromDirectory();
            try
            {
                _container.ComposeParts(this);
            }
            catch (CompositionException ex)
            {
                string err = ex.Message;
            }
            return true;
        }


        public MainWindow()
        {
            InitializeComponent();
            bool successfulCompose = Compose();
            if (!successfulCompose)
                this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var _default = string.Empty;
            foreach (var export in this.ImportedMainFormContracts)
            {
                var exportedMenuText = _default = export.Metadata["MenuText"] as string;

                if (string.IsNullOrEmpty(exportedMenuText))
                {
                    return;
                }

                HomeComboBox0.Items.Add(exportedMenuText);
                HomeComboBox0.SelectionChanged += HomeComboBox0_SelectionChanged;
            }

            if (!string.IsNullOrEmpty(_default))
                HomeComboBox0.SelectedItem = _default;

            // HomeComboBox0.ItemsSource = HomeComboBox0.Items;
        }

        private void HomeComboBox0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbox = sender as ComboBox;
            if (cbox == null) return;
            var item = cbox.SelectedItem as string;

            foreach (var export in this.ImportedMainFormContracts)
            {
                string menuItem = export.Metadata["MenuText"] as string;
                string title = export.Metadata["Title"] as string;
                if (string.IsNullOrEmpty(menuItem)) return;

                if (menuItem == item)
                {
                    //(export.Value as Window).Show();

                    Window window = export.Value as Window;
                    if (window == null) return;
                    window.Title = title;
                    window.Show();
                }
            }
        }
    }
}
