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

namespace codestacks.mef.wpf.Views
{



    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [ImportMany]
        public Lazy<IMainFormContract, IDictionary<string, object>>[] ImportedMainFormContracts { get; set; }

        private CompositionContainer _container;
        string _extensionDir = string.Empty;

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
    }
}
