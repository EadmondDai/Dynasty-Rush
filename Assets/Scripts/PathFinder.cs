using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Vector2Int startPos;
    public Vector2Int StartPos { get { return startPos; } }
    [SerializeField] Vector2Int goalPos;
    public Vector2Int GoalPos { get { return goalPos; } }
    
    Node curNode;
    Node startNode;
    Node goalNode;

    Queue<Node> nodesToVisit = new Queue<Node>();
    Dictionary<Vector2Int, Node> visited = new Dictionary<Vector2Int, Node>();

    Vector2Int[] directions = {Vector2Int.right, Vector2Int.down, Vector2Int.left, Vector2Int.up};
    private Graph graph;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    void Awake()
    {   

        graph = FindObjectOfType<Graph>();
        if (graph)
        {
            grid = graph.Grid;        
            startNode = grid[startPos];
            goalNode = grid[goalPos];
        }
    }

    void Start()
    {
        GetNewPath();
    }

    public List<Node> GetNewPath()
    {
        return GetNewPath(startPos);
    }

    public List<Node> GetNewPath(Vector2Int coordinates)
    {
        graph.ResetNodes();
        BFS(coordinates);
        return BuildPath();
    }

    void VisitNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborPosi = curNode.position + direction;

            if (grid.ContainsKey(neighborPosi))
            {
                neighbors.Add(grid[neighborPosi]);
            }
        }

        foreach(Node neighbor in neighbors)
        {
            if(!visited.ContainsKey(neighbor.position) && neighbor.isWalkable)
            {
                neighbor.cameFrom = curNode;
                visited.Add(neighbor.position, neighbor);
                nodesToVisit.Enqueue(neighbor);
            }
        }
    }

    void BFS(Vector2Int coordinates)
    {
        startNode.isWalkable = true;
        goalNode.isWalkable = true;

        nodesToVisit.Clear();
        visited.Clear();


        bool isRunning = true;

        nodesToVisit.Enqueue(grid[coordinates]);
        visited.Add(coordinates, grid[coordinates]);

        while(nodesToVisit.Count > 0 && isRunning)
        {
            curNode = nodesToVisit.Dequeue();
            curNode.isSearched = true;
            VisitNeighbors();
            if(curNode.position == goalPos)
            {
                isRunning = false;
            }
        }
    }

    List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node curNode = goalNode;

        path.Add(curNode);
        curNode.isPath = true;
        while (curNode.cameFrom != null)
        {
            curNode = curNode.cameFrom;
            path.Add(curNode);
            curNode.isPath = true;
        }

        path.Reverse();

        return path;
    }

    public bool WillBlockPath(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            bool preState = grid[coordinates].isWalkable;
            grid[coordinates].isWalkable = false;
            List<Node> newPath = GetNewPath();
            grid[coordinates].isWalkable = preState;
            
            if(newPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }
        }

        return false;
    }

    public void NotifyPathChange()
    {
        BroadcastMessage("GetNewpath", false, SendMessageOptions.DontRequireReceiver);
    }
}
