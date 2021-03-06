using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public Vector2Int position;
    public bool isWalkable;
    public bool isSearched;
    public bool isPath;
    public Node cameFrom;

    public Node(Vector2Int position, bool walkable)
    {
        this.position = position;
        this.isWalkable = walkable;
    }
}
