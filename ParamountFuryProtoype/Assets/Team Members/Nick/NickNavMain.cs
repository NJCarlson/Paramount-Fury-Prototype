using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NickNavMain : MonoBehaviour {

    [SerializeField] GameObject Mapgroup;
    [SerializeField] List<GameObject> MapgroupRows;
    [SerializeField] int columns, rows;
    [SerializeField] int[,] MAP;
 
	// Use this for initialization
	void Start () {

      MAP = Buildmap();
	}
	
	// Update is called once per frame
	void Update () {
		

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

                Nodes[j].setrowcol(i, j);
            }
        }

        return map;
    }

}

public class NickNavSearch
{
    public Graph graph;
    public List<Node> reachable;
    public List<Node> explored;
    public List<Node> path;
    public Node goalNode;
    public int iterations;
    public bool finished;

    public NickNavSearch(Graph graph)
    {
        this.graph = graph;
    }

    public void Start(Node start, Node goal)
    {
        reachable = new List<Node>();
        reachable.Add(start);

        goalNode = goal;

        explored = new List<Node>();
        path = new List<Node>();
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
        Node node = ChosenNode();
        if (node == goalNode)
        {
            while (node != null)
            {
                path.Insert(0, node);
                node = node.prev;
            }
            finished = true;
            return;

        }

        reachable.Remove(node);
        explored.Add(node);

        for (int i = 0; i < node.Neighbors.Count; i++)
        {
            AddAdjasent(node, node.Neighbors[i]);
        }

    }

    public void AddAdjasent(Node node, Node Adjacent)
    {
        if (FindNode(Adjacent, explored) || FindNode(Adjacent, reachable))
        {
            return;

        }
        Adjacent.prev = node;
        reachable.Add(Adjacent);

    }

    public bool FindNode(Node node, List<Node> list)
    {
        return GetNodeIndex(node, list) >= 0;
    }

    public int GetNodeIndex(Node node, List<Node> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (node == list[i])
            {
                return i;
            }
        }
        return -1;
    }


    public Node ChosenNode()
    {
        return reachable[Random.Range(0, reachable.Count)];
    }
}

public class NickNavGraph
{
    public int rows = 0, columns = 0;
    public Node[] nodes;

    public NickNavGraph(int[,] grid)
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
