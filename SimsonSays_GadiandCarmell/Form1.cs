using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimsonSays_GadiandCarmell
{
    
    public partial class Form1 : Form
    {
        private PictureBox[] PictureBoxArr = new PictureBox[4];
        Random rnd = new Random();
        private int[] order = new int[4];
        private int count = 3;
        private int x = -1;
        private int y = 0;
       
        public Form1()
        {
            InitializeComponent();
            SetArr();
        }

        public void SetArr()
        {
            PictureBoxArr[0] = pictureBox1;
            PictureBoxArr[1] = pictureBox2;
            PictureBoxArr[2] = pictureBox3;
            PictureBoxArr[3] = pictureBox4;

            for (int i = 0; i < order.Length; i++)
            {
                order[i] = rnd.Next(0, 4);
            }
        }

       
        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x++;
            y = 0;
            timer2.Start();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (y == 0)
            {
                PictureBoxArr[order[x]].Visible = false;
            }

            else if (y==1)
            {
                PictureBoxArr[order[x]].Visible = true;
            }

            else
            {
                if (x >= count)
                {
                    timer1.Stop();
                }
                timer2.Stop();

            }
            y++;
        }
    }
}
