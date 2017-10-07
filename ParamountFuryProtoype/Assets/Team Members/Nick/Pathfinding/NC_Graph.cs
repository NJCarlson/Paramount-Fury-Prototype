using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph 
{
    public int rows = 0, columns = 0;
    public Node[] nodes;

    public Graph(int[,] grid)
    {
        rows = grid.GetLength(0);
        columns = grid.GetLength(1);

        nodes = new Node[grid.Length];
        for (int i = 0; i < nodes.Length; i++)
        {
            var node = new Node();
            node.label = i.ToString();
            nodes[i] = node;
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                var node = nodes[columns * r + c];
                if (grid[r,c] == 1)
                {
                    continue;
                }

                // cell above exists
                if (r>0)
                {
                    node.Neighbors.Add(nodes[columns * (r - 1) + c]);
                }

                // cell to right exists
                if (c < columns -1)
                {
                    node.Neighbors.Add(nodes[columns * r+c+1]);
                }

                // cell below exists
                if (r <rows - 1)
                {
                    node.Neighbors.Add(nodes[columns*(r+1)+c]);
                }

                //cell left exists
                if (c > 0)
                {
                    node.Neighbors.Add(nodes[columns * r + c - 1]);
                }

            }
        }

    }
	
}
