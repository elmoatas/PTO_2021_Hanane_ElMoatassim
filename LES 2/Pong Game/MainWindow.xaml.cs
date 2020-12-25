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
        Rectangle player1 = new Rectangle();
        Rectangle player2 = new Rectangle();
        Ellipse circle = new Ellipse();
        DispatcherTimer timer = new DispatcherTimer();
        int speed_x = 1;                   //snelheid van de bal
        int speed_y = 1;
        double position_ball_x = 0;        //Plaatsbepaling van de bal
        double position_ball_y = 0;
        double positionPlayer1y = 0;       //positie bepalen van rechthoekje
        double positionPlayer2y = 0;
        int scorePlayer1 = 0;             //score player1 en 2 
        int scorePlayer2 = 0;
        bool collisionP1;


        public MainWindow()
        {
            InitializeComponent();
            Draw_Rectangle();               //Speler1 en speler 2 tekenen 
            Draw_Ball();                    //Bal tekenen      
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            MoveBall();
            MovePlayer1();                //PLAYER 1 laten bewegen met up en down keys
            MovePlayer2();                //player 2 laten bewegen met a en q keys
        }
        private bool CollussionPlayer1()
        {
            if (Canvas.GetTop(circle) <= (Canvas.GetTop(player1) + player1.ActualHeight) &&
                Canvas.GetTop(circle) >= Canvas.GetTop(player1) &&
                Canvas.GetLeft(circle) <= (Canvas.GetLeft(player1) + player1.ActualWidth))
            {
                collisionP1 = true;
                return true;
            }
            else return false;
        }
        private bool CollussionPlayer2()
        {
            if (Canvas.GetTop(circle) <= (Canvas.GetTop(player2) + player2.ActualHeight) &&
                Canvas.GetTop(circle) >= Canvas.GetTop(player2) &&
                Canvas.GetLeft(circle) >= Canvas.GetLeft(player2))
            {
                collisionP1 = false;
                return true;
            }
            else return false;
        }
        private void Timer()
        {
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private void PauzeGame()
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
            }
        }
        private void GiveScoreAndPrint()
        {

            //collisionP1 == true ? scorePlayer1++ : scorePlayer2++; //ternary operatoren lukken niet 
            if (collisionP1)
            {
                scorePlayer1 += 1;
            }
            else
            {
                scorePlayer2 += 1;
            }
            ScorePlayer1Label.Content = scorePlayer1;
            ScorePlayer2Label.Content = scorePlayer2;

        }
        private void MoveBall()
        {

            if (CollussionPlayer1() || CollussionPlayer2())
            {
                speed_x *= -1;
            }
            if (Canvas.GetTop(circle) < 0 || Canvas.GetTop(circle) + circle.ActualHeight > Canvas.ActualHeight)
            {
                speed_y *= -1;             // Bounce wnr bal tussen 0 en height 
            }
            if (Canvas.GetLeft(circle) == 0 || (Canvas.GetLeft(circle) + circle.ActualWidth) == Canvas.ActualWidth)
            {
                position_ball_x = Canvas.ActualWidth / 2;      // als de bal botst tegen muur moet hij terug naar het midden en stopt de timer tot je weer op start drukt 
                position_ball_y = Canvas.ActualHeight / 2;
                PauzeGame();
                GiveScoreAndPrint();
            }
            position_ball_x += speed_x;
            position_ball_y += speed_y;
            Canvas.SetLeft(circle, position_ball_x);
            Canvas.SetTop(circle, position_ball_y);
        }

        private void MovePlayer1()
        {
            if (Keyboard.IsKeyDown(Key.Down) && positionPlayer1y < Canvas.ActualHeight - player1.Height)
            {
                positionPlayer1y += 4;    // naar beneden bewegen van Player1 && stopt als het aan einde van canvas komt
            }
            if (Keyboard.IsKeyDown(Key.Up) && positionPlayer1y > 0)
            {
                positionPlayer1y -= 4;    // Naar boven bewegen van Player1 && stopt als het aan begin van canvas komt
            }
            Canvas.SetLeft(player1, 20);
            Canvas.SetTop(player1, positionPlayer1y);
        }

        private void MovePlayer2()
        {
            if (Keyboard.IsKeyDown(Key.Q) && positionPlayer2y < Canvas.ActualHeight - player2.Height)
            {
                positionPlayer2y += 4;  // naar beneden bewegen van Player1 && stopt als het aan einde van canvas komt
            }
            else if (Keyboard.IsKeyDown(Key.A) && positionPlayer2y > 0)
            {
                positionPlayer2y -= 4;  // Naar boven bewegen van Player1 && stopt als het aan begin van canvas komt
            }

            Canvas.SetLeft(player2, (Canvas.ActualWidth - player2.Width) - 20);
            Canvas.SetTop(player2, positionPlayer2y);
        }

        private void Draw_Ball()
        {
            circle.Height = 20;
            circle.Width = 20;
            circle.Fill = Brushes.White;
            Canvas.Children.Add(circle);
        }

        private void Draw_Rectangle()
        {
            player1.Height = 100;
            player1.Width = 20;
            player1.Fill = Brushes.White;
            Canvas.Children.Add(player1);

            player2.Height = 100;
            player2.Width = 20;
            player2.Fill = Brushes.White;
            Canvas.Children.Add(player2);
        }

        private void start_Button_Click(object sender, RoutedEventArgs e)
        {
            Timer();
        }

        private void Pause_Button_Click(object sender, RoutedEventArgs e)
        {
            PauzeGame();
        }
    }
}
