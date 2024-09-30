using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Media;
using Microsoft.Maui.Primitives;

namespace Mp2Editor
{
    /// <summary>
    /// Interaction logic for FlatToggleButton.xaml
    /// </summary>
    public partial class FlatToggleButton : ToggleButton
    {
        static new internal DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(FlatToggleButton),
            new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Black), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        static new internal DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(FlatToggleButton),
            new FrameworkPropertyMetadata(new SolidColorBrush(Colors.White), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        static internal DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(FlatToggleButton),
                new FrameworkPropertyMetadata("OFF", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        private string textOn;
        private string textOff;

        public FlatToggleButton()
        {
            InitializeComponent();

            DependencyPropertyDescriptor prop = DependencyPropertyDescriptor.FromProperty(IsCheckedProperty, this.GetType());
            prop.AddValueChanged(this, (x, y) => SetValue(TextProperty, IsChecked.GetValueOrDefault() ? TextOn ?? "ON" : TextOff ?? "OFF"));
        }

        public new Brush Background
        {
            get { return (Brush)base.GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        public new Brush BorderBrush
        {
            get { return (Brush)base.GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        public string Text
        {
            get { return (string)base.GetValue(TextProperty); }
        }

        public string TextOn
        {
            get
            {
                return textOn;
            }
            set
            {
                textOn = value;
                if (IsChecked.GetValueOrDefault())
                    SetValue(TextProperty, value);
            }
        }

        public string TextOff
        {
            get
            {
                return textOff;
            }
            set
            {
                textOff = value;
                if (!IsChecked.GetValueOrDefault())
                    SetValue(TextProperty, value);
            }
        }
    }
}
