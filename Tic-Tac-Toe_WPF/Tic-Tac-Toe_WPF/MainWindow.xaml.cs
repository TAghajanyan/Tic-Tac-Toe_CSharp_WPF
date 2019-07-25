using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tic_Tac_Toe_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Two_Players(object sender, RoutedEventArgs e)
        {
            FirstPage first = new FirstPage();
            first.PlayerOrPC = true;
            Visibility = Visibility.Hidden;
            first.Title = "Playing with Friend";
            first.Show();

        }

        private void With_Computer(object sender, RoutedEventArgs e)
        {
            FirstPage first = new FirstPage();
            first.PlayerOrPC = false;
            Visibility = Visibility.Hidden;
            first.Title = "Playing with Computer";
            first.Show();

            first.buttonX[0] = first.B0_0;
            first.buttonX[1] = first.B0_1;
            first.buttonX[2] = first.B0_2;
            first.buttonX[3] = first.B1_0;
            first.buttonX[4] = first.B1_1;
            first.buttonX[5] = first.B1_2;
            first.buttonX[6] = first.B2_0;
            first.buttonX[7] = first.B2_1;
            first.buttonX[8] = first.B2_2;

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
