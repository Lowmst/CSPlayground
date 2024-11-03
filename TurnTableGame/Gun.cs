using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnTableGame
{
    class Gun
    {
        public double Angle { get; set; }
        public Border icon = new Border()
        {
            BorderBrush = new SolidColorBrush(Colors.Red),
            BorderThickness = new Thickness(1, 1, 1, 1),
            Child = new FontIcon() { Glyph = "\uE72A", RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5), },
            RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5)
        };
        
            //
        public void Rotate(double angle)
        {
            //icon.Child = new FontIcon() { Glyph = "\uE72A" , RenderTransformOrigin  = new Windows.Foundation.Point(0.5,0.5)};
            var trans = new RotateTransform() { Angle = 180 * angle/Math.PI };
            icon.RenderTransform = trans;

        }
    }

}
