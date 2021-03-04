using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] bool isPlaceable = false;
    public bool IsPlaceable { get { return isPlaceable; } }


    void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(tower, transform.position, transform.rotation);
            isPlaceable = false;
        }   
    }
}
