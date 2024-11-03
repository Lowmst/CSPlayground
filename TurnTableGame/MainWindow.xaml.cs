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

        //List<(UIElement, double x, double y)> elements_b = new List<(UIElement, double x, double y)> ();
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


            game = new Game(HitPoint, ContestantCount, this, grid, Canvas);
            //MsgList.Items.Add($"{ContestantCount}, {HitDamage}, {HitPoint}");
            Restart.IsEnabled = true;
            Shot.IsEnabled = true;
            //grid.Visibility = Visibility.Collapsed; 

            //var rect = new Rectangle { Width = 50, Height = 50, Fill = new SolidColorBrush(Colors.Blue) };
            //var rect1 = new Rectangle { Width = 10, Height = 10, Fill = new SolidColorBrush(Colors.Red) };

            //Draw(rect1, 0, 0);
            //Draw(rect, 10, 10);

        }

        private void Shot_Click(object sender, RoutedEventArgs e)
        {
            Canvas.Children.Clear();
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

        

        //public void Draw(UIElement item, double x, double y)
        //{
        //    //elements.Add((item, x, y));

        //    double centerX = Canvas.ActualWidth / 2;
        //    double centerY = Canvas.ActualHeight / 2;

        //    Canvas.SetLeft(item, x + centerX);
        //    Canvas.SetTop(item, y + centerY);

        //    Canvas.Children.Add(item);
        //}

        public void Draw( UIElement item, double angle, double radiusRate, double offset)
        {
            elements.Add((item, angle, radiusRate, offset));

            double radius = (Canvas.ActualHeight > Canvas.ActualWidth ? Canvas.ActualWidth : Canvas.ActualHeight) / 2;
            double x = radiusRate * radius * Math.Cos(angle);
            double y = radiusRate * radius * Math.Sin(angle);

            double centerX = Canvas.ActualWidth / 2;
            double centerY = Canvas.ActualHeight / 2;

            Canvas.SetLeft(item, x + centerX);
            Canvas.SetTop(item, y + centerY + offset);

            Canvas.Children.Add(item);
            //Draw(item, x, y);
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
            //double x = radius * Math.Cos(angle);
            //double y = radius * Math.Sin(angle);

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
