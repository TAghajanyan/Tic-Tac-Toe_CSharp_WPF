using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void Color()
        {

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
            });
        }

        private void B0_0_Click(object sender, RoutedEventArgs e)
        {
            if (e.Handled)
            {

            }
        }
    }
}
