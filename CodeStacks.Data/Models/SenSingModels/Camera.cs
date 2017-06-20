namespace xiaowen.codestacks.data.SenSingModels
{
    public class Camera
    {
        public int Id { get; set; }
        public long Id64 { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public decimal SnapPeopleCount { get; set; }
        public int TypeKey { get; set; }
        public string TypeValue { get; set; }
        /// <summary>
        /// 摄像头所在具体位置
        /// </summary>
        public string Location { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        /// <summary>
        /// 摄像头品牌、生产厂商
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 是否已打开视频流，进行是视频预览
        /// </summary>
        public bool IsOpen { get; set; }
        /// <summary>
        /// 通道开关状态
        /// </summary>
        public long CameraSwitchState { get; set; }

        /// <summary>
        /// 冗余字段1
        /// </summary>
        public object Content1 { get; set; }
        /// <summary>
        /// 冗余字段2
        /// </summary>
        public object Content2 { get; set; }

        #region redundancy
        public string Host { get; set; }
        public int Port { get; set; }
        public string Description { get; set; }

        #endregion

        #region METHODS



        #endregion
    }
}
