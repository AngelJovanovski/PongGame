﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StartPongGameForm s = new StartPongGameForm();
            s.ShowDialog();
        }
    }
}
