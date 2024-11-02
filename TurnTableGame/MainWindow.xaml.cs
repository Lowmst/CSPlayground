using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System.Collections.Generic;

namespace TurnTableGame
{

    public sealed partial class MainWindow : Window
    {

        private int ContestantCount;
        private int HitPoint;
        private int HitDamage;

        List<(UIElement, double x, double y)> elements = new List<(UIElement, double x, double y)> ();


        private Game game;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {

            elements.Clear(); 

            game = new Game(HitPoint, ContestantCount, Canvas);
            MsgList.Items.Add($"{ContestantCount}, {HitDamage}, {HitPoint}");
            Restart.IsEnabled = true;
            Shot.IsEnabled = true;


            var rect = new Rectangle { Width = 50, Height = 50, Fill = new SolidColorBrush(Colors.Blue) };
            var rect1 = new Rectangle { Width = 10, Height = 10, Fill = new SolidColorBrush(Colors.Red) };

            Draw(rect1, 0, 0);
            Draw(rect, 10, 10);

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

        

        public void Draw(UIElement item, double x, double y)
        {
            elements.Add((item, x, y));

            double centerX = Canvas.ActualWidth / 2;
            double centerY = Canvas.ActualHeight / 2;

            Canvas.SetLeft(item, x + centerX);
            Canvas.SetTop(item, y + centerY);

            Canvas.Children.Add(item);
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

            double centerX = Canvas.ActualWidth / 2;
            double centerY = Canvas.ActualHeight / 2;

            foreach (var (item,x,y) in elements)
            {
                Canvas.SetLeft(item, x + centerX);
                Canvas.SetTop(item, y + centerY);
            }

        }
    }
}
