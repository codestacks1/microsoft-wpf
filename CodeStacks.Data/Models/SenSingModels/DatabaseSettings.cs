using System.Collections.Generic;

namespace xiaowen.codestacks.data.Models.SenSingModels
{
    public class DatabaseSettings
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public TbConfig SettingsItem { get; set; }
        public List<TbConfig> SettingsCollection { get; set; }
    }



    public class TbConfig
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int Type { get; set; }
        public string Mean { get; set; }
    }
}
