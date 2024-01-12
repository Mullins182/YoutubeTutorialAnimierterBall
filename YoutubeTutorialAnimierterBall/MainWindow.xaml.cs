using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace YoutubeTutorialAnimierterBall
{

    // Turorial Video auf Youtube zum Programm >> https://www.youtube.com/watch?v=ugji-_yWoRk
    public partial class MainWindow : Window
    {
        private DispatcherTimer _animationTimer = new DispatcherTimer();

        private bool ball1goesRight = true;
        private bool ball2goesRight = true;
        private bool ball3goesRight = true;

        private bool ball1goesDown = true;
        private bool ball2goesDown = true;
        private bool ball3goesDown = true;

        private bool ball1x_collision = false;
        private bool ball2x_collision = false;
        private bool ball3x_collision = false;
        private bool ball1y_collision = false;
        private bool ball2y_collision = false;
        private bool ball3y_collision = false;

        public MainWindow()
        {
            InitializeComponent();

            _animationTimer.Interval    = TimeSpan.FromMilliseconds(5);
            _animationTimer.Tick        += positioniereBall;                 // Die Methode unter diesem "Tick" wird immer ausgeführt, wenn der Timer abgelaufen ist !
        }

        private void positioniereBall(object? sender, EventArgs e)
        {
            var ball1X = Canvas.GetLeft(Ball1);
            var ball2X = Canvas.GetLeft(Ball2);
            var ball3X = Canvas.GetLeft(Ball3);
            var ball1Y = Canvas.GetTop(Ball1);
            var ball2Y = Canvas.GetTop(Ball2);
            var ball3Y = Canvas.GetTop(Ball3);


            if (ball1X == ball2X || ball1X == ball3X || ball1X == ball2Y || ball1X == ball3Y)        
            {
                ball1x_collision = true;
            }
            else if (ball1Y == ball2X || ball1Y == ball2Y || ball1Y == ball3X || ball1Y == ball3Y )
            {
                ball1y_collision = true;
            }

            if (ball2X >= AnimationField.ActualWidth - Ball2.ActualWidth)                  // In Arbeit !!! (Kollisionslogik)
            {
                ball2goesRight = false;
            }
            else if (ball2X <= 0)
            {
                ball2goesRight = true;
            }

            if (ball3X >= AnimationField.ActualWidth - Ball3.ActualWidth)
            {
                ball3goesRight = false;
            }
            else if (ball3X <= 0)
            {
                ball3goesRight = true;
            }


            if (ball1X >= AnimationField.ActualWidth - Ball1.ActualWidth)         // Ball im Canvas auf der X-Achse (links/rechts) bewegen !
            {
                ball1goesRight = false;
            }
            else if (ball1X <= 0)
            {
                ball1goesRight = true;
            }
            
            if (ball2X >= AnimationField.ActualWidth - Ball2.ActualWidth)
            {
                ball2goesRight = false;
            }
            else if (ball2X <= 0)
            {
                ball2goesRight = true;
            }

            if (ball3X >= AnimationField.ActualWidth - Ball3.ActualWidth)
            {
                ball3goesRight = false;
            }
            else if (ball3X <= 0)
            {
                ball3goesRight = true;
            }


            if (ball1goesRight)
            {
                Canvas.SetLeft(Ball1, ball1X + 2);                
            }
            else
            {
                Canvas.SetLeft(Ball1, ball1X - 2);
            }

            if (ball2goesRight)
            {
                Canvas.SetLeft(Ball2, ball2X + 2);
            }
            else
            {
                Canvas.SetLeft(Ball2, ball2X - 2);
            }

            if (ball3goesRight)
            {
                Canvas.SetLeft(Ball3, ball3X + 2);
            }
            else
            {
                Canvas.SetLeft(Ball3, ball3X - 2);
            }


            if (ball1Y >= AnimationField.ActualHeight - Ball1.ActualHeight)       // Ball im Canvas auf der Y-Achse (auf/ab) bewegen !
            {
                ball1goesDown = false;
            }
            else if (ball1Y <= 0)
            {
                ball1goesDown = true;
            }

            if (ball2Y >= AnimationField.ActualHeight - Ball2.ActualHeight)       // Ball im Canvas auf der Y-Achse (auf/ab) bewegen !
            {
                ball2goesDown = false;
            }
            else if (ball2Y <= 0)
            {
                ball2goesDown = true;
            }

            if (ball3Y >= AnimationField.ActualHeight - Ball3.ActualHeight)       // Ball im Canvas auf der Y-Achse (auf/ab) bewegen !
            {
                ball3goesDown = false;
            }
            else if (ball3Y <= 0)
            {
                ball3goesDown = true;
            }


            if (ball1goesDown)
            {
                Canvas.SetTop(Ball1, ball1Y + 2);
            }
            else
            {
                Canvas.SetTop(Ball1, ball1Y - 2);
            }

            if (ball2goesDown)
            {
                Canvas.SetTop(Ball2, ball2Y + 2);
            }
            else
            {
                Canvas.SetTop(Ball2, ball2Y - 2);
            }

            if (ball3goesDown)
            {
                Canvas.SetTop(Ball3, ball3Y + 2);
            }
            else
            {
                Canvas.SetTop(Ball3, ball3Y - 2);
            }
        }

        private void StartStopAnimation_Click(object sender, RoutedEventArgs e)   // Button zum Starten und Stoppen der Animation
        {
            if (_animationTimer.IsEnabled)
            {
                _animationTimer.Stop();
            }
            else
            {
                _animationTimer.Start();
            }

            //var mitteX = AnimationField.ActualWidth / 2;          
            //var mitteY = AnimationField.ActualHeight / 2;

            //Canvas.SetLeft(Ball, mitteX);                         // Position auf X und Y Achse festlegen für Ball im Canvas Objekt !
            //Canvas.SetTop(Ball, mitteY);
        }
    }
}