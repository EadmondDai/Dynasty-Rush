using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] float waitTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintPath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PrintPath()
    {
        foreach(var wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
