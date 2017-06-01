using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xiaowen.codestacks.data.Interfaces;

namespace CodeStacks.MainFrom
{
    public partial class MainWindow : Form
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

        private void MainWindow_Load(object sender, EventArgs e)
        {
            foreach (var export in this.ImportedMainFormContracts)
            {
                var exportedMenuText = export.Metadata["MenuText"] as string;
                if (string.IsNullOrEmpty(exportedMenuText))
                {
                    return;
                }

                ToolStripItem menuItem = toolStripMenuItem2.DropDownItems.Add(exportedMenuText);
                menuItem.Click += new System.EventHandler(this.LaunchModule_Click);
            }
        }

        private void LaunchModule_Click(object sender, EventArgs e)
        {
            ToolStripItem thisItem = sender as ToolStripItem;
            if (thisItem == null) return;

            string thisItemTitle = thisItem.Text;
            foreach (var export in this.ImportedMainFormContracts)
            {
                string menuTitle = export.Metadata["MenuText"] as string;
                if (string.IsNullOrEmpty(menuTitle))
                {
                    return;
                }

                if (menuTitle == thisItemTitle)
                {
                    Form fm = export.Value as Form;
                    if (fm == null) return;

                    fm.Show(this);
                    return;
                }
            }
        }
    }
}
