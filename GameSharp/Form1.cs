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
        snake wezyk = new snake();
        public void Generategame()
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
                    punkty[i, j].punkt.BackColor = Color.FromArgb(92, 38, 0);
                    punkty[i, j].punkt.Location = new Point(j * 20, i * 20);
                    punkty[i, j].punkt.Size = new Size(20, 20);
                    punkty[i, j].punkt.Padding = new Padding(0);
                    punkty[i, j].punkt.Margin = new Padding(0);
                    flowLayoutPanel1.Controls.Add(punkty[i, j].punkt);
                    column++;
                }
                row++;
            }
        }
        public void updateGame()
        {
            punkty[wezyk.snakesegments[0].x, wezyk.snakesegments[0].y].punkt.BackColor = Color.FromArgb(169, 173, 33);
        }
        private void button1_Click(object sender, EventArgs e)
        {


            Generategame();
            punkty[0, 0].punkt.BackColor = Color.FromArgb(169, 173, 33);



            //flowLayoutPanel1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //punkty[0, 0].punkt.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            punkty[wezyk.snakesegments[0].x, wezyk.snakesegments[0].y].punkt.BackColor = Color.FromArgb(92, 38, 0);
            if (e.KeyCode == Keys.D)
            {
                if (wezyk.snakesegments[0].y <19)
                {
                    wezyk.snakesegments[0].y = wezyk.snakesegments[0].y + 1;
                }
                
                updateGame();
            }
            if (e.KeyCode == Keys.S)
            {
                if (wezyk.snakesegments[0].x < 19)
                {
                    wezyk.snakesegments[0].x = wezyk.snakesegments[0].x + 1;
                }
                updateGame();
            }
            if (e.KeyCode == Keys.A)
            {
                if (wezyk.snakesegments[0].y > 0)
                {
                    wezyk.snakesegments[0].y = wezyk.snakesegments[0].y - 1;
                }
                updateGame();
            }
            if (e.KeyCode == Keys.W)
            {
                if (wezyk.snakesegments[0].x > 0)
                {
                    wezyk.snakesegments[0].x = wezyk.snakesegments[0].x - 1;
                }
                    updateGame();
            }
        }
    }
}
