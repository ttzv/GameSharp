using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharp
{
    class snake
    {
        public SnakeElemement[] snakebody;
        
        public snake()
        {
            snakebody = new SnakeElemement[1];
            snakebody[0] = new SnakeElemement(0, 0);


        }
        public void snakemove(string direction, SnakeFood[] food)
        {
            SnakeElemement first = snakebody[0];

            SnakeElemement[] tempsnakebody;
            tempsnakebody = new SnakeElemement[snakebody.Length];
            
            for (int i = 0; i < tempsnakebody.Length-1 ; i++)
            {
                tempsnakebody[i] = snakebody[i+1];           
            }
            if (direction=="up")
            {
                
                    tempsnakebody[tempsnakebody.Length-1] = new SnakeElemement(snakebody[tempsnakebody.Length-1].x, snakebody[tempsnakebody.Length-1].y - 1);
                
               

              
            }
            if (direction == "down")
            {
                tempsnakebody[tempsnakebody.Length-1] = new SnakeElemement(snakebody[tempsnakebody.Length-1].x, snakebody[tempsnakebody.Length-1].y+1);
            }
            if (direction == "left")
            {
                tempsnakebody[tempsnakebody.Length-1] = new SnakeElemement(snakebody[tempsnakebody.Length-1].x-1, snakebody[tempsnakebody.Length-1].y);
            }
            if (direction == "right")
            {
                tempsnakebody[tempsnakebody.Length-1] = new SnakeElemement(snakebody[tempsnakebody.Length-1].x+1, snakebody[tempsnakebody.Length-1].y);
            }
           
            snakebody = tempsnakebody;
            for (int i = 0; i < food.Length; i++)
            {
                if (food[i].x == snakebody[snakebody.Length - 1].x && food[i].y == snakebody[snakebody.Length - 1].y)
                {
                    eatsnake(food[i].x, food[i].y, first);
                }

            }

        }
        public void eatsnake(int x, int y, SnakeElemement first)
        {
            SnakeElemement[] tempsnakebody;
            tempsnakebody = new SnakeElemement[snakebody.Length + 1];
            for (int i = 0; i < snakebody.Length; i++)
            {
                tempsnakebody[i+1] = snakebody[i];
            }
            tempsnakebody[0] = first;
            snakebody = tempsnakebody;

        
    }

    }
}
