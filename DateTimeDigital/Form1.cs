using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace DateTimeDigital
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //the timer active an down 
            timer1.Enabled = true;
        }
        /// <summary>
        /// exite buttom
        /// </summary>
        /// how to program the buttom and after you push and what massage shows.
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا برای خروج مطمئن هستید؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign) == DialogResult.Yes)
                Close();
        }
        //private void playSimpleSound()
        //{
          //  SoundPlayer simpleSound= new SoundPlayer(@"Sound Sourse = Sound\1");
           // simpleSound.Play();
       // }

        private void timer1_Tick(object sender, EventArgs e)
        {
          //  playSimpleSound();

            //How to give calender to persian and show in textBox1

            DateTime curDate = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();
            int y = pc.GetYear(curDate);
            int m = pc.GetMonth(curDate);
            int d = pc.GetDayOfMonth(curDate);
            textBox1.Text = string.Format($"{y}/{m}/{d}");
 
            //How to give local time to computer and show in textBox2
            
            int hour = curDate.Hour;
            int minute = curDate.Minute;
            int second = curDate.Second;

            textBox2.Text = string.Format($"{hour}:{minute}:{second}");

            drawClock(hour, minute, second);
        }

        private void drawClock(int h, int m, int s)
        {

            Graphics g = pictureBox1.CreateGraphics();

            //second

            int rs = (pictureBox1.Width - 60) / 2;

            int degSec = -s * 6 + 90;
            double radSec = degSec * Math.PI / 180.0;

            int xs = (int)(rs * Math.Cos(radSec));
            int ys = -(int)(rs * Math.Sin(radSec));

            //minute
            
            int rm = (pictureBox1.Width - 80) / 2;
            
            //MIN
            double degMin = -m * 6 + 94;

            double radMin = degMin * Math.PI / 180.0;

            int xm = (int)(rm * Math.Cos(radMin));
            int ym = -(int)(rm * Math.Sin(radMin));
            
            //MIN1
            double degMin1 = -m * 6 + 90;

            double radMin1 = degMin1 * Math.PI / 180.0;

            int xm1 = (int)((rm+5) * Math.Cos(radMin1));
            int ym1 = -(int)((rm+5) * Math.Sin(radMin1));
            //MIN2
            double degMin2 = -m * 6 + 86;

            double radMin2 = degMin2 * Math.PI / 180.0;

            int xm2 = (int)(rm * Math.Cos(radMin2));
            int ym2 = -(int)(rm * Math.Sin(radMin2));

            //hour
            int rh = (pictureBox1.Width - 130) / 2;
            //HOUR1
            double degHour1 = 0;
            if (h <= 12 && h >= 0)
            {
                degHour1 = -h * 30 + 95;
            }
            else if (h > 12 && h < 23)
            {
                int i = h - 12;
                degHour1 = -i * 30 + 95;
            }
            double radHour1 = degHour1 * Math.PI / 180.0;

            int xh1 = (int)(rh * Math.Cos(radHour1));
            int yh1 = -(int)(rh * Math.Sin(radHour1));

            //HOUR2
            double degHour2 = 0;
            if (h <= 12 && h >= 0)
            {
                degHour2 = -h * 30 + 85;
            }
            else if (h > 12 && h < 23)
            {
                int i = h - 12;
                degHour2 = -i * 30 + 85;
            }
            double radHour2 = degHour2 * Math.PI / 180.0;

            int xh2 = (int)(rh * Math.Cos(radHour2));
            int yh2 = -(int)(rh * Math.Sin(radHour2));
            //HOUR
            double degHour = 0;
            if (h <= 12 && h >= 0)
            {
                degHour = -h * 30 + 90;
            }
            else if (h > 12 && h < 23)
            {
                int i = h - 12;
                degHour = -i * 30 + 90;
            }
            double radHour = degHour * Math.PI / 180.0;
            
            int xh = (int)((rh+10) * Math.Cos(radHour));
            int yh = -(int)((rh+10) * Math.Sin(radHour));
            DrawCircle(g,rs);
            DrawScreen(g,xh, yh,xh1, yh1,xh2, yh2, xm, ym, xm1, ym1, xm2, ym2, xs, ys);
        }
        private void DrawScreen(Graphics g,int xh, int yh, int xh1, int yh1, int xh2, int yh2, int xm, int ym, int xm1, int ym1, int xm2, int ym2, int xs, int ys)
        {
           // g.Clear(Color.White);
            int offsetX = pictureBox1.Width / 2;
            int offsetY = pictureBox1.Height / 2;
           
            //second
            g.DrawLine(Pens.Red, offsetX, offsetY, xs + offsetX, ys + offsetY);
            
            //minute
            g.DrawLine(Pens.Black, offsetX, offsetY, xm + offsetX, ym + offsetY);
            g.DrawLine(Pens.Black, offsetX, offsetY, xm1 + offsetX, ym1 + offsetY);
            g.DrawLine(Pens.Black, offsetX, offsetY, xm2 + offsetX, ym2 + offsetY);
            g.DrawLine(Pens.Black, xm + offsetX, ym + offsetY, xm1 + offsetX, ym1 + offsetY);
            g.DrawLine(Pens.Black, xm2 + offsetX, ym2 + offsetY, xm1 + offsetX, ym1 + offsetY);
            
            //hour
            g.DrawLine(Pens.Black, offsetX, offsetY, xh + offsetX, yh + offsetY);
            g.DrawLine(Pens.Black, offsetX, offsetY, xh1 + offsetX, yh1 + offsetY);
            g.DrawLine(Pens.Black, offsetX, offsetY, xh2 + offsetX, yh2 + offsetY);
            g.DrawLine(Pens.Black, xh1 + offsetX, yh1 + offsetY, xh + offsetX, yh + offsetY);
            g.DrawLine(Pens.Black, xh2 + offsetX, yh2 + offsetY, xh + offsetX, yh + offsetY);
            
        }
        private void DrawCircle(Graphics g, int rs)
        {
            //offSet
            int offsetX = pictureBox1.Width / 2;
            int offsetY = pictureBox1.Height / 2;

            //circle
            g.FillEllipse(Brushes.CornflowerBlue, 18, 30, 280, 280);
            g.DrawEllipse(Pens.Black,17,30,280,280);

            //g.Clear(Color.White);

            //number of clock 
            //number 1
            double I = -60 * Math.PI / 180.0;
            int Ix = (int)((rs + 10) * Math.Cos(I));
            int Iy = (int)((rs + 10) * Math.Sin(I));
            g.DrawString("1", DefaultFont, Brushes.Black, Ix + offsetX, Iy + offsetY);

            //number 2
            double II = -30 * Math.PI / 180.0;
            int IIx = (int)((rs + 10) * Math.Cos(II));
            int IIy = (int)((rs + 10) * Math.Sin(II));
            g.DrawString("2", DefaultFont, Brushes.Black, IIx + offsetX, IIy + offsetY);

            //number 3
            double III = 0 * Math.PI / 180.0;
            int IIIx = (int)((rs + 10) * Math.Cos(III));
            int IIIy = (int)((rs + 10) * Math.Sin(III));
            g.DrawString("3", DefaultFont, Brushes.Black, IIIx + offsetX, IIIy + offsetY);

            //number 4
            double IV = -330 * Math.PI / 180.0;
            int IVx = (int)((rs + 10) * Math.Cos(IV));
            int IVy = (int)((rs + 10) * Math.Sin(IV));
            g.DrawString("4", DefaultFont, Brushes.Black,IVx+offsetX,IVy+offsetY);

            //number 5
            double V = -300 * Math.PI / 180.0;
            int Vx = (int)((rs + 10) * Math.Cos(V));
            int Vy = (int)((rs + 10) * Math.Sin(V));
            g.DrawString("5", DefaultFont, Brushes.Black, Vx + offsetX, Vy + offsetY);

            //number 6
            double VI = -270 * Math.PI / 180.0;
            int VIx = (int)((rs + 10) * Math.Cos(VI));
            int VIy = (int)((rs + 10) * Math.Sin(VI));
            g.DrawString("6", DefaultFont, Brushes.Black, VIx + offsetX, VIy + offsetY);

            //number 7
            double VII = -240 * Math.PI / 180.0;
            int VIIx = (int)((rs + 10) * Math.Cos(VII));
            int VIIy = (int)((rs + 10) * Math.Sin(VII));
            g.DrawString("7", DefaultFont, Brushes.Black, VIIx + offsetX, VIIy + offsetY);

            //number 8
            double VIII = -210 * Math.PI / 180.0;
            int VIIIx = (int)((rs + 10) * Math.Cos(VIII));
            int VIIIy = (int)((rs + 10) * Math.Sin(VIII));
            g.DrawString("8", DefaultFont, Brushes.Black, VIIIx + offsetX, VIIIy + offsetY);

            //number 9
            double IX = -180 * Math.PI / 180.0;
            int IXx = (int)((rs + 10) * Math.Cos(IX));
            int IXy = (int)((rs + 10) * Math.Sin(IX));
            g.DrawString("9", DefaultFont, Brushes.Black, IXx + offsetX, IXy + offsetY);

            //number 10
            double X = -150 * Math.PI / 180.0;
            int Xx = (int)((rs + 10) * Math.Cos(X));
            int Xy = (int)((rs + 10) * Math.Sin(X));
            g.DrawString("10", DefaultFont, Brushes.Black, Xx + offsetX, Xy + offsetY);

            //number 11
            double XI = -120 * Math.PI / 180.0;
            int XIx = (int)((rs + 10) * Math.Cos(XI));
            int XIy = (int)((rs + 10) * Math.Sin(XI));
            g.DrawString("11", DefaultFont, Brushes.Black, XIx + offsetX, XIy + offsetY);

            //number 12
            double XII = -90 * Math.PI / 180.0;
            int XIIx = (int)((rs + 10) * Math.Cos(XII));
            int XIIY = (int)((rs + 10) * Math.Sin(XII));
            g.DrawString("12", DefaultFont, Brushes.Black, XIIx + offsetX, XIIY + offsetY);
        }
    }
}
