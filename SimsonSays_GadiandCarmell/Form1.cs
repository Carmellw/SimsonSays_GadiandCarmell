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
       
        public Form1()
        {
            InitializeComponent();
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
