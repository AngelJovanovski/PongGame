using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PONG_GAME
{
    public partial class StartPongGameForm : Form
    {
        int ballXspeed = 4;
        int ballYspeed = 4;
        int speed = 2;
        Random Random = new Random();
        bool goUp, goDown;
        int computer_speed_change = 50;
        int playerScore = 0;
        int computerScore = 0;
        int playerSpeed = 8;
        int[] com_speed = { 5, 6, 8, 9 };
        int[] speedForXandY = { 10, 9, 11, 12, 8 };
        public StartPongGameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.MaximumSize = this.Size;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            pbBall.Top -= ballYspeed;
            pbBall.Left -= ballXspeed;

            this.Text = "Player score: " + playerScore + " -- Computer score: " + computerScore;

            if (pbBall.Top < 0 || pbBall.Bottom > this.ClientSize.Height)
            {
                ballYspeed = -ballYspeed;
            }
            if (pbBall.Left < -2)
            {
                pbBall.Left = 300;
                ballXspeed = -ballXspeed;
                computerScore++;
            }
            if (pbBall.Right > this.ClientSize.Width + 2)
            {
                pbBall.Left = 300;
                ballXspeed = -ballXspeed;
                playerScore++;
            }
            if (pbComputer.Top <= 1)
            {
                pbComputer.Top = 0;
            }
            else if (pbComputer.Bottom >= this.ClientSize.Height)
            {
                pbComputer.Top = this.ClientSize.Height - pbComputer.Height;
            }
            if (pbBall.Top < pbComputer.Top + (pbComputer.Height / 2) && pbBall.Left > 300)
            {
                pbComputer.Top -= speed;
            }
            if (pbBall.Top > pbComputer.Top + (pbComputer.Height / 2) && pbBall.Left > 300)
            {
                pbComputer.Top += speed;
            }

            computer_speed_change -= 1;

            if (computer_speed_change < 0)
            {
                speed = com_speed[Random.Next(com_speed.Length)];
                computer_speed_change = 50;
            }

            if (goDown && pbPlayer.Top + pbPlayer.Height < this.ClientSize.Height)
            {
                pbPlayer.Top += playerSpeed;
            }

            if (goUp && pbPlayer.Top > 0)
            {
                pbPlayer.Top -= playerSpeed;
            }

            checkCollision(pbBall, pbPlayer, pbPlayer.Right + 5);
            checkCollision(pbBall, pbComputer, pbComputer.Left - 35);

            if (computerScore > 5)
            {
                gameOver("Sorry you lost the game!");
            }
            else if (playerScore > 5)
            {
                gameOver("You won the game!");
            }
        }

        private void checkCollision(PictureBox ball, PictureBox playerOrPC, int offset)
        {
            if (ball.Bounds.IntersectsWith(playerOrPC.Bounds))
            {
                ball.Left = offset;

                int x = speedForXandY[Random.Next(speedForXandY.Length)];
                int y = speedForXandY[Random.Next(speedForXandY.Length)];

                ballXspeed = (ballXspeed < 0) ? x : -x;
                ballYspeed = (ballYspeed < 0) ? -y : y;
            }
        }

        private void StartPongGameForm_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

        }

        private void StartPongGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
            if(e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
        }

        private void gameOver(string message)
        {
            gameTimer.Stop();
            MessageBox.Show(message, "GAME OVER");
            computerScore = 0;
            playerScore = 0;
            ballXspeed = ballYspeed = 4;
            computer_speed_change = 50;
            gameTimer.Start();
        }
    }
}
