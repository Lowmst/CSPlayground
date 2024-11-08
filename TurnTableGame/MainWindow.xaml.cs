using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace TurnTableGame
{

    public sealed partial class MainWindow : Window
    {

        private int ContestantNum;
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

            game = new Game(ContestantNum, HitDamage, HitPoint, this, Canvas);
            Restart.IsEnabled = true;
            Shot.IsEnabled = true;

        }

        private async void Shot_Click(object sender, RoutedEventArgs e)
        {
            await game.Shot();
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


        public async void MsgBox(String content)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog.XamlRoot = grid.XamlRoot;
            dialog.Content = content;
            dialog.CloseButtonText = "OK";
            var result = await dialog.ShowAsync();
        }

        public void AddMsg(String content)
        {
            MsgList.Items.Add(content);
        }

        private void ContestantCount_ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            this.ContestantNum = (int)sender.Value;
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
