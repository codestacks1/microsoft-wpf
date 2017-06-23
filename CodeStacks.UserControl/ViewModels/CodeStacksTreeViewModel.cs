using Prism.Mvvm;
using System.Collections.ObjectModel;
using Xiaowen.CodeStacks.Data.SenSingModels;

namespace Xiaowen.CodeStacks.UserControls.ViewModels
{
    public class CodeStacksTreeViewModel : BindableBase
    {
        public CodeStacksTreeViewModel()
        {
            Init();
        }

        ObservableCollection<Camera> _cameraCollection;
        public ObservableCollection<Camera> CameraCollection
        {
            get { return _cameraCollection; }
            set { SetProperty(ref _cameraCollection, value); }
        }

        public void Init()
        {
            CameraCollection = new ObservableCollection<Camera>();
            CameraCollection.Add(new Camera() { Id = 1, Name = "xiaowen", ParentId = 0, TypeValue = "Normal" });
            CameraCollection.Add(new Camera() { Id = 2, Name = "xiaowen", ParentId = 0, TypeValue = "Black" });
            CameraCollection.Add(new Camera() { Id = 3, Name = "xiaowen", ParentId = 1, TypeValue = "White" });
            CameraCollection.Add(new Camera() { Id = 4, Name = "xiaowen", ParentId = 1, TypeValue = "White" });
            CameraCollection.Add(new Camera() { Id = 5, Name = "xiaowen", ParentId = 3, TypeValue = "White" });
            CameraCollection.Add(new Camera() { Id = 6, Name = "xiaowen", ParentId = 5, TypeValue = "White" });
        }

    }
}
