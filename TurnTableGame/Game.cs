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
        private int contestantNum;
        private int hitDamage;
        private int hitPoint;

        private int contestantCount;

        private bool isProcessing = false;

        Canvas Canvas { get; set; }
        ListView msgList;

        List<Contestant> contestants = new List<Contestant>();
        //List<double> angles = new List<double>();
        Gun gun = new Gun() { Angle = 0 };
        int rotatedCount = 0;

        private MainWindow mainWindow; // 传入窗口对象以使用窗口Draw方法
        public Grid grid; // 传入窗口根对象

        public Game(int contestantNum, int hitDamage, int hitPoint, MainWindow mainWindow, Grid grid, Canvas canvas, ListView msgList)
        {
            this.contestantNum = contestantNum;
            this.hitDamage = hitDamage;
            this.hitPoint = hitPoint;

            this.contestantCount = this.contestantNum;

            this.mainWindow = mainWindow;
            this.Canvas = canvas;
            this.grid = grid;
            this.msgList = msgList;

            //this.rotatedCount = 0;

            for (int i = 0; i < contestantCount; i++)
            {
                contestants.Add(new Contestant(hitPoint, $"玩家{i + 1}") { Angle = i * 2 * Math.PI / contestantCount });

                //angles.Add(i * 2 * Math.PI / contestantCount);

            }

            Draw();
        }

        public async Task Shot()
        {
            if (isProcessing) return;
            isProcessing = true;
            try
            {
                var currentContestant = contestants[rotatedCount % contestantNum];
                var nextContestant = contestants[(rotatedCount + 1) % contestantNum];

                currentContestant.Shock();

                var rand = new Random();
                if (rand.Next(3) == 0)
                {
                    currentContestant.Hurt(this.hitDamage);
                }

                await Task.Delay(500);

                currentContestant.Recovery();

                rotatedCount++;

                if (currentContestant.CurrentHitPoint == 0)
                {
                    msgList.Items.Add($"{currentContestant.name.Text}被淘汰了！");
                    var currentIndex = contestants.IndexOf(currentContestant);
                    contestants.Remove(currentContestant);
                    contestantNum--;
                    //rotatedCount--;
                    rotatedCount = currentIndex;

                    //rotatedCount = currentIndex - 1;
                    //if (rotatedCount < 0) rotatedCount = contestantNum - 1;

                    for (int i = 0; i < contestantNum; i++)
                    {
                        contestants[i].Angle = i * 2 * Math.PI / contestantNum;
                    }

                    Draw();
                }

                gun.Rotate(nextContestant.Angle);

                if(contestantNum == 1)
                {
                    Utils.MsgBox($"{nextContestant.name.Text}取得了游戏胜利！！", grid.XamlRoot);
                    mainWindow.Finish();
                }

            }
            finally
            {
                isProcessing = false;
            }
        }

        //public async void Shot()
        //{
        //    var currentContestant = contestants[rotatedCount % contestantCount];
        //    var nextContestant = contestants[(rotatedCount + 1) % contestantCount];




        //    bool death = false;


        //    //currentContestant.avatar.Fill = new SolidColorBrush(Colors.Blue);
        //    //await Task.Delay(2000);


        //    var rand = new Random();
        //    if (rand.Next(3) == 0)
        //    {
        //        currentContestant.Hurt(this.hitDamage);
        //        currentContestant.avatar.Fill = new SolidColorBrush(Colors.Red);
        //        await Task.Delay(500);

        //        if (currentContestant.CurrentHitPoint == 0)
        //        {
        //            death = true;

        //            this.msgList.Items.Add($"{currentContestant.name.Text}被淘汰了！");

        //            int currentIndex = contestants.IndexOf(currentContestant);

        //            contestantCount--;
        //            contestants.Remove(currentContestant);
        //            //currentContestant = null;
        //            //angles.Clear();

        //            for (int i = 0; i < contestantCount; i++)
        //            {
        //                //angles.Add(i * 2 * Math.PI / contestantCount);
        //                contestants[i].Angle = i * 2 * Math.PI / contestantCount;

        //            }
        //            Draw();

        //            if (contestantCount > 0)
        //            {
        //                rotatedCount = currentIndex;
        //            }
        //        }
        //    }
        //    else {
        //        currentContestant.avatar.Fill = new SolidColorBrush(Colors.Blue);
        //        await Task.Delay(500);
        //    }


        //    currentContestant.avatar.Fill = new SolidColorBrush(Colors.Green);

        //    if (!death)
        //    {
        //        rotatedCount++;
        //    }


        //    gun.Rotate(nextContestant.Angle);
        //    if (contestantCount == 1)
        //    {
        //        //finish()
        //        mainWindow.Finish();
        //        Utils.MsgBox($"{currentContestant.name.Text}取得了游戏胜利！！", grid.XamlRoot);
        //    }


        //}



        public void Draw()
        {
            Canvas.Children.Clear();
            double radiusRate = 0.9;
            for (int i = 0; i < contestantNum; i++)
            {
                mainWindow.Draw(contestants[i].avatar, contestants[i].Angle, radiusRate, 0);
                mainWindow.Draw(contestants[i].hitpanel, contestants[i].Angle, radiusRate, -20);
                mainWindow.Draw(contestants[i].name, contestants[i].Angle, radiusRate, 10);
            }
            mainWindow.Draw(gun.icon, 0, 0, 0);
        }
    }
}