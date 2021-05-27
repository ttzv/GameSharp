using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharp
{
    class SnakeFood
    {
        public int x;
        public int y;
        public SnakeFood(int col, int row)
        {
            this.x = col;
            this.y = row;
        }
    }
}
