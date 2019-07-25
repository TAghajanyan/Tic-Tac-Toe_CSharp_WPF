
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

using Tic_Tac_Toe_Multiline_WPF;
namespace Tic_Tac_Toe_Multiline_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private uint n;

        public MainWindow()
        {
            InitializeComponent();
            CreatTables(10);
        }



        private void CreatTables(int n)
        {
            int iRow = -1;

            foreach (RowDefinition row in Conteiner.RowDefinitions)

            {

                iRow++;

                int iCol = -1;

                foreach (ColumnDefinition col in Conteiner.ColumnDefinitions)

                {

                    iCol++;

                    var button = new Button();

                    button.HorizontalAlignment = HorizontalAlignment.Center;
                    button.VerticalAlignment= VerticalAlignment.Center;
                    button.Width = 75;

                    Border panel = new Border();

                    Grid.SetColumn(button, iCol);

                    Grid.SetRow(button, iRow);

                    Conteiner.Children.Add(button);

                    button.Background = Brushes.Green;

                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            button.Name = "sd";
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.VerticalAlignment = VerticalAlignment.Center;
            button.Width = 75;
        }
    }
}
