using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shapes
{
    public partial class Form1 : Form
    {
        Graphics global_g;
        int CenterX, CenterY, RadiusValue;
        bool DrawFlag = false;
        public Form1()
        {
            InitializeComponent();
            this.Width = 680;
            this.Height = 550;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (this.DrawFlag == true)
            {
                Graphics g = e.Graphics;
                int x = 0;
                int y = this.RadiusValue;
                int p = 1 - this.RadiusValue;
                Bitmap bm = new Bitmap(1, 1);
                bm.SetPixel(0, 0, Color.Red);
                while (x < y)
                {
                    x++;
                    if (p < 0)
                    {
                        p += 2 * x + 1;
                    }
                    else
                    {
                        y--;
                        p += 2 * (x - y) + 1;
                    }
                    int xCenter = this.CenterX;
                    int yCenter = this.CenterY;
                    g.DrawImageUnscaled(bm, xCenter + x, yCenter + y);
                    g.DrawImageUnscaled(bm, xCenter - x, yCenter + y);
                    g.DrawImageUnscaled(bm, xCenter + x, yCenter - y);
                    g.DrawImageUnscaled(bm, xCenter - x, yCenter - y);
                    g.DrawImageUnscaled(bm, xCenter + y, yCenter + x);
                    g.DrawImageUnscaled(bm, xCenter - y, yCenter + x);
                    g.DrawImageUnscaled(bm, xCenter + y, yCenter - x);
                    g.DrawImageUnscaled(bm, xCenter - y, yCenter - x);
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(XCenter.Text == "" || YCenter.Text == "" || RadiusText.Text ==""))
            {
                bool test =  Int32.TryParse(XCenter.Text, out int XCenter1);
                bool test2 = Int32.TryParse(YCenter.Text, out int YCenter1);
                bool test3 = Int32.TryParse(RadiusText.Text, out int Radius1);
                if (test && test2 && test3)
                {
                    this.CenterX = XCenter1;
                    this.CenterY = YCenter1;
                    this.RadiusValue = Radius1;
                    this.DrawFlag = true;
                    Refresh();
                }
                else
                {
                    //must enter integer number.
                }
            }
        }


    }
}
