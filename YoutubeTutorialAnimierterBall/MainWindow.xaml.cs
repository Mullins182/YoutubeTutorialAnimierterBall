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

        private bool goesRight = true;
        public MainWindow()
        {
            InitializeComponent();

            _animationTimer.Interval = TimeSpan.FromMilliseconds(15);
            _animationTimer.Tick += positioniereBall;                       // Die Methode unter diesem "Tick" wird immer ausgeführt, wenn der Timer abgelaufen ist !
        }

        private void positioniereBall(object? sender, EventArgs e)
        {
            var x = Canvas.GetLeft(Ball);

            if (goesRight)
            {
                Canvas.SetLeft(Ball, x + 2);                
            }
            else
            {
                Canvas.SetLeft(Ball, x - 2);
            }

            if (x >= AnimationField.ActualWidth - Ball.ActualWidth)
            {
                goesRight = false;
            }
            else if (x <= 0)
            {
                goesRight = true;
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

            //Canvas.SetLeft(Ball, mitteX);
            //Canvas.SetTop(Ball, mitteY);
        }
    }
}