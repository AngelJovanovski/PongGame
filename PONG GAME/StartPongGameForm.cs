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
            
        }

        private void checkCollision(PictureBox ball, PictureBox playerOrPC, int offset)
        {
            if (ball.Bounds.IntersectsWith(playerOrPC.Bounds))
            {
                ball.Left = offset;

                int x = speedForXandY[Random.Next(speedForXandY.Length)];
                int y = speedForXandY[Random.Next(speedForXandY.Length)];

                if (ballXspeed < 0)
                {
                    ballXspeed = x;
                }
                else
                {
                    ballXspeed = -x;
                }
                if (ballYspeed < 0)
                {
                    ballYspeed = -y;
                }
                else
                {
                    ballYspeed = y;
                }
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
