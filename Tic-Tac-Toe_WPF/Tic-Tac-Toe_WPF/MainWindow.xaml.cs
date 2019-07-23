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
        //      c0  c1  c2
        //  r0 | 0  | 1 | 2
        //  r1 | 3  | 4 | 5
        //  r2 | 6  | 7 | 8

        private SelectType[] result = new SelectType[9];
        private bool playerTurn = true;
        private bool endGame = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Check()
        {
            SelectType res = SelectType.Free;

            #region Check_Row
            if (result[0] != SelectType.Free && (result[0] & result[1] & result[2]) == result[0])
            {
                res = result[0];
                B0_0.Background = B0_1.Background = B0_2.Background = Brushes.Green;
                endGame = true;
            }
            if (result[3] != SelectType.Free && (result[3] & result[4] & result[5]) == result[3])
            {
                res = result[3];
                B1_0.Background = B1_1.Background = B1_2.Background = Brushes.Green;
                endGame = true;
            }
            if (result[6] != SelectType.Free && (result[6] & result[7] & result[8]) == result[6])
            {
                res = result[6];
                B2_0.Background = B2_1.Background = B2_2.Background = Brushes.Green;
                endGame = true;
            }
            #endregion

            #region Check_Col
            if (result[0] != SelectType.Free && (result[0] & result[3] & result[6]) == result[0])
            {
                res = result[0];
                B0_0.Background = B1_0.Background = B2_0.Background = Brushes.Green;
                endGame = true;
            }
            if (result[1] != SelectType.Free && (result[1] & result[4] & result[7]) == result[1])
            {
                res = result[1];
                B0_1.Background = B1_1.Background = B2_1.Background = Brushes.Green;
                endGame = true;
            }
            if (result[2] != SelectType.Free && (result[2] & result[5] & result[8]) == result[2])
            {
                res = result[2];
                B0_2.Background = B1_2.Background = B2_2.Background = Brushes.Green;
                endGame = true;
            }
            #endregion

            #region Check_Diagonal
            if (result[0] != SelectType.Free && (result[0] & result[4] & result[8]) == result[0])
            {
                res = result[0];
                B0_0.Background = B1_1.Background = B2_2.Background = Brushes.Green;
                endGame = true;
            }
            if (result[2] != SelectType.Free && (result[2] & result[4] & result[6]) == result[2])
            {
                res = result[2];
                B0_2.Background = B1_1.Background = B2_0.Background = Brushes.Green;
                endGame = true;
            }
            #endregion

            if (endGame)
            {
                Result.TextAlignment = TextAlignment.Center;
                Result.Background = Brushes.SaddleBrown;
                Result.Foreground = Brushes.Black;
                Result.Text = $"{res} is Winner!!!";
            }

            #region Check_Draw
            if (!result.Any(val => val == SelectType.Free))
            {
                endGame = true;
                try
                {
                    foreach (Button button in Container.Children)
                    {

                        if (button.Name != "Exit" && button.Name != "NewGame")
                        {
                            button.Background = Brushes.PowderBlue;
                        }
                    }
                }
                catch { }
                Result.TextAlignment = TextAlignment.Center;
                Result.Background = Brushes.Orange;
                Result.Foreground = Brushes.Black;
                Result.Text = "Draw";
            }
            #endregion
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            if (endGame)
                return;

            Button button = (Button)sender;

            int col = Grid.GetColumn(button);
            int row = Grid.GetRow(button);
            int index = col + (row * 3);

            if (result[index] == SelectType.Free)
            {
                result[index] = playerTurn ? SelectType.X : SelectType.O;
                button.Content = playerTurn ? result[index].ToString() : result[index].ToString();

                playerTurn = playerTurn ? false : true;
            }
            Check();  
        }

        private void New_Game_Click(object sender, RoutedEventArgs e) 
        {
            result = new SelectType[9];
            endGame = false;

            for (int i = 0; i < result.Length; i++)
                result[i] = SelectType.Free;

            playerTurn = true;
            try
            {
                foreach (Button button in Container.Children)
                {
                    if (button.Name != "Exit" && button.Name != "NewGame")
                    {
                        button.Content = string.Empty;
                        button.Background = Brushes.White;
                    }
                }
            }
            catch { }
            Result.Text = string.Empty;
            Result.Background = Brushes.LightGray;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
