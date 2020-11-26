using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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
            DrawBear();
        }
        private void DrawBear()
        {
            //left ear
            drawEar(12, 0);
            // right ear
            drawEar(120, 0);
            //face
            face();
            //left eye
            eyes(0, 80);
            // right eye
            eyes(120, 80);
        }
        private void drawEar(double x, double y)
        {
            Ellipse ear = new Ellipse();
            ear.Height = 80;
            ear.Width = 80;
            ear.Fill = Brushes.LightSkyBlue;
            ear.Stroke = Brushes.CadetBlue;
            ear.StrokeThickness = 1.0;

            Ellipse innerEar = new Ellipse();
            innerEar.Height = 40;
            innerEar.Width = 40;
            innerEar.Fill = Brushes.LightPink;
            innerEar.Stroke = Brushes.DeepPink;
            innerEar.StrokeThickness = 1.0;

            DrawCanvas.Children.Add(ear);
            DrawCanvas.Children.Add(innerEar);

            Canvas.SetLeft(ear, x);
            Canvas.SetTop(ear, y);

            Canvas.SetLeft(innerEar, x + 20);
            Canvas.SetTop(innerEar, y + 20);

        }
        private void face()
        {
            Ellipse face = new Ellipse();
            face.Height = 180;
            face.Width = 180;
            face.Fill = Brushes.LightSkyBlue;
            face.Stroke = Brushes.CadetBlue;
            face.StrokeThickness = 1.0;

            DrawCanvas.Children.Add(face);
        }
        private void eyes(double x, double y)
        {
            Ellipse eyes = new Ellipse();
            eyes.Height = 20;
            eyes.Width = 20;
            eyes.Fill = Brushes.White;
            eyes.Stroke = Brushes.CadetBlue;
            eyes.StrokeThickness = 1.0;

            Ellipse innerEyes = new Ellipse();
            innerEyes.Height = 10;
            innerEyes.Width = 10;
            innerEyes.Fill = Brushes.Black;

            DrawCanvas.Children.Add(eyes);
            DrawCanvas.Children.Add(innerEyes);
            Canvas.SetLeft(eyes, x);
            Canvas.SetTop(eyes, y);

            Canvas.SetLeft(innerEyes, x + 5);
            Canvas.SetTop(innerEyes, y + 5);
        }

        

    }

}
