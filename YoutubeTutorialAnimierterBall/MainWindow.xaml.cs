using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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

        //MediaElement sound  = new MediaElement();
        //MediaElement sound2 = new MediaElement();
        //MediaElement sound3 = new MediaElement();


        public MainWindow()
        {
            InitializeComponent();

            _animationTimer.Interval    = TimeSpan.FromMilliseconds(1);
            _animationTimer.Tick        += PositioniereBall;                 // Die Methode unter diesem "Tick" wird immer ausgeführt, wenn der Timer abgelaufen ist !

            sound.MediaEnded            += Sound_MediaEnded;
            sound2.MediaEnded           += Sound2_MediaEnded;
            sound3.MediaEnded           += Sound3_MediaEnded;
        }
        private void Sound_MediaEnded(object sender, RoutedEventArgs e)
        {
            //sound.Position  = TimeSpan.Zero;
        }
        private void Sound2_MediaEnded(object sender, RoutedEventArgs e)
        {
            //sound2.Position = TimeSpan.Zero;
        }
        private void Sound3_MediaEnded(object sender, RoutedEventArgs e)
        {
            //sound3.Position = TimeSpan.Zero;
        }



        public void PositioniereBall(object? sender, EventArgs e)
        {
            var smiley1X = Canvas.GetLeft(Smiley1);
            var smiley2X = Canvas.GetLeft(Smiley2);
            var smiley3X = Canvas.GetLeft(Smiley3);

            var smiley1Y = Canvas.GetTop(Smiley1);
            var smiley2Y = Canvas.GetTop(Smiley2);
            var smiley3Y = Canvas.GetTop(Smiley3);

            var ball1X = Canvas.GetLeft(Ball1);
            var ball2X = Canvas.GetLeft(Ball2);
            var ball3X = Canvas.GetLeft(Ball3);
            var ball1Y = Canvas.GetTop(Ball1);
            var ball2Y = Canvas.GetTop(Ball2);
            var ball3Y = Canvas.GetTop(Ball3);

            var ball1_M = Canvas.GetLeft(Ball1) + (Ball1.ActualWidth / 2);
            var ball2_M = Canvas.GetLeft(Ball2) + (Ball2.ActualWidth / 2);
            var ball3_M = Canvas.GetLeft(Ball3) + (Ball3.ActualWidth / 2);

            var b1_h = Ball1.ActualHeight;
            var b2_h = Ball2.ActualHeight;
            var b3_h = Ball3.ActualHeight;
            var b1_w = Ball1.ActualWidth;
            var b2_w = Ball2.ActualWidth;
            var b3_w = Ball3.ActualWidth;

            var smiley1_dirX_right  = smiley1X + 1;
            var smiley2_dirX_right  = smiley2X + 1.3;
            var smiley3_dirX_right  = smiley3X + 1.5;
            var smiley1_dirX_left   = smiley1X - 1;
            var smiley2_dirX_left   = smiley2X - 1.3;
            var smiley3_dirX_left   = smiley3X - 1.5;

            var smiley1_dirY_down   = smiley1Y + 1;
            var smiley2_dirY_down   = smiley2Y + 1.3;
            var smiley3_dirY_down   = smiley3Y + 1.5;
            var smiley1_dirY_up     = smiley1Y - 1;
            var smiley2_dirY_up     = smiley2Y - 1.3;
            var smiley3_dirY_up     = smiley3Y - 1.5;

            var ball1_dirX_right    = ball1X + 1;
            var ball2_dirX_right    = ball2X + 1.3;
            var ball3_dirX_right    = ball3X + 1.5;
            var ball1_dirX_left     = ball1X - 1;
            var ball2_dirX_left     = ball2X - 1.3;
            var ball3_dirX_left     = ball3X - 1.5;

            var ball1_dirY_down     = ball1Y + 1;
            var ball2_dirY_down     = ball2Y + 1.3;
            var ball3_dirY_down     = ball3Y + 1.5;
            var ball1_dirY_up       = ball1Y - 1;
            var ball2_dirY_up       = ball2Y - 1.3;
            var ball3_dirY_up       = ball3Y - 1.5;

            PositionInfo.Content = $"Ball 1 M-Pos: {((Int16)ball1_M)} \n\nBall 2 M-Pos: {((Int16)ball2_M)} \n\nBall 3 M-Pos: {((Int16)ball3_M)} \n\nBall 1 Y-Pos: {((Int16)ball1Y)} \n\nBall 2 Y-Pos: {((Int16)ball2Y)} \n\nBall 3 Y-Pos: {((Int16)ball3Y)}";

            // Kollisionslogik Ball-Kollisionen                                  I N  A R B E I T !!!


            if (ball1_M.CompareTo(ball2_M) < Ball2.ActualWidth && ball1Y.CompareTo(ball2Y) < Ball2.ActualHeight - (Ball2.ActualHeight * 2))
            {
                ball1_collisionR = true;
                ball1_collisionL = false;
            }

            if (ball2_M.CompareTo(ball1_M - Ball1.ActualWidth) == 0 || ball2_M.CompareTo(ball3_M - Ball3.ActualWidth) == 0)
            {
                if (ball2Y.CompareTo(ball1Y)! > b1_h && ball2Y.CompareTo(ball1Y)! < b1_h - (b1_h * 2) || ball2Y.CompareTo(ball3Y)! > b3_h && ball2Y.CompareTo(ball3Y)! < b3_h - (b3_h * 2))
                {
                    ball2_collisionR = true;
                    //MessageBox.Show("Kollision R !!!");
                    ball2_collisionL = false;
                }
            }

            if (ball3_M.CompareTo(ball1_M - Ball1.ActualWidth) == 0 || ball3_M.CompareTo(ball2_M - Ball2.ActualWidth) == 0)
            {
                if (ball3Y.CompareTo(ball1Y)! > b1_h && ball3Y.CompareTo(ball1Y)! < b1_h - (b1_h * 2) || ball3Y.CompareTo(ball2Y)! > b2_h && ball3Y.CompareTo(ball2Y)! < b2_h - (b2_h * 2))
                {
                    ball3_collisionR = true;
                    //MessageBox.Show("Kollision R !!!");
                    ball3_collisionL = false;
                }
            }

            if (ball1_M.CompareTo(ball2_M + Ball2.ActualWidth) == 0 || ball1_M.CompareTo(ball3_M + Ball3.ActualWidth) == 0)
            {
                if (ball1Y.CompareTo(ball2Y)! > b2_h && ball1Y.CompareTo(ball2Y)! < b2_h - (b2_h * 2) || ball1Y.CompareTo(ball3Y)! > b3_h && ball1Y.CompareTo(ball3Y)! < b3_h - (b3_h * 2))
                {
                    ball1_collisionR = false;
                    //MessageBox.Show("Kollision L !!!");
                    ball1_collisionL = true;
                }
            }

            if (ball2_M.CompareTo(ball1_M + Ball1.ActualWidth) == 0 || ball2_M.CompareTo(ball3_M + Ball3.ActualWidth) == 0)
            {
                if (ball2Y.CompareTo(ball1Y)! > b1_h && ball2Y.CompareTo(ball1Y)! < b1_h - (b1_h * 2) || ball2Y.CompareTo(ball3Y)! > b3_h && ball2Y.CompareTo(ball3Y)! < b3_h - (b3_h * 2))
                {
                    ball2_collisionR = false;
                    //MessageBox.Show("Kollision L !!!");
                    ball2_collisionL = true;
                }
            }

            if (ball3_M.CompareTo(ball1_M + Ball1.ActualWidth) == 0 || ball1_M.CompareTo(ball2_M + Ball2.ActualWidth) == 0)
            {
                if (ball3Y.CompareTo(ball1Y)! > b1_h && ball3Y.CompareTo(ball1Y)! < b1_h - (b1_h * 2) || ball3Y.CompareTo(ball2Y)! > b2_h && ball3Y.CompareTo(ball2Y)! < b2_h - (b2_h * 2))
                {
                    ball3_collisionR = false;
                    //MessageBox.Show("Kollision L !!!");
                    ball3_collisionL = true;
                }
            }

            // Kollisionslogik für Y-Achse

            if (ball1Y.CompareTo(ball2Y - Ball1.ActualHeight) == 0 || ball1Y.CompareTo(ball3Y - Ball1.ActualHeight) == 0)
            {
                if (ball1_M.CompareTo(ball2_M) !> b2_w && ball1_M.CompareTo(ball2_M) !< b2_w - (b2_w * 2) || ball1_M.CompareTo(ball3_M) !> b3_w && ball1_M.CompareTo(ball3_M) !< b3_w - (b3_w * 2)) 
                {
                    ball1_collisionU = true;
                    ball1_collisionD = false;
                }
            }
            else if (ball1Y.CompareTo(ball2Y + Ball1.ActualHeight) == 0 || ball1Y.CompareTo(ball3Y + Ball1.ActualHeight) == 0)
            {
                if (ball1_M.CompareTo(ball2_M)! > b2_w && ball1_M.CompareTo(ball2_M)! < b2_w - (b2_w * 2) || ball1_M.CompareTo(ball3_M)! > b3_w && ball1_M.CompareTo(ball3_M)! < b3_w - (b3_w * 2))
                {
                    ball1_collisionU = false;
                    ball1_collisionD = true;
                }
            }

            if (ball2Y.CompareTo(ball1Y - Ball2.ActualHeight) == 0 || ball2Y.CompareTo(ball3Y - Ball2.ActualHeight) == 0)
            {
                if (ball2_M.CompareTo(ball1_M) !> b1_w && ball2_M.CompareTo(ball1_M) !< b1_w - (b1_w * 2) || ball2_M.CompareTo(ball3_M) !> b3_w && ball2_M.CompareTo(ball3_M) !< b3_w - (b3_w * 2))
                {
                    ball2_collisionU = true;
                    ball2_collisionD = false;
                }
            }
            else if (ball2Y.CompareTo(ball1Y + Ball2.ActualHeight) == 0 || ball2Y.CompareTo(ball3Y + Ball2.ActualHeight) == 0)
            {
                if (ball2_M.CompareTo(ball1_M)! > b1_w && ball2_M.CompareTo(ball1_M)! < b1_w - (b1_w * 2) || ball2_M.CompareTo(ball3_M)! > b3_w && ball2_M.CompareTo(ball3_M)! < b3_w - (b3_w * 2))
                {
                    ball2_collisionU = false;
                    ball2_collisionD = true;
                }
            }

            if (ball3Y.CompareTo(ball1Y - Ball3.ActualHeight) == 0 || ball3Y.CompareTo(ball2Y - Ball3.ActualHeight) == 0)
            {
                if (ball3_M.CompareTo(ball1_M) !> b1_w && ball3_M.CompareTo(ball1_M) !< b1_w - (b1_w * 2) || ball3_M.CompareTo(ball2_M) !> b2_w && ball3_M.CompareTo(ball2_M) !< b2_w - (b2_w * 2))
                {
                    ball3_collisionU = true;
                    ball3_collisionD = false;
                }
            }
            else if (ball3Y.CompareTo(ball1Y + Ball3.ActualHeight) == 0 || ball3Y.CompareTo(ball2Y + Ball3.ActualHeight) == 0)
            {
                if (ball3_M.CompareTo(ball1_M)! > b1_w && ball3_M.CompareTo(ball1_M)! < b1_w - (b1_w * 2) || ball3_M.CompareTo(ball2_M)! > b2_w && ball3_M.CompareTo(ball2_M)! < b2_w - (b2_w * 2))
                {
                    ball3_collisionU = false;
                    ball3_collisionD = true;
                }
            }

            // Kollisionslogik Canvas Grenzen

            if (ball1_M >= AnimationField.ActualWidth - Ball1.ActualWidth / 2)         
            {
                sound.Position = TimeSpan.Zero;
                sound.Play();

                ball1_collisionL = false;
                ball1_collisionR = true;
            }
            else if (ball1_M <= 0 + Ball1.ActualWidth / 2)
            {
                sound.Position = TimeSpan.Zero;
                sound.Play();

                ball1_collisionL = true;
                ball1_collisionR = false;
            }

            if (ball2_M >= AnimationField.ActualWidth - Ball2.ActualWidth / 2)
            {
                sound2.Position = TimeSpan.Zero;
                sound2.Play();

                ball2_collisionL = false;
                ball2_collisionR = true;
            }
            else if (ball2_M <= 0 + Ball2.ActualWidth / 2)
            {
                sound2.Position = TimeSpan.Zero;
                sound2.Play();

                ball2_collisionL = true;
                ball2_collisionR = false;
            }

            if (ball3_M >= AnimationField.ActualWidth - Ball3.ActualWidth / 2)
            {
                sound3.Position = TimeSpan.Zero;
                sound3.Play();

                ball3_collisionL = false;
                ball3_collisionR = true;
            }
            else if (ball3_M <= 0 + Ball3.ActualWidth / 2)
            {
                sound3.Position = TimeSpan.Zero;
                sound3.Play();

                ball3_collisionL = true;
                ball3_collisionR = false;
            }

            // Kollisionslogik Canvas Grenzen für Y-Achse

            if (ball1Y >= AnimationField.ActualHeight - Ball1.ActualHeight)       
            {
                sound.Position = TimeSpan.Zero;
                sound.Play();

                ball1_collisionD = true;
                ball1_collisionU = false;
            }
            else if (ball1Y <= 0)
            {
                sound.Position = TimeSpan.Zero;
                sound.Play();

                ball1_collisionU = true;
                ball1_collisionD = false;
            }

            if (ball2Y >= AnimationField.ActualHeight - Ball2.ActualHeight)       
            {
                sound2.Position = TimeSpan.Zero;
                sound2.Play();

                ball2_collisionD = true;
                ball2_collisionU = false;
            }
            else if (ball2Y <= 0)
            {
                sound2.Position = TimeSpan.Zero;
                sound2.Play();

                ball2_collisionU = true;
                ball2_collisionD = false;
            }

            if (ball3Y >= AnimationField.ActualHeight - Ball3.ActualHeight)       
            {
                sound3.Position = TimeSpan.Zero;
                sound3.Play();

                ball3_collisionD = true;
                ball3_collisionU = false;
            }
            else if (ball3Y <= 0)
            {
                sound3.Position = TimeSpan.Zero;
                sound3.Play();

                ball3_collisionU = true;
                ball3_collisionD = false;
            }

            // Bewegungslogik der Bälle für X-Achse

            if (ball1_collisionL)
            {
                Canvas.SetLeft(Ball1, ball1_dirX_right);                           // Ball im Canvas auf der X-Achse (links/rechts) bewegen !
                Canvas.SetLeft(Smiley1, smiley1_dirX_right);
            }
            else if (ball1_collisionR)
            {
                Canvas.SetLeft(Ball1, ball1_dirX_left);                           // Ball im Canvas auf der X-Achse (links/rechts) bewegen !
                Canvas.SetLeft(Smiley1, smiley1_dirX_left);
            }

            if (ball2_collisionL)
            {
                Canvas.SetLeft(Ball2, ball2_dirX_right);                           // Ball im Canvas auf der X-Achse (links/rechts) bewegen !
                Canvas.SetLeft(Smiley2, smiley2_dirX_right);

            }
            else if (ball2_collisionR)
            {
                Canvas.SetLeft(Ball2, ball2_dirX_left);                           // Ball im Canvas auf der X-Achse (links/rechts) bewegen !
                Canvas.SetLeft(Smiley2, smiley2_dirX_left);

            }

            if (ball3_collisionL)
            {
                Canvas.SetLeft(Ball3, ball3_dirX_right);                          // Ball im Canvas auf der X-Achse (links/rechts) bewegen !
                Canvas.SetLeft(Smiley3, smiley3_dirX_right);

            }
            else if (ball3_collisionR)
            {
                Canvas.SetLeft(Ball3, ball3_dirX_left);                           // Ball im Canvas auf der X-Achse (links/rechts) bewegen !
                Canvas.SetLeft(Smiley3, smiley3_dirX_left);


            }

            // Bewegungslogik der Bälle für Y-Achse

            if (ball1_collisionD)
            {
                Canvas.SetTop(Ball1, ball1_dirY_up);
                Canvas.SetTop(Smiley1, smiley1_dirY_up);

            }
            else if (ball1_collisionU)
            {
                Canvas.SetTop(Ball1, ball1_dirY_down);
                Canvas.SetTop(Smiley1, smiley1_dirY_down);

            }

            if (ball2_collisionD)
            {
                Canvas.SetTop(Ball2, ball2_dirY_up);
                Canvas.SetTop(Smiley2, smiley2_dirY_up);

            }
            else if (ball2_collisionU)
            {
                Canvas.SetTop(Ball2, ball2_dirY_down);
                Canvas.SetTop(Smiley2, smiley2_dirY_down);

            }

            if (ball3_collisionD)
            {
                Canvas.SetTop(Ball3, ball3_dirY_up);
                Canvas.SetTop(Smiley3, smiley3_dirY_up);

            }
            else if (ball3_collisionU)
            {
                Canvas.SetTop(Ball3, ball3_dirY_down);
                Canvas.SetTop(Smiley3, smiley3_dirY_down);

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

        private void SoundOnOff_Click(object sender, RoutedEventArgs e)
        {
            if (SoundOnOff.Foreground == Brushes.OrangeRed)
            {
                SoundOnOff.Foreground = Brushes.GreenYellow;

                sound.Source = new Uri("drum.mp3", UriKind.RelativeOrAbsolute);
                sound2.Source = new Uri("drum2.mp3", UriKind.RelativeOrAbsolute);
                sound3.Source = new Uri("drum3.mp3", UriKind.RelativeOrAbsolute);

                sound.Stop();
                sound2.Stop();
                sound3.Stop();
            }
            else
            {
                sound.Close();
                sound2.Close();
                sound3.Close();

                SoundOnOff.Foreground = Brushes.OrangeRed;

                sound.Source = new Uri("", UriKind.RelativeOrAbsolute);
                sound2.Source = new Uri("", UriKind.RelativeOrAbsolute);
                sound3.Source = new Uri("", UriKind.RelativeOrAbsolute);
            }
        }
    }
}