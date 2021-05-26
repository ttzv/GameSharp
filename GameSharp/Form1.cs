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

        string direction = "right";
        Random R = new Random();
        point[,] punkty = new point[20, 20];
        snake wezyk = new snake();


        public System.Timers.Timer timer = new System.Timers.Timer();
       
        public void move(object source, System.Timers.ElapsedEventArgs e)
        {
            punkty[wezyk.snakesegments[0].y, wezyk.snakesegments[0].x].punkt.BackColor = Color.FromArgb(92, 38, 0);

            if (direction == "right")
            {
                if (wezyk.snakesegments[0].x == 19)
                {
                    timer.Stop();
                    MessageBox.Show("Koniec gry");
                }
                else
                {
                    wezyk.snakesegments[0].x = wezyk.snakesegments[0].x + 1;
                }
                
            }
            if (direction == "left")
            {
                if (wezyk.snakesegments[0].x == 0)
                {
                    timer.Stop();
                    MessageBox.Show("Koniec gry");
                }
                else
                {
                    wezyk.snakesegments[0].x = wezyk.snakesegments[0].x - 1;
                }
            }
            if (direction == "down")
            {
                if (wezyk.snakesegments[0].y == 19)
                {
                    timer.Stop();
                    MessageBox.Show("Koniec gry");
                }
                else
                {
                    wezyk.snakesegments[0].y = wezyk.snakesegments[0].y + 1;
                }
            }
            if (direction == "up")

            {
                if (wezyk.snakesegments[0].y == 0)
                {
                   
                    timer.Stop();
                    MessageBox.Show("Koniec gry");
                }
                else
                {
                    wezyk.snakesegments[0].y = wezyk.snakesegments[0].y - 1;
                }
            }
            updateGame();
        }
        public void Generategame()
        {
           
            for (int i = 0; i < 20; i++)
            {
               
                for (int j = 0; j < 20; j++)
                {
                    punkty[i, j] = new point();
                    punkty[i, j].punkt = new Panel();

                    // Panel panel1 = new Panel();
                    punkty[i, j].punkt.Name = "panel" + j + "_" + i;
                    punkty[i, j].punkt.BackColor = Color.FromArgb(92, 38, 0);
                    punkty[i, j].punkt.Location = new Point(j * 20, i * 20);
                    punkty[i, j].punkt.Size = new Size(20, 20);
                    punkty[i, j].punkt.Padding = new Padding(0);
                    punkty[i, j].punkt.Margin = new Padding(0);
                    flowLayoutPanel1.Controls.Add(punkty[i, j].punkt);
                   
                }
            
            }
         
        }

        public void updateGame()
        {
            punkty[wezyk.snakesegments[0].y, wezyk.snakesegments[0].x].punkt.BackColor = Color.FromArgb(169, 173, 33);
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
            timer.Interval = 700;            
            timer.Elapsed += move;          
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            punkty[wezyk.snakesegments[0].x, wezyk.snakesegments[0].y].punkt.BackColor = Color.FromArgb(92, 38, 0);
            if (e.KeyCode == Keys.D)
            {

                if (wezyk.snakesegments[0].y < 19 && direction != "left")
                {
                    direction = "right";
                }
                
               // updateGame();
            }
            if (e.KeyCode == Keys.S && direction != "up")
            {
                if (wezyk.snakesegments[0].x < 19)
                {
                    direction = "down";
                }
                //updateGame();
            }
            if (e.KeyCode == Keys.A && direction !="right")
            {
                if (wezyk.snakesegments[0].y > 0)
                {
                    direction = "left";
                }
                //updateGame();
            }
            if (e.KeyCode == Keys.W && direction != "down")
            {
                if (wezyk.snakesegments[0].x > 0)
                {
                    direction = "up";
                }
                   // updateGame();
            }
        }
    }
}
