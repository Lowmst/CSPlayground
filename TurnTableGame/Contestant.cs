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

        public bool Survive {  get; set; } = true;

        public TextBlock name;
        public double Angle { get; set; }

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
            if (this.CurrentHitPoint <= 0)
            {
                this.CurrentHitPoint = 0;
            }
            this.hitpanel.Text = $"{CurrentHitPoint}/{totalHitPoint}";
            this.avatar.Fill = new SolidColorBrush(Colors.Red);
            //await Task.Delay(2000);
        }

        public void Shock()
        {
            this.avatar.Fill = new SolidColorBrush(Colors.Blue);
        }


        public void Recovery()
        {
            this.avatar.Fill = new SolidColorBrush(Colors.Green);
        }
    }
}
