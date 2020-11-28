using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace beer_tekenen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Start();
            timer.Tick += DispatcherTimer_Tick;
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            double x = rnd.Next(0, 800);
            double y = rnd.Next(0, 450);
            DrawBear(x, y);
        }
        private void DrawBear(double x, double y)
        {
            //left ear
            drawEar(x - 60, y - 80);
            // right ear
            drawEar(x + 60, y - 80);
            //face
            face(x, y);
            //left eye
            eyes(x - 30, y - 25);
            // right eye
            eyes(x + 30, y - 25);
            //MOUTH
            Mouth(x, y + 40);
            //NOSE
            Nose(x, y + 40);
        }
        private void AddCircle(double x, double y, double width, double height, Brush fillColor, Brush strokeColor)
        {
            Ellipse circle = new Ellipse();
            circle.Height = height;
            circle.Width = width;
            circle.Fill = fillColor;
            circle.Stroke = strokeColor;
            circle.StrokeThickness = 1.0;
            Canvas.SetLeft(circle, x - width / 2); // position based on center
            Canvas.SetTop(circle, y - height / 2); // position based on center
            DrawCanvas.Children.Add(circle);
        }

        private void drawEar(double x, double y)
        {
            //OUTER EAr
            AddCircle(x, y, 80, 80, Brushes.LightSkyBlue, Brushes.CadetBlue);
            //INNER EAR
            AddCircle(x, y, 40, 40, Brushes.LightPink, Brushes.CadetBlue);
        }

        private void face(double x, double y)
        {
            //Face
            AddCircle(x, y, 220, 200, Brushes.LightSkyBlue, Brushes.CadetBlue);
        }

        private void eyes(double x, double y)
        {
            //OUTER EYE
            AddCircle(x, y, 40, 40, Brushes.White, Brushes.CadetBlue);
            //INNER EYE
            AddCircle(x, y, 20, 20, Brushes.Black, Brushes.Black);
        }

        private void Mouth(double x, double y)
        {
            //MOUTH
            AddCircle(x, y, 130, 100, Brushes.LightPink, Brushes.CadetBlue);

        }

        private void Nose(double x, double y)
        {
            //OUTER NOSE
            AddCircle(x, y, 60, 40, Brushes.CornflowerBlue, Brushes.CadetBlue);
        }

    }

}
