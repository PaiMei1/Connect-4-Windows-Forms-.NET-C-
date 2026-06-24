using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace connect_4
{
    public partial class Form1 : Form
    {
        private Button[,] buttons = new Button[6, 7]; 
        private int[,] board = new int[6, 7]; 
        private bool isRedTurn = true;  
        public Form1()
        {
            InitializeComponent();
            CreateGameBoard();
        }
        private void CreateGameBoard()
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    buttons[row, col] = new Button();
                    buttons[row, col].Size = new Size(100, 100);  
                    buttons[row, col].Location = new Point(col * 100, row * 100);  
                    buttons[row, col].Click += new EventHandler(Button_Click); 
                    buttons[row, col].BackColor = Color.LightGray;  
                    this.Controls.Add(buttons[row, col]); 
                    board[row, col] = 0;  
                }
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender; 
            int column = clickedButton.Location.X / 100;  

   
            for (int row = 5; row >= 0; row--)
            {
                if (board[row, column] == 0)
                {
                    
                    board[row, column] = isRedTurn ? 1 : 2; 
                    buttons[row, column].BackColor = isRedTurn ? Color.Red : Color.Yellow;  
                    isRedTurn = !isRedTurn;  
                    break;
                }
            }


            if (CheckWin())
            {
                MessageBox.Show(isRedTurn ? "Yellow wins!" : "Red wins!");
                ResetBoard();
            }
        }
        private bool CheckWin()
        {

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (board[row, col] != 0)
                    {
            
                        if (col <= 3 && board[row, col] == board[row, col + 1] && board[row, col] == board[row, col + 2] && board[row, col] == board[row, col + 3])
                            return true;

                     
                        if (row <= 2 && board[row, col] == board[row + 1, col] && board[row, col] == board[row + 2, col] && board[row, col] == board[row + 3, col])
                            return true;

              
                        if (row <= 2 && col <= 3 && board[row, col] == board[row + 1, col + 1] && board[row, col] == board[row + 2, col + 2] && board[row, col] == board[row + 3, col + 3])
                            return true;

            
                        if (row >= 3 && col <= 3 && board[row, col] == board[row - 1, col + 1] && board[row, col] == board[row - 2, col + 2] && board[row, col] == board[row - 3, col + 3])
                            return true;
                    }
                }
            }
            return false;
        }
        private void ResetBoard()
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    board[row, col] = 0;
                    buttons[row, col].BackColor = Color.LightGray;  
                }
            }
            isRedTurn = true; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
