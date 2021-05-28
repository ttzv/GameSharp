using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharp
{
    class SnakeElemement
    {
        public SnakeElemement(int i,int j)
        {
            x = i;
            y = j;
        }
        public string nextdirection;
        public int x;
        public int y;

    }
}
