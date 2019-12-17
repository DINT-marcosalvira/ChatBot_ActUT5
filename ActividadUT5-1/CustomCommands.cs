﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ActividadUT5_1
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand OpenConf = new RoutedUICommand
            (
                "OpenConf", "OpenConf", typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.C, ModifierKeys.Control)
                }
            );
    }
}
