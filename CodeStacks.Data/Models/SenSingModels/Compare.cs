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
        /// 抓拍对象
        /// </summary>
        public Snap Snap { get; set; }
        public Template Template { get; set; }
    }
}
