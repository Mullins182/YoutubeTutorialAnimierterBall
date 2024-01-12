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

namespace YoutubeTutorialAnimierterBall
{

    // Turorial Video auf Youtube zum Programm >> https://www.youtube.com/watch?v=ugji-_yWoRk
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartStopAnimation_Click(object sender, RoutedEventArgs e)
        {
            var mitteX = AnimationField.ActualWidth / 2;
            var mitteY = AnimationField.ActualHeight / 2;

            Canvas.SetLeft(Ball, mitteX);
            Canvas.SetTop(Ball, mitteY);
        }
    }
}