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
        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;

        enum enPlayer
        { 
            Player1,
            Player2,
            GameOver,
        }
        enum enWinner 
        { 
            Player1,
            Player2,
            Draw, 
            InPrgrass
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;

        }

        public Form1()
        {
            InitializeComponent();
        }       


        bool CheckValues(Button b1,Button b2, Button b3)
        {
            if (b1.Tag.ToString() !="?" && b1.Tag== b2.Tag && b1.Tag == b3.Tag)
            {
               if(b1.Tag.ToString()=="X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

               else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }

            GameStatus.GameOver=false;
            return false;
        }


        void EndGame()
        {
            lblTurn.Text = "Game Over";
            switch (GameStatus.Winner)
            {

                case enWinner.Player1:

                    lblWinner.Text = "Player1";
                    break;

                case enWinner.Player2:

                    lblWinner.Text = "Player2";
                    break;

                default:

                    lblWinner.Text = "Draw";
                    break;

            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        void CheckWinner()
        {


            if (CheckValues(btn1_1, btn1_2, btn1_3))
                return;

            if (CheckValues(btn2_1, btn2_2, btn2_3))
                return;

            if (CheckValues(btn3_1, btn3_2, btn3_3))
                return;

            if (CheckValues(btn1_1, btn2_1, btn3_1))
                return;

            if (CheckValues(btn1_2, btn2_2, btn3_2))
                return;

            if (CheckValues(btn1_3, btn2_3, btn3_3))
                return;

            if (CheckValues(btn1_1, btn2_2, btn3_3))
                return;

            if (CheckValues(btn1_3, btn2_2, btn3_1))
                return;
        }
        void ChangePhoto(Object sender)
        {
            Button button=(Button)sender;


            if (button.Tag.ToString() == "?")
            {

                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        button.BackgroundImage = Properties.Resources.x;
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatus.PlayCount++;
                        button.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        button.BackgroundImage = Properties.Resources.o;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        button.Tag = "O";
                        CheckWinner();
                        break;
                }
            }
            else
            {

                MessageBox.Show("Wrong Choice", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangePhoto(sender);
        }

       void RestartGame()
        {
            foreach (Button b in this.Controls.OfType<Button>())
            {
                if (b.Tag.ToString() != "Restart")
                {
                    b.Tag = "?";
                    b.BackgroundImage = Properties.Resources.q;
                }
            }

            PlayerTurn = enPlayer.Player1;
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.InPrgrass;
            lblWinner.Text = "In Prograss";
        }

        private void btnRestart_Click_1(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }
    }
}
