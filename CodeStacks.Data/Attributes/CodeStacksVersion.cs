using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.CodeStacks.Data.Attributes
{
    public class CodeStacksVersionAttribute : Attribute
    {
        public string Guid { get; set; }
        public string Version { get; set; }
    }
}
