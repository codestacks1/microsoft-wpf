using System.Windows.Media;

namespace xiaowen.codestacks.data.SenSingModels
{
    public class Person
    {
        public int Id { get; set; }
        public int Id64 { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public int SexKey { get; set; }
        public string SexValue { get; set; }
        public int Age { get; set; }
        public string IdCard { get; set; }
        public ImageSource Photo { get; set; }
        public byte[] PhotoStream { get; set; }
        public byte[] AttributeValue { get; set; }
    }
}
