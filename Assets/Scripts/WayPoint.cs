using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable = false;
    public bool IsPlaceable { get { return isPlaceable; } }


    void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool succss = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !succss;
        }   
    }
}
