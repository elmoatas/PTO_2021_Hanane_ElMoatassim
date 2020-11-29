using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Pong_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int speedx = 4;           //snelheid van de bal
        public int speedy = 4;
        int position_ball_x = 0;                      //Plaatsbepaling van de bal
        int position_ball_y = 0;




        public MainWindow()
        {
            InitializeComponent();
            Draw_Rectangle(20, 250);                        //Speler1
            Draw_Rectangle(750, 250);                       //Speler2
            DispatcherTimer timer = new DispatcherTimer();  //timer aanmaken 
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Start();
            timer.Tick += Timer_Tick;

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            position_ball_x += speedx;
            position_ball_y += speedy;


            Draw_Ball(position_ball_x, position_ball_y);
        }
        private void Draw_Ball(double x, double y)
        {
            Ellipse circle = new Ellipse();
            circle.Height = 20;
            circle.Width = 20;
            circle.Fill = Brushes.White;
            Canvas.SetLeft(circle, x);
            Canvas.SetTop(circle, y);
            Draw_Canvas.Children.Add(circle);
        }
        private void Draw_Rectangle(double x, double y)
        {
            Rectangle player = new Rectangle();
            player.Height = 100;
            player.Width = 20;
            player.Fill = Brushes.White;
            Canvas.SetLeft(player, x); // position based on center
            Canvas.SetTop(player, y); // position based on center
            Draw_Canvas.Children.Add(player);

        }
    }
}
