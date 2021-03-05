using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))][DisallowMultipleComponent]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [Range(0, 10)] [SerializeField] float speed = 1.0f;

    private Enemy enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        enemyScript = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        FindPath();
        GetToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        path.Clear();

        GameObject pathNode = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in pathNode.transform)
        {
            WayPoint wayPoint = child.GetComponent<WayPoint>();
            if(wayPoint)
                path.Add(wayPoint);
        }
    }

    void GetToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemyScript.onEscaped();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach(var wayPoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = wayPoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPos);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
    } 
}
