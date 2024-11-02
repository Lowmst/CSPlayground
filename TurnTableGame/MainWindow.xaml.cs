using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace TurnTableGame
{

    public sealed partial class MainWindow : Window
    {

        private int ContestantCount;
        private int HitPoint;
        private int HitDamage;
        private Game game;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            game = new Game(HitPoint, ContestantCount, Canvas);
            MsgList.Items.Add($"{ContestantCount}, {HitDamage}, {HitPoint}");
            Restart.IsEnabled = true;
            Shot.IsEnabled = true;


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
    }
}
