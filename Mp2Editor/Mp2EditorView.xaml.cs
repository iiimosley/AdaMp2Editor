﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Primitives;
using Microsoft.Maui.Media;
using Microsoft.Maui.Controls.Shapes;

namespace Mp2Editor
{
    /// <summary>
    /// Interaction logic for Mp2EditorView.xaml
    /// </summary>
    public partial class Mp2EditorView : UserControl
    {
        public Mp2EditorView()
        {
            InitializeComponent();

            var knobs = GetChildrenOfType<LightKnob>(this.Content as Grid).ToArray();
            foreach (var item in knobs)
            {
                DependencyPropertyDescriptor.FromProperty(LightKnob.ValueProperty, this.GetType()).AddValueChanged(item,
                    (s, e) =>
                    {
                        var vm = DataContext as MainViewModel;
                        Task.Run(() =>
                        {
                            Thread.Sleep(10);
                            vm.Refresh();
                        });
                    });
            }

            var buttons = GetChildrenOfType<AdaToggleButton>(this.Content as Grid).ToArray();
            foreach (var item in buttons)
            {
                DependencyPropertyDescriptor.FromProperty(AdaToggleButton.IsCheckedProperty, this.GetType()).AddValueChanged(item,
                    (s, e) =>
                    {
                        var vm = DataContext as MainViewModel;
                        Task.Run(() =>
                        {
                            Thread.Sleep(10);
                            vm.Refresh();
                        });
                    });
            }
        }

        public static IEnumerable<T> GetChildrenOfType<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield break;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                if (child is T)
                    yield return child as T;
                else
                {
                    var result = GetChildrenOfType<T>(child);
                    if (result != null)
                        foreach (var r in result)
                            yield return r;
                }
            }
        }
    }
}
