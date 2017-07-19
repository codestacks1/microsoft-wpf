using GMap.NET;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using Xiaowen.CodeStacks.Data.Models.GMap;
using Xiaowen.CodeStacks.PopWindow;
using Xiaowen.CodeStacks.Wpf.Gmap.Source;
using Xiaowen.CodeStacks.Wpf.Gmap.Views;

namespace Xiaowen.CodeStacks.Wpf.Gmap.ViewModels
{
    public partial class MainWindowViewModel : BindableBase
    {
        #region View Properties 

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

        public void RefreshGeoData()
        {
            RaisePropertyChanged("GeoData");
        }

        public void RefreshGeoTitle()
        {
            RaisePropertyChanged("GeoTitle");
        }

        #endregion

        #region Location Properties

        public Route Route { get; set; }

        public ObservableCollection<PointLatLng> Points { get; set; }

        #endregion

        #region Command

        void InitCommand<T>() where T : class, new()
        {
            T t = new T();
            Cmd = t as Cmd;

            Cmd.ClearAllCommand = new DelegateCommand<object>(ClearAllCommandFunc);
            Cmd.PlayActiveRouteCommand = new DelegateCommand<object>(PlayActiveRouteFunc);
            Cmd.StopActiveRouteCommand = new DelegateCommand<object>(StopActiveRouteCommandFunc);
            Cmd.SpeedUpCommand = new DelegateCommand<object>(SpeedUpCommandFunc);
            Cmd.CopyLngCmd = new DelegateCommand<object>(CopyLngCmdFunc);
            Cmd.CopyLatCmd = new DelegateCommand<object>(CopyLatCmdFunc);
            Cmd.TakeAnchorCommand = new DelegateCommand<object>(TakeAnchorCommandFunc);
        }

        /// <summary>
        /// 播放活动线路
        /// </summary>
        /// <param name="obj"></param>
        private void PlayActiveRouteFunc(object obj)
        {
            if (MyMapControl.Route != null)
            {
                IsPlayVisibility = Visibility.Collapsed;
                IsStopVisibility = Visibility.Visible;

                MyMapControl.MainMap.Markers.Clear();
                MyMapControl.Route.Delay = 2;
                if (Points != null && Points.Count > 0)
                    CodeStacksGMapRoute.SetRouteOffline(Points, MyMapControl, MyMapControl.Route, IsPlayVisibility, IsStopVisibility);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void StopActiveRouteCommandFunc(object obj)
        {
            IsPlayVisibility = Visibility.Visible;
            IsStopVisibility = Visibility.Collapsed;
            CodeStacksGMapRoute.StopRouteTask();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void TakeAnchorCommandFunc(object obj)
        {
            if ("true".Equals(obj))
            {
                IsMarkVisibility = Visibility.Collapsed;
                IsCancelMarkVisibility = Visibility.Visible;
                MyMapControl.IsMakeAnchor = true;
            }
            else
            {
                IsMarkVisibility = Visibility.Visible;
                IsCancelMarkVisibility = Visibility.Collapsed;
                MyMapControl.IsMakeAnchor = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void CopyLatCmdFunc(object obj)
        {
            Clipboard.SetDataObject(obj);
        }

        private void CopyLngCmdFunc(object obj)
        {
            Clipboard.SetDataObject(obj);
        }
        
        private void SpeedUpCommandFunc(object obj)
        {
            try
            {
                Route.Delay = Route.Delay <= 0 ? 0 : Route.Delay - 1;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void ClearAllCommandFunc(object obj)
        {
            if (CodeStacksWindow.MessageBox.Invoke(true, false, -1, "您确定要清理地图图层？"))
            {
                IsPlayVisibility = Visibility.Collapsed;
                Points.Clear();
                MyMapControl.MainMap.Markers.Clear();
                //MyMapControl.MainMap.Manager.PrimaryCache.DeleteOlderThan(DateTime.Now, null);
            }
        }

        #endregion

    }
}
