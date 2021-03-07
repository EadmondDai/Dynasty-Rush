using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))][DisallowMultipleComponent]
public class EnemyMover : MonoBehaviour
{
    
    [Range(0, 10)] [SerializeField] float speed = 1.0f;

    List<Node> path = new List<Node>();

    private Enemy enemyScript;
    private Graph graph;
    private PathFinder pathFinder;

    // Start is called before the first frame update
    void Awake()
    {
        enemyScript = GetComponent<Enemy>();
        graph = FindObjectOfType<Graph>();
        pathFinder = FindObjectOfType<PathFinder>();
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
        path = pathFinder.GetNewPath();
    }

    void GetToStart()
    {
        transform.position = graph.GetWorldPositionFromCoordinates(pathFinder.StartPos);
    }

    void FinishPath()
    {
        enemyScript.onEscaped();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        for(int i = 0; i < path.Count; ++i)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = graph.GetWorldPositionFromCoordinates(path[i].position);
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
