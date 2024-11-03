using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace TurnTableGame
{
    public class Contestant
    {
        public int totalHitPoint;
        public int CurrentHitPoint { get; set; }
        public TextBlock name;

        public Rectangle avatar = new Rectangle() { Width = 10, Height = 10, Fill = new SolidColorBrush(Colors.Green) };
        public TextBlock hitpanel = new TextBlock();

        public Contestant(int totalHitPoint, String name)
        {
            this.totalHitPoint = totalHitPoint;
            this.CurrentHitPoint = totalHitPoint;

            this.hitpanel.Text = $"{CurrentHitPoint}/{totalHitPoint}";
            this.name = new TextBlock() { Text = name};
        }

        public void Hurt(int hit)
        {
            this.CurrentHitPoint -= hit;
            this.hitpanel.Text = $"{CurrentHitPoint}/{totalHitPoint}";
        }

        //public async void Shock()
        //{
        //    this.avatar.Fill = new SolidColorBrush(Colors.Blue);
        //    //Thread.Sleep(400);
        //    await Task.Delay(400);
        //    this.avatar.Fill = new SolidColorBrush(Colors.Green);

        //}
    }
}
