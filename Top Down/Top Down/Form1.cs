using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Top_Down
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbl_over.Visible = false;
        }

        bool left, right;
        Random rand = new Random();
        int score; 

        void Blocks()
        {
            foreach (Control x in this.Controls) //для случайного изменения размера ширины блока
            {
                if (x is PictureBox && x.Tag == "block")
                {
                    if (x.Top > 450)
                    {
                        x.Top = 25;
                        x.Width = rand.Next(50, 200);
                        score += 1;
                        lbl_score.Text = "Счёт : " + score;
                    }
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        lbl_over.Visible = true;
                        timer1.Stop();
                    }
                    x.Top += 5;
                }
            }
        }

        void Player_Move()
        {
            if (right == true)
            {
                if (player.Left < 280)
                {
                    player.Left += 5;
                }
            }
            if (left == true)
            {
                if (player.Left > 2)
                {
                    player.Left -= 5;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Player_Move();
            Blocks();
        }
    }
}
