using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;

namespace TurnTableGame
{
    public class Game
    {

        Canvas Canvas { get; set; }
        int ContestantCount { get; set; }
        
        
        List<Contestant> contestants = new List<Contestant>();
        List<(double, double)> positions = new List<(double, double)>();

        private MainWindow mainWindow;
        public Grid grid;

        public Game(int HitPoint, int ContestantCount, Canvas Canvas, MainWindow mainWindow, Grid grid)
        {
            this.Canvas = Canvas;

            this.ContestantCount = ContestantCount;

            this.mainWindow = mainWindow;

            this.grid = grid;

            double radius = (Canvas.ActualHeight > Canvas.ActualWidth ? Canvas.ActualWidth : Canvas.ActualHeight)/2;

            Utils.MsgBox($"{radius}", grid.XamlRoot);

            for (int i = 0; i < ContestantCount; i++)
            {
                contestants.Add(new Contestant() { Name = $"玩家{i + 1}", TotalHitPoint = HitPoint ,CurrentHitPoint = HitPoint});

                double x =  0.9*radius * Math.Cos(i * 2 * Math.PI / ContestantCount);
                double y =  0.9*radius * Math.Sin(i * 2 * Math.PI / ContestantCount);

                var rect = new Rectangle() { Width = 10, Height = 10, Fill = new SolidColorBrush(Colors.Blue) };

                positions.Add((x, y));

                mainWindow.Draw(rect, x, y);
            }
        }

        public void Shot()
        {

        }
    }
}
