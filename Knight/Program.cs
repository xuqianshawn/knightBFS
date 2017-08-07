using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knight
{
    public class Program
    {
        public static int boundaryX, boundaryY, startingX, startingY;
        //possible moves of knight
        static int[] row = { 2, 2, -2, -2, 1, 1, -1, -1 };
        static int[] col = { -1, 1, 1, -1, 2, -2, 2, -2 };
       public static bool IsKnightStillOnBoard(int x, int y)
        {
            if (x < 0 || y < 0 || x >= boundaryX || y >= boundaryY)
                return false;

            return true;
        }
        public static void SetBounary(int x,int y)
        {
            boundaryX=x;
            boundaryY=y;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            try
            {
                while (!input.ToLower().Equals("quit"))
                {
                    string[] inputs = input.Split(' ');
                    Int32.TryParse(inputs[0], out boundaryX);
                    Int32.TryParse(inputs[1], out boundaryY);
                    Int32.TryParse(inputs[2], out startingX);
                    Int32.TryParse(inputs[3], out startingY);
                    //Console.WriteLine("X is " + boundaryX);
                    //Console.WriteLine("Y is " + boundaryY);
                    //Console.WriteLine("startX is " + startingX);
                    //Console.WriteLine("startY is " + startingY);

                    var chess = new Node[boundaryX, boundaryY];
                    //initialize board game
                    for (int i = 0; i < boundaryY; i++)
                    {

                        for (int j = 0; j < boundaryX; j++)
                        {
                            chess[j, i] = new Node(j, i, -1);
                        }

                    }
                    Node startingPoint = new Node(startingX, startingY, 0);
                    foreach (Node n in chess)
                    {
                        if (n.x == startingPoint.x && n.y == startingPoint.y)
                        {
                            n.dist = 0;
                            continue;
                        }
                        n.dist = BFS(startingPoint, n);
                    }
                    for (int i = 0; i < boundaryY; i++)
                    {

                        for (int j = 0; j < boundaryX; j++)
                        {
                            if (j < boundaryX - 1)
                                Console.Write(chess[j, i].dist + " ");
                            else
                                Console.WriteLine(chess[j, i].dist);
                        }

                    }
                    input = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Your input is invalid "+ex.Message);
            }
        }
        public static int BFS(Node src, Node dest)
        {
            // map to check if matrix cell is visited before or not
            Dictionary<Node, bool> visited = new Dictionary<Node, bool>();

            // create a queue and enqueue first node
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(src);

            // run till queue is not empty
            while (q.Count() != 0)
            {
                // pop front node from queue and process it
                Node node = q.Dequeue();

                int x = node.x;
                int y = node.y;
                int dist = node.dist;

                // if destination is reached, return distance
                if (x == dest.x && y == dest.y)
                    return dist;

                //if dist greator than 100, treat it as unreachable
                if (visited.Count > 100)
                {
                    return -1;
                }
                // Skip if location is visited before
                if (!visited.ContainsKey(node))
                {
                    // mark current node as visited
                    visited[node] = true;

                    // check for all 8 possible movements for a knight
                    // and enqueue each valid movement into the queue
                    for (int i = 0; i < 8; ++i)
                    {
                        // Get the new valid position of Knight from current
                        // position on chessboard and enqueue it in the  
                        // queue with +1 distance
                        int x1 = x + row[i];
                        int y1 = y + col[i];

                        if (IsKnightStillOnBoard(x1, y1))
                            q.Enqueue(new Node(x1, y1, dist + 1));
                    }
                }
            }

            // return INFINITY if path is not possible
            return -1;
        }

    }
}
