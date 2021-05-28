using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace GameSharp
{
    public partial class Form1 : Form
    {
        private readonly int BaseGameSpeed = 700;
        private int score = 0;
        private GameMap gameMap;
        private snake wezyk;
        private string direction;
        private Timer timer;
        private Timer foodtimer;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            foodtimer = new Timer();

            direction = "right";
            wezyk = new snake();
            wezyk.AppleEaten += Wezyk_AppleEaten;

        }

        private void Wezyk_AppleEaten(object sender, EventArgs e)
        {
            score += 1;
            UpdateScore( score.ToString() );
            timer.Interval = BaseGameSpeed - wezyk.speed;
        }

        public void Generategame()
        {
            this.gameMap = new GameMap(flowLayoutPanel1);
            this.gameMap.Draw(20, 20);
            this.gameMap.GenerateFood();
            this.gameMap.DrawFood();

        }
        public void newFood(object source, System.Timers.ElapsedEventArgs e)
        {
            this.gameMap.NextFoodLayout();
        }


            public void move(object source, System.Timers.ElapsedEventArgs e)
        {
            this.gameMap.Punkty[wezyk.snakebody[0].y, wezyk.snakebody[0].x].punkt.BackColor = Color.FromArgb(92, 38, 0);

            if (direction == "right")
            {
                if (wezyk.snakebody[wezyk.snakebody.Length-1].x == 19)
                {
                    timer.Stop();
                    MessageBox.Show("Koniec gry");
                }
                else
                {
                    wezyk.snakemove(direction,gameMap.food);
                }
                
            }
            if (direction == "left")
            {
                if (wezyk.snakebody[wezyk.snakebody.Length-1].x == 0)
                {
                    timer.Stop();
                    MessageBox.Show("Koniec gry");
                }
                else
                {
                    wezyk.snakemove(direction, gameMap.food);
                }
            }
            if (direction == "down")
            {
                if (wezyk.snakebody[wezyk.snakebody.Length-1].y == 19)
                {
                    timer.Stop();
                    MessageBox.Show("Koniec gry");
                }
                else
                {
                    wezyk.snakemove(direction, gameMap.food);
                }
            }
            if (direction == "up")

            {
                if (wezyk.snakebody[wezyk.snakebody.Length-1].y == 0)
                {
                   
                    timer.Stop();
                    MessageBox.Show("Koniec gry");
                }
                else
                {
                    wezyk.snakemove(direction, gameMap.food);
                }
            }
            updateGame();
        }
        

        public void updateGame()
        {
            for (int i = 0; i < wezyk.snakebody.Length; i++)
            {
                this.gameMap.Punkty[wezyk.snakebody[i].y, wezyk.snakebody[i].x].punkt.BackColor = Color.FromArgb(169, 173, 33);
            }
           // this.gameMap.Punkty[wezyk.snakebody[0].y, wezyk.snakebody[0].x].punkt.BackColor = Color.FromArgb(169, 173, 33);
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
            foodtimer.Interval = 10000;
            foodtimer.Elapsed += newFood;
            foodtimer.AutoReset = true;
            foodtimer.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            this.gameMap.Punkty[wezyk.snakebody[0].y, wezyk.snakebody[0].x].punkt.BackColor = Color.FromArgb(92, 38, 0);
            if (e.KeyCode == Keys.D)
            {

                if (wezyk.snakebody[0].x < 19 && direction != "left")
                {
                    direction = "right";
                }
                
               // updateGame();
            }
            if (e.KeyCode == Keys.S && direction != "up")
            {
                if (wezyk.snakebody[0].y < 19)
                {
                    direction = "down";
                }
                //updateGame();
            }
            if (e.KeyCode == Keys.A && direction !="right")
            {
                if (wezyk.snakebody[0].x > 0)
                {
                    direction = "left";
                }
                //updateGame();
            }
            if (e.KeyCode == Keys.W && direction != "down")
            {
                if (wezyk.snakebody[0].y > 0)
                {
                    direction = "up";
                }
                //updateGame();
            }
        }

        private delegate void SafeCallDelegate(string text);
        private void UpdateScore(string score)
        {
            if (label_score.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateScore);
                label_score.Invoke(d, new object[] { score });
            }
            else
            {
                label_score.Text = score;
            }
        }

    }
}
