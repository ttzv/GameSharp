using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random R = new Random();
        point[,] punkty = new point[20, 20];
        private void button1_Click(object sender, EventArgs e)
        {
          
            int row = 0;
            int column = 0;
            for (int i = 0; i < 20; i++)
            {
                column = 0;
                for (int j = 0; j < 20; j++)
                {
                    punkty[i, j] = new point();
                    punkty[i, j].punkt = new Panel();

                   // Panel panel1 = new Panel();
                    punkty[i, j].punkt.Name = "panel" + column + "_" + row;
                    punkty[i, j].punkt.BackColor = Color.FromArgb(123, R.Next(222), R.Next(222));
                    punkty[i, j].punkt.Location = new Point(j*20, i*20);
                    punkty[i, j].punkt.Size = new Size(20, 20);
                    punkty[i, j].punkt.Padding = new Padding(0);
                    punkty[i, j].punkt.Margin = new Padding(0);
                    flowLayoutPanel1.Controls.Add(punkty[i, j].punkt);
                    column++; 
                }
                row++;
            }

           
            //flowLayoutPanel1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            punkty[0, 0].punkt.BackColor = Color.FromArgb(255, 255, 255);
        }
    }
}
