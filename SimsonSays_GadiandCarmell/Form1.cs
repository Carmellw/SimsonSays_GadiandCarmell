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
        private int[] order = new int[5];
        private int countlevel = 1;
        private int countcomp = -1;
        private int countflash = 0;
        private int countclicks = 0;
        private bool iswrong = false;
        private int k;
       
        public Form1()
        {
            InitializeComponent();
            SetArr();
        }

        public void SetArr()
        {
            PictureBoxArr[0] = pictureBox0;
            PictureBoxArr[1] = pictureBox1;
            PictureBoxArr[2] = pictureBox2;
            PictureBoxArr[3] = pictureBox3;

            for (int i = 0; i < order.Length; i++)
            {
                order[i] = rnd.Next(0, 4);
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {

            countcomp = -1;
            timer1.Start();
        }


        private void pictureBox_Click(object sender, EventArgs e)
        {

            PictureBox pictureBox = sender as PictureBox;

            countclicks++;

            string picName = pictureBox.Name;
            k = int.Parse(picName.Substring(picName.Length - 1));

            countflash = 0;
            timer3.Start();

            
            if (k != order[countclicks-1])
            {
                iswrong = true;
                MessageBox.Show("אתה כשלון");
                SetArr();
                countclicks = 0;
                countcomp = -1;
                countlevel = 1;
            }

               

            if (countclicks == countlevel)
            {
                countclicks = 0;
                countcomp = -1;
                if (countlevel == order.Length)
                {
                    MessageBox.Show("לך לגד");
                    countlevel = 1;
                    SetArr();
                }
                else
                {
                    timer1.Start();
                    countlevel++;
                }

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countcomp++;
            countflash = 0;
            timer2.Start();
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (countflash == 0)
            {
                PictureBoxArr[order[countcomp]].Visible = false;
            }

            else if (countflash == 1)
            {
                PictureBoxArr[order[countcomp]].Visible = true;
            }

            else
            {
                if ((countcomp + 1) >= countlevel)
                {
                    timer1.Stop();
                }
                timer2.Stop();

            }
            countflash++;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (countflash == 0)
            {
                PictureBoxArr[k].Visible = false;
            }

            else if (countflash == 1)
            {
                PictureBoxArr[k].Visible = true;
            }

            else
            {
                
                timer3.Stop();

            }
            countflash++;
        }
    }
    
}
