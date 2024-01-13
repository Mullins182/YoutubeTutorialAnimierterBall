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

    // Tutorial Video auf Youtube zum Programm >> https://www.youtube.com/watch?v=ugji-_yWoRk
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _animationTimer = new DispatcherTimer();

        public bool ball1goesRight = true;
        public bool ball2goesRight = true;
        public bool ball3goesRight = true;

        public bool ball1goesDown = true;
        public bool ball2goesDown = true;
        public bool ball3goesDown = true;

        public bool ball1_collisionL = true;
        public bool ball2_collisionL = true;
        public bool ball3_collisionL = true;

        public bool ball1_collisionR = false;
        public bool ball2_collisionR = false;
        public bool ball3_collisionR = false;

        public MainWindow()
        {
            InitializeComponent();

            _animationTimer.Interval    = TimeSpan.FromMilliseconds(5);
            _animationTimer.Tick        += positioniereBall;                 // Die Methode unter diesem "Tick" wird immer ausgeführt, wenn der Timer abgelaufen ist !

        }

        public void positioniereBall(object? sender, EventArgs e)
        {

            var ball1X = Canvas.GetLeft(Ball1);
            var ball2X = Canvas.GetLeft(Ball2);
            var ball3X = Canvas.GetLeft(Ball3);
            var ball1Y = Canvas.GetTop(Ball1);
            var ball2Y = Canvas.GetTop(Ball2);
            var ball3Y = Canvas.GetTop(Ball3);

            var ball1_M = Canvas.GetLeft(Ball1) + (Ball1.ActualWidth / 2);
            var ball2_M = Canvas.GetLeft(Ball2) + (Ball2.ActualWidth / 2);
            var ball3_M = Canvas.GetLeft(Ball3) + (Ball3.ActualWidth / 2);

            var ball1_dirX_right = ball1X + 1;
            var ball2_dirX_right = ball2X + 1;
            var ball3_dirX_right = ball3X + 1;
            var ball1_dirX_left  = ball1X - 1;
            var ball2_dirX_left  = ball2X - 1;
            var ball3_dirX_left  = ball3X - 1;

            var ball1_dirY_down  = ball1Y + 1;
            var ball2_dirY_down  = ball2Y + 1;
            var ball3_dirY_down  = ball3Y + 1;
            var ball1_dirY_up    = ball1Y - 1;
            var ball2_dirY_up    = ball2Y - 1;
            var ball3_dirY_up    = ball3Y - 1;

            PositionInfo.Content = $"Ball 1 M-Pos: {ball1_M} \n\nBall 2 M-Pos: {ball2_M} \n\nBall 3 M-Pos: {ball3_M}";

            // Kollisionslogik

            if (ball1_M == ball2_M - Ball2.ActualWidth || ball1_M == ball3_M - Ball3.ActualWidth)        
            {
                ball1_collisionR = true;
                MessageBox.Show("Kollision R !!!");
                ball1_collisionL = false;
            }

            if (ball2_M == ball1_M - Ball1.ActualWidth || ball2_M == ball3_M - Ball3.ActualWidth)
            {
                ball2_collisionR = true;
                //MessageBox.Show("Kollision R !!!");
                ball2_collisionL = false;
            }

            if (ball3_M == ball1_M - Ball1.ActualWidth || ball3_M == ball2_M - Ball2.ActualWidth)
            {
                ball3_collisionR = true;
                //MessageBox.Show("Kollision R !!!");
                ball3_collisionL = false;
            }

            if (ball1_M == ball2_M + Ball2.ActualWidth || ball1_M == ball3_M + Ball3.ActualWidth)
            {
                ball1_collisionR = false;
                //MessageBox.Show("Kollision L !!!");
                ball1_collisionL = true;
            }

            if (ball2_M == ball1_M + Ball1.ActualWidth || ball2_M == ball3_M + Ball3.ActualWidth)
            {
                ball2_collisionR = false;
                //MessageBox.Show("Kollision L !!!");
                ball2_collisionL = true;
            }

            if (ball3_M == ball1_M + Ball1.ActualWidth || ball3_M == ball2_M + Ball2.ActualWidth)
            {
                ball3_collisionR = false;
                //MessageBox.Show("Kollision L !!!");
                ball3_collisionL = true;
            }


            if (ball1_M >= AnimationField.ActualWidth - Ball1.ActualWidth / 2)         // Ball im Canvas auf der X-Achse (links/rechts) bewegen !
            {
                ball1_collisionL = false;
                ball1_collisionR = true;
            }
            else if (ball1_M <= 0 + Ball1.ActualWidth / 2)
            {
                ball1_collisionL = true;
                ball1_collisionR = false;
            }

            if (ball2_M >= AnimationField.ActualWidth - Ball2.ActualWidth / 2)
            {
                ball2_collisionL = false;
                ball2_collisionR = true;
            }
            else if (ball2_M <= 0 + Ball2.ActualWidth / 2)
            {
                ball2_collisionL = true;
                ball2_collisionR = false;
            }

            if (ball3_M >= AnimationField.ActualWidth - Ball3.ActualWidth / 2)
            {
                ball3_collisionL = false;
                ball3_collisionR = true;
            }
            else if (ball3_M <= 0 + Ball3.ActualWidth / 2)
            {
                ball3_collisionL = true;
                ball3_collisionR = false;
            }


            if (ball1_collisionL)
            {
                Canvas.SetLeft(Ball1, ball1_dirX_right);                           // Ball im Canvas auf der X-Achse (links/rechts) bewegen !
            }
            else if (ball1_collisionR)
            {
                Canvas.SetLeft(Ball1, ball1_dirX_left);                           // Ball im Canvas auf der X-Achse (links/rechts) bewegen !
            }

            if (ball2_collisionL)
            {
                Canvas.SetLeft(Ball2, ball2_dirX_right);                           // Ball im Canvas auf der X-Achse (links/rechts) bewegen !
            }
            else if (ball2_collisionR)
            {
                Canvas.SetLeft(Ball2, ball2_dirX_left);                           // Ball im Canvas auf der X-Achse (links/rechts) bewegen !
            }

            if (ball3_collisionL)
            {
                Canvas.SetLeft(Ball3, ball3_dirX_right);                          // Ball im Canvas auf der X-Achse (links/rechts) bewegen !
            }
            else if (ball3_collisionR)
            {                
                Canvas.SetLeft(Ball3, ball3_dirX_left);                           // Ball im Canvas auf der X-Achse (links/rechts) bewegen !
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
                Canvas.SetTop(Ball1, ball1_dirY_down);
            }
            else
            {
                Canvas.SetTop(Ball1, ball1_dirY_up);
            }

            if (ball2goesDown)
            {
                Canvas.SetTop(Ball2, ball2_dirY_down);
            }
            else
            {
                Canvas.SetTop(Ball2, ball2_dirY_up);
            }

            if (ball3goesDown)
            {
                Canvas.SetTop(Ball3, ball3_dirY_down);
            }
            else
            {
                Canvas.SetTop(Ball3, ball3_dirY_up);
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