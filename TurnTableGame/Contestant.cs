using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System;


namespace TurnTableGame
{
    public class Contestant
    {
        public int totalHitPoint;
        public int CurrentHitPoint { get; set; }
        public String name;
        //public String Avatar { get; set; }

        //public UIElement

        public UIElement avatar = new Rectangle() { Width = 10, Height = 10, Fill = new SolidColorBrush(Colors.Blue) };
        public TextBlock hitpanel = new TextBlock();

        public Contestant(int totalHitPoint, String name)
        {
            //this.CurrentHitPoint = this.TotalHitPoint;
            this.totalHitPoint = totalHitPoint;
            this.CurrentHitPoint = totalHitPoint;
            //this.graph.Children.Add(new TextBlock() { Text = $"{CurrentHitPoint}/{totalHitPoint}"});
            this.hitpanel.Text = $"{CurrentHitPoint}/{totalHitPoint}";
            //this.graph.Children.Add(new Rectangle() { Width = 10, Height = 10, Fill = new SolidColorBrush(Colors.Blue) });
        }

        public void Hurt(int hit)
        {
            this.CurrentHitPoint -= hit;
            this.hitpanel.Text = $"{CurrentHitPoint}/{totalHitPoint}";
        }

    }
}
