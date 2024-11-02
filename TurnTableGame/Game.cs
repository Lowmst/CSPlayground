using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;

namespace TurnTableGame
{
    public class Game
    {
        struct Position
        {
            double x, y;
        }


        Canvas Canvas { get; set; }
        int ContestantCount { get; set; }
        
        
        List<Contestant> contestants = new List<Contestant>();
        List<Position> positions = new List<Position>();

        public Game(int HitPoint, int ContestantCount, Canvas Canvas)
        {
            this.Canvas = Canvas;

            this.ContestantCount = ContestantCount;
            for (int i = 0; i < ContestantCount; i++)
            {
                contestants.Add(new Contestant() { Name = $"玩家{i + 1}", TotalHitPoint = HitPoint ,CurrentHitPoint = HitPoint});
                
            }


           
        }

        private void Draw()
        {
            //Canvas.Children.Add();
        }

        public void Shot()
        {

        }
    }
}
