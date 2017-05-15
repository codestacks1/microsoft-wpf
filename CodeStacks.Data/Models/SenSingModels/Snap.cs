using System.Windows.Media;

namespace xiaowen.codestacks.data.SenSingModels
{
    public class Snap
    {
        public int Id { get; set; }
        public int Id64 { get; set; }
        public string Guid { get; set; }
        public string DateTime { get; set; }
        public ImageSource Photo { get; set; }
        public byte[] SnapPhotoBuffer { get; set; }
        public ImageSource EnvironmentPhoto { get; set; }
        public byte[] EnvironmentBuffer { get; set; }
        public Camera SnapCamera { get; set; }
    }
}
