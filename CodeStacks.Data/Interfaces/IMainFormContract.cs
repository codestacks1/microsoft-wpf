using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xiaowen.codestacks.data.Interfaces
{
    public interface IMainWindowContract
    {
        /// <summary>
        /// Menu item name
        /// </summary>
        string MenuItemText { get; }

        /// <summary>
        /// Form title name
        /// </summary>
        string SubWindowTitle { get; }
    }
}
