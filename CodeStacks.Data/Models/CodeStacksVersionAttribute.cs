using System;

namespace Xiaowen.CodeStacks.Data.Models
{
    /// <summary>
    /// 通用版本设置
    /// </summary>
    public class CodeStacksVersionAttribute : Attribute
    {
        public string Version { get; set; }
        public string Author { get; set; }
        public string CreatedOn { get; set; }
    }
}
