using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Drag this script into Editor folder when build
[RequireComponent(typeof(TextMeshPro))][ExecuteAlways][DisallowMultipleComponent]
public class CoordinateLabel : MonoBehaviour
{
    Color defaultColor = Color.white;
    Color blockedColor = Color.grey;
    Color exploredColor = Color.yellow;
    Color pathColorColor = new Color(1f, .5f, 0f);
    [SerializeField] bool enableNameChange = true;

    TextMeshPro tmpObj;
    Vector2Int position = new Vector2Int();
    [SerializeField] Graph graph;

    void Awake()
    {
        graph = FindObjectOfType<Graph>();
        tmpObj = GetComponent<TextMeshPro>();
        tmpObj.enabled = true;
        DisplayCurrentCoordinates();
        UpdateObjName();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCurrentCoordinates();
            UpdateObjName();
        }

        ChangeLabelColor();
        ToggleLabel();
    }

    void ChangeLabelColor()
    {
        if (graph)
        {
            Node curNode = graph.GetNode(position);
            if (tmpObj!=null && curNode!=null)
            {
                if (!curNode.isWalkable)
                {
                    tmpObj.color = blockedColor;
                }else if (curNode.isPath)
                {
                    tmpObj.color = pathColorColor;
                }else if (curNode.isSearched)
                {
                    tmpObj.color = exploredColor;
                }
                else
                {
                    tmpObj.color = defaultColor;
                }
            }

        }
    }

    void DisplayCurrentCoordinates()
    {
        if (graph == null) return;

        position.x = Mathf.RoundToInt(transform.parent.position.x / graph.UnityGridSize);
        position.y = Mathf.RoundToInt(transform.parent.position.z / graph.UnityGridSize);
        tmpObj.text = position.x + "," + position.y;
    }

    void UpdateObjName()
    {
        if (enableNameChange)
            transform.parent.name = position.ToString();
    }

    void ToggleLabel()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            tmpObj.enabled = !tmpObj.enabled;
        }
    }
}
