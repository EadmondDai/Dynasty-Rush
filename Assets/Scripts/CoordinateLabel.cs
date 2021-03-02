using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    TextMeshPro tmpObj;
    Vector2Int position = new Vector2Int();

    void Awake()
    {
        tmpObj = GetComponent<TextMeshPro>();
        DisplayCurrentCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCurrentCoordinates();
        }   
    }

    void DisplayCurrentCoordinates()
    {
        position.x = Mathf.RoundToInt(transform.parent.position.x);
        position.y = Mathf.RoundToInt(transform.parent.position.y);
        tmpObj.text = position.x / 10 + "," + position.y/10;
    }
}
