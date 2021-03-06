﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    [Tooltip("World Grid Size will match UnityEditor snap setting")][SerializeField] int unityGridSize = 10;
    public int UnityGridSize { get { return unityGridSize; } }

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }

    void Awake()
    {
        CreateGrid();
    }

    public Node GetNode(Vector2Int position)
    {
        if (grid.ContainsKey(position))
            return grid[position];
        else
            return null;
    }

    public void BlockNode(Vector2Int position)
    {
        if (grid.ContainsKey(position))
        {
            grid[position].isWalkable = false;
        }
    }

    public void ResetNodes()
    {
        foreach(KeyValuePair<Vector2Int, Node> entry in grid)
        {
            entry.Value.cameFrom = null;
            entry.Value.isSearched = false;
            entry.Value.isPath = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);
        return coordinates;
    }

    public Vector3 GetWorldPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 worldPosition = new Vector3();
        worldPosition.x = coordinates.x * unityGridSize;
        worldPosition.z = coordinates.y * unityGridSize;
        return worldPosition;
    }

    void CreateGrid()
    {
        for(int x = 0; x < gridSize.x; ++x)
        {
            for(int y = 0; y < gridSize.y; ++y)
            {
                Vector2Int position = new Vector2Int(x, y);
                grid.Add(position, new Node(position, true));
            }
        }
    }

}
