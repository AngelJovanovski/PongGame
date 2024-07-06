namespace PONG_GAME
{
    partial class StartPongGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartPongGameForm));
            this.pbBall = new System.Windows.Forms.PictureBox();
            this.pbComputer = new System.Windows.Forms.PictureBox();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbBall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbComputer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBall
            // 
            this.pbBall.Image = global::PONG_GAME.Properties.Resources.savenew;
            this.pbBall.Location = new System.Drawing.Point(386, 227);
            this.pbBall.Margin = new System.Windows.Forms.Padding(2);
            this.pbBall.Name = "pbBall";
            this.pbBall.Size = new System.Drawing.Size(25, 25);
            this.pbBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBall.TabIndex = 2;
            this.pbBall.TabStop = false;
            // 
            // pbComputer
            // 
            this.pbComputer.Image = global::PONG_GAME.Properties.Resources.dark_red_color_solid_background_1920x1080;
            this.pbComputer.Location = new System.Drawing.Point(763, 181);
            this.pbComputer.Margin = new System.Windows.Forms.Padding(2);
            this.pbComputer.Name = "pbComputer";
            this.pbComputer.Size = new System.Drawing.Size(28, 110);
            this.pbComputer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbComputer.TabIndex = 1;
            this.pbComputer.TabStop = false;
            // 
            // pbPlayer
            // 
            this.pbPlayer.Image = global::PONG_GAME.Properties.Resources.blue_still1_fr_1713295206;
            this.pbPlayer.Location = new System.Drawing.Point(9, 181);
            this.pbPlayer.Margin = new System.Windows.Forms.Padding(2);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(28, 110);
            this.pbPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayer.TabIndex = 0;
            this.pbPlayer.TabStop = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 16;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // StartPongGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(802, 503);
            this.Controls.Add(this.pbBall);
            this.Controls.Add(this.pbComputer);
            this.Controls.Add(this.pbPlayer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "StartPongGameForm";
            this.Text = "Player: 0 --- Computer: 0";
            this.TransparencyKey = System.Drawing.Color.White;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartPongGameForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StartPongGameForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbBall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbComputer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayer;
        private System.Windows.Forms.PictureBox pbComputer;
        private System.Windows.Forms.PictureBox pbBall;
        private System.Windows.Forms.Timer gameTimer;
    }
}