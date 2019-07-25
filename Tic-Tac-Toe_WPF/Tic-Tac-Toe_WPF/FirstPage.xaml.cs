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
using System.Windows.Shapes;

namespace Tic_Tac_Toe_WPF
{
    /// <summary>
    /// Interaction logic for FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Window
    {
        //      c0  c1  c2
        //  r0 | 0  | 1 | 2
        //  r1 | 3  | 4 | 5
        //  r2 | 6  | 7 | 8

        public Button[] buttonX = new Button[9];
        private SelectType[] board = new SelectType[9];
        private bool playerTurn = true;
        private bool endGame = false;
        internal bool PlayerOrPC;

        public FirstPage()
        {
            InitializeComponent();
        }

        private void Check()
        {
            SelectType res = SelectType.Free;

            #region Check_Row
            if (board[0] != SelectType.Free && (board[0] & board[1] & board[2]) == board[0])
            {
                res = board[0];
                B0_0.Background = B0_1.Background = B0_2.Background = Brushes.Green;
                endGame = true;
            }
            if (board[3] != SelectType.Free && (board[3] & board[4] & board[5]) == board[3])
            {
                res = board[3];
                B1_0.Background = B1_1.Background = B1_2.Background = Brushes.Green;
                endGame = true;
            }
            if (board[6] != SelectType.Free && (board[6] & board[7] & board[8]) == board[6])
            {
                res = board[6];
                B2_0.Background = B2_1.Background = B2_2.Background = Brushes.Green;
                endGame = true;
            }
            #endregion

            #region Check_Col
            if (board[0] != SelectType.Free && (board[0] & board[3] & board[6]) == board[0])
            {
                res = board[0];
                B0_0.Background = B1_0.Background = B2_0.Background = Brushes.Green;
                endGame = true;
            }
            if (board[1] != SelectType.Free && (board[1] & board[4] & board[7]) == board[1])
            {
                res = board[1];
                B0_1.Background = B1_1.Background = B2_1.Background = Brushes.Green;
                endGame = true;
            }
            if (board[2] != SelectType.Free && (board[2] & board[5] & board[8]) == board[2])
            {
                res = board[2];
                B0_2.Background = B1_2.Background = B2_2.Background = Brushes.Green;
                endGame = true;
            }
            #endregion

            #region Check_Diagonal
            if (board[0] != SelectType.Free && (board[0] & board[4] & board[8]) == board[0])
            {
                res = board[0];
                B0_0.Background = B1_1.Background = B2_2.Background = Brushes.Green;
                endGame = true;
            }
            if (board[2] != SelectType.Free && (board[2] & board[4] & board[6]) == board[2])
            {
                res = board[2];
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
            if (!board.Any(val => val == SelectType.Free))
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

            if (PlayerOrPC)
            {
                WithFriendX(button, index);
            }
            else
            {
                if (board[index] == SelectType.Free)
                {
                    board[index] = playerTurn ? SelectType.X : SelectType.O;
                    buttonX[index].Content = playerTurn ? board[index].ToString() : board[index].ToString();
                    Check();
                    if (endGame)
                        return;
                    do
                    {
                        index = CheckPC();
                    } while (board[index] != SelectType.Free);

                    board[index] = !playerTurn ? SelectType.X : SelectType.O;
                    buttonX[index].Content = !playerTurn ? board[index].ToString() : board[index].ToString();

                }
            }

            Check();
        }

        private void WithFriendX(Button button, int index)
        {
            if (board[index] == SelectType.Free)
            {
                board[index] = playerTurn ? SelectType.X : SelectType.O;
                button.Content = playerTurn ? board[index].ToString() : board[index].ToString();

                playerTurn = playerTurn ? false : true;
            }
        }

        private int CheckPC()
        {
            for (int i = 0; i < 9; i += 3)
            {
                if (((board[i] & board[i + 1]) == SelectType.X || (board[i] & board[i + 1]) == SelectType.O) && board[i + 2] == SelectType.Free)
                {
                    return i + 2;
                }
            }
            //Tox 2|3
            for (int i = 0; i < 9; i += 3)
            {
                if (((board[i + 1] & (board[i + 2])) == SelectType.X || (board[i] & board[i + 1]) == SelectType.O) && board[i] == SelectType.Free)
                {
                    return i;
                }
            }
            //Tox 1|3
            for (int i = 0; i < 9; i += 3)
            {
                if (((board[i] & (board[i + 2])) == SelectType.X || (board[i] & board[i + 1]) == SelectType.O) && board[i + 1] == SelectType.Free)
                {
                    return i + 1;
                }
            }
            //Syun 1|4
            for (int i = 0; i < 3; i++)
            {
                if (((board[i] & (board[i + 3])) == SelectType.X || (board[i] & board[i + 1]) == SelectType.O) && board[i + 6] == SelectType.Free)
                {
                    return i + 6;
                }
            }
            //Syun 4|7
            for (int i = 3; i < 6; i++)
            {
                if (((board[i] & (board[i + 3])) == SelectType.X || (board[i] & board[i + 1]) == SelectType.O) && board[i - 3] == SelectType.Free)
                {
                    return i - 3;
                }
            }
            //Syun 1|7
            for (int i = 0; i < 3; i++)
            {
                if (((board[i] & (board[i + 6])) == SelectType.X || (board[i] & board[i + 1]) == SelectType.O) && board[i + 3] == SelectType.Free)
                {
                    return i + 3;
                }
            }

            //Ankyun  1|9
            if (((board[0] & (board[8])) == SelectType.X || (board[0] & board[8]) == SelectType.O) && board[4] == SelectType.Free) { return 4; }
            //Ankyun 3|7
            if (((board[2] & (board[6])) == SelectType.X || (board[2] & board[6]) == SelectType.O) && board[4] == SelectType.Free) { return 4; }
            // Ankyun 1|5
            if (((board[0] & (board[4])) == SelectType.X || (board[0] & board[4]) == SelectType.O) && board[8] == SelectType.Free) { return 8; }
            // Ankyun 3|5
            if (((board[2] & (board[4])) == SelectType.X || (board[2] & board[4]) == SelectType.O) && board[6] == SelectType.Free) { return 6; }
            // Ankyun 5|7
            if (((board[6] & (board[4])) == SelectType.X || (board[6] & board[4]) == SelectType.O) && board[2] == SelectType.Free) { return 2; }
            // Ankyun 5|9
            if (((board[8] & (board[4])) == SelectType.X || (board[8] & board[4]) == SelectType.O) && board[0] == SelectType.Free) { return 0; }

            return new Random().Next(0, 8);
        }

        private void New_Game_Click(object sender, RoutedEventArgs e)
        {
            board = new SelectType[9];
            endGame = false;

            for (int i = 0; i < board.Length; i++)
                board[i] = SelectType.Free;

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
