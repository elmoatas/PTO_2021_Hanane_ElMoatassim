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

        public int speed_x = 2;           //snelheid van de bal
        public int speed_y = 2;
        int position_ball_x = 0;        //Plaatsbepaling van de bal
        int position_ball_y = 0;
        Ellipse circle = new Ellipse();
        public object ClientSize { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Draw_Rectangle(20, 250);                        //Speler1
            Draw_Rectangle(750, 250);                       //Speler2
            Draw_Ball(0, 0);
            DispatcherTimer timer = new DispatcherTimer();  //timer aanmaken 
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Start();
            timer.Tick += Timer_Tick;

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // heen en weer laten gaan 
            //Draw_Canvas.Children.Clear();
            //Balpositie naar rechts
            if (position_ball_x < 0 || position_ball_x + 20 > 800) speed_x *= -1;   // Bounce
            if (position_ball_y < 0 || position_ball_y + 20 > 450) speed_y *= -1;   // Bounce
            position_ball_x += speed_x;
            position_ball_y += speed_y;
            MoveBall(position_ball_x, position_ball_y);
        }

        private void MoveBall(int position_ball_x, int position_ball_y)
        {
            Canvas.SetLeft(circle, position_ball_x);
            Canvas.SetTop(circle, position_ball_y);
        }

        private void Draw_Ball(double x, double y)
        {

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
