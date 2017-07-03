using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.CodeStacks.Wpf.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public class CodeStacksDynamic
    {
        #region Properties

        public dynamic MyFirstDynamicFiled { get; set; }


        #endregion

        public CodeStacksDynamic() { }

        public string TestMethod(int i)
        {
            //1、任何对象都可隐式转换为动态类型
            dynamic d1 = 1;
            dynamic d2 = "dynamic";
            dynamic d3 = DateTime.Today;
            dynamic d4 = System.Diagnostics.Process.GetProcesses();

            return i.ToString();
        }


    }
}
