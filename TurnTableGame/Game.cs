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
        List<double> angles = new List<double>();

        private MainWindow mainWindow; // 传入窗口对象以使用窗口Draw方法
        public Grid grid; // 传入窗口根对象

        public Game(int HitPoint, int ContestantCount, MainWindow mainWindow, Grid grid, Canvas canvas)
        {
            this.Canvas = canvas;

            this.ContestantCount = ContestantCount;

            this.mainWindow = mainWindow;

            this.grid = grid;

            for (int i = 0; i < ContestantCount; i++)
            {
                contestants.Add(new Contestant(HitPoint, $"玩家{i + 1}"));

                //var rect = new Rectangle() { Width = 10, Height = 10, Fill = new SolidColorBrush(Colors.Blue) };
                angles.Add(i * 2 * Math.PI / ContestantCount);
                //positions.Add((x, y));

                //mainWindow.Draw(rect, i * 2 * Math.PI / ContestantCount);
            }

            Draw();
        }

        public void Shot()
        {
            // ... //
            Draw();
        }

        public void Draw()
        {
            // todo, 绘制contestants, gun //
            Canvas.Children.Clear();
            double radiusRate = 0.9;
            for (int i = 0;i < ContestantCount; i++)
            {
                mainWindow.Draw(contestants[i].avatar, angles[i], radiusRate,0);
                mainWindow.Draw(contestants[i].hitpanel, angles[i], radiusRate, -20);
            }
            mainWindow.Draw(new Rectangle() { Width = 10, Height = 10, Fill = new SolidColorBrush(Colors.Red) }, 0, 0,0);
        }
    }
}
