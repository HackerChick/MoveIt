﻿using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MoveIt.Model
{
    public class JustMoveInstruction : ModelBase
    {
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; OnNotifyPropertyChanged("Text"); }
        }
    }
}
