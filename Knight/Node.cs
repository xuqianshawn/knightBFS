using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knight
{
   public class Node
    {
        public int x, y, dist;
        public Node(int startingX, int startingY, int distance)
        {
            x = startingX;
            y = startingY;
            dist = distance;
        }

    }
}
