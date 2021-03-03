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
    }

    void DisplayCurrentCoordinates()
    {
        position.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        position.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        tmpObj.text = position.x + "," + position.y;
    }

    void UpdateObjName()
    {
        transform.parent.name = position.ToString();
    }
}
