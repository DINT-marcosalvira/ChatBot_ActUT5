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

        public static readonly RoutedUICommand Exit = new RoutedUICommand
            (
                "Exit", "Exit", typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.S, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand SendMessage = new RoutedUICommand
            (
                "SendMessage", "SendMessage", typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.Enter)
                }
            );

        public static readonly RoutedUICommand NewChat = new RoutedUICommand
            (
                "NewChat", "NewChat", typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.N, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand CheckConnection = new RoutedUICommand
            (
                "CheckConnection", "CheckConnection", typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.O, ModifierKeys.Control)
                }
            );
    }
}
