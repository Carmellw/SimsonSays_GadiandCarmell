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
        private PictureBox[] PictureBoxArr = new PictureBox[4]; // מערך התמונות שהן הכפתורים של המשחק
        Random rnd = new Random(); 
        private int[] order = new int[10]; // מערך שקובע את סדר ההבהובים
        private int countlevel = 1; // סופר את התור בו השחקן נמצא בו
        private int countcomp = -1; // סופר כמה פעמים המחשב הבהב כבר בתור
        private int countflash = 0; // מסמל את המצב בו כל הבהוב נמצא
        private int countclicks = 0; //  סופר כמה פעמים השחקן לחץ על כפתורי המשחק בתור מסויים
        private int k; // מכיל את המספר הסידורי של הכפתור שהשחקן לחץ עליו
       
        public Form1()
        {
            InitializeComponent();
            SetArr();
        }

        public void SetArr()
        {
            // מגדיר את מערך התמונות
            PictureBoxArr[0] = pictureBox0;
            PictureBoxArr[1] = pictureBox1;
            PictureBoxArr[2] = pictureBox2;
            PictureBoxArr[3] = pictureBox3;

            // מגדיר את מערך הסדר
            for (int i = 0; i < order.Length; i++)
            {
                order[i] = rnd.Next(0, 4);
            }
        }

        // כאשר השחקן לוחץ על התחל מתחילים את טיימר 1 ומאתחלים את כל הערכים וחושפים את התמונות
        private void Start_Click(object sender, EventArgs e)
        {
            PictureBoxArr[0].Visible = true;
            PictureBoxArr[1].Visible = true;
            PictureBoxArr[2].Visible = true;
            PictureBoxArr[3].Visible = true;
            SetArr();
            countclicks = 0;
            countcomp = -1;
            countlevel = 1;
            timer1.Start();
        }


        private void pictureBox_Click(object sender, EventArgs e)
        {

            PictureBox pictureBox = sender as PictureBox;

            countclicks++; // מוסיף למספר הלחיצות בשלב הנוכחי לחיצה

            // מוצא את מספר התמונה
            string picName = pictureBox.Name;
            k = int.Parse(picName.Substring(picName.Length - 1));

            // מסמנים לשחקן על מה הוא לחץ
            countflash = 0;
            timer3.Start();

            // בודקים אם השחקן טעה
            if (k != order[countclicks-1])
            {
                // מציג הודעה ומעלים את התמונות
                MessageBox.Show("אתה כישלון");
                PictureBoxArr[0].Visible = false;
                PictureBoxArr[1].Visible = false;
                PictureBoxArr[2].Visible = false;
                PictureBoxArr[3].Visible = false;

            }

               
            // בודק אם השחקן סיים את השלב
            if (countclicks == countlevel)
            {
                countclicks = 0;
                countcomp = -1;

                // בוק אם השחקן ניצח

                //כן
                if (countlevel == order.Length)
                {
                    //מציג הודעה ומעלים את התמונות
                    MessageBox.Show("אתה כישלון אבל ניצחת");
                    PictureBoxArr[0].Visible = false;
                    PictureBoxArr[1].Visible = false;
                    PictureBoxArr[2].Visible = false;
                    PictureBoxArr[3].Visible = false;
                }

                //לא
                else
                {
                    // ממשיך לשלב הבא
                    timer1.Start();
                    countlevel++;
                }

            }

        }

        // כשהטיימר דולק המחשב מהבהב על פי הסדר שקבוע מראש
        private void timer1_Tick(object sender, EventArgs e)
        {
            countcomp++;
            countflash = 0;
            timer2.Start();
        }

        // טיימר שאחראי על ההבהוב של המחשב
        private void timer2_Tick(object sender, EventArgs e)
        {
            // מעלים או מראה את התמונה בהתאם למצב ההבהוב
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
                // בודק אם המחשב הראה את כל מה שצריך להראות בתור
                if ((countcomp + 1) >= countlevel) 
                {
                    // מכבה את טיימר 1
                    timer1.Stop();
                }
                timer2.Stop();

            }
            countflash++;
        }

        // טיימר שאחראי על ההבהוב של השחקן
        private void timer3_Tick(object sender, EventArgs e)
        {
            // מעלים או מראה את התמונה בהתאם למצב ההבהוב
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
