﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xiaowen.codestacks.data.SenSingModels;

namespace xiaowen.codestacks.data.Models.SenSingModels
{
    public class ModuleChannelModel
    {
        public ObservableCollection<Camera> CameraCollection { get; set; }
        public Camera CameraItem { get; set; }
        public ObservableCollection<Compare> CompareResultCollection { get; set; }
        public Compare CompareResultItem { get; set; }
        public ObservableCollection<Snap> SnapResultCollection { get; set; }
        public Snap SnapResultItem { get; set; }
    }
}
