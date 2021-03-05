using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Drag this script into Editor folder when build
[RequireComponent(typeof(TextMeshPro))][ExecuteAlways][DisallowMultipleComponent]
public class CoordinateLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;
    [SerializeField] bool enableNameChange = true;

    TextMeshPro tmpObj;
    Vector2Int position = new Vector2Int();
    WayPoint waypoint;

    void Awake()
    {
        tmpObj = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<WayPoint>();
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
        if(tmpObj) tmpObj.color = waypoint.IsPlaceable ? defaultColor : blockedColor;
    }

    void DisplayCurrentCoordinates()
    {
        position.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        position.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
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
