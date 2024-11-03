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
        Gun gun = new Gun() { Angle = 0 };
        int rotatedCount;

        private MainWindow mainWindow; // 传入窗口对象以使用窗口Draw方法
        public Grid grid; // 传入窗口根对象

        public Game(int HitPoint, int ContestantCount, MainWindow mainWindow, Grid grid, Canvas canvas)
        {
            this.Canvas = canvas;

            this.ContestantCount = ContestantCount;

            this.mainWindow = mainWindow;

            this.grid = grid;
            this.rotatedCount = 0;
            for (int i = 0; i < ContestantCount; i++)
            {
                contestants.Add(new Contestant(HitPoint, $"玩家{i + 1}"));

                angles.Add(i * 2 * Math.PI / ContestantCount);

            }

            Draw();
        }

        public void Shot()
        {
            // ... //
            rotatedCount++;
            gun.Rotate(angles[rotatedCount % ContestantCount]);
            Draw();
        }

        public void Draw()
        {
            // todo, 绘制contestants, gun //
            Canvas.Children.Clear();
            double radiusRate = 0.9;
            for (int i = 0; i < ContestantCount; i++)
            {
                mainWindow.Draw(contestants[i].avatar, angles[i], radiusRate, 0);
                //mainWindow.Draw(contestants[i].hitpanel, angles[i], radiusRate, -20);
                //mainWindow.Draw(contestants[i].name, angles[i], radiusRate, 10);
            }
            mainWindow.Draw(gun.icon, 0, 0, 0);

            mainWindow.Draw(new Ellipse() { Stroke = new SolidColorBrush(Colors.Green), Height = 10, Width = 10, RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5) } ,0,0,0);
        }
    }
}
