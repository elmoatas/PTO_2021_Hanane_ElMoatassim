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
        DispatcherTimer timer = new DispatcherTimer();
        public int speed_x = 1;             //snelheid van de bal
        public int speed_y = 1;
        double position_ball_x = 0;         //Plaatsbepaling van de bal
        double position_ball_y = 0;
        double position_player1_y = 0;      //positie bepalen van rechthoekje
        double position_player2_y = 0;

        public MainWindow()
        {
            InitializeComponent();
            Draw_Rectangle();               //Speler1 en speler 2 tekenen 
            Draw_Ball();                    //Bal tekenen         
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (position_ball_x < 0 || position_ball_x + 20 > Draw_Canvas.ActualWidth) //|| position_ball_x >= (position_player1_y + player_1.ActualHeight) || position_ball_x <= position_player1_y
            {
                speed_x *= -1;             // Bounce wnr bal tussen 0 en width, wanneer bal groter is dan bottom van racket, wanneer bal kleiner dan top van racket 
            }
            if (position_ball_y < 0 || position_ball_y + 20 > Draw_Canvas.ActualHeight) // || position_ball_y >= (position_player1_y + player_1.ActualHeight) || position_ball_y <= position_player1_y
            {
                speed_y *= -1;             // Bounce wnr bal tussen 0 en height 
            }
            if (position_ball_x == 0 || position_ball_x + 20 == Draw_Canvas.ActualWidth)
            {
                position_ball_x = Draw_Canvas.ActualWidth / 2;      // als de bal botst tegen muur moet hij terug naar het midden en stopt de timer tot je weer op start drukt 
                position_ball_y = Draw_Canvas.ActualHeight / 2;
                start_Button.Visibility = Visibility.Visible;       // Button wordt weer zichtbaar en de timer stopt tot je op start drukt
                timer.Stop();
            }
            position_ball_x += speed_x;
            position_ball_y += speed_y;
            MoveBall(position_ball_x, position_ball_y);
            Move_Player1();                //PLAYER 1 laten bewegen met up en down keys
            Move_Player2();                //player 2 laten bewegen met a en q keys

            //nog toevoegen: 
            //- als het botst tegen de rectangle dan gaat *-1 
        }

        private void MoveBall(double position_ball_x, double position_ball_y)
        {
            Canvas.SetLeft(circle, position_ball_x);
            Canvas.SetTop(circle, position_ball_y);
        }

        private void Move_Player1()
        {
            if (Keyboard.IsKeyDown(Key.Down) && position_player1_y < Draw_Canvas.ActualHeight - player_1.Height)
            {
                position_player1_y += 4;
            }
            if (Keyboard.IsKeyDown(Key.Up) && position_player1_y > 0)
            {
                position_player1_y -= 4;
            }
            if (Keyboard.IsKeyDown(Key.Down) && position_player2_y >= Draw_Canvas.ActualHeight - player_1.Height)
            {
                position_player2_y += 0;        //laten stoppen als je aan einde van venster komt (verticaal)
            }
            Canvas.SetLeft(player_1, 20); // position based on center
            Canvas.SetTop(player_1, position_player1_y); // position based on center
        }
        private void Move_Player2()
        {
            if (Keyboard.IsKeyDown(Key.Q) && position_player2_y < Draw_Canvas.ActualHeight - player_2.Height)
            {
                position_player2_y += 4;
            }
            else if (Keyboard.IsKeyDown(Key.A) && position_player2_y > 0)
            {
                position_player2_y -= 4;
            }
            if (position_player2_y >= Draw_Canvas.ActualHeight - player_2.Height || position_player2_y <= 0)
            {
                position_player2_y += 0;
            }

            Canvas.SetLeft(player_2, (Draw_Canvas.ActualWidth - player_2.Width) - 20); // position based on center
            Canvas.SetTop(player_2, position_player2_y); // position based on center
        }

        private void Draw_Ball()
        {
            circle.Height = 20;
            circle.Width = 20;
            circle.Fill = Brushes.White;
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

        private void start_Button_Click(object sender, RoutedEventArgs e)
        {
            start_Button.Visibility = Visibility.Hidden;
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Start();
            timer.Tick += Timer_Tick;
        }
    }
}
