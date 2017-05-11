using System.Windows.Media;

namespace DATA.MODELS.SensingModels
{
    public class Snap
    {
        public int Id { get; set; }
        public int Id64 { get; set; }
        public string Guid { get; set; }
        public string SanpDateTime { get; set; }
        public ImageSource SnapPhoto { get; set; }
        public byte[] SnapPhotoStream { get; set; }
        public Camera SnapCamera { get; set; }
    }
}
