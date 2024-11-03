using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Windows.Graphics.Printing;

namespace TurnTableGame
{
    public class Game
    {
        private int contestantCount;
        private int hitDamage;
        private int hitPoint;

        Canvas Canvas { get; set; }


        List<Contestant> contestants = new List<Contestant>();
        List<double> angles = new List<double>();
        Gun gun = new Gun() { Angle = 0 };
        int rotatedCount;

        private MainWindow mainWindow; // 传入窗口对象以使用窗口Draw方法
        public Grid grid; // 传入窗口根对象

        public Game(int contestantCount, int hitDamage, int hitPoint, MainWindow mainWindow, Grid grid, Canvas canvas)
        {
            this.contestantCount = contestantCount;
            this.hitDamage = hitDamage;
            this.hitPoint = hitPoint;

            this.mainWindow = mainWindow;
            this.Canvas = canvas;
            this.grid = grid;
                    
            this.rotatedCount = 0;

            for (int i = 0; i < contestantCount; i++)
            {
                contestants.Add(new Contestant(hitPoint, $"玩家{i + 1}"));

                angles.Add(i * 2 * Math.PI / contestantCount);

            }

            Draw();
        }

        public async void Shot()
        {
            contestants[rotatedCount % contestantCount].avatar.Fill = new SolidColorBrush(Colors.Blue);
            await Task.Delay(400);
            

            var rand = new Random();
            if(rand.Next(3)==0)
            {
                contestants[rotatedCount % contestantCount].Hurt(this.hitDamage);
            }
            
            rotatedCount++;
            gun.Rotate(angles[rotatedCount % contestantCount]);
            
            contestants[(rotatedCount-1) % contestantCount].avatar.Fill = new SolidColorBrush(Colors.Green);

        }

        public void Draw()
        {
            Canvas.Children.Clear();
            double radiusRate = 0.9;
            for (int i = 0; i < contestantCount; i++)
            {
                mainWindow.Draw(contestants[i].avatar, angles[i], radiusRate, 0);
                mainWindow.Draw(contestants[i].hitpanel, angles[i], radiusRate, -20);
                mainWindow.Draw(contestants[i].name, angles[i], radiusRate, 10);
            }
            mainWindow.Draw(gun.icon, 0, 0, 0);
        }
    }
}