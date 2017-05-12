using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xiaowen.codestacks.wpf.Models
{
    public class GeoTitle
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get { return "姓 名："; } }
        /// <summary>
        /// 来源库
        /// 普通 黑名单 ...
        /// </summary>
        public string Source { get { return "来源库："; } }
        /// <summary>
        /// 时间
        /// </summary>
        public string DateTime { get { return "时 间："; } }
        /// <summary>
        /// 位置
        /// </summary>
        public string Location { get { return "位 置："; } }


    }
}
