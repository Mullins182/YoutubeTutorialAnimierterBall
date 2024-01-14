using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace YoutubeTutorialAnimierterBall
{

    // Tutorial Video auf Youtube zum Programm >> https://www.youtube.com/watch?v=ugji-_yWoRk
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _animationTimer = new DispatcherTimer();

        // Kollisionsprüfung X-Achse / Y-Achse
        private bool ball1_collisionU = true;
        private bool ball2_collisionU = true;
        private bool ball3_collisionU = true;

        private bool ball1_collisionD = false;
        private bool ball2_collisionD = false;
        private bool ball3_collisionD = false;

        private bool ball1_collisionL = true;
        private bool ball2_collisionL = true;
        private bool ball3_collisionL = true;

        private bool ball1_collisionR = false;
        private bool ball2_collisionR = false;
        private bool ball3_collisionR = false;


        public MainWindow()
        {
            InitializeComponent();

            _animationTimer.Interval    = TimeSpan.FromMilliseconds(5);
            _animationTimer.Tick        += PositioniereBall;                 // Die Methode unter diesem "Tick" wird immer ausgeführt, wenn der Timer abgelaufen ist !

        }

        public void PositioniereBall(object? sender, EventArgs e)
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

            PositionInfo.Content = $"Ball 1 M-Pos: {ball1_M} \n\nBall 2 M-Pos: {ball2_M} \n\nBall 3 M-Pos: {ball3_M} \n\nBall 1 Y-Pos: {ball1Y} \n\nBall 2 Y-Pos: {ball2Y} \n\nBall 3 Y-Pos: {ball3Y}";

            // Kollisionslogik Ball-Kollisionen                                  I N  A R B E I T !!!

                // Reichweite Prüfung für Bälle


            if (ball1_M.CompareTo(ball2_M - Ball2.ActualWidth) == 0 || ball1_M.CompareTo(ball3_M - Ball3.ActualWidth) == 0)
            {
                ball1_collisionR = true;
                //MessageBox.Show("Kollision R !!!");
                ball1_collisionL = false;
            }

            if (ball2_M.CompareTo(ball1_M - Ball1.ActualWidth) == 0 || ball2_M.CompareTo(ball3_M - Ball3.ActualWidth) == 0)
            {
                ball2_collisionR = true;
                //MessageBox.Show("Kollision R !!!");
                ball2_collisionL = false;
            }

            if (ball3_M.CompareTo(ball1_M - Ball1.ActualWidth) == 0 || ball3_M.CompareTo(ball2_M - Ball2.ActualWidth) == 0)
            {
                ball3_collisionR = true;
                //MessageBox.Show("Kollision R !!!");
                ball3_collisionL = false;
            }

            if (ball1_M.CompareTo(ball2_M + Ball2.ActualWidth) == 0 || ball1_M.CompareTo(ball3_M + Ball3.ActualWidth) == 0)
            {
                ball1_collisionR = false;
                //MessageBox.Show("Kollision L !!!");
                ball1_collisionL = true;
            }

            if (ball2_M.CompareTo(ball1_M + Ball1.ActualWidth) == 0 || ball2_M.CompareTo(ball3_M + Ball3.ActualWidth) == 0)
            {
                ball2_collisionR = false;
                //MessageBox.Show("Kollision L !!!");
                ball2_collisionL = true;
            }

            if (ball3_M.CompareTo(ball1_M + Ball1.ActualWidth) == 0 || ball1_M.CompareTo(ball2_M + Ball2.ActualWidth) == 0)
            {
                ball3_collisionR = false;
                //MessageBox.Show("Kollision L !!!");
                ball3_collisionL = true;
            }

            // Kollisionslogik für Y-Achse

            if (ball1Y.CompareTo(ball2Y - Ball1.ActualHeight) == 0 || ball1Y.CompareTo(ball3Y - Ball1.ActualHeight) == 0)
            {
                if (ball1_M.CompareTo(ball2_M) !> ball2_M && ball1_M.CompareTo(ball2_M) !< ball2_M || ball1_M.CompareTo(ball3_M) !> ball3_M && ball1_M.CompareTo(ball3_M) !< ball3_M) 
                {
                    ball1_collisionU = true;
                    ball1_collisionD = false;
                }
            }
            else if (ball1Y.CompareTo(ball2Y + Ball1.ActualHeight) == 0 || ball1Y.CompareTo(ball3Y + Ball1.ActualHeight) == 0)
            {
                if (ball1_M.CompareTo(ball2_M) !> ball2_M && ball1_M.CompareTo(ball2_M) !< ball2_M || ball1_M.CompareTo(ball3_M) !> ball3_M && ball1_M.CompareTo(ball3_M) !< ball3_M)
                {
                    ball1_collisionU = false;
                    ball1_collisionD = true;
                }
            }

            if (ball2Y.CompareTo(ball1Y - Ball2.ActualHeight) == 0 || ball2Y.CompareTo(ball3Y - Ball2.ActualHeight) == 0)
            {
                if (ball2_M.CompareTo(ball1_M) !> ball1_M && ball2_M.CompareTo(ball1_M) !< ball1_M || ball2_M.CompareTo(ball3_M) !> ball3_M && ball2_M.CompareTo(ball3_M) !< ball3_M)
                {
                    ball2_collisionU = true;
                    ball2_collisionD = false;
                }
            }
            else if (ball2Y.CompareTo(ball1Y + Ball2.ActualHeight) == 0 || ball2Y.CompareTo(ball3Y + Ball2.ActualHeight) == 0)
            {
                if (ball2_M.CompareTo(ball1_M) !> ball1_M && ball2_M.CompareTo(ball1_M) !< ball1_M || ball2_M.CompareTo(ball3_M) !> ball3_M && ball2_M.CompareTo(ball3_M) !< ball3_M)
                {
                    ball2_collisionU = false;
                    ball2_collisionD = true;
                }
            }

            if (ball3Y.CompareTo(ball1Y - Ball3.ActualHeight) == 0 || ball3Y.CompareTo(ball2Y - Ball3.ActualHeight) == 0)
            {
                if (ball3_M.CompareTo(ball1_M) !> ball1_M && ball3_M.CompareTo(ball1_M) !< ball1_M || ball3_M.CompareTo(ball2_M) !> ball2_M && ball3_M.CompareTo(ball2_M) !< ball2_M)
                {
                    ball3_collisionU = true;
                    ball3_collisionD = false;
                }
            }
            else if (ball3Y.CompareTo(ball1Y + Ball3.ActualHeight) == 0 || ball3Y.CompareTo(ball2Y + Ball3.ActualHeight) == 0)
            {
                if (ball3_M.CompareTo(ball1_M) !> ball1_M && ball3_M.CompareTo(ball1_M) !< ball1_M || ball3_M.CompareTo(ball2_M) !> ball2_M && ball3_M.CompareTo(ball2_M) !< ball2_M)
                {
                    ball3_collisionU = false;
                    ball3_collisionD = true;
                }
            }


            //if (ball1Y.CompareTo(ball2Y + Ball2.ActualHeight) == 0 || ball1Y.CompareTo(ball3Y + Ball3.ActualHeight) == 0)
            //{
            //    ball1_collisionU = true;
            //    //MessageBox.Show("Kollision U !!!");
            //    ball1_collisionD = false;
            //}

            //if (ball2Y.CompareTo(ball1Y + Ball1.ActualHeight) == 0 || ball2Y.CompareTo(ball3Y + Ball3.ActualHeight) == 0)
            //{
            //    ball2_collisionU = true;
            //    //MessageBox.Show("Kollision U !!!");
            //    ball2_collisionD = false;
            //}

            //if (ball3Y.CompareTo(ball1Y + Ball1.ActualHeight) == 0 || ball1Y.CompareTo(ball2Y + Ball2.ActualHeight) == 0)
            //{
            //    ball3_collisionU = true;
            //    //MessageBox.Show("Kollision U !!!");
            //    ball3_collisionD = false;
            //}

            //if (ball1Y.CompareTo(ball2Y - Ball2.ActualHeight) == 0 || ball1Y.CompareTo(ball3Y - Ball3.ActualHeight) == 0)
            //{
            //    ball1_collisionU = false;
            //    //MessageBox.Show("Kollision D !!!");
            //    ball1_collisionD = true;
            //}

            //if (ball2Y.CompareTo(ball1Y - Ball1.ActualHeight) == 0 || ball2Y.CompareTo(ball3Y - Ball3.ActualHeight) == 0)
            //{
            //    ball2_collisionU = false;
            //    //MessageBox.Show("Kollision D !!!");
            //    ball2_collisionD = true;
            //}

            //if (ball3Y.CompareTo(ball1Y - Ball1.ActualHeight) == 0 || ball3Y.CompareTo(ball2Y - Ball2.ActualHeight) == 0)
            //{
            //    ball3_collisionU = false;
            //    //MessageBox.Show("Kollision D !!!");
            //    ball3_collisionD = true;
            //}


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


            // Kollisionslogik für Y-Achse

            if (ball1Y >= AnimationField.ActualHeight - Ball1.ActualHeight)       // Ball im Canvas auf der Y-Achse (auf/ab) bewegen !
            {
                ball1_collisionD = true;
                ball1_collisionU = false;
            }
            else if (ball1Y <= 0)
            {
                ball1_collisionU = true;
                ball1_collisionD = false;
            }

            if (ball2Y >= AnimationField.ActualHeight - Ball2.ActualHeight)       // Ball im Canvas auf der Y-Achse (auf/ab) bewegen !
            {
                ball2_collisionD = true;
                ball2_collisionU = false;
            }
            else if (ball2Y <= 0)
            {
                ball2_collisionU = true;
                ball2_collisionD = false;
            }

            if (ball3Y >= AnimationField.ActualHeight - Ball3.ActualHeight)       // Ball im Canvas auf der Y-Achse (auf/ab) bewegen !
            {
                ball3_collisionD = true;
                ball3_collisionU = false;
            }
            else if (ball3Y <= 0)
            {
                ball3_collisionU = true;
                ball3_collisionD = false;
            }


            if (ball1_collisionD)
            {
                Canvas.SetTop(Ball1, ball1_dirY_up);
            }
            else if (ball1_collisionU)
            {
                Canvas.SetTop(Ball1, ball1_dirY_down);
            }

            if (ball2_collisionD)
            {
                Canvas.SetTop(Ball2, ball2_dirY_up);
            }
            else if (ball2_collisionU)
            {
                Canvas.SetTop(Ball2, ball2_dirY_down);
            }

            if (ball3_collisionD)
            {
                Canvas.SetTop(Ball3, ball3_dirY_up);
            }
            else if (ball3_collisionU)
            {
                Canvas.SetTop(Ball3, ball3_dirY_down);
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