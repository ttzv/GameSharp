using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSharp
{
    class GameMap
    {
        private FlowLayoutPanel canvas;
        public point[,] Punkty { get; set; }
        public GameMap( FlowLayoutPanel canvas )
        {
            this.canvas = canvas;
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
