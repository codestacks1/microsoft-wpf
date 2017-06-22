using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xiaowen.CodeStacks.Data.Interfaces;

namespace ClodeStacks.Plugin.MenuFirst
{
    [Export(typeof(IMainWindowContract))]
    [ExportMetadata("Name", "Employee Pane")]
    [ExportMetadata("MenuText", "&Employees")]
    public partial class EmployeeMaintenance : Form, IMainWindowContract
    {
        public string MenuItemText
        {
            get { return "&Employees"; }
        }

        public string SubWindowTitle
        {
            get { return "Employee Pane"; }
        }

        public EmployeeMaintenance()
        {
            InitializeComponent();
        }
    }
}
