using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        Rectangle player_1 = new Rectangle();
        Rectangle player_2 = new Rectangle();
        Ellipse circle = new Ellipse();
        public int speed_x = 2;           //snelheid van de bal
        public int speed_y = 2;
        int position_ball_x = 0;         //Plaatsbepaling van de bal
        int position_ball_y = 0;
        int position_player1_y = 0;      //positie bepalen van rechthoekje
        int position_player2_y = 0;


        public object ClientSize { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Draw_Rectangle();                       //Speler1
            //Draw_Rectangle(750, 250);             //Speler2 even niet drawen tot als je player 1 af hebt
            Draw_Ball(0, 0);
            DispatcherTimer timer = new DispatcherTimer();  //timer aanmaken 
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Start();
            timer.Tick += Timer_Tick;

        }
        private void Timer_Tick(object sender, EventArgs e)
        {

            if (position_ball_x < 0 || position_ball_x + 20 > Draw_Canvas.ActualWidth) speed_x *= -1;   // Bounce
            if (position_ball_y < 0 || position_ball_y + 20 > Draw_Canvas.ActualHeight) speed_y *= -1;   // Bounce
            position_ball_x += speed_x;
            position_ball_y += speed_y;
            MoveBall(position_ball_x, position_ball_y);
            Move_Player1();
            Move_Player2();
            //nog toevoegen: 
            //- als het botst tegen de rectangle dan gaat *-1 
            //- als het tegen draw canvas.actual width en height komt moet de bal weer naar midden van pagina gaan 
        }

        private void MoveBall(int position_ball_x, int position_ball_y)
        {

            Canvas.SetLeft(circle, position_ball_x);
            Canvas.SetTop(circle, position_ball_y);
        }

        private void Move_Player1()
        {
            if (Keyboard.IsKeyDown(Key.Down) && position_player1_y < Draw_Canvas.ActualHeight - player_1.Height)
            {
                position_player1_y += 5;
            }
            if (Keyboard.IsKeyDown(Key.Up) && position_player1_y>0)
            {
                position_player1_y -= 5;
            }
            if (Keyboard.IsKeyDown(Key.Down) && position_player2_y >= Draw_Canvas.ActualHeight - player_1.Height)
            {
                position_player2_y += 0;
            }
            Canvas.SetLeft(player_1, 20); // position based on center
            Canvas.SetTop(player_1, position_player1_y); // position based on center
        }
        private void Move_Player2()
        {
            if (Keyboard.IsKeyDown(Key.Q) && position_player2_y <Draw_Canvas.ActualHeight - player_2.Height )
            {
                position_player2_y += 5;
            }
            else if (Keyboard.IsKeyDown(Key.A) && position_player2_y>0)
            {
                position_player2_y -= 5;
            }
            if (position_player2_y >= Draw_Canvas.ActualHeight - player_2.Height || position_player2_y <= 0)
            {
                position_player2_y += 0;
            }

            Canvas.SetLeft(player_2, Draw_Canvas.ActualWidth - player_2.Width - 10); // position based on center
            Canvas.SetTop(player_2, position_player2_y); // position based on center
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

        private void Draw_Rectangle()
        {
            player_1.Height = 100;
            player_1.Width = 20;
            player_1.Fill = Brushes.White;
            Draw_Canvas.Children.Add(player_1);

            player_2.Height = 100;
            player_2.Width = 20;
            player_2.Fill = Brushes.White;
            Draw_Canvas.Children.Add(player_2);
        }
    }
}
