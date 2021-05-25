using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharp
{
    class snake
    {
        public SnakeElemement[] snakesegments;
        
        public snake()
        {
            snakesegments = new SnakeElemement[1];
            snakesegments[0] = new SnakeElemement(0, 0);


        }
        public void Eatsnake(int x,int y)
        {

        }

    }
}
