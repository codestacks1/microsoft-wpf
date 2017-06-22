using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.CodeStacks.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class CodeStacks
    {
        public class PackURI
        {
            private PackURI() { }

            /// <summary>
            /// 应用程序内绝对路径前缀
            /// </summary>
            public const string APPLICATION = "pack://application:,,,";
            /// <summary>
            /// 引用程序集资源绝对路径前缀
            /// </summary>
            public const string REFERENCEASSEMBLY = "pack://application:,,,/ReferencedAssembly;component";
            /// <summary>
            /// 外部非资源型文件绝对路径前缀
            /// </summary>
            public const string SITEOFORIGIN = "pack://siteoforigin:,,,";
            

        }

        

    }
}
