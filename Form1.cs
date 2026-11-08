using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        enum enGameOption { Player1, Player2, GameOver, Draw, InPrgrass }
        private struct GameInfo
        {
            public enGameOption Turn;
            public enGameOption Winner;
            public bool IsPlyer1;
            public int Count;

        }

       void InitializeGame()
        {
            gameInfo.Turn = enGameOption.Player1;
            gameInfo.Winner = enGameOption.InPrgrass;
            gameInfo.IsPlyer1 = true;
            gameInfo.Count = 0;

            ChangeGameInfoResult();

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGame();
        }




        GameInfo gameInfo;

        void ShowGameOver()
        {
            lblWinner.Text = gameInfo.Winner.ToString();
            lblTurn.Text = enGameOption.GameOver.ToString();
            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        void ChangeGameInfoResult()
        {
            lblTurn.Text=gameInfo.Turn.ToString();
            lblWinner.Text=gameInfo.Winner.ToString();
        }

        bool IsWin(string c,Button b1,Button b2, Button b3)
        {
            if (b1.Tag.ToString() == c && b1.Tag== b2.Tag && b1.Tag == b3.Tag)
            {
                b1.BackColor = b2.BackColor = b3.BackColor = Color.DarkOrange;
                return true;
            }
            return false;
        }

        bool CheckResult(string PlyerChar)
        {
            

            if (IsWin(PlyerChar, btn1_1, btn1_2, btn1_3))
                return true;
            
            if (IsWin(PlyerChar, btn2_1, btn2_2, btn2_3))
                return true;
            
            if (IsWin(PlyerChar, btn3_1, btn3_2, btn3_3))
                return true;
            
            if (IsWin(PlyerChar, btn1_1, btn2_1, btn3_1))
                return true;
            
            if (IsWin(PlyerChar, btn1_2, btn2_2, btn3_2))
                return true;
            
            if (IsWin(PlyerChar, btn1_3, btn2_3, btn3_3))
                return true;
            
            if (IsWin(PlyerChar, btn1_1, btn2_2, btn3_3))
                return true; 
            
            if (IsWin(PlyerChar, btn1_3, btn2_2, btn3_1))
                return true;

            return false;        
        }

        bool IsPlayerWin()
        {
            string PlyerChar = gameInfo.IsPlyer1 ? "X" : "O";

            if (CheckResult(PlyerChar))
            {
                gameInfo.Winner = gameInfo.Turn;
                ShowGameOver();
                return true;
            }
            return false;
        }
        void ChangePhoto(Object sender)
        {
            Button button=(Button)sender;

          
            if (button.Tag.ToString() != "?")
            {
                MessageBox.Show("Wrong Choice", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(gameInfo.IsPlyer1)
            {
                button.BackgroundImage = Properties.Resources.x;
                button.Tag = "X";
               if(IsPlayerWin())
                {
                    return;
                }
                gameInfo.Turn = enGameOption.Player2;
            }

            else
            {
                button.BackgroundImage = Properties.Resources.o;
                button.Tag = "O";

                if (IsPlayerWin())
                {
                    return;
                }

                gameInfo.Turn = enGameOption.Player1;
            }

            

            gameInfo.Count++;
            gameInfo.IsPlyer1 = !gameInfo.IsPlyer1;

            ChangeGameInfoResult();

            if (gameInfo.Count == 9)
            {
                gameInfo.Winner=enGameOption.Draw;
                ShowGameOver();
                return;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangePhoto(sender);
        }

       

        private void btnRestart_Click_1(object sender, EventArgs e)
        {
            foreach(Button b in this.Controls.OfType<Button>())
            {
                if(b.Tag.ToString()!="R")
                {
                    b.Tag = "?";
                    b.BackgroundImage = Properties.Resources.q;
                }
            }

            InitializeGame();
        }
    }
}
