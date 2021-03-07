using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable = false;
    public bool IsPlaceable { get { return isPlaceable; } }

    private Bank playerBank;

    Graph graph;
    Vector2Int coordinates = new Vector2Int();
    PathFinder pathFinder;

    void Awake()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        graph = FindObjectOfType<Graph>();
    }

    void Start()
    {
        playerBank = GameObject.FindObjectOfType<Bank>();

        if (graph)
        {
            coordinates = graph.GetCoordinatesFromPosition(transform.position);

            if (!IsPlaceable)
            {
                graph.BlockNode(coordinates);
            }
        }
    }

    void OnMouseDown()
    {
        if (graph.GetNode(coordinates).isWalkable && !pathFinder.WillBlockPath(coordinates))
        {
            Tower towObj = towerPrefab.CreateTower(towerPrefab, transform.position);
            playerBank.Withdraw(towObj.GoldNeed);
            isPlaceable = towObj == null;
            if(towObj)
            {
                graph.BlockNode(coordinates);
                pathFinder.NotifyPathChange();
            }
                
        }   
    }
}
