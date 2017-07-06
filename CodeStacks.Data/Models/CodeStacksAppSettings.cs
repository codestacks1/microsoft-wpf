using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.CodeStacks.Data.Models
{
    public class CodeStacksAppSettings
    {
        private CodeStacksAppSettings() { }

        /// <summary>
        /// demo property 
        /// 实时更新，热修改
        /// </summary>
        public static string DemoProperty
        {
            get
            {
                return ConfigurationManager.AppSettings["AppSettingsKey"];
            }
        }
    }
}
