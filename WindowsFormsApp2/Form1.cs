using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        bool playerTurn = true;
        int turnCount = 0;
        int winStreak = 0;

        public Form1()
        {
            InitializeComponent();
            updateWinStreak("");
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoNewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Tic-Tac Game");
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button theButtton = (Button)sender;

            if (playerTurn)
            {
                theButtton.Text = "X";
                theButtton.Enabled = false;
            }
            else
            {
                theButtton.Text = "O";
                theButtton.Enabled = false;
            }

            turnCount++;
            playerTurn = !playerTurn;
            checkWinner();
        }

        private void checkWinner()
        {

            bool weHaveWinner = false;


            //---
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A2.Enabled))
                weHaveWinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B2.Enabled))
                weHaveWinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C2.Enabled))
                weHaveWinner = true;

            // |||
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!B1.Enabled))
                weHaveWinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!B2.Enabled))
                weHaveWinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!B3.Enabled))
                weHaveWinner = true;

            //X
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!B2.Enabled))
                weHaveWinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!B2.Enabled))
                weHaveWinner = true;


            if (weHaveWinner)
            {

                String winner = "";

                if (playerTurn)
                    winner = "0";
                else
                    winner = "X";
                updateWinStreak(winner);

                MessageBox.Show(winner + " Wins!", "GG");
                autoNewGame();
            }
            else
            {
                if (turnCount == 9)
                {
                    MessageBox.Show("Draw");
                    autoNewGame();
                }

            }

        }

        private void autoNewGame()
        {
            playerTurn = true;
            turnCount = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    if (c is Button)
                    {
                        (c as Button).Enabled = true;
                        (c as Button).Text = "";
                    }
                }
            }
            catch{ }
        }

        private void updateWinStreak(string winner)
        {
            if (winner == "X")
            {
                if (winStreak < 0) 
                    winStreak = 0;
                winStreak++;
            }
            else if (winner == "O")
            {
                if (winStreak > 0) 
                    winStreak = 0;
                winStreak--;
            }
            else
            {
                winStreak = 0;
            }

            winStreakLabel.Visible = (winStreak != 0);
            winStreakLabel.Text = String.Format("{0} is on a win streak of {1}", winner, Math.Abs(winStreak));
        }

        private void winStreakLabel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the win streak?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                updateWinStreak("");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
