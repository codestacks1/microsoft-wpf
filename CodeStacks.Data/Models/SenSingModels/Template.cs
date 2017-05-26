namespace xiaowen.codestacks.data.SenSingModels
{
    /// <summary>
    /// 模板数据结构
    /// </summary>
    public class Template
    {
        /// <summary>
        /// 短整型主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 长整形主键
        /// </summary>
        public int Id64 { get; set; }
        /// <summary>
        /// 使用32位GUID的主键
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// 模板类型Key
        /// </summary>
        public int TypeKey { get; set; }
        /// <summary>
        /// 模板类型Value
        /// </summary>
        public string TypeValue { get; set; }
        /// <summary>
        /// 类型对应的图片路径 pack://application:,,,/Gallery/home-icon-redcamera.png
        /// </summary>
        public string TypePhotoPath { get; set; }
        /// <summary>
        /// 模板人员信息
        /// </summary>
        public Person PersonInfo { get; set; }
        /// <summary>
        /// 主模板
        /// </summary>
        public int MainTemplate { get; set; }

    }
}
