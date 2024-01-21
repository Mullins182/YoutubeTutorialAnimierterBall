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

        private int collision_counter       = 0;
        private int collision_sound_counter = 0;

        private bool sound_off      = true;
        private bool sound1_played  = false;
        private bool sound2_played  = false;
        private bool sound4_played  = false;
        private bool sound5_played  = false;
        private bool wallHit        = false;

        public MainWindow()
        {
            InitializeComponent();

            _animationTimer.Interval    = TimeSpan.FromMilliseconds(1);
            _animationTimer.Tick        += PositioniereBall;                 // Die Methode unter diesem "Tick" wird immer ausgeführt, wenn der Timer abgelaufen ist !

            //sound.MediaEnded            += Sound_MediaEnded;
            //sound2.MediaEnded           += Sound2_MediaEnded;
            //sound3.MediaEnded           += Sound3_MediaEnded;
        }
        //private void Sound_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    //sound.Position  = TimeSpan.Zero;
        //}
        //private void Sound2_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    //sound2.Position = TimeSpan.Zero;
        //}
        //private void Sound3_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    //sound3.Position = TimeSpan.Zero;
        //}

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
            var ball1yM = Canvas.GetTop(Ball1)  + (Ball1.ActualHeight / 2);
            var ball2yM = Canvas.GetTop(Ball2)  + (Ball2.ActualHeight / 2);
            var ball3yM = Canvas.GetTop(Ball3)  + (Ball3.ActualHeight / 2);

            var smiley1_dirX_right  = smiley1X + 1;
            var smiley2_dirX_right  = smiley2X + 1;
            var smiley3_dirX_right  = smiley3X + 1;
            var smiley1_dirX_left   = smiley1X - 1;
            var smiley2_dirX_left   = smiley2X - 1;
            var smiley3_dirX_left   = smiley3X - 1;

            var smiley1_dirY_down   = smiley1Y + 1;
            var smiley2_dirY_down   = smiley2Y + 1;
            var smiley3_dirY_down   = smiley3Y + 1;
            var smiley1_dirY_up     = smiley1Y - 1;
            var smiley2_dirY_up     = smiley2Y - 1;
            var smiley3_dirY_up     = smiley3Y - 1;

            var ball1_dirX_right    = ball1X + 1;               // Ball Bewegung auf der x-Achse
            var ball2_dirX_right    = ball2X + 1;
            var ball3_dirX_right    = ball3X + 1;
            var ball1_dirX_left     = ball1X - 1;
            var ball2_dirX_left     = ball2X - 1;
            var ball3_dirX_left     = ball3X - 1;

            var ball1_dirY_down     = ball1Y + 1;               // Ball Bewegung auf der Y-Achse
            var ball2_dirY_down     = ball2Y + 1;
            var ball3_dirY_down     = ball3Y + 1;
            var ball1_dirY_up       = ball1Y - 1;
            var ball2_dirY_up       = ball2Y - 1;
            var ball3_dirY_up       = ball3Y - 1;

            var dist_b1_b2 = Math.Sqrt(Math.Pow(ball1_M - ball2_M, 2) + Math.Pow(ball1yM - ball2yM, 2));    // Distanz zwischen Ball1 und Ball2
            var dist_b1_b3 = Math.Sqrt(Math.Pow(ball1_M - ball3_M, 2) + Math.Pow(ball1yM - ball3yM, 2));
            var dist_b2_b3 = Math.Sqrt(Math.Pow(ball2_M - ball3_M, 2) + Math.Pow(ball2yM - ball3yM, 2));

            PositionInfo.Content = $"Dist B1 to B2: { Math.Round(dist_b1_b2, 3)} \n\nDist B1 to B3: {Math.Round(dist_b1_b3, 3)} \n\nDist B2 to B3: {Math.Round(dist_b2_b3, 3)} \n\nBall Collisions: {collision_counter / 2} \n\nSound 5 Played: {sound5_played} \n\nSound Counter: {collision_sound_counter / 2}";

            // Kollisionslogik Ball-Kollisionen (X-Achse)                               I N  A R B E I T !!!


            if (dist_b1_b2 < Ball2.ActualWidth && ball2_M > ball1_M)
            {
                if(Canvas.GetTop(Ball1) < Canvas.GetTop(Ball2))
                {
                    ball1_collisionD = false;
                    ball1_collisionU = true;
                    ball2_collisionD = true;
                    ball2_collisionU = false;
                    ball1_collisionR = true;
                    ball1_collisionL = false;
                    ball2_collisionR = false;
                    ball2_collisionL = true;
                }
                else if(Canvas.GetTop(Ball1) > Canvas.GetTop(Ball2))
                {
                    ball1_collisionD = false;
                    ball1_collisionU = true;
                    ball2_collisionD = true;
                    ball2_collisionU = false;
                    ball1_collisionR = false;
                    ball1_collisionL = true;
                    ball2_collisionR = true;
                    ball2_collisionL = false;
                }
                else
                {
                    ball1_collisionR = true;
                    ball1_collisionL = false;
                    ball2_collisionR = false;
                    ball2_collisionL = true;
                }

                collision_counter++;
            }
            else if (dist_b1_b2 < Ball2.ActualWidth && ball2_M < ball1_M)
            {
                if (Canvas.GetTop(Ball1) < Canvas.GetTop(Ball2))
                {
                    ball1_collisionD = false;
                    ball1_collisionU = true;
                    ball2_collisionD = true;
                    ball2_collisionU = false;
                    ball1_collisionR = false;
                    ball1_collisionL = true;
                    ball2_collisionR = true;
                    ball2_collisionL = false;
                }
                else if (Canvas.GetTop(Ball1) > Canvas.GetTop(Ball2))
                {
                    ball1_collisionU = true;
                    ball1_collisionD = false;
                    ball2_collisionU = false;
                    ball2_collisionD = true;
                    ball1_collisionR = false;
                    ball1_collisionL = true;
                    ball2_collisionR = true;
                    ball2_collisionL = false;
                }
                else
                {
                    ball1_collisionR = false;
                    ball1_collisionL = true;
                    ball2_collisionR = true;
                    ball2_collisionL = false;
                }

                collision_counter++;
            }

            if (dist_b1_b3 < Ball3.ActualWidth && ball3_M > ball1_M)
            {
                ball1_collisionR = true;
                ball1_collisionL = false;
                ball3_collisionR = false;
                ball3_collisionL = true;

                collision_counter++;
            }
            else if (dist_b1_b3 < Ball3.ActualWidth && ball3_M < ball1_M)
            {
                ball1_collisionR = false;
                ball1_collisionL = true;
                ball3_collisionR = true;
                ball3_collisionL = false;

                collision_counter++;
            }

            if (dist_b2_b3 < Ball3.ActualWidth && ball3_M > ball2_M)
            {
                ball2_collisionR = true;
                ball2_collisionL = false;
                ball3_collisionR = false;
                ball3_collisionL = true;

                collision_counter++;
            }
            else if (dist_b2_b3 < Ball3.ActualWidth && ball3_M < ball2_M)
            {
                ball2_collisionR = false;
                ball2_collisionL = true;
                ball3_collisionR = true;
                ball3_collisionL = false;

                collision_counter++;
            }

            // Kollisionslogik Ball-Kollisionen (Y-Achse)                               I N  A R B E I T !!!

            if (dist_b1_b2 < Ball2.ActualHeight && ball2yM > ball1yM)
            {
                ball1_collisionD = true;
                ball1_collisionU = false;
                ball2_collisionD = false;
                ball2_collisionU = true;

                collision_counter++;
            }
            else if (dist_b1_b2 < Ball2.ActualHeight && ball2yM < ball1yM)
            {
                ball1_collisionD = false;
                ball1_collisionU = true;
                ball2_collisionD = true;
                ball2_collisionU = false;

                collision_counter++;
            }

            if (dist_b1_b3 < Ball3.ActualHeight && ball3yM > ball1yM)
            {
                ball1_collisionD = true;
                ball1_collisionU = false;
                ball3_collisionD = false;
                ball3_collisionU = true;

                collision_counter++;
            }
            else if (dist_b1_b3 < Ball3.ActualHeight && ball3yM < ball1yM)
            {
                ball1_collisionD = false;
                ball1_collisionU = true;
                ball3_collisionD = true;
                ball3_collisionU = false;

                collision_counter++;
            }

            if (dist_b2_b3 < Ball3.ActualHeight && ball3yM > ball2yM)
            {
                ball2_collisionD = true;
                ball2_collisionU = false;
                ball3_collisionD = false;
                ball3_collisionU = true;

                collision_counter++;
            }
            else if (dist_b2_b3 < Ball3.ActualHeight && ball3yM < ball2yM)
            {
                ball2_collisionD = false;
                ball2_collisionU = true;
                ball3_collisionD = true;
                ball3_collisionU = false;

                collision_counter++;
            }


            // Kollisionslogik Canvas Grenzen

            if (ball1_M >= AnimationField.ActualWidth - Ball1.ActualWidth / 2)         
            {
                wallHit = true;

                ball1_collisionL = false;
                ball1_collisionR = true;
            }
            else if (ball1_M <= 0 + Ball1.ActualWidth / 2)
            {
                wallHit = true;

                ball1_collisionL = true;
                ball1_collisionR = false;
            }

            if (ball2_M >= AnimationField.ActualWidth - Ball2.ActualWidth / 2)
            {
                wallHit = true;

                ball2_collisionL = false;
                ball2_collisionR = true;
            }
            else if (ball2_M <= 0 + Ball2.ActualWidth / 2)
            {
                wallHit = true;

                ball2_collisionL = true;
                ball2_collisionR = false;
            }

            if (ball3_M >= AnimationField.ActualWidth - Ball3.ActualWidth / 2)
            {
                wallHit = true;

                ball3_collisionL = false;
                ball3_collisionR = true;
            }
            else if (ball3_M <= 0 + Ball3.ActualWidth / 2)
            {
                wallHit = true;

                ball3_collisionL = true;
                ball3_collisionR = false;
            }

            // Kollisionslogik Canvas Grenzen für Y-Achse

            if (ball1Y >= AnimationField.ActualHeight - Ball1.ActualHeight)       
            {
                wallHit = true;

                ball1_collisionD = true;
                ball1_collisionU = false;
            }
            else if (ball1Y <= 0)
            {
                wallHit = true;

                ball1_collisionU = true;
                ball1_collisionD = false;
            }

            if (ball2Y >= AnimationField.ActualHeight - Ball2.ActualHeight)       
            {
                wallHit = true;

                ball2_collisionD = true;
                ball2_collisionU = false;
            }
            else if (ball2Y <= 0)
            {
                wallHit = true;

                ball2_collisionU = true;
                ball2_collisionD = false;
            }

            if (ball3Y >= AnimationField.ActualHeight - Ball3.ActualHeight)       
            {
                wallHit = true;

                ball3_collisionD = true;
                ball3_collisionU = false;
            }
            else if (ball3Y <= 0)
            {
                wallHit = true;

                ball3_collisionU = true;
                ball3_collisionD = false;
            }

            // Kollisionssound-Logik (Bälle)

            if (!sound_off)
            {
                if (wallHit)
                {
                    if (!sound4_played)
                    {
                        sound4.Position = TimeSpan.Zero;
                        sound4.Play();
                        sound4_played = true;
                    }
                    else if (!sound5_played)
                    {
                        sound5.Position = TimeSpan.Zero;
                        sound5.Play();
                        sound5_played = true;
                    }
                    else
                    {
                        sound6.Position = TimeSpan.Zero;
                        sound6.Play();
                        sound4_played = false;
                        sound5_played = false;
                    }

                    wallHit = false;
                }

                if (collision_sound_counter < collision_counter)
                {
                    if (!sound1_played)
                    {
                        sound.Position = TimeSpan.Zero;
                        sound.Play();
                        sound1_played = true;
                    }
                    else if (!sound2_played)
                    {
                        sound2.Position = TimeSpan.Zero;
                        sound2.Play();
                        sound2_played = true;
                    }
                    else
                    {
                        sound3.Position = TimeSpan.Zero;
                        sound3.Play();
                        sound1_played = false;
                        sound2_played = false;
                    }

                    collision_sound_counter++;
                }
            }
            else
            {
                collision_sound_counter = collision_counter;
                wallHit = false;
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

            if (StartStopAnimation.Foreground == Brushes.OrangeRed)
            {
                StartStopAnimation.Foreground = Brushes.GreenYellow;

            }
            else
            {
                StartStopAnimation.Foreground = Brushes.OrangeRed;

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
                sound.Close();
                sound2.Close();
                sound3.Close();
                sound4.Close();
                sound5.Close();
                sound6.Close();

                SoundOnOff.Foreground = Brushes.GreenYellow;

                sound.Source    = new Uri("drum.mp3", UriKind.RelativeOrAbsolute);
                sound2.Source   = new Uri("drum.mp3", UriKind.RelativeOrAbsolute);
                sound3.Source   = new Uri("drum.mp3", UriKind.RelativeOrAbsolute);
                sound4.Source   = new Uri("classic_piouh.mp3", UriKind.RelativeOrAbsolute);
                sound5.Source   = new Uri("classic_piouh.mp3", UriKind.RelativeOrAbsolute);
                sound6.Source   = new Uri("classic_piouh.mp3", UriKind.RelativeOrAbsolute);

                sound.Position  = TimeSpan.Zero;
                sound2.Position = TimeSpan.Zero;
                sound3.Position = TimeSpan.Zero;
                sound4.Position = TimeSpan.Zero;
                sound5.Position = TimeSpan.Zero;
                sound6.Position = TimeSpan.Zero;

                sound_off = false;
            }
            else
            {
                sound_off = true;

                SoundOnOff.Foreground = Brushes.OrangeRed;

                //sound.Source = new Uri(" ", UriKind.Absolute);
                //sound2.Source = new Uri(" ", UriKind.Absolute);            // Verursacht Fehler und Programmabsturz("The Uri is empty"), wenn Sound ausgeschalt. wird !
                //sound3.Source = new Uri(" ", UriKind.Absolute);
                //sound4.Source = new Uri(" ", UriKind.Absolute);
                //sound5.Source = new Uri(" ", UriKind.Absolute);
                //sound6.Source = new Uri(" ", UriKind.Absolute);

                sound.Close();
                sound2.Close();
                sound3.Close();
                sound4.Close();
                sound5.Close();
                sound6.Close();
            }
        }
    }
}