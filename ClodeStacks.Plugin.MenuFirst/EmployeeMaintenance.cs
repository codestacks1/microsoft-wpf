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
using xiaowen.codestacks.data.Interfaces;

namespace ClodeStacks.Plugin.MenuFirst
{
    [Export(typeof(IMainFormContract))]
    [ExportMetadata("Name", "Employee Pane")]
    [ExportMetadata("MenuText", "&Employees")]
    public partial class EmployeeMaintenance : Form, IMainFormContract
    {
        public string MenuItemText
        {
            get { return "&Employees"; }
        }

        public string SubFormTitle
        {
            get { return "Employee Pane"; }
        }

        public EmployeeMaintenance()
        {
            InitializeComponent();
        }
    }
}
