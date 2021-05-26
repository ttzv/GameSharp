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
        private GameMap gameMap;
        private snake wezyk;
        private string direction;
        private System.Timers.Timer timer;
        public Form1()
        {
            InitializeComponent();
            direction = "right";
            wezyk = new snake();
            timer = new System.Timers.Timer();
        }

        public void Generategame()
        {
            this.gameMap = new GameMap(flowLayoutPanel1);
            this.gameMap.Draw(20, 20);
        }


        public void move(object source, System.Timers.ElapsedEventArgs e)
        {
            this.gameMap.Punkty[wezyk.snakesegments[0].y, wezyk.snakesegments[0].x].punkt.BackColor = Color.FromArgb(92, 38, 0);

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
        

        public void updateGame()
        {
            this.gameMap.Punkty[wezyk.snakesegments[0].y, wezyk.snakesegments[0].x].punkt.BackColor = Color.FromArgb(169, 173, 33);
        }
        private void button1_Click(object sender, EventArgs e)
        {


            Generategame();
            this.gameMap.Punkty[0, 0].punkt.BackColor = Color.FromArgb(169, 173, 33);



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
            this.gameMap.Punkty[wezyk.snakesegments[0].x, wezyk.snakesegments[0].y].punkt.BackColor = Color.FromArgb(92, 38, 0);
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
                //updateGame();
            }
        }
    }
}
