using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace GameSharp
{
    class GameMap
    {
        private FlowLayoutPanel canvas;
        public point[,] Punkty { get; set; }

        public SnakeFood[] food { get; set; }
        public GameMap( FlowLayoutPanel canvas )
        {
            this.canvas = canvas;
        }
        public Random rand=new Random ();
        public void GenerateFood()
        {
            food = new SnakeFood[5];
            for (int i = 0; i < 5; i++)
            {
                food[i] = new SnakeFood(rand.Next(20), rand.Next(20));
                
            }
        }
        public void NextFoodLayout()
        {
            ClearFood();
            GenerateFood();
            DrawFood();
        }
        public void DrawFood()
        {
            for (int i = 0; i < food.Length; i++)
            {
                Punkty[food[i].y, food[i].x].punkt.BackColor = Color.FromArgb(158, 0, 16);
            }
        }
        public void ClearFood()
        {
            for (int i = 0; i < food.Length; i++)
            {
                Punkty[food[i].y, food[i].x].punkt.BackColor = Color.FromArgb(92, 38, 0);
            }
        }
        public void Draw(int width, int height)
        {
            Punkty = new point[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Punkty[i, j] = new point();
                    Punkty[i, j].punkt.Name = "panel" + j + "_" + i;
                    Punkty[i, j].punkt.BackColor = Color.FromArgb(92, 38, 0);
                    Punkty[i, j].punkt.Location = new Point(j * 20, i * 20);
                    Punkty[i, j].punkt.Size = new Size(20, 20);
                    Punkty[i, j].punkt.Padding = new Padding(0);
                    Punkty[i, j].punkt.Margin = new Padding(0);
                    canvas.Controls.Add(Punkty[i, j].punkt);
                }
            }
        }

       
    }
}
