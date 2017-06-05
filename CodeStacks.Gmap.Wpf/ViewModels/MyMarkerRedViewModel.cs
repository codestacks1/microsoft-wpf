using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;
using xiaowen.codestacks.gmap.demo.Models;

namespace xiaowen.codestacks.wpf.ViewModels
{
    public partial class MainWindowViewModel : BindableBase
    {
        Geo _geoData;
        public Geo GeoData
        {
            get { return _geoData; }
            set { SetProperty(ref _geoData, value); }
        }

        GeoTitle _geoTitle;
        public GeoTitle GeoTitle
        {
            get { return _geoTitle; }
            set { SetProperty(ref _geoTitle, value); }
        }

        #region Refres Properties
        public void RefreshGeoData()
        {
            RaisePropertyChanged("GeoData");
        }

        public void RefreshGeoTitle()
        {
            RaisePropertyChanged("GeoTitle");
        }
        #endregion

        #region Command

        void InitCommand<T>() where T : class, new()
        {
            T t = new T();
            Cmd = t as Cmd;

            Cmd.AddMarkerCommand = new DelegateCommand<object>(AddMarkerCommandFunc);
            Cmd.ClearAllCommand = new DelegateCommand<object>(ClearAllCommandFunc);
            Cmd.ActiveTrackCommand = new DelegateCommand<object>(ActiveTrackCommandFunc);
        }

        private void ClearAllCommandFunc(object obj)
        {
            if (MessageBox.Show("小伙子，你确定，别后悔 ~_~？", "Clear GMap.NET cache?", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                try
                {
                    int i = MyMapControl.MainMap.Manager.PrimaryCache.DeleteOlderThan(DateTime.Now, null);
                    MessageBox.Show("不作就不会 啊哈哈... 白白");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

    }
}
