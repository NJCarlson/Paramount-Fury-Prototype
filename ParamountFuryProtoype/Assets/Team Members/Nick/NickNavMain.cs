using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NickNavMain : MonoBehaviour
{

    [SerializeField] List<GameObject> MapgroupRows = new List<GameObject>();
    [SerializeField] int columns, rows;
    [SerializeField] int[,] MAP;

    NickNavGraph graph;
    NickNavSearch Search;
 


    public List<NickNavNode> Findpath(NickNavNode start, NickNavNode End)
    {
        MAP = Buildmap();
        graph  = new NickNavGraph(MAP);
        Search = new NickNavSearch(graph);
       
        
        Search.Start(graph.nodes[start.graphindex], graph.nodes[End.graphindex]);

        while (!Search.finished)
        {
            Search.Step();
        }
       
        print("Search done, Path Length" + Search.path.Count + " Iterations" + Search.iterations);

        return Search.path;
    }


    int[,] Buildmap()
    {
        int[,] map = new int[columns, rows];

        for (int i = 0; i < MapgroupRows.Count; i++)
        {
            NickNavNode[] Nodes = MapgroupRows[i].GetComponentsInChildren<NickNavNode>();

            for (int j = 0; j < Nodes.Length; j++)
            {
                if (Nodes[j].GetBlocked())
                {
                    map[i, j] = 1;
                }
                else
                {
                    map[i, j] = 0;
                }              
            }
        }
        return map;
    }

}

public class NickNavSearch
{
    public NickNavGraph graph;
    public List<NickNavNode> reachable;
    public List<NickNavNode> explored;
    public List<NickNavNode> path;
    public NickNavNode goalNode;
    public NickNavNode startNode;
   
    public int iterations;
    public bool finished;

    public NickNavSearch(NickNavGraph graph)
    {
        this.graph = graph;
    }

    public void Start(NickNavNode start, NickNavNode goal)
    {
        reachable = new List<NickNavNode>();
        reachable.Add(start);

        goalNode = goal;
        startNode = start;

        explored = new List<NickNavNode>();
        path = new List<NickNavNode>();
        iterations = 0;

        for (int i = 0; i < graph.nodes.Length; i++)
        {
            graph.nodes[i].Clear();
        }

    }

    public void Step()
    {
        if (path.Count > 0)
        {
            return;
        }

        if (reachable.Count == 0)
        {
            finished = true;
            return;
        }

        iterations++;
        NickNavNode node = ChosenNode();   
        
        
        if (node.graphindex == goalNode.graphindex)
        {
            while (true)
            {
                if (node.graphindex == startNode.graphindex )
                {
                    finished = true;
                    return;
                }
                else
                {
                    path.Insert(0, node);
                    node = node.prev;  
                }
            }
          

        }

        reachable.Remove(node);
        explored.Add(node);

        for (int i = 0; i < node.Neighbors.Count; i++)
        {
            AddAdjasent(node, node.Neighbors[i]);
        }

    }

    public void AddAdjasent(NickNavNode node, NickNavNode Adjacent)
    {
        if (FindNode(Adjacent, explored) || FindNode(Adjacent, reachable))
        {
            return;

        }
        Adjacent.prev = node;
        reachable.Add(Adjacent);

    }

    public bool FindNode(NickNavNode node, List<NickNavNode> list)
    {
        return GetNodeIndex(node, list) >= 0;
    }

    public int GetNodeIndex(NickNavNode node, List<NickNavNode> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (node.graphindex == list[i].graphindex)
            {
                return i;
            }
        }
        return -1;
    }


    public NickNavNode ChosenNode()
    {
        return reachable[0];
    }
}

public class NickNavGraph
{
    public int rows = 0, columns = 0;
    public NickNavNode[] nodes;

    public NickNavGraph(int[,] grid)
    {
        rows = grid.GetLength(0);
        columns = grid.GetLength(1);

        nodes = new NickNavNode[grid.Length + 1];
        for (int i = 0; i < nodes.Length; i++)
        {
            NickNavNode node = new NickNavNode();
            node.graphindex = i;
            nodes[i] = node;
        }
        NickNavNode lastnode = new NickNavNode();
        lastnode.graphindex = int.MaxValue;
        nodes[nodes.Length - 1] = lastnode;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                NickNavNode node = nodes[columns * r + c];
                if (grid[r, c] == 1)
                {
                    continue;
                }

                // cell above exists
                if (r > 0)
                {
                    node.Neighbors.Add(nodes[columns * (r - 1) + c]);
                }

                // cell to right exists
                if (c < columns - 1)
                {
                    node.Neighbors.Add(nodes[columns * r + c + 1]);
                }

                // cell below exists
                if (r < rows - 1)
                {
                    node.Neighbors.Add(nodes[columns * (r + 1) + c]);
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
