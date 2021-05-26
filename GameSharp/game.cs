using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GameSharp
{
    class game
    {

        public void Game(FlowLayoutPanel flp)
        {
            flowLayoutPanel1 = flp;
        }
        public static FlowLayoutPanel flowLayoutPanel1;
        public void generateGame(point[,] punkty)
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
    }
}
