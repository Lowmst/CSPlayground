using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace TurnTableGame
{

    public sealed partial class MainWindow : Window
    {

        private int ContestantCount;
        private int HitPoint;
        private int HitDamage;

        List<(UIElement, double, double, double)> elements = new List<(UIElement, double, double, double)>();


        private Game game;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {

            elements.Clear();
            MsgList.Items.Clear();
            Canvas.Children.Clear();

            game = new Game(ContestantCount,HitDamage, HitPoint,  this, grid, Canvas, MsgList);
            Restart.IsEnabled = true;
            Shot.IsEnabled = true;

        }

        private void Shot_Click(object sender, RoutedEventArgs e)
        {
            game.Shot();
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            MsgList.Items.Clear();
            Canvas.Children.Clear();
            Restart.IsEnabled = false;
            Shot.IsEnabled = false;
            elements.Clear();
        }

        public void Draw( UIElement item, double angle, double radiusRate, double offset)
        {
            //item.RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5);
            elements.Add((item, angle, radiusRate, offset));

            double radius = (Canvas.ActualHeight > Canvas.ActualWidth ? Canvas.ActualWidth : Canvas.ActualHeight) / 2;
            double x = radiusRate * radius * Math.Cos(angle);
            double y = radiusRate * radius * Math.Sin(angle);

            double centerX = Canvas.ActualWidth / 2;
            double centerY = Canvas.ActualHeight / 2;

            Canvas.SetLeft(item, x + centerX);
            Canvas.SetTop(item, y + centerY + offset);

            Canvas.Children.Add(item);
        }

        public void Finish()
        {
            Shot.IsEnabled = false;
        }

        private void ContestantCount_ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            this.ContestantCount = (int)sender.Value;
        }

        private void HitDamage_ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            this.HitDamage = (int)sender.Value;
        }

        private void HitPoint_ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            this.HitPoint = (int)sender.Value;
        }

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            double radius = (Canvas.ActualHeight > Canvas.ActualWidth ? Canvas.ActualWidth : Canvas.ActualHeight) / 2;

            double centerX = Canvas.ActualWidth / 2;
            double centerY = Canvas.ActualHeight / 2;

            foreach (var (item, angle, radiusRate,offset) in elements)
            {
                double x = radiusRate * radius * Math.Cos(angle);
                double y = radiusRate * radius * Math.Sin(angle);

                Canvas.SetLeft(item, x + centerX);
                Canvas.SetTop(item, y + centerY + offset);
            }

        }
    }
}
