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
            // Move the ball's position on the form
            pbBall.Top -= ballYspeed;  // Move the ball up or down based on ballYspeed
            pbBall.Left -= ballXspeed; // Move the ball left or right based on ballXspeed

            // Update the form's title to display player and computer scores
            this.Text = "Player score: " + playerScore + " -- Computer score: " + computerScore;

            // Check if the ball hits the top or bottom boundary of the form
            if (pbBall.Top < 0 || pbBall.Bottom > this.ClientSize.Height)
            {
                ballYspeed = -ballYspeed; // Reverse the vertical speed to bounce the ball
            }

            // Check if the ball goes past the left boundary (computer scores)
            if (pbBall.Left < -2)
            {
                pbBall.Left = 300;         // Reset ball position to middle
                ballXspeed = -ballXspeed;  // Reverse the horizontal speed
                computerScore++;           // Increase computer's score
            }

            // Check if the ball goes past the right boundary (player scores)
            if (pbBall.Right > this.ClientSize.Width + 2)
            {
                pbBall.Left = 300;         // Reset ball position to middle
                ballXspeed = -ballXspeed;  // Reverse the horizontal speed
                playerScore++;             // Increase player's score
            }

            // Ensure the computer paddle stays within the top and bottom boundaries
            if (pbComputer.Top <= 1)
            {
                pbComputer.Top = 0; // Set the top boundary for the computer paddle
            }
            else if (pbComputer.Bottom >= this.ClientSize.Height)
            {
                pbComputer.Top = this.ClientSize.Height - pbComputer.Height; // Set the bottom boundary for the computer paddle
            }

            // Move the computer paddle based on the ball's position (y-axis)
            if (pbBall.Top < pbComputer.Top + (pbComputer.Height / 2) && pbBall.Left > 300)
            {
                pbComputer.Top -= speed; // Move the computer paddle up
            }
            if (pbBall.Top > pbComputer.Top + (pbComputer.Height / 2) && pbBall.Left > 300)
            {
                pbComputer.Top += speed; // Move the computer paddle down
            }

            // Decrease the counter for changing computer paddle speed
            computer_speed_change -= 1;

            // Randomly change the speed of the computer paddle
            if (computer_speed_change < 0)
            {
                speed = com_speed[Random.Next(com_speed.Length)]; // Select a random speed from com_speed array
                computer_speed_change = 50;                        // Reset the speed change counter
            }

            // Move the player paddle up or down based on key presses
            if (goDown && pbPlayer.Top + pbPlayer.Height < this.ClientSize.Height)
            {
                pbPlayer.Top += playerSpeed; // Move the player paddle down
            }
            if (goUp && pbPlayer.Top > 0)
            {
                pbPlayer.Top -= playerSpeed; // Move the player paddle up
            }

            // Check for collisions between the ball and player/computer paddles
            checkCollision(pbBall, pbPlayer, pbPlayer.Right + 5);    // Check collision with player paddle
            checkCollision(pbBall, pbComputer, pbComputer.Left - 35); // Check collision with computer paddle

            // Check if the game is over
            if (computerScore > 5)
            {
                gameOver("Sorry you lost the game!"); // End the game with a message if the computer wins
            }
            else if (playerScore > 5)
            {
                gameOver("You won the game!"); // End the game with a message if the player wins
            }
        }

        private void checkCollision(PictureBox ball, PictureBox playerOrPC, int offset)
        {
            // Check if the ball's bounds intersect with the player or computer paddle's bounds
            if (ball.Bounds.IntersectsWith(playerOrPC.Bounds))
            {
                // Reset the ball's position horizontally to prevent sticking inside the paddle
                ball.Left = offset;

                // Randomly select x and y directions for the ball after collision
                int x = speedForXandY[Random.Next(speedForXandY.Length)];
                int y = speedForXandY[Random.Next(speedForXandY.Length)];

                // Update the ball's horizontal speed based on its current direction
                ballXspeed = (ballXspeed < 0) ? x : -x;

                // Update the ball's vertical speed based on its current direction
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
