﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace xiaowen.codestacks.data.Models
{
    public class CloseWindowModel
    {
        public ICommand CmdClose { get; set; }

        public Window WillCloseWindow { get; set; }
    }
}