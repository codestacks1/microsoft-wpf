using System;

namespace xiaowen.codestacks.data.SenSingModels
{
    /// <summary>
    /// 比对结果
    /// </summary>
    public class Compare
    {
        public long Row { get; set; }
        public int Id { get; set; }
        public long Id64 { get; set; }
        public string Guid { get; set; }
        /// <summary>
        /// Score
        /// </summary>
        public int Score { get; set; }
        public int Threshold { get; set; }
        public Camera Camera { get; set; }
        /// <summary>
        /// 20170608新增字段 判断是比对 还是 告警
        /// </summary>
        public string Captype { get; set; }
        /// <summary>
        /// 抓拍对象
        /// </summary>
        public Snap Snap { get; set; }
        public Template Template { get; set; }
    }
}
